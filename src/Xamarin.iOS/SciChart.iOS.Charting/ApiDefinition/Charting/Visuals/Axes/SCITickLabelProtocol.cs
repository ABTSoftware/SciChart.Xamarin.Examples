using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCITickLabelProtocol : INSObjectProtocol { }

    // @protocol SCITickLabelProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
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