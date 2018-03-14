using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIAxisDeltaProtocol { }

    // @protocol SCIAxisDeltaProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIAxisDeltaProtocol
    {
        // @required @property (nonatomic) SCIGenericType majorDelta;
        [Abstract]
        [Export("majorDelta", ArgumentSemantic.Assign)]
        SCIGenericType MajorDelta { get; set; }

        // @required @property (nonatomic) SCIGenericType minorDelta;
        [Abstract]
        [Export("minorDelta", ArgumentSemantic.Assign)]
        SCIGenericType MinorDelta { get; set; }
    }
}