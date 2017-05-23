using System;
using Foundation;
using ObjCRuntime;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class MultiplePaneStockChartsLayout : UIStackView
    {
        public SCIChartSurface PriceSurfaceView => PriceSurface;
        public SCIChartSurface MacdSurfaceView => MacdSurface;
        public SCIChartSurface RsiSurfaceView => RsiSurface;
        public SCIChartSurface VolumeChartView => RsiSurface;

        public MultiplePaneStockChartsLayout(IntPtr handle) : base(handle)
        {
        }

        public static MultiplePaneStockChartsLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("MultiplePaneStockChartsLayout", null, null);
            var view = Runtime.GetNSObject<MultiplePaneStockChartsLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}