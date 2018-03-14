using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCITextAnnotationViewSetupBlock)(UITextField *);
    delegate void SCITextAnnotationViewTextFieldSetupBlock(UITextField view);

    // @interface SCIAxisMarkerAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIAxisMarkerAnnotationStyle : ISCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCITextFormattingStyle * textStyle;
        [Export("textStyle", ArgumentSemantic.Strong)]
        SCITextFormattingStyle TextStyle { get; set; }

        // @property (nonatomic, strong) UIColor * textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (copy, nonatomic) SCIAxisMarkerAnnotationViewSetupBlock viewSetup;
        [Export("viewSetup", ArgumentSemantic.Copy)]
        SCITextAnnotationViewTextFieldSetupBlock ViewSetup { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * markerLinePen;
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

        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> interactionMarker;
        [Export("interactionMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol InteractionMarker { get; set; }

        // @property (nonatomic) double interactionRadius;
        [Export("interactionRadius")]
        double InteractionRadius { get; set; }

        // @property (nonatomic) SCIAnnotationSurfaceEnum annotationSurface;
        [Export("annotationSurface", ArgumentSemantic.Assign)]
        SCIAnnotationSurfaceEnum AnnotationSurface { get; set; }
    }
}