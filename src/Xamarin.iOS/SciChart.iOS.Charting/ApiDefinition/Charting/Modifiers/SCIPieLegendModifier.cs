using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieLegendModifier : SCILegendModifier
    [BaseType(typeof(SCILegendModifier))]
    interface SCIPieLegendModifier
    {
        //@property(nonatomic, weak) id<SCIPieRenderableSeriesProtocol> pieSeries;
        [Export("pieSeries")]
        ISCIPieRenderableSeriesProtocol PieSeries { get; set; }
    }
}
