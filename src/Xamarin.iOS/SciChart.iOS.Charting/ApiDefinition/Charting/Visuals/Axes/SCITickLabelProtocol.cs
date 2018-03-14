using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCITickLabelProtocol { }

    // @protocol SCITickLabelProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCITickLabelProtocol
    {
        // @required @property (nonatomic) BOOL hasExponent;
        [Abstract]
        [Export("hasExponent")]
        bool HasExponent { get; set; }

        // @required @property (copy, nonatomic) NSString * separator;
        [Abstract]
        [Export("separator")]
        string Separator { get; set; }

        // @required @property (copy, nonatomic) NSString * exponent;
        [Abstract]
        [Export("exponent")]
        string Exponent { get; set; }

        // @required @property (copy, nonatomic) NSString * text;
        [Abstract]
        [Export("text")]
        string Text { get; set; }
    }
}