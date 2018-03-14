using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIRelativeZoomModifierBase : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIRelativeZoomModifierBase
    {
        // @property (nonatomic) SCIDirection2D direction;
        [Export("direction", ArgumentSemantic.Assign)]
        SCIDirection2D Direction { get; set; }

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