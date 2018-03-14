using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieLayoutPassData : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIPieLayoutPassData
    {
        //@property(nonatomic) CGPoint center;
        [Export("center")]
        CGPoint Center { get; set; }
        //@property(nonatomic) double innerRadius;
        [Export("innerRadius")]
        double InnerRadius { get; set; }
        //@property(nonatomic) double outerRadius;
        [Export("outerRadius")]
        double OuterRadius { get; set; }
        //@property(nonatomic) CGRect frame;
        [Export("frame")]
        CGRect Frame { get; set; }
        //@property(nonatomic) double segmentSpacing;
        [Export("segmentSpacing")]
        double SegmentSpacing { get; set; }
    }
}
