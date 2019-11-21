using System;
using System.Timers;
using UIKit;
using SciChart.iOS.Charting;

namespace Tutorial3D_01_CreateSimpleScatterChart3D
{
    public class ViewController : UIViewController
    {
        private readonly Random random = new Random();

        private int pointsCount = 200;
        private Timer timer;
        private SCIDoubleValues xValues = new SCIDoubleValues();
        private SCIDoubleValues yValues = new SCIDoubleValues();
        private SCIDoubleValues zValues = new SCIDoubleValues();
        private XyzDataSeries3D<double, double, double> dataSeries = new XyzDataSeries3D<double, double, double>();

        private const int TimerInterval = 10;
        private volatile bool _isRunning = false;

        public SCIChartSurface3D Surface => (SCIChartSurface3D)View;

        public override void LoadView()
        {
            View = new SCIChartSurface3D();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            for (int i = 0; i < pointsCount; i++)
            {
                xValues.Add(GetGaussianRandomNumber(5, 1.5));
                yValues.Add(GetGaussianRandomNumber(5, 1.5));
                zValues.Add(GetGaussianRandomNumber(5, 1.5));
            }
            dataSeries.AppendValues(xValues, yValues, zValues);

            var rSeries = new SCIScatterRenderableSeries3D
            {
                DataSeries = dataSeries,
                PointMarker = new SCISpherePointMarker3D { FillColor = 0xFF32CD32, Size = 10.0f }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D();
                Surface.YAxis = new SCINumericAxis3D();
                Surface.ZAxis = new SCINumericAxis3D();
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers = new SCIChartModifier3DCollection
                {
                    new SCIOrbitModifier3D(2),
                    new SCIZoomExtentsModifier3D(),
                    new SCIPinchZoomModifier3D(),
                    new SCITooltipModifier3D { CrosshairMode = SCICrosshairMode.Lines }
                };
            }

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

                for (int i = 0; i < pointsCount; i++)
                {
                    var xValue = xValues.GetValueAt(i) + random.NextDouble() - 0.5;
                    var yValue = yValues.GetValueAt(i) + random.NextDouble() - 0.5;
                    var zValue = zValues.GetValueAt(i) + random.NextDouble() - 0.5;

                    xValues.Set(xValue, i);
                    yValues.Set(yValue, i);
                    zValues.Set(zValue, i);
                }

                using (Surface.SuspendUpdates())
                {
                    dataSeries.UpdateRangeXyzAt(xValues, yValues, zValues, 0);
                }
            });
        }

        private double GetGaussianRandomNumber(double mean, double stdDev)
        {
            var u1 = random.NextDouble();
            var u2 = random.NextDouble();
            var normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            return mean * stdDev * normal;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            View.Dispose();
        }
    }
}