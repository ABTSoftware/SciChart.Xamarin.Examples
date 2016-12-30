using System;
using Foundation;
using ObjCRuntime;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    public partial class SingleRealtimeChartLayout : UIStackView
    {
        public UIButton Start => StartButton;

        public UIButton Pause => PauseButton;

        public UIButton Reset => ResetButton;

        public SCIChartSurfaceView SciChartSurfaceView => Surface;

        public SingleRealtimeChartLayout(IntPtr handle) : base(handle)
        {
        }

        public static SingleRealtimeChartLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("SingleRealtimeChartLayout", null, null);
            var view = Runtime.GetNSObject<SingleRealtimeChartLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}