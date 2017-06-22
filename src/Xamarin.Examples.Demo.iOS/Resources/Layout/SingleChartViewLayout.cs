using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    public partial class SingleChartViewLayout : UIView
    {
        public SCIChartSurface SciChartSurface => Surface;

        public SingleChartViewLayout (IntPtr handle) : base (handle)
        {
        }

        public static SingleChartViewLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("SingleChartViewLayout", null, null);
            var view = Runtime.GetNSObject<SingleChartViewLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}