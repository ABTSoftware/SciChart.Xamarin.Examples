using System.Collections.Generic;
using System.Timers;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Featured
{
    [FeaturedExampleDefinition("ECG Monitor Demo", "Showcases a real-time heart-rate monitor", ExampleIcon.FeatureChart)]
    public class ECGMonitorFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private const int TimerInterval = 20;
        private const int BufferSize = 3850;

        private readonly XyDataSeries<double, double> _series0 = new XyDataSeries<double, double> { FifoCapacityValue = BufferSize };
        private readonly XyDataSeries<double, double> _series1 = new XyDataSeries<double, double> { FifoCapacityValue = BufferSize };

        private int _currentIndex;
        private int _totalIndex;

        private readonly List<double> _data = DataManager.Instance.LoadWaveformData();

        private volatile bool _isRunning = false;
        private readonly object _syncRoot = new object();
        private Timer _timer;

        private volatile bool _isFirstTrace = false;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity)
            {
                VisibleRange = new DoubleRange(0, 10), 
                AutoRange = AutoRange.Never, 
                AxisTitle = "Time (seconds)"
            };

            var yAxis = new NumericAxis(Activity)
            {
                VisibleRange = new DoubleRange(-0.5, 1.5),
                AxisTitle = "Voltage (mV)"
            };

            var rs0 = new FastLineRenderableSeries()
            {
                DataSeries = _series0,
                StrokeStyle = new SolidPenStyle(0xFFC6E6FF, 2f.ToDip(Activity))
            };
            var rs1 = new FastLineRenderableSeries()
            {
                DataSeries = _series1,
                StrokeStyle = new SolidPenStyle(0xFFC6E6FF, 2f.ToDip(Activity))
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rs0);
                Surface.RenderableSeries.Add(rs1);
            }
            Start();
        }

        private void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _timer = new Timer(TimerInterval);
            _timer.Elapsed += OnTick;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_syncRoot)
            {
                if (!_isRunning) return;

                for (var i = 0; i < 10; i++)
                {
                    AppendPoint(400);
                }
            }
        }

        private void AppendPoint(double sampleRate)
        {
            if (_currentIndex >= _data.Count)
            {
                _currentIndex = 0;
            }

            // Get the next voltage and time, and append to the chart
            var voltage = _data[_currentIndex];
            var time = (_totalIndex / sampleRate) % 10;

            if (_isFirstTrace)
            {
                _series0.Append(time, voltage);
                _series1.Append(time, double.NaN);
            }
            else
            {
                _series0.Append(time, double.NaN);
                _series1.Append(time, voltage);
            }

            _currentIndex++;
            _totalIndex++;

            if (_totalIndex % 4000 == 0)
            {
                _isFirstTrace = !_isFirstTrace;
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            Stop();
        }

        private void Stop()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }
    }
}