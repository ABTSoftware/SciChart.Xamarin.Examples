using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieSeriesInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIPieSeriesInfo
    {
        //@property(nonatomic, strong) NSNumberFormatter* numberFormatter;
        [Export("numberFormatter")]
        NSNumberFormatter NumberFormatter { get; set; }

        //-(id<SCIPieRenderableSeriesProtocol>) series;
        [Export("series")]
        ISCIPieRenderableSeriesProtocol Series { get; }
        //-(SCIPieSegment*) segment;
        [Export("segment")]
        SCIPieSegment Segment { get; }
        //-(int) segmentIndex;
        [Export("segmentIndex")]
        int SegmentIndex { get; }
        //-(double) totalValue;
        [Export("totalValue")]
        double TotalValue { get; }
        //-(double) segmentValue;
        [Export("segmentValue")]
        double SegmentValue { get; }
        //-(BOOL) isHit;
        [Export("isHit")]
        bool IsHit { get; }
        //-(NSString*) seriesName;
        [Export("seriesName")]
        string SeriesName { get; }
        //-(NSString*) segmentTitle;
        [Export("segmentTitle")]
        string SegmentTitle { get; }

        //-(instancetype) initWithHitTest:(SCIPieHitTestInfo*) hitTest;
        [Export("initWithHitTest:")]
        IntPtr Constructor(SCIPieHitTestInfo hitTest);

        //-(SCIPieSeriesDataView*) createDataSeriesView;
        [Export("createDataSeriesView")]
        SCIPieSeriesDataView CreateDataSeriesView();

        //- (NSString*) fortmattedValueFromSeriesInfo;
        [Export("fortmattedValueFromSeriesInfo")]
        string FortmattedValueFromSeriesInfo();
    }
}
