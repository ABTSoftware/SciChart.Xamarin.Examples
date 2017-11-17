using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using scichartshowcase.CustomViews.Data.DataSeries;
using scichartshowcase.CustomViews.Data.Ranges;
using scichartshowcase.CustomViews.RenderableSeries;
using scichartshowcase.CustomViews.Visuals.Axes;
using scichartshowcase.Services.AudioService;
using Xamarin.Forms;

namespace scichartshowcase.TestCases.AudioAnalyzer
{
    public partial class AudioAnalyzer : ContentPage
    {
        XYDataSeries<int, int> samplesDataSeries;
        XYDataSeries<int, int> fftDataSeries;

        HeatmapRenderableSeries heatmapSeries;

        int samplesCount = 2048;

        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token;

        public AudioAnalyzer()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ConfigureSamplesChart();
            ConfigureFFTChart();
            ConfigureSpectrogramChart();

            token = cancelTokenSource.Token;

            Task.Run(() =>
            {
                var audioService = DependencyService.Get<IAudioService>();

                audioService.samplesUpdated += (e, args) =>
                {

                    if (token.IsCancellationRequested)
                    {
                        audioService.StopRecord();

                        return;
                    }
                    var arguments = args as SamplesUpdatedEventArgs;

                    if (arguments != null)
                    {
                        var samples = arguments.UpdatedSamples;
                        if (samples.Length < samplesCount)
                            return;

                        samplesDataSeries.YValues = samples;
                        var fftValues = audioService.FFT(samples);
                        fftDataSeries.YValues = fftValues;
                        heatmapSeries.AppenData(fftValues);

                        Device.BeginInvokeOnMainThread(sampleSurface.UpdateDataSeries);
                        Device.BeginInvokeOnMainThread(fftSurface.UpdateDataSeries);
                        Device.BeginInvokeOnMainThread(spectrogramSurface.UpdateDataSeries);
                    }
                };

                audioService.StartRecord();
            }, token);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            cancelTokenSource.Cancel();
        }

        void ConfigureSamplesChart()
        {
            sampleSurface.XAxes = new List<AxisBase> { new NumericAxis
                {
                    AutoRange = AutoRange.Always,
                    DrawMajorBands = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false }
            };


            sampleSurface.YAxes = new List<AxisBase> { new NumericAxis
                {
                    AutoRange = AutoRange.Never,
                    VisibleRange = new DoubleRange{Min = short.MinValue, Max= short.MaxValue},
                    DrawMajorBands = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false }
            };

            samplesDataSeries = new XYDataSeries<int, int> { FifoCapacity = 500000 };

            var lineSeries = new LineRenderableSeries();
            lineSeries.DataSeries = samplesDataSeries;

            sampleSurface.ChartSeries = lineSeries;
        }

        void ConfigureFFTChart()
        {
            fftSurface.XAxes = new List<AxisBase> { new NumericAxis
                {
                    AutoRange = AutoRange.Never,
                    VisibleRange = new DoubleRange { Min = 0, Max = 1024 },
                    DrawMajorBands = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false
                }
             };

            fftSurface.YAxes = new List<AxisBase> { new NumericAxis
                {
                    AutoRange = AutoRange.Never,
                    VisibleRange = new DoubleRange { Min = -30, Max = 60 },
                    DrawMinorGridLines = false,
                    DrawMinorTicks = false,
                    AxisAlignment = AxisAlignment.Left
                }
            };
            fftDataSeries = new XYDataSeries<int, int>();

            var columnSeries = new ColumnRenderableSeries();
            columnSeries.DataSeries = fftDataSeries;

            fftSurface.ChartSeries = columnSeries;
        }

        void ConfigureSpectrogramChart()
        {
            spectrogramSurface.XAxes = new List<AxisBase> { new NumericAxis
                {
                    AutoRange = AutoRange.Always,
                    DrawMajorBands = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false,
                    FlipCoordinates = true,
                    AxisAlignment = AxisAlignment.Left
                }
            };

            spectrogramSurface.YAxes = new List<AxisBase> { new NumericAxis
                {
                    AutoRange = AutoRange.Always,
                    DrawMajorBands = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false,
                    FlipCoordinates = true,
                    AxisAlignment = AxisAlignment.Bottom
                }
            };

            heatmapSeries = new HeatmapRenderableSeries(1024, 1024);
            spectrogramSurface.ChartSeries = heatmapSeries;
        }
    }
}