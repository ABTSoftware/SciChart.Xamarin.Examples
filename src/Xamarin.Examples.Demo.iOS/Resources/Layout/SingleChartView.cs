using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    public partial class SingleChartView : UIView
    {
        public ExampleBaseView SciChartSurfaceView => Surface;

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