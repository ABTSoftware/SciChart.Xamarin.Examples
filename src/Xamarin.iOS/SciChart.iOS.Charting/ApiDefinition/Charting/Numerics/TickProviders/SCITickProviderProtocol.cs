using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCITickProviderProtocol : INSObjectProtocol { }

    // @protocol SCITickProviderProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCITickProviderProtocol
    {
        // @required @property (nonatomic, weak) id<SCIAxisCoreProtocol> axis;
        [Abstract]
        [Export("axis", ArgumentSemantic.Weak)]
        ISCIAxisCoreProtocol Axis { get; set; }

        // @required -(SCIArrayController *)getMajorTicksFromAxis:(id<SCIAxisCoreProtocol>)axis;
        [Abstract]
        [Export("getMajorTicksFromAxis:")]
        SCIArrayController GetMajorTicksFromAxis(ISCIAxisCoreProtocol axis);

        // @required -(SCIArrayController *)getMinorTicksFromAxis:(id<SCIAxisCoreProtocol>)axis;
        [Abstract]
        [Export("getMinorTicksFromAxis:")]
        SCIArrayController GetMinorTicksFromAxis(ISCIAxisCoreProtocol axis);
    }
}
