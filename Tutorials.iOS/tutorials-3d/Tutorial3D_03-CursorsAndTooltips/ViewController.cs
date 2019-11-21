using System;
using UIKit;
using SciChart.iOS.Charting;

namespace Tutorial3D_01_CreateSimpleScatterChart3D
{
    public class ViewController : UIViewController
    {
        private readonly Random random = new Random();

        public SCIChartSurface3D Surface => (SCIChartSurface3D)View;

        public override void LoadView()
        {
            View = new SCIChartSurface3D();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var dataSeries = new XyzDataSeries3D<double, double, double>();
            for (int i = 0; i < 200; i++)
            {
                var x = GetGaussianRandomNumber(5, 1.5);
                var y = GetGaussianRandomNumber(5, 1.5);
                var z = GetGaussianRandomNumber(5, 1.5);

                dataSeries.Append(x, y, z);
            }

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