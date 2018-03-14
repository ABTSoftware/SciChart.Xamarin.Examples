using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIVerticalLineAnnotation : SCILineAnnotation
    [BaseType(typeof(SCILineAnnotation))]
    interface SCIVerticalLineAnnotation
    {
        // @property (copy, nonatomic) NSString * formattedValue;
        [Export("formattedValue")]
        string FormattedValue { get; set; }

        // @property (nonatomic) SCIGenericType x;
        [Export("x", ArgumentSemantic.Assign)]
        SCIGenericType X { get; set; }

        // @property (nonatomic) SCIVerticalLineAnnotationAlignment verticalAlignment;
        [Export("verticalAlignment", ArgumentSemantic.Assign)]
        SCIVerticalLineAnnotationAlignment VerticalAlignment { get; set; }

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