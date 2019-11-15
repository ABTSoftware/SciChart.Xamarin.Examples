using Foundation;
using System;
using ObjCRuntime;
using UIKit;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class DashboardStyleChartsLayout : UIView
    {
        public UISegmentedControl ChartSelectorView => ChartSelector;
        public SCIChartSurface ChartView => Chart;

        public DashboardStyleChartsLayout(IntPtr handle) : base(handle) { }

        public static DashboardStyleChartsLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("DashboardStyleChartsLayout", null, null);
            var view = Runtime.GetNSObject<DashboardStyleChartsLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}