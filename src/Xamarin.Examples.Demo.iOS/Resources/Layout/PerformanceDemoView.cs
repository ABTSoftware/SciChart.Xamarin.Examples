using System;
using Foundation;
using ObjCRuntime;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    public partial class PerformanceDemoView : UIStackView
    {
        //public SCIChartSurfaceView SciChartSurfaceView => Surface;

        public PerformanceDemoView (IntPtr handle) : base (handle)
        {
        }

        public static PerformanceDemoView Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("PerformanceDemoView", null, null);
            var view = Runtime.GetNSObject<PerformanceDemoView>(pointersArray.ValueAt(0));

            return view;
        }
    }
}