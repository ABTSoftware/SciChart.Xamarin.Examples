using CoreGraphics;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIPanModifier : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIPanModifier
    {
        // -(void)performPanFrom:(CGPoint)lastPoint To:(CGPoint)currentPoint;
        [Export("performPanFrom:To:")]
        void PerformPan(CGPoint lastPoint, CGPoint currentPoint);

        // -(void)performPanEndingFrom:(CGPoint)lastPoint andVelocity:(CGPoint)velocity;
        [Export("performPanEndingFrom:andVelocity:")]
        void PerformPanEnding(CGPoint lastPoint, CGPoint velocity);
    }
}