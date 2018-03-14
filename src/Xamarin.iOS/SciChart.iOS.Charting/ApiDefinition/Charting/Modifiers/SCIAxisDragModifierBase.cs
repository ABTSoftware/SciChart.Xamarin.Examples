using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisDragModifierBase : SCIPanModifier
    [BaseType(typeof(SCIPanModifier))]
    interface SCIAxisDragModifierBase
    {
        // @property (copy, nonatomic) NSString * axisId;
        [Export("axisId")]
        string AxisId { get; set; }

        // @property (nonatomic) SCIAxisDragMode dragMode;
        [Export("dragMode", ArgumentSemantic.Assign)]
        SCIAxisDragMode DragMode { get; set; }

        // @property (readonly, nonatomic) BOOL gestureLocked;
        [Export("gestureLocked")]
        bool GestureLocked { get; }

        // -(BOOL)getIsSecondHalfPoint:(CGPoint)point Frame:(CGRect)axisBounds IsHorizontal:(BOOL)isHorizontalAxis;
        [Export("getIsSecondHalfPoint:Frame:IsHorizontal:")]
        bool GetIsSecondHalfPoint(CGPoint point, CGRect axisBounds, bool isHorizontalAxis);

        // -(id<SCIAxis2DProtocol>)getCurrentAxis;
        [Export("getCurrentAxis")]
        ISCIAxis2DProtocol CurrentAxis { get; }

        // -(id<SCIRangeProtocol>)calculateScaledRangeFrom:(CGPoint)lastPoint To:(CGPoint)currentPoint IsSecondHalf:(BOOL)isSecondHalf AtAxis:(id<SCIAxis2DProtocol>)axis;
        [Export("calculateScaledRangeFrom:To:IsSecondHalf:AtAxis:")]
        ISCIRangeProtocol CalculateScaledRangeFrom(CGPoint lastPoint, CGPoint currentPoint, bool isSecondHalf, ISCIAxis2DProtocol axis);

        // -(SCIDoubleRange *)calculateRelativeRangeFrom:(id<SCIRangeProtocol>)fromRange AtAxis:(id<SCIAxis2DProtocol>)axis;
        [Export("calculateRelativeRangeFrom:AtAxis:")]
        SCIDoubleRange CalculateRelativeRangeFrom(ISCIRangeProtocol fromRange, ISCIAxis2DProtocol axis);

        // -(void)performScaleFrom:(CGPoint)lastPoint To:(CGPoint)currentPoint IsSecondHalf:(BOOL)isSecondHalf;
        [Export("performScaleFrom:To:IsSecondHalf:")]
        void PerformScale(CGPoint lastPoint, CGPoint currentPoint, bool isSecondHalf);
    }
}