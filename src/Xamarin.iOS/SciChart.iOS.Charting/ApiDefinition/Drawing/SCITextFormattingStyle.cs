using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCITextFormattingStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCITextFormattingStyle : SCIStyleProtocol, INSCopying
    {
        // -(instancetype)initWithFontSize:(float)fontSize andTextColor:(unsigned int)textColor;
        [Export("initWithFontSize:andTextColor:")]
        IntPtr Constructor(float fontSize, uint textColor);

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