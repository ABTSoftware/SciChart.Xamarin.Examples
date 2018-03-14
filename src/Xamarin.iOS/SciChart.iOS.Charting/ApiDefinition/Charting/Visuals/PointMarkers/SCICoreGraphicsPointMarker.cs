using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIPointMarkerCoreGraphicsSetup)(CGContextRef, CGRect);
    unsafe delegate void SCIPointMarkerCoreGraphicsSetup(CGContext arg0, CGRect arg1);

    // @interface SCICoreGraphicsPointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCICoreGraphicsPointMarker
    {
        // @property (nonatomic) float scale;
        [Export("scale")]
        float Scale { get; set; }

        // @property (copy, nonatomic) SCIPointMarkerCoreGraphicsSetup drawingCall;
        [Export("drawingCall", ArgumentSemantic.Copy)]
        SCIPointMarkerCoreGraphicsSetup DrawingCall { get; set; }
    }
}