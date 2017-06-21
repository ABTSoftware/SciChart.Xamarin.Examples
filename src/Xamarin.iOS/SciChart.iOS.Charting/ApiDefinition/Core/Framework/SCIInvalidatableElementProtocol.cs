using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIInvalidatableElementProtocol : INSObjectProtocol { }

    // @protocol SCIInvalidatableElementProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIInvalidatableElementProtocol
    {
        // @required -(void)invalidateElement;
        [Abstract]
        [Export("invalidateElement")]
        void InvalidateElement();
    }
}
