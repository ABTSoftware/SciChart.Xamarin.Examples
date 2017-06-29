using System.Collections.Generic;
using System.Timers;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("ECG Monitor Demo", description: "The ECG Monitor Demo showcases a real-time heart-rate monitor", icon: ExampleIcon.FeatureChart)]
    public class ECGMonitorView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        private const int TimerInterval = 20;
        private const int BufferSize = 3850;

        private readonly XyDataSeries<double, double> _series0 = new XyDataSeries<double, double>() { FifoCapacity = BufferSize };
        private readonly XyDataSeries<double, double> _series1 = new XyDataSeries<double, double>() { FifoCapacity = BufferSize };

        private int _currentIndex;
        private int _totalIndex;

        private readonly List<double> _data = DataManager.Instance.LoadWaveformData();

        private readonly object _syncRoot = new object();
        private volatile bool _isRunning = false;
        private Timer _timer;

        private volatile bool _isFirstTrace = false;

        protected override void UpdateFrame()
        {
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint constraintRight = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint constraintLeft = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint constraintTop = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint constraintBottom = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0);

            this.AddConstraint(constraintRight);
            this.AddConstraint(constraintLeft);
            this.AddConstraint(constraintTop);
            this.AddConstraint(constraintBottom);
        }

        protected override void InitExampleInternal()
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

        public override void RemoveFromSuperview()
        {
            base.RemoveFromSuperview();

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