using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIPenStyleProtocol { }

    // @protocol SCIPenStyleProtocol <SCIStyleProtocol, NSCopying>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIPenStyleProtocol : SCIStyleProtocol, INSCopying
    {
        // @required @property (nonatomic) float thickness;
        [Abstract]
        [Export("thickness")]
        float Thickness { get; set; }

        // @required @property (nonatomic) NSArray<NSNumber *> * _Nullable strokeDashArray;
        [Abstract]
        [NullAllowed, Export("strokeDashArray", ArgumentSemantic.Assign)]
        // TODO check StrokeDashArray binding in SCIPenStyleProtocol
        NSNumber[] StrokeDashArray { get; set; }

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