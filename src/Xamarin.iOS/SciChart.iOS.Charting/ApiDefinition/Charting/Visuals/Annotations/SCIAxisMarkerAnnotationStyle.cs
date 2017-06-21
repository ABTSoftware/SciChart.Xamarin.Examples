using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCITextAnnotationViewSetupBlock)(UITextField *);
    delegate void SCITextAnnotationViewSetupBlock(UITextField view);

    // @interface SCIAxisMarkerAnnotationStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIAxisMarkerAnnotationStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCITextFormattingStyle * textStyle;
        [Export("textStyle", ArgumentSemantic.Strong)]
        SCITextFormattingStyle TextStyle { get; set; }

        // @property (nonatomic, strong) UIColor * textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (copy, nonatomic) SCITextAnnotationViewSetupBlock viewSetup;
        [Export("viewSetup", ArgumentSemantic.Copy)]
        SCITextAnnotationViewSetupBlock ViewSetup { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> markerLinePen;
        [Export("markerLinePen", ArgumentSemantic.Strong)]
        SCIPenStyle MarkerLinePen { get; set; }

        // @property (nonatomic) float margin;
        [Export("margin")]
        float Margin { get; set; }

        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * borderColor;
        [Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; set; }

        // @property (nonatomic) float borderWidth;
        [Export("borderWidth")]
        float BorderWidth { get; set; }

        // @property (nonatomic) float arrowSize;
        [Export("arrowSize")]
        float ArrowSize { get; set; }

        // @property (nonatomic) float opacity;
        [Export("opacity")]
        float Opacity { get; set; }
    }
}