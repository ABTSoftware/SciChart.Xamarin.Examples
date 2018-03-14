using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieHitTestInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIPieHitTestInfo
    {
        //@property(nonatomic, weak) id<SCIPieRenderableSeriesProtocol> renderableSeries;
        [Export("renderableSeries", ArgumentSemantic.Weak)]
        ISCIPieRenderableSeriesProtocol RenderableSeries { get; set; }
        //@property(nonatomic, weak) SCIPieSegment* segment;
        [Export("segment", ArgumentSemantic.Weak)]
        SCIPieSegment Segment { get; set; }
        //@property(nonatomic) BOOL isHit;
        [Export("isHit")]
        bool IsHit { get; set; }
        //@property(nonatomic) int segmentIndex;
        [Export("segmentIndex")]
        int SegmentIndex { get; set; }

        //-(instancetype) initWithSeries:(id<SCIPieRenderableSeriesProtocol>) series segment:(SCIPieSegment*) segment isHit:(BOOL) isHit segmentIndex:(int) index;
        [Export("initWithSeries:segment:isHit:segmentIndex:")]
        IntPtr Constructor(ISCIPieRenderableSeriesProtocol series, SCIPieSegment segment, bool isHit, int index);
    }
}
