using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIBrushStyleProtocol { }

    // @protocol SCIBrushStyleProtocol <SCIStyleProtocol, NSCopying>
    [Protocol, Model]
    interface SCIBrushStyleProtocol : SCIStyleProtocol, INSCopying
    {
        // @required @property (nonatomic) UIColor * _Nonnull color;
        [Abstract]
        [Export("color", ArgumentSemantic.Assign)]
        UIColor Color { get; set; }

        // @required @property (nonatomic) unsigned int colorCode;
        [Abstract]
        [Export("colorCode")]
        uint ColorCode { get; set; }
    }
}