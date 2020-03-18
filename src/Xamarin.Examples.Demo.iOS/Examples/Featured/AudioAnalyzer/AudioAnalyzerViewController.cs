using System;
using UIKit;
using SciChart.iOS.Charting;
using System.Reactive.Linq;
using Xamarin.Examples.Demo.Showcase.AudioAnalyzer;
using AVFoundation;

namespace Xamarin.Examples.Demo.iOS
{
    [FeaturedExampleDefinition("Audio Analyzer", description: "Showcases a real-time audio recorder", icon: ExampleIcon.FeatureChart)]
    public partial class AudioAnalyzerViewController : UIViewController
    {
        private const int AudioStreamBufferSize = 500_000;
        private IDisposable _dataSubscription;
        private IAudioAnalyzerDataProvider _provider = new StubAudioAnalyzerDataProvider();

        private readonly double _hzPerDataPoint;
        private readonly int _fftSize;
        private readonly int _fftOffsetValuesCount;

        private readonly double[] _fftCache;
        private readonly double[] _spectrogramCache;

        private readonly XyDataSeries<long, short> _audioDataSeries;
        private readonly XyDataSeries<double, double> _fftDataSeries;
        private readonly UniformHeatmapDataSeries<long, long, double> _spectrogramDataSeries;

        public AudioAnalyzerViewController() : base("AudioAnalyzerViewController", null)
        {
            _hzPerDataPoint = (double)_provider.SampleRate / _provider.BufferSize;

            _fftSize = _provider.BufferSize / 2;

            var fftCount = AudioStreamBufferSize / _provider.BufferSize;
            var fftValuesCount = _fftSize * fftCount;

            _fftOffsetValuesCount = fftValuesCount - _fftSize;

            _fftCache = new double[_fftSize];
            _spectrogramCache = new double[fftValuesCount];

            _audioDataSeries = new XyDataSeries<long, short>() { FifoCapacity = AudioStreamBufferSize };
            _fftDataSeries = new XyDataSeries<double, double>() { FifoCapacity = _fftSize };
            _spectrogramDataSeries = new UniformHeatmapDataSeries<long, long, double>(_fftSize, fftCount);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AVAudioSession.SharedInstance().RequestRecordPermission((granted) =>
            {
                if (granted)
                {
                    _provider = new DefaultAudioAnalyzerDataProvider();
                }

                InvokeOnMainThread(() => {
                    proceedWithInit();
                });
            });
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            _dataSubscription.Dispose();
            _dataSubscription = null;
        }

        private void proceedWithInit()
        {
            InitAudioStreamChart();
            InitFftChart();
            InitSpectrogramChart();

            var fft = new Radix2FFT(_provider.BufferSize);

            _dataSubscription = _provider.Data.Do(data =>
            {
                fft.Run(data.YData, _fftCache);
                Array.Copy(_spectrogramCache, _fftSize, _spectrogramCache, 0, _fftOffsetValuesCount);
                Array.Copy(_fftCache, 0, _spectrogramCache, _fftOffsetValuesCount, _fftSize);

                InvokeOnMainThread(() =>
                {
                    _audioDataSeries.Append(data.XData, data.YData);
                    _fftDataSeries.UpdateRangeYAt(0, _fftCache);
                    _spectrogramDataSeries.UpdateZValues(_spectrogramCache);
                });
            }).Subscribe();
        }

        private void InitAudioStreamChart()
        {
            var xAxis = new SCINumericAxis()
            {
                AutoRange = SCIAutoRange.Always,
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false
            };

            var yAxis = new SCINumericAxis()
            {
                VisibleRange = new SCIDoubleRange(Int16.MinValue, Int16.MaxValue),
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false
            };

            var rs = new SCIFastLineRenderableSeries()
            {
                DataSeries = _audioDataSeries,
                StrokeStyle = new SCISolidPenStyle(UIColor.Gray, 1)
            };

            using (AudioStreamChart.SuspendUpdates())
            {
                AudioStreamChart.XAxes.Add(xAxis);
                AudioStreamChart.YAxes.Add(yAxis);
                AudioStreamChart.RenderableSeries.Add(rs);
            }
        }

        private void InitFftChart()
        {
            var xAxis = new SCINumericAxis()
            {
                DrawMajorBands = false,
                MaxAutoTicks = 5,
                AxisTitle = "Hz",
                AxisTitlePlacement = SCIAxisTitlePlacement.Right,
                AxisTitleOrientation = SCIAxisTitleOrientation.Horizontal,
            };

            var yAxis = new SCINumericAxis()
            {
                AxisAlignment = SCIAxisAlignment.Left,
                VisibleRange = new SCIDoubleRange(-30, 70),
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                DrawMinorTicks = false,
                DrawMinorGridLines = false,
                DrawMajorBands = false,
                AxisTitle = "dB",
                AxisTitlePlacement = SCIAxisTitlePlacement.Top,
                AxisTitleOrientation = SCIAxisTitleOrientation.Horizontal
            };

            var rs = new SCIFastColumnRenderableSeries()
            {
                DataSeries = _fftDataSeries,
                PaletteProvider = new FFTPaletteProvider(),
                ZeroLineY = -30  // set zero line equal to VisibleRange.Min
            };

            for (int i = 0; i < _fftSize; i++)
            {
                _fftDataSeries.Append(i * _hzPerDataPoint, 0d);
            }

            using (FftChart.SuspendUpdates())
            {
                FftChart.XAxes.Add(xAxis);
                FftChart.YAxes.Add(yAxis);
                FftChart.RenderableSeries.Add(rs);
            }
        }

        private void InitSpectrogramChart()
        {
            var xAxis = new SCINumericAxis()
            {
                AutoRange = SCIAutoRange.Always,
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false,
                AxisAlignment = SCIAxisAlignment.Right,
                FlipCoordinates = true
            };

            var yAxis = new SCINumericAxis()
            {
                AutoRange = SCIAutoRange.Always,
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false,
                AxisAlignment = SCIAxisAlignment.Bottom,
                FlipCoordinates = false
            };

            var rs = new SCIFastUniformHeatmapRenderableSeries()
            {
                DataSeries = _spectrogramDataSeries,
                Minimum = -30,
                Maximum = 70,
                ColorMap = new SCIColorMap(
                    new[] { UIColor.Clear, UIColor.FromRGB(0, 0, 139), UIColor.Purple, UIColor.Red, UIColor.Yellow, UIColor.White },
                    new[] { 0f, 0.0001f, 0.03f, 0.3f, 0.5f, 1f }),
            };

            using (SpectrogramChart.SuspendUpdates())
            {
                SpectrogramChart.XAxes.Add(xAxis);
                SpectrogramChart.YAxes.Add(yAxis);
                SpectrogramChart.RenderableSeries.Add(rs);
            }
        }
    }
}
