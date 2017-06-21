using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCITickCoordinatesProviderProtocol { }

    // @protocol SCITickCoordinatesProviderProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCITickCoordinatesProviderProtocol
    {
        // @required @property (nonatomic, weak) id<SCIAxisCoreProtocol> parentAxis;
        [Abstract]
        [Export("parentAxis", ArgumentSemantic.Weak)]
        ISCIAxisCoreProtocol ParentAxis { get; set; }

        // @required -(void)setAxis:(id<SCIAxisCoreProtocol>)parentAxis;
        [Abstract]
        [Export("setAxis:")]
        void SetAxis(ISCIAxisCoreProtocol parentAxis);
    }
}
