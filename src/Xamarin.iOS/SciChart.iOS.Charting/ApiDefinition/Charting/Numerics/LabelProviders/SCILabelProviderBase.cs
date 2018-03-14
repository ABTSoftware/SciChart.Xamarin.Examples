using Foundation;
using ObjCRuntime;

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