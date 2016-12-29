using System;
using Foundation;
using ObjCRuntime;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    public partial class PerformanceDemoViewLayout : UIStackView
    {
        public UIButton Start => StartButton;

        public UIButton Pause => PauseButton;

        public UIButton Reset => ResetButton;

        public SCIChartSurfaceView SciChartSurfaceView => Surface;

        public PerformanceDemoViewLayout(IntPtr handle) : base(handle)
        {
        }

        public static PerformanceDemoViewLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("PerformanceDemoViewLayout", null, null);
            var view = Runtime.GetNSObject<PerformanceDemoViewLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}