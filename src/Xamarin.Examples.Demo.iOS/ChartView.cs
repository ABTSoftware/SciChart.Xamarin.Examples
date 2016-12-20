using System;
using UIKit;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class ChartView : UIView
    {
        public ChartView(IntPtr handle) : base(handle)
        {
        }

        public void InitChartView(SCIChartSurfaceView view)
        {
            SCIChartSurfaceViewBase sciChartSurfaceView = view;
            sciChartSurfaceView.Frame = Frame;
            sciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;

            this.Add(sciChartSurfaceView);
        }
    }
}