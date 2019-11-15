using System.Collections.Generic;
using System.Timers;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [FeaturedExampleDefinition("ECG Monitor Demo", description: "The ECG Monitor Demo showcases a real-time heart-rate monitor", icon: ExampleIcon.FeatureChart)]
    public class ECGMonitorViewController : SingleChartViewController<SCIChartSurface>
    {
        private const int TimerInterval = 20;
        private const int BufferSize = 3850;

        private readonly XyDataSeries<double, double> _series0 = new XyDataSeries<double, double> { FifoCapacity = BufferSize };
        private readonly XyDataSeries<double, double> _series1 = new XyDataSeries<double, double> { FifoCapacity = BufferSize };

        private int _currentIndex;
        private int _totalIndex;

        private readonly List<double> _data = DataManager.Instance.LoadWaveformData();

        private volatile bool _isRunning = false;
        private Timer _timer;

        private volatile bool _isFirstTrace = false;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { VisibleRange = new SCIDoubleRange(0.0, 10.0), AutoRange = SCIAutoRange.Never, AxisTitle = "Time (seconds)" };
            var yAxis = new SCINumericAxis { VisibleRange = new SCIDoubleRange(-0.5, 1.5), AxisTitle = "Voltage (mV)" };

            var rs0 = new SCIFastLineRenderableSeries { DataSeries = _series0, StrokeStyle = new SCISolidPenStyle(0xFFC6E6FF, 2f) };
            var rs1 = new SCIFastLineRenderableSeries { DataSeries = _series1, StrokeStyle = new SCISolidPenStyle(0xFFC6E6FF, 2f) };

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

            if (!_isRunning) return;

            InvokeOnMainThread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    AppendPoint(400);
                }
            });
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

        private void Stop()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Stop();
        }
    }
}