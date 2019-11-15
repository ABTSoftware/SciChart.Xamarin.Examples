using System;
using Foundation;
using ObjCRuntime;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class RealtimeTickingStockChartsLayout : UIView
    {
        public SCIChartSurface MainSurfaceView => MainSurface;

        public SCIChartSurface OverviewSurfaceView => OverviewSurface;

        public RealtimeTickingStockChartsLayout(IntPtr handle) : base(handle) { }

        public static RealtimeTickingStockChartsLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("RealtimeTickingStockChartsLayout", null, null);
            var view = Runtime.GetNSObject<RealtimeTickingStockChartsLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}