using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITextFormattingStyle : NSObject <ISCIStyleProtocol, NSCopying>

    [BaseType(typeof(NSObject))]
    interface SCITextFormattingStyle : SCIStyleProtocol, INSCopying
    {
        // @property (copy, nonatomic) NSString * fontName;
        [Export("fontName")]
        string FontName { get; set; }

        // @property (nonatomic) float fontSize;
        [Export("fontSize")]
        float FontSize { get; set; }

        // @property (copy, nonatomic) UIColor * color;
        [Export("color", ArgumentSemantic.Copy)]
        UIColor Color { get; set; }

        // @property (nonatomic) unsigned int colorCode;
        [Export("colorCode")]
        uint ColorCode { get; set; }

        // @property (nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }

        // @property (nonatomic) SCILabelAlignmentHorizontalMode alignmentHorizontal;
        [Export("alignmentHorizontal", ArgumentSemantic.Assign)]
        SCILabelAlignmentHorizontalMode AlignmentHorizontal { get; set; }

        // @property (nonatomic) SCILabelAlignmentVerticalMode alignmentVertical;
        [Export("alignmentVertical", ArgumentSemantic.Assign)]
        SCILabelAlignmentVerticalMode AlignmentVertical { get; set; }

        // -(UIFont *)getFont;
        [Export("getFont")]
        UIFont Font { get; }
    }
}