using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIRelativeZoomModifierBase : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIRelativeZoomModifierBase
    {
        // @property (nonatomic) SCIXYDirection xyDirection;
        [Export("xyDirection", ArgumentSemantic.Assign)]
        SCIXYDirection XyDirection { get; set; }

        // @property (nonatomic) double growFactor;
        [Export("growFactor")]
        double GrowFactor { get; set; }

        // -(void)performZoomAt:(CGPoint)mousePoint XValue:(double)xValue YValue:(double)yValue;
        [Export("performZoomAt:XValue:YValue:")]
        void PerformZoomAt(CGPoint mousePoint, double xValue, double yValue);

        // -(void)growByFraction:(double)fraction AtPoint:(CGPoint)location AtAxis:(id<SCIAxis2DProtocol>)axis;
        [Export("growByFraction:AtPoint:AtAxis:")]
        void GrowByFraction(double fraction, CGPoint location, ISCIAxis2DProtocol axis);
    }
}