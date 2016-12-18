using Foundation;
using System;
using UIKit;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
	public partial class ChartView : UIView
    {
		SCIChartSurfaceViewBase chartView;

        public ChartView (IntPtr handle) : base (handle)
        {
        }

		public void InitChartView(SCIChartSurfaceView view)
		{
			chartView = view;
			chartView.Frame = this.Frame;
			chartView.TranslatesAutoresizingMaskIntoConstraints = true;

			this.Add(chartView);
		}
	}
}