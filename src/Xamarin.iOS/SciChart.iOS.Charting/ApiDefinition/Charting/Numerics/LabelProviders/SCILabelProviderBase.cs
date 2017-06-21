using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILabelProviderBase : NSObject <SCILabelProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCILabelProviderBase : SCILabelProviderProtocol
    {
        // @property (nonatomic, weak) id<SCIAxisCoreProtocol> parentAxis;
        [Export("parentAxis", ArgumentSemantic.Weak)]
        ISCIAxisCoreProtocol ParentAxis { get; set; }
    }
}