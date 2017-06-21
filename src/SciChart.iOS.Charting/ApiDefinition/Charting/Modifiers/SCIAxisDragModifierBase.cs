using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisDragModifierBase
    [BaseType(typeof(SCIGestureModifier))]
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

        // -(void)performPanFrom:(CGPoint)lastPoint To:(CGPoint)currentPoint;
        [Export("performPanFrom:To:")]
        void PerformPan(CGPoint lastPoint, CGPoint currentPoint);

        // -(void)performScaleFrom:(CGPoint)lastPoint To:(CGPoint)currentPoint IsSecondHalf:(BOOL)isSecondHalf;
        [Export("performScaleFrom:To:IsSecondHalf:")]
        void PerformScale(CGPoint lastPoint, CGPoint currentPoint, bool isSecondHalf);
    }
}