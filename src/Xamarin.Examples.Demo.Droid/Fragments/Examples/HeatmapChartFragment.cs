using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Android.Graphics;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Core.Model;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Heatmap Chart")]
    public class HeatmapChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        private const int Width = 300;
        private const int Height = 200;
        private const int SeriesPerPeriod = 30;

        private readonly Timer _timer = new Timer(40) {AutoReset = true};
        private int _timerIndex = 0;
        private readonly UniformHeatmapDataSeries<int, int, double> _dataSeries = new UniformHeatmapDataSeries<int, int, double>(Width, Height);

        private static readonly List<IValues<double>> ValuesList = new List<IValues<double>>(SeriesPerPeriod);

        static HeatmapChartFragment()
        {
            Task.Run(() =>
            {
                var array = new double[Width*Height];

                for (var i = 0; i < SeriesPerPeriod; i++)
                {
                    DataManager.Instance.SetHeatmapValues(array, i, Width, Height, SeriesPerPeriod);
                    var doubleValues = new DoubleValues(array);

                    lock (ValuesList)
                    {
                        ValuesList.Add(doubleValues);
                    }
                }
            });
        }

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity);
            var yAxis = new NumericAxis(Activity);

            var rs = new FastUniformHeatmapRenderableSeries
            {
                ColorMap = new ColorMap(new []{Color.DarkBlue, Color.CornflowerBlue, Color.DarkGreen, Color.Chartreuse, Color.Yellow, Color.Red}, new[] {0, 0.2f, 0.4f, 0.6f, 0.8f, 1}),
                Minimum = 0,
                Maximum = 200,
                DataSeries = _dataSeries,
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(rs);

            _timer.Elapsed += OnTick;
            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            IValues<double> values;
            lock (ValuesList)
            {
                values = ValuesList[_timerIndex % ValuesList.Count];
            }
            _dataSeries.UpdateZValues(values);

            _timerIndex++;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            _timer.Stop();
            _timer.Elapsed -= OnTick;
        }
    }
}