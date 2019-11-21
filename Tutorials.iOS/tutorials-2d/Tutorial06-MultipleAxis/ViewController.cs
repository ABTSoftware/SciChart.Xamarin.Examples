using System;
using UIKit;
using CoreGraphics;
using SciChart.iOS.Charting;
using System.Timers;

namespace Tutorial06_MultipleAxis
{
    public class ViewController : UIViewController
    {
        private int pointsCount = 200;
        private static readonly int fifoCapacity = 300;
        private Timer timer;
        private double phase = 0;
        private int count = 0;
        private const int TimerInterval = 10;
        private volatile bool _isRunning = false;

        private readonly SCIDoubleValues lineData = new SCIDoubleValues();
        private readonly SCIDoubleValues scatterData = new SCIDoubleValues();
        private readonly XyDataSeries<int, double> lineDataSeries = new XyDataSeries<int, double> { SeriesName = "Line Series", FifoCapacity = fifoCapacity };
        private readonly XyDataSeries<int, double> scatterDataSeries = new XyDataSeries<int, double> { SeriesName = "Scatter Series", FifoCapacity = fifoCapacity };

        public SCIChartSurface Surface => (SCIChartSurface)View;

        public override void LoadView()
        {
            View = new SCIChartSurface();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Create another numeric axis, right-aligned
            var yAxisRight = new SCINumericAxis();
            yAxisRight.AxisTitle = "Primary Y-Axis";
            yAxisRight.AxisId = "Primary Y-Axis";
            yAxisRight.AxisAlignment = SCIAxisAlignment.Right;

            // Create another numeric axis, left-aligned
            var yAxisLeft = new SCINumericAxis();
            yAxisLeft.AxisTitle = "Secondary Y-Axis";
            yAxisLeft.AxisId = "Secondary Y-Axis";
            yAxisLeft.AxisAlignment = SCIAxisAlignment.Left;
            yAxisLeft.GrowBy = new SCIDoubleRange(0.2, 0.2);

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

            var lineSeries = new SCIFastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "Primary Y-Axis" };
            var scatterSeries = new SCIXyScatterRenderableSeries
            {
                YAxisId = "Secondary Y-Axis",
                DataSeries = scatterDataSeries,
                PointMarker = new SCIEllipsePointMarker { FillStyle = new SCISolidBrushStyle(0xFF32CD32), Size = new CGSize(10, 10) }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(new SCINumericAxis());
                Surface.YAxes.Add(yAxisLeft);
                Surface.YAxes.Add(yAxisRight);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(scatterSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIRolloverModifier(),
                    new SCILegendModifier
                    {
                        Orientation = SCIOrientation.Horizontal,
                        Margins = new UIEdgeInsets(0, 0, 10, 0),
                        Position = SCIAlignment.Bottom | SCIAlignment.CenterHorizontal
                    },
                    new SCIYAxisDragModifier()
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

                    TryAddAnnotationAt(x);

                    // zoom series to fit viewport size into X-Axis direction
                    Surface.ZoomExtents();
                    count++;
                }
            });
        }

        private void TryAddAnnotationAt(int x)
        {
            // add label every 100 data points
            if (x % 100 == 0)
            {
                var label = new SCITextAnnotation
                {
                    YAxisId = x % 200 == 0 ? "Primary Y-Axis" : "Secondary Y-Axis",
                    Text = "N",
                    X1Value = x,
                    Y1Value = 0,
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Center,
                    FontStyle = new SCIFontStyle(30, 0xFFFFFFFF)
                };

                // add label into annotation collection
                Surface.Annotations.Add(label);

                // if we add annotation and x > fifoCapacity
                // then we need to remove annotation which goes out of the screen
                if (x > fifoCapacity)
                {
                    Surface.Annotations.RemoveAt(0);
                }
            }
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            View.Dispose();
        }
    }
}