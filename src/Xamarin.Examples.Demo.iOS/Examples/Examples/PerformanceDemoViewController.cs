using System;
using System.Collections.Generic;
using System.Timers;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Performance Demo", description: "Draws up to 1 Million points in realtime!", icon: ExampleIcon.RealTime)]
    public class PerformanceDemoViewController : SingleChartWithTopPanelViewController<SCIChartSurface>
    {
        private static readonly int MaxPointCount = CalculateMaxPointCountToDisplay();
        private const int TimerInterval = 10;
        private const int BufferSize = 1000;

        private readonly MovingAverage _maLow = new MovingAverage(200);
        private readonly MovingAverage _maHigh = new MovingAverage(1000);

        private int _xValue = 0;
        private double _yValue = 10;

        private readonly List<int> _xValues = new List<int>(BufferSize);
        private readonly List<float> _firstYValues = new List<float>(BufferSize);
        private readonly List<float> _secondYValues = new List<float>(BufferSize);
        private readonly List<float> _thirdYValues = new List<float>(BufferSize);

        private readonly XyDataSeries<int, float> _mainSeries = new XyDataSeries<int, float>();
        private readonly XyDataSeries<int, float> _maLowSeries = new XyDataSeries<int, float>();
        private readonly XyDataSeries<int, float> _maHighSeries = new XyDataSeries<int, float>();

        private readonly Random _random = new Random();

        private volatile bool _isRunning = false;
        private Timer _timer;

        private SCITextAnnotation CountAnnotation = new SCITextAnnotation
        {
            X1Value = 0, Y1Value = 0,
            Padding = new UIEdgeInsets(5, 5, 0, 0),
            CoordinateMode = SCIAnnotationCoordinateMode.Relative,
            FontStyle = new SCIFontStyle(14, UIColor.White),
        };

        public override UIView ProvidePanel()
        {
            var panel = new RealtimeExamplePanel();
            panel.StartButton.TouchUpInside += (sender, args) => Start();
            panel.PauseButton.TouchUpInside += (sender, args) => Pause();
            panel.ResetButton.TouchUpInside += (sender, args) => Reset();

            return panel;
        }

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };
            var yAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };

            var rs1 = new SCIFastLineRenderableSeries { DataSeries = _mainSeries, StrokeStyle = new SCISolidPenStyle(0xFF4083B7, 2f) };
            var rs2 = new SCIFastLineRenderableSeries { DataSeries = _maLowSeries, StrokeStyle = new SCISolidPenStyle(0xFFFFA500, 2f) };
            var rs3 = new SCIFastLineRenderableSeries { DataSeries = _maHighSeries, StrokeStyle = new SCISolidPenStyle(0xFFE13219, 2f) };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rs1);
                Surface.RenderableSeries.Add(rs2);
                Surface.RenderableSeries.Add(rs3);
                Surface.Annotations.Add(CountAnnotation);
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

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }

        private void Reset()
        {
            if (_isRunning)
                Pause();

            using (Surface.SuspendUpdates())
            {
                _mainSeries.Clear();
                _maLowSeries.Clear();
                _maHighSeries.Clear();
            }

            _maLow.Clear();
            _maHigh.Clear();
        }

		private void OnTick(object sender, ElapsedEventArgs e)
		{
			if (!_isRunning) return;

			InvokeOnMainThread(() =>
			{
				if (GetPointsCount() < MaxPointCount)
				{
					DoAppendLoop();
				}
				else
				{
					Pause();
				}
			});
		}

        private int GetPointsCount()
        {
            return _mainSeries.Count + _maLowSeries.Count + _maHighSeries.Count;
        }

        private void DoAppendLoop()
        {
            using (Surface.SuspendUpdates())
            {
                _xValues.Clear();
                _firstYValues.Clear();
                _secondYValues.Clear();
                _thirdYValues.Clear();

                for (var i = 0; i < BufferSize; i++)
                {
                    _xValue++;
                    _yValue += _random.NextDouble() - 0.5;

                    _xValues.Add(_xValue);
                    _firstYValues.Add((float)_yValue);
                    _secondYValues.Add((float)_maLow.Push(_yValue).Current);
                    _thirdYValues.Add((float)_maHigh.Push(_yValue).Current);
                }

                _mainSeries.Append(_xValues, _firstYValues);
                _maLowSeries.Append(_xValues, _secondYValues);
                _maHighSeries.Append(_xValues, _thirdYValues);

                CountAnnotation.Text = "Amount of Points: " + _mainSeries.Count;
            }
        }

        private static int CalculateMaxPointCountToDisplay()
        {
            const int oneMlnPointsRequirement = 8 + 16 + 4 + 8;
            var memorySize = GetMaxMemorySize() - 40;
            var maxPointCount = memorySize / oneMlnPointsRequirement * 1000000;

            return (int)Math.Round(maxPointCount / 3);
        }

        private static double GetMaxMemorySize()
        {
            //return Runtime.GetRuntime().MaxMemory() / 1024.0 / 1024.0;
            return 256;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Reset();
        }
    }
}