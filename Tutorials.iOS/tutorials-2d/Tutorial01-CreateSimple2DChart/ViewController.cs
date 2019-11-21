using System;
using UIKit;
using CoreGraphics;
using SciChart.iOS.Charting;

namespace Tutorial01_CreateSimple2DChart
{
    public class ViewController : UIViewController
    {
        public SCIChartSurface Surface => (SCIChartSurface)View;

        public override void LoadView()
        {
            View = new SCIChartSurface();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var lineDataSeries = new XyDataSeries<int, double>();
            var scatterDataSeries = new XyDataSeries<int, double>();
            for (int i = 0; i < 200; i++)
            {
                lineDataSeries.Append(i, Math.Sin(i * 0.1));
                scatterDataSeries.Append(i, Math.Cos(i * 0.1));
            }

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
            }
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            View.Dispose();
        }
    }
}