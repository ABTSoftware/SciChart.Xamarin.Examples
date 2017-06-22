// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Xamarin.Examples.Demo.iOS
{
    [Register ("MultiplePaneStockChartsLayout")]
    partial class MultiplePaneStockChartsLayout
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface MacdSurface { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface PriceSurface { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface RsiSurface { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface VolumeSurface { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MacdSurface != null) {
                MacdSurface.Dispose ();
                MacdSurface = null;
            }

            if (PriceSurface != null) {
                PriceSurface.Dispose ();
                PriceSurface = null;
            }

            if (RsiSurface != null) {
                RsiSurface.Dispose ();
                RsiSurface = null;
            }

            if (VolumeSurface != null) {
                VolumeSurface.Dispose ();
                VolumeSurface = null;
            }
        }
    }
}