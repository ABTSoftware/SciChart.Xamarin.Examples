using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIHorizontalLineAnnotation : SCILineAnnotation
    [BaseType(typeof(SCILineAnnotation))]
    interface SCIHorizontalLineAnnotation
    {
        // @property (copy, nonatomic) NSString * formattedValue;
        [Export("formattedValue")]
        string FormattedValue { get; set; }

        // @property (nonatomic) SCIGenericType y;
        [Export("y", ArgumentSemantic.Assign)]
        SCIGenericType Y { get; set; }

        // @property (nonatomic) SCIHorizontalLineAnnotationAlignment horizontalAlignment;
        [Export("horizontalAlignment", ArgumentSemantic.Assign)]
        SCIHorizontalLineAnnotationAlignment HorizontalAlignment { get; set; }

        // -(NSString *)formatValue:(SCIGenericType)value;
        [Export("formatValue:")]
        string FormatValue(SCIGenericType value);

        // -(void)addLabel:(SCILineAnnotationLabel *)label;
        [Export("addLabel:")]
        void AddLabel(SCILineAnnotationLabel label);

        // -(void)removeLabel:(SCILineAnnotationLabel *)label;
        [Export("removeLabel:")]
        void RemoveLabel(SCILineAnnotationLabel label);

        // -(SCILineAnnotationLabel *)labelAt:(int)index;
        [Export("labelAt:")]
        SCILineAnnotationLabel LabelAt(int index);

        // -(void)removeLabelAt:(int)index;
        [Export("removeLabelAt:")]
        void RemoveLabelAt(int index);
    }
}