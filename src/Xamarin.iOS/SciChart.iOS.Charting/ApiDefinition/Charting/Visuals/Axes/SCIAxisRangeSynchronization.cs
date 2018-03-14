using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisRangeSynchronization : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIAxisRangeSynchronization
    {
        // -(void)attachAxis:(id<SCIAxis2DProtocol>)axis;
        [Export("attachAxis:")]
        void AttachAxis(ISCIAxis2DProtocol axis);

        // -(void)detachAxis:(id<SCIAxis2DProtocol>)axis;
        [Export("detachAxis:")]
        void DetachAxis(ISCIAxis2DProtocol axis);
    }
}