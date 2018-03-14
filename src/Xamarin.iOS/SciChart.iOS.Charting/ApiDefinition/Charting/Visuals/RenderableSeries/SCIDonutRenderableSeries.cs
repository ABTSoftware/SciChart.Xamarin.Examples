using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIDonutRenderableSeries : NSObject<SCIPieRenderableSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDonutRenderableSeries : SCIPieRenderableSeriesProtocol
    {
        //@property(nonatomic) double appearAnimationDuration;
        [Export("appearAnimationDuration")]
        double AppearAnimationDuration { get; set; }

        //-(void) startAnimation;
        [Export("startAnimation")]
        void StartAnimation();

        //@property(nonatomic) BOOL drawLabels;
        [Export("drawLabels")]
        bool DrawLabels { get; set; }

        //-(CGImageRef) getMaskImageWithCentre:(CGPoint)centre radius:(double) radius startAngle:(double) startAngle endAngle:(double) endAngle;
        [Export("getMaskImageWithCentre:radius:startAngle:endAngle:")]
        CGImage GetMaskImage(CGPoint centre, double radius, double startAngle, double endAngle);

        //-(void) drawSegment:(SCIPieSegment*) segment offset:(double) offset arcSize:(double) arcSize center:(CGPoint) center innerRadius:(double) innerRadius outerRadius:(double) outerRadius;
        [Export("drawSegment:offset:arcSize:center:innerRadius:outerRadius:")]
        void DrawSegment(SCIPieSegment segment, double offset, double arcSize, CGPoint center, double innerRadius, double outerRadius);

        //-(void) drawSegmentFill:(SCIPieSegment*) segment path:(CGMutablePathRef) path;
        [Export("drawSegmentFill:path:")]
        void DrawSegmentFill(SCIPieSegment segment, CGPath path);
        //-(void) drawSegmentSolidFill:(SCIPieSegment*) segment path:(CGMutablePathRef) path;
        [Export("drawSegmentSolidFill:path:")]
        void DrawSegmentSolidFill(SCIPieSegment segment, CGPath path);
        //-(void) drawSegmentGradientFill:(SCIPieSegment*) segment path:(CGMutablePathRef) path;
        [Export("drawSegmentGradientFill:path:")]
        void DrawSegmentGradientFill(SCIPieSegment segment, CGPath path);
        //-(void) drawSegmentStroke:(SCIPieSegment*) segment path:(CGMutablePathRef) path;
        [Export("drawSegmentStroke:path:")]
        void DrawSegmentStroke(SCIPieSegment segment, CGPath path);
        //-(void) drawSegmentOutline:(SCIPieSegment*) segment path:(CGMutablePathRef) path;
        [Export("drawSegmentOutline:path:")]
        void DrawSegmentOutline(SCIPieSegment segment, CGPath path);

        //-(void) drawSegmentLabel:(SCIPieSegment*) segment offset:(double) offset arcSize:(double) arcSize center:(CGPoint) center innerRadius:(double) innerRadius outerRadius:(double) outerRadius;
        [Export("drawSegmentLabel:offset:arcSize:center:innerRadius:outerRadius:")]
        void DrawSegmentLabel(SCIPieSegment segment, double offset, double arcSize, CGPoint center, double innerRadius, double outerRadius);
        //-(NSString*) getLabelTextForSegment:(SCIPieSegment*) segment totalValue:(double) value;
        [Export("getLabelTextForSegment:totalValue:")]
        string GgetLabelText(SCIPieSegment segment, double totalValue);

        //-(void) placeLabelForSegment:(SCIPieSegment*) segment text:(NSString*) text centre:(CGPoint) centre innerRadius:(double) innerRadius outerRadius:(double) outerRadius startAngle:(double) startAngle endAngle:(double) endAngle placementOption:(int) placementOption;
        [Export("placeLabelForSegment:text:centre:innerRadius:outerRadius:startAngle:endAngle:placementOption:")]
        void PlaceLabelForSegment(SCIPieSegment segment, string text, CGPoint center, double innerRadius, double outerRadius, double startAngle, double endAngle, int placementOption);
        //-(CGMutablePathRef) getSegmentPath:(SCIPieSegment*) segment centre:(CGPoint) centre innerRadius:(double) innerRadius outerRadius:(double) outerRadius startAngle:(double) startAngle endAngle:(double) endAngle segmentSpacing:(double) segmentSpacing;
        [Export("getSegmentPath:centre:innerRadius:outerRadius:startAngle:endAngle:segmentSpacing:")]
        CGPath GetSegmentPath(SCIPieSegment segment, CGPoint centre, double innerRadius, double outerRadius, double startAngle, double endAngle, double segmentSpacing);
        //-(CGMutablePathRef) getOutlinePath:(SCIPieSegment*) segment centre:(CGPoint) centre innerRadius:(double) innerRadius outerRadius:(double) outerRadius startAngle:(double) startAngle endAngle:(double) endAngle segmentSpacing:(double) segmentSpacing;
        [Export("getOutlinePath:centre:innerRadius:outerRadius:startAngle:endAngle:segmentSpacing:")]
        CGPath GetOutlinePath(SCIPieSegment segment, CGPoint centre, double innerRadius, double outerRadius, double startAngle, double endAngle, double segmentSpacing);

        //-(CGAffineTransform) getTransformForSegment:(SCIPieSegment*) segment startAngle:(double) startAngle endAngle:(double) endAngle;
        [Export("getTransformForSegment:startAngle:endAngle:")]
        CGAffineTransform GetTransformForSegment(SCIPieSegment segment, double startAngle, double endAngle);

        //@property(nonatomic) float segmentSpacing;
        [Export("segmentSpacing")]
        float SegmentSpacing { get; set; }
    }
}
