using System;
using System.Drawing;
using System.Reactive.Linq;
using Java.Lang;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Numerics.CoordinateCalculators;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Xamarin.Examples.Demo.Showcase.AudioAnalyzer;

namespace Xamarin.Examples.Demo.Droid.Fragments.Featured.AudioAnalyzer
{
    [FeaturedExampleDefinition("Audio Analyzer", "Showcases a real-time audio recorder", ExampleIcon.FeatureChart)]
    public class AudioAnalyzerShowcaseFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Audio_Analyzer_Fragment;

        public SciChartSurface AudioStreamChart => View.FindViewById<SciChartSurface>(Resource.Id.audioStreamChart);
        public SciChartSurface FftChart => View.FindViewById<SciChartSurface>(Resource.Id.fftChart);
        public SciChartSurface SpectrogramChart => View.FindViewById<SciChartSurface>(Resource.Id.spectrogramChart);


        private const int AudioStreamBufferSize = 500_000;

        private IDisposable _dataSubscription;
        private readonly IAudioAnalyzerDataProvider _provider;

        private readonly double _hzPerDataPoint;
        private readonly int _fftSize;
        private readonly int _fftOffsetValuesCount;

        private readonly double[] _fftCache;
        private readonly double[] _spectrogramCache;

        private readonly XyDataSeries<long, short> _audioDataSeries;
        private readonly XyDataSeries<double, double> _fftDataSeries;
        private readonly UniformHeatmapDataSeries<long, long, double> _spectrogramDataSeries;

        public AudioAnalyzerShowcaseFragment()
        {
            var defaultProvider = new DefaultAudioAnalyzerDataProvider();

            _provider = defaultProvider.IsInitialized ? defaultProvider : (IAudioAnalyzerDataProvider) new StubAudioAnalyzerDataProvider();

            _hzPerDataPoint = (double)_provider.SampleRate / _provider.BufferSize;

            _fftSize = _provider.BufferSize / 2;

            var fftCount = AudioStreamBufferSize / _provider.BufferSize;
            var fftValuesCount = _fftSize * fftCount;

            _fftOffsetValuesCount = fftValuesCount - _fftSize;

            _fftCache = new double[_fftSize];
            _spectrogramCache = new double[fftValuesCount];

            _audioDataSeries = new XyDataSeries<long, short>() { FifoCapacity = new Integer(AudioStreamBufferSize)};
            _fftDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(_fftSize)};
            _spectrogramDataSeries = new UniformHeatmapDataSeries<long, long, double>(_fftSize, fftCount);
        }

        protected override void InitExample()
        {
            InitAudioStreamChart();
            InitFftChart();
            InitSpectrogramChart();

            var fft = new Radix2FFT(_provider.BufferSize);

            _dataSubscription = _provider.Data.Do(data =>
            {
                _audioDataSeries.Append(data.XData, data.YData);

                fft.Run(data.YData, _fftCache);

                _fftDataSeries.UpdateRangeYAt(0, _fftCache);

                Array.Copy(_spectrogramCache, _fftSize, _spectrogramCache, 0, _fftOffsetValuesCount);
                Array.Copy(_fftCache, 0, _spectrogramCache, _fftOffsetValuesCount, _fftSize);

                _spectrogramDataSeries.UpdateZValues(_spectrogramCache);
            }).Subscribe();
        }

        public override void OnDestroyView()
        {
            _dataSubscription.Dispose();
            _dataSubscription = null;

            base.OnDestroyView();
        }

        private void InitAudioStreamChart()
        {
            var xAxis = new NumericAxis(Activity)
            {
                AutoRange = AutoRange.Always,
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false
            };

            var yAxis = new NumericAxis(Activity)
            {
                VisibleRange = new DoubleRange(Short.MinValue, Short.MaxValue),
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false
            };

            var rs = new FastLineRenderableSeries()
            {
                DataSeries = _audioDataSeries,
                StrokeStyle = new SolidPenStyle(Color.Gray, 1f.ToDip(Activity))
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
            var xAxis = new NumericAxis(Activity)
            {
                DrawMajorBands = false,
                MaxAutoTicks = 5,
                AxisTitle = "Hz",
                AxisTitlePlacement = AxisTitlePlacement.Right,
                AxisTitleOrientation = AxisTitleOrientation.Horizontal,
            };

            var yAxis = new NumericAxis(Activity)
            {
                AxisAlignment = AxisAlignment.Left,
                VisibleRange = new DoubleRange(-30, 70),
                GrowBy = new DoubleRange(0.1, 0.1),
                DrawMinorTicks = false,
                DrawMinorGridLines = false,
                DrawMajorBands = false,
                AxisTitle = "dB",
                AxisTitlePlacement = AxisTitlePlacement.Top,
                AxisTitleOrientation = AxisTitleOrientation.Horizontal
            };

            var rs = new FastColumnRenderableSeries()
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
            var xAxis = new NumericAxis(Activity)
            {
                AutoRange = AutoRange.Always,
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false,
                AxisAlignment = AxisAlignment.Left,
                FlipCoordinates = true
            };

            var yAxis = new NumericAxis(Activity)
            {
                AutoRange = AutoRange.Always,
                DrawLabels = false,
                DrawMinorTicks = false,
                DrawMajorTicks = false,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false,
                AxisAlignment = AxisAlignment.Bottom,
                FlipCoordinates = true
            };
            
            var rs = new FastUniformHeatmapRenderableSeries()
            {
                DataSeries = _spectrogramDataSeries,
                Minimum = -30,
                Maximum = 70,
                ColorMap = new ColorMap(
                    new[] { Color.Transparent, Color.DarkBlue, Color.Purple, Color.Red, Color.Yellow, Color.White }, 
                    new[] { 0f, 0.0001f, 0.25f, 0.50f, 0.75f, 1f }),
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