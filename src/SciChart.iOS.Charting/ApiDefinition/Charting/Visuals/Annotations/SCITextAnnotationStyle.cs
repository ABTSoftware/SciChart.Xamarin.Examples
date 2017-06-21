using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITextAnnotationStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCITextAnnotationStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCITextFormattingStyle * textStyle;
        [Export("textStyle", ArgumentSemantic.Strong)]
        SCITextFormattingStyle TextStyle { get; set; }

        // @property (nonatomic, strong) UIColor * textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (copy, nonatomic) SCITextAnnotationViewSetupBlock viewSetup;
        [Export("viewSetup", ArgumentSemantic.Copy)]
        SCITextAnnotationViewSetupBlock ViewSetup { get; set; }
    }
}