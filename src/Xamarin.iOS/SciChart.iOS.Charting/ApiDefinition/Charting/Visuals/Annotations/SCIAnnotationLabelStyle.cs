using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIAnnotationLabelSetupBlock)(UILabel *);
    delegate void SCIAnnotationLabelSetupBlock(UILabel arg0);

    // @interface SCIAnnotationLabelStyle : NSObject <SCIStyleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIAnnotationLabelStyle : SCIStyleProtocol
    {
        // @property (nonatomic) float borderWidth;
        [Export("borderWidth")]
        float BorderWidth { get; set; }

        // @property (nonatomic) float cornerRadius;
        [Export("cornerRadius")]
        float CornerRadius { get; set; }

        // @property (nonatomic) float backgroundOpacity;
        [Export("backgroundOpacity")]
        float BackgroundOpacity { get; set; }

        // @property (nonatomic) float contentPadding;
        [Export("contentPadding")]
        float ContentPadding { get; set; }

        // @property (nonatomic) float alignmentMargin;
        [Export("alignmentMargin")]
        float AlignmentMargin { get; set; }

        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * borderColor;
        [Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; set; }

        // @property (copy, nonatomic) SCIAnnotationLabelSetupBlock labelSetup;
        [Export("labelSetup", ArgumentSemantic.Copy)]
        SCIAnnotationLabelSetupBlock LabelSetup { get; set; }

        // @property (nonatomic, strong) SCITextFormattingStyle * textStyle;
        [Export("textStyle", ArgumentSemantic.Strong)]
        SCITextFormattingStyle TextStyle { get; set; }

        // @property (nonatomic) SCILabelPlacement labelPlacement;
        [Export("labelPlacement", ArgumentSemantic.Assign)]
        SCILabelPlacement LabelPlacement { get; set; }
    }
}