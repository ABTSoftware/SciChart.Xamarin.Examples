using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieLegendItem : SCILegendItem
    [BaseType(typeof(SCILegendItem))]
    interface SCIPieLegendItem
    {
        //-(instancetype) initWithSegment:(SCIPieSegment*) segment;
        [Export("initWithSegment:")]
        IntPtr Constructor(SCIPieSegment segment);

        //@property(nonatomic, weak) SCIPieSegment* segment;
        [Export("segment")]
        SCIPieSegment Segment { get; set; }
    }
}
