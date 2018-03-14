using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCITickProviderProtocol { }

    // @protocol SCITickProviderProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
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