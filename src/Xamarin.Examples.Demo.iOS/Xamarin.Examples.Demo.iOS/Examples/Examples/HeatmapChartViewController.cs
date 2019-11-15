using System.Collections.Generic;
using System.Timers;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Data;
using System.Threading.Tasks;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Heatmap Chart", description: "Demonstrates a Real-time 2D scientific Heatmap", icon: ExampleIcon.HeatmapChart)]
    public class HeatmapChartViewController : SingleChartViewController<SCIChartSurface>
    {
        private const int Width = 300;
        private const int Height = 200;
        private const int SeriesPerPeriod = 30;

        private volatile bool _isRunning = false;
        private readonly Timer _timer = new Timer(40) { AutoReset = true };

        private int _timerIndex = 0;
        private readonly UniformHeatmapDataSeries<int, int, double> _dataSeries = new UniformHeatmapDataSeries<int, int, double>(Width, Height);

        private static readonly List<ISCIValues<double>> ValuesList = new List<ISCIValues<double>>(SeriesPerPeriod);

        static HeatmapChartViewController()
        {
            Task.Run(() =>
            {
                var array = new double[Width * Height];
                for (var i = 0; i < SeriesPerPeriod; i++)
                {
                    DataManager.Instance.SetHeatmapValues(array, i, Width, Height, SeriesPerPeriod);
                    var doubleValues = new SCIDoubleValues(array);
                    lock (ValuesList)
                    {
                        ValuesList.Add(doubleValues);
                    }
                }
            });
        }

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis();
            var yAxis = new SCINumericAxis();

            var rSeries = new SCIFastUniformHeatmapRenderableSeries
            {
                DataSeries = _dataSeries,
                Minimum = 0,
                Maximum = 200,
                ColorMap = new SCIColorMap(
                    new[] { ColorUtil.DarkBlue.ToUIColor(), ColorUtil.CornflowerBlue.ToUIColor(), ColorUtil.DarkGreen.ToUIColor(), ColorUtil.Chartreuse.ToUIColor(), ColorUtil.Yellow.ToUIColor(), ColorUtil.Red.ToUIColor() },
                    new[] { 0, 0.2f, 0.4f, 0.6f, 0.8f, 1 })
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(rSeries);
            Surface.ChartModifiers.Add(CreateDefaultModifiers());

            Start();
        }

        private void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _timer.Elapsed += OnTick;
            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            if (!_isRunning) return;

            UpdateDataSeries(_timerIndex);
            _timerIndex++;
        }

        private void UpdateDataSeries(int index)
        {
            InvokeOnMainThread(() =>
            {
                var values = ValuesList[index % ValuesList.Count];
                _dataSeries.UpdateZValues(values);
            });            
        }

        private void Stop()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Stop();
        }
    }
}