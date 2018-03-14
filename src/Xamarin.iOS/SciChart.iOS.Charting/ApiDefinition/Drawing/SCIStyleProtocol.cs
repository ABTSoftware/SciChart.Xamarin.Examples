using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIStyleProtocol { }

    // @protocol SCIStyleProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIStyleProtocol
    {
        // @required @property (copy, nonatomic) SCIActionBlock styleChanged;
        [Abstract]
        [Export("styleChanged", ArgumentSemantic.Copy)]
        SCIActionBlock StyleChanged { get; set; }
    }
}