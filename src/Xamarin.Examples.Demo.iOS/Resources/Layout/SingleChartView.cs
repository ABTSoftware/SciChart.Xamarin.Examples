using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    public partial class SingleChartView : UIView
    {
        public SCIChartSurfaceView SciChartSurfaceView => Surface;

        public SingleChartView (IntPtr handle) : base (handle)
        {
        }

        public static SingleChartView Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("SingleChartView", null, null);
            var view = Runtime.GetNSObject<SingleChartView>(pointersArray.ValueAt(0));

            return view;
        }
    }
}