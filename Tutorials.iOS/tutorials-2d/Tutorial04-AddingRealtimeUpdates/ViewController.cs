using System;
using UIKit;
using CoreGraphics;
using SciChart.iOS.Charting;
using System.Timers;

namespace Tutorial04_AddingRealtimeUpdates
{
    public class ViewController : UIViewController
    {
        private int pointsCount = 200;
        private Timer timer;
        private double phase = 0;
        private int count = 0;
        private const int TimerInterval = 10;
        private volatile bool _isRunning = false;

        private readonly SCIDoubleValues lineData = new SCIDoubleValues();
        private readonly SCIDoubleValues scatterData = new SCIDoubleValues();
        private readonly XyDataSeries<int, double> lineDataSeries = new XyDataSeries<int, double> { SeriesName = "Line Series", FifoCapacity = 300 };
        private readonly XyDataSeries<int, double> scatterDataSeries = new XyDataSeries<int, double> { SeriesName = "Scatter Series", FifoCapacity = 300 };

        public SCIChartSurface Surface => (SCIChartSurface)View;

        public override void LoadView()
        {
            View = new SCIChartSurface();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var xValues = new SCIIntegerValues();
            for (int i = 0; i < pointsCount; i++)
            {
                xValues.Add(i);
                lineData.Add(Math.Sin(i * 0.1));
                scatterData.Add(Math.Cos(i * 0.1));
                count++;
            }
            lineDataSeries.AppendValues(xValues, lineData);
            scatterDataSeries.AppendValues(xValues, scatterData);

            var lineSeries = new SCIFastLineRenderableSeries { DataSeries = lineDataSeries };
            var scatterSeries = new SCIXyScatterRenderableSeries
            {
                DataSeries = scatterDataSeries,
                PointMarker = new SCIEllipsePointMarker { FillStyle = new SCISolidBrushStyle(0xFF32CD32), Size = new CGSize(10, 10) }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(new SCINumericAxis());
                Surface.YAxes.Add(new SCINumericAxis());
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(scatterSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIPinchZoomModifier(),
                    new SCIZoomPanModifier(),
                    new SCIZoomExtentsModifier(),
                    new SCIRolloverModifier(),
                    new SCILegendModifier
                    {
                        Orientation = SCIOrientation.Horizontal,
                        Margins = new UIEdgeInsets(0, 0, 10, 0),
                        Position = SCIAlignment.Bottom | SCIAlignment.CenterHorizontal
                    }
                };
            }

            // start timer here
            Start();
        }

        private void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            timer = new Timer(TimerInterval);
            timer.Elapsed += UpdateData;
            timer.AutoReset = true;
            timer.Start();
        }

        private void UpdateData(object sender, ElapsedEventArgs e)
        {
            InvokeOnMainThread(() =>
            {
                if (!_isRunning) return;

                var x = count;
                using (Surface.SuspendUpdates())
                {
                    lineDataSeries.Append(x, Math.Sin(x * 0.1));
                    scatterDataSeries.Append(x, Math.Cos(x * 0.1));

                    // zoom series to fit viewport size into X-Axis direction
                    Surface.ZoomExtents();
                    count++;
                }
            });
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            View.Dispose();
        }
    }
}