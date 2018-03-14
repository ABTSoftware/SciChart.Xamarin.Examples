using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{

    interface ISCIAnimationContextInvalidate {}

    // @protocol SCIAnimationContextInvalidate
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIAnimationContextInvalidate
    {
        // @required -(void)invalidateAnimationsContext;
        [Abstract]
        [Export("invalidateAnimationsContext")]
        void InvalidateAnimationsContext();
    }
}