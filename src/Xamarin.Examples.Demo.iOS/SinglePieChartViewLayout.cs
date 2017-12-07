using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class SinglePieChartViewLayout : UIView
    {
        public SCIPieChartSurface SciPieChartSurface => Surface;

        public SinglePieChartViewLayout(IntPtr handle) : base(handle)
        {
        }

        public static SinglePieChartViewLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("SinglePieChartViewLayout", null, null);
            var view = Runtime.GetNSObject<SinglePieChartViewLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}