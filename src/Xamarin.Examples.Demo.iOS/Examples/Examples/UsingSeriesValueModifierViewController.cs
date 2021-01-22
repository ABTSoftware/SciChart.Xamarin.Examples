using System;
using SciChart.iOS.Charting;
using System.Timers;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Realtime Series Values on Axis", description: "Demonstrates usage of the SCISeriesValueModifier", icon: ExampleIcon.RealTime)]
    public class UsingSeriesValueModifierViewController : SingleChartViewController<SCIChartSurface>
    {
        private const int FifoCapacity = 100;
        private const double TimerInterval = 20;
        private const double OneOverTimeInteval = 1.0 / TimerInterval;
        private Timer _timer;
        private double _t = 0;

        private readonly XyDataSeries<double, double> _ds1 = new XyDataSeries<double, double> { FifoCapacity = FifoCapacity, SeriesName = "Orange Series" };
        private readonly XyDataSeries<double, double> _ds2 = new XyDataSeries<double, double> { FifoCapacity = FifoCapacity, SeriesName = "Blue Series" };
        private readonly XyDataSeries<double, double> _ds3 = new XyDataSeries<double, double> { FifoCapacity = FifoCapacity, SeriesName = "Green Series" };

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis
            {
                AutoRange = SCIAutoRange.Always,
                AxisTitle = "Time (Seconds)",
                TextFormatting = "0.0"
            };
            var yAxis = new SCINumericAxis
            {
                AutoRange = SCIAutoRange.Always,
                AxisTitle = "Amplitude (Volts)",
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                TextFormatting = "0.00",
                CursorTextFormatting = "0.00"
            };

            var rSeries1 = new SCIFastLineRenderableSeries { DataSeries = _ds1, StrokeStyle = new SCISolidPenStyle(0xFFFF8C00, 2f) };
            var rSeries2 = new SCIFastLineRenderableSeries { DataSeries = _ds2, StrokeStyle = new SCISolidPenStyle(0xFF4682B4, 2f) };
            var rSeries3 = new SCIFastLineRenderableSeries { DataSeries = _ds3, StrokeStyle = new SCISolidPenStyle(0xFF556B2F, 2f) };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries1);
                Surface.RenderableSeries.Add(rSeries2);
                Surface.RenderableSeries.Add(rSeries3);
                Surface.ChartModifiers.Add(new SCILegendModifier { Margins = new UIEdgeInsets(16, 16, 16, 16)});
                Surface.ChartModifiers.Add(new SCISeriesValueModifier());
            }

            Start();
        }

        private void Start()
        {   
            _timer = new Timer(TimerInterval);
            _timer.Elapsed += OnTick;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            InvokeOnMainThread(() =>
            {
                var y1 = 3.0 * Math.Sin(((2 * Math.PI) * 1.4) * _t * 0.02);
                var y2 = 2.0 * Math.Cos(((2 * Math.PI) * 0.8) * _t * 0.02);
                var y3 = 1.0 * Math.Sin(((2 * Math.PI) * 2.2) * _t * 0.02);

                _ds1.Append(_t, y1);
                _ds2.Append(_t, y2);
                _ds3.Append(_t, y3);

                _t += OneOverTimeInteval;
            });
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Reset();
        }

        private void Reset()
        {
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;

            using (Surface.SuspendUpdates())
            {
                _t = 0;

                _ds1.Clear();
                _ds2.Clear();
                _ds3.Clear();
            }
        }
    }
}