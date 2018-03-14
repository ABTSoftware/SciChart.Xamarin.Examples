using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCITextAnnotation : SCIAnchorPointAnnotation
    [BaseType(typeof(SCIAnchorPointAnnotation))]
    interface SCITextAnnotation
    {
        // @property (nonatomic) SCIGenericType x1;
        [Export("x1", ArgumentSemantic.Assign)]
        SCIGenericType X1 { get; set; }

        // @property (nonatomic) SCIGenericType y1;
        [Export("y1", ArgumentSemantic.Assign)]
        SCIGenericType Y1 { get; set; }

        // @property (copy, nonatomic) NSString * text;
        [Export("text")]
        string Text { get; set; }

        // @property (copy, nonatomic) SCITextAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCITextAnnotationStyle Style { get; set; }

        // @property (nonatomic) BOOL editableText;
        [Export("editableText")]
        bool EditableText { get; set; }

        // @property (nonatomic) BOOL selectableText;
        [Export("selectableText")]
        bool SelectableText { get; set; }
    }
}