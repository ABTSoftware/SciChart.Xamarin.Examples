using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisHitTestProvider : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIAxisHitTestProvider
    {
        // -(SCIAxisInfo *)hitTestAxis:(id<SCIAxis2DProtocol>)axis AtX:(double)x Y:(double)y;
        [Export("hitTestAxis:AtX:Y:")]
        SCIAxisInfo HitTestAxis(ISCIAxis2DProtocol axis, double x, double y);

        // -(SCIAxisInfo *)hitTestAxis:(id<SCIAxis2DProtocol>)axis AtValue:(SCIGenericType)dataValue;
        [Export("hitTestAxis:AtValue:")]
        SCIAxisInfo HitTestAxis(ISCIAxis2DProtocol axis, SCIGenericType dataValue);
    }
}