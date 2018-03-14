using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieLayoutManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIPieLayoutManager
    {
        //@property(nonatomic, weak) SCIPieChartSurface* parentSurface;
        [Export("parentSurface", ArgumentSemantic.Weak)]
        SCIPieChartSurface ParentSurface { get; set; }
        //@property(nonatomic) float holeRadius;
        [Export("holeRadius")]
        float HoleRadius { get; set; }
        //@property(nonatomic) float seriesSpacing;
        [Export("seriesSpacing")]
        float SeriesSpacing { get; set; }
        //@property(nonatomic) float margin;
        [Export("margin")]
        float Margin { get; set; }
        //@property(nonatomic) float seriesMinimumHeight;
        [Export("seriesMinimumHeight")]
        float SeriesMinimumHeight { get; set; }
        //@property(nonatomic) float segmentSpacing;
        [Export("segmentSpacing")]
        float SegmentSpacing { get; set; }

        //-(instancetype) initWithParent:(SCIPieChartSurface*) parentSurface;
        [Export("initWithParent:")]
        IntPtr Constructor(SCIPieChartSurface parentSurface);

        //-(void) layoutSeries;
        [Export("layoutSeries")]
        void LayoutSeries();
    }
}
