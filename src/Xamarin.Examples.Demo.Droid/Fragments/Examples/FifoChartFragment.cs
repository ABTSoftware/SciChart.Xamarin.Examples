using System;
using System.Timers;
using Android.Widget;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("FIFO Chart", description:"Demonstrates a scrolling FIFO chart", icon: ExampleIcon.RealTime)]
    public class FifoChartFragment : ExampleBaseFragment
    {
        private const int FifoCapacity = 50;
        private const long TimerInterval = 30;
        private const double OneOverTimeInteval = 1.0/TimerInterval;
        private const double VisibleRangeMax = FifoCapacity*OneOverTimeInteval;
        private const double GrowBy = VisibleRangeMax*0.1;

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Realtime_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        private readonly Random _random = new Random(42);

        private readonly XyDataSeries<double, double> _ds1 = new XyDataSeries<double, double> {FifoCapacityValue = FifoCapacity};
        private readonly XyDataSeries<double, double> _ds2 = new XyDataSeries<double, double> {FifoCapacityValue = FifoCapacity};
        private readonly XyDataSeries<double, double> _ds3 = new XyDataSeries<double, double> {FifoCapacityValue = FifoCapacity};

        private readonly DoubleRange _xVisibleRange = new DoubleRange(-GrowBy, VisibleRangeMax + GrowBy);

        private double _t = 0;
        private volatile bool _isRunning = false;
        private readonly object _syncRoot = new object();
        private Timer _timer;

        protected override void InitExample()
        {
            View.FindViewById<Button>(Resource.Id.start).Click += (sender, args) => Start();
            View.FindViewById<Button>(Resource.Id.pause).Click += (sender, args) => Pause();
            View.FindViewById<Button>(Resource.Id.reset).Click += (sender, args) => Reset();

            var xAxis = new NumericAxis(Activity) {VisibleRange = _xVisibleRange, AutoRange = AutoRange.Never};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1), AutoRange = AutoRange.Always};

            var rs1 = new FastLineRenderableSeries {DataSeries = _ds1, StrokeStyle = new SolidPenStyle(0xFF4083B7, 2f.ToDip(Activity))};
            var rs2 = new FastLineRenderableSeries {DataSeries = _ds2, StrokeStyle = new SolidPenStyle(0xFFFFA500, 2f.ToDip(Activity))};
            var rs3 = new FastLineRenderableSeries {DataSeries = _ds3, StrokeStyle = new SolidPenStyle(0xFFE13219, 2f.ToDip(Activity))};

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rs1);
                Surface.RenderableSeries.Add(rs2);
                Surface.RenderableSeries.Add(rs3);
            }
            Start();
        }

        private void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _timer = new Timer(TimerInterval);
                _timer.Elapsed += OnTick;
                _timer.AutoReset = true;
                _timer.Start();
            }
        }

        private void Pause()
        {
            if (_isRunning)
            {
                _isRunning = false;
                _timer.Stop();
                _timer.Elapsed -= OnTick;
                _timer = null;
            }
        }

        private void Reset()
        {
            if (_isRunning)
            {
                Pause();
            }

            using (Surface.SuspendUpdates())
            {
                _t = 0;
                _xVisibleRange.SetMinMaxDouble(-GrowBy, VisibleRangeMax + GrowBy);

                _ds1.Clear();
                _ds2.Clear();
                _ds3.Clear();
            }
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_syncRoot)
            {
                if(!_isRunning) return;

                AppendData(_random);
            }
        }

        private void AppendData(Random random)
        {
            var y1 = 3.0*Math.Sin(2*Math.PI*1.4*_t) + random.NextDouble()*0.5;
            var y2 = 2.0*Math.Cos(2*Math.PI*0.8*_t) + random.NextDouble()*0.5;
            var y3 = 1.0*Math.Sin(2*Math.PI*2.2*_t) + random.NextDouble()*0.5;

            _ds1.Append(_t, y1);
            _ds2.Append(_t, y2);
            _ds3.Append(_t, y3);

            _t += OneOverTimeInteval;
            if (_t > VisibleRangeMax)
            {
                _xVisibleRange.SetMinMax(_xVisibleRange.Min + OneOverTimeInteval, _xVisibleRange.Max + OneOverTimeInteval);
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            Reset();
        }

        public override void InitExampleForUiTest()
        {
            base.InitExampleForUiTest();

            lock (_syncRoot)
            {
                Reset(); 

                var random = new Random(42);
                for (var i = 0; i < FifoCapacity; i++)
                {
                    AppendData(random);
                }
            }
        }
    }
}