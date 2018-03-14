using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCITextAnnotationViewSetupBlock)(UITextView *);
    delegate void SCITextAnnotationViewTextViewSetupBlock(UITextView arg0);

    // @interface SCITextAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCITextAnnotationStyle : ISCIStyleProtocol, INSCopying
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
        SCITextAnnotationViewTextViewSetupBlock ViewSetup { get; set; }
    }
}