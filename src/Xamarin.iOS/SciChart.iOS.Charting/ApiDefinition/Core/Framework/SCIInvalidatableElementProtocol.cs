using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIInvalidatableElementProtocol { }

    // @protocol SCIInvalidatableElementProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIInvalidatableElementProtocol
    {
        // @required -(void)invalidateElement;
        [Abstract]
        [Export("invalidateElement")]
        void InvalidateElement();
    }
}