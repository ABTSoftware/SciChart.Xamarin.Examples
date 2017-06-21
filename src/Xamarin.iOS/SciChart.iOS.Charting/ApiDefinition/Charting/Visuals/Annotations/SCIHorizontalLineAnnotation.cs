using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
	// @interface SCIHorizontalLineAnnotation : SCILineAnnotation
	[BaseType(typeof(SCILineAnnotation))]
    interface SCIHorizontalLineAnnotation
    {
        // @property (nonatomic, copy) NSString * formattedValue;
        [Export("formattedValue")]
        string FormattedValue { get; set; }

        // Bounded in Extras
        // -(NSString *) formatValue:(SCIGenericType)value;

        // Bounded in Extras
        // @property(nonatomic) SCIGenericType x1;

        // Bounded in Extras
        // @property(nonatomic) SCIGenericType y1;

        // -(void) addLabel:(SCILineAnnotationLabel*)label;
        [Export("addLabel:", ArgumentSemantic.Copy)]
        void AddLabel(SCILineAnnotationLabel label);
        
        // -(void) removeLabel:(SCILineAnnotationLabel*)label;
        [Export("removeLabel:", ArgumentSemantic.Copy)]
        void RemoveLabel(SCILineAnnotationLabel label);

        // -(SCILineAnnotationLabel*) labelAt:(int)index;
        [Export("labelAt:", ArgumentSemantic.Copy)]
        SCILineAnnotationLabel LabelAt(int index);

        // -(void) removeLabelAt:(int)index;
        [Export("removeLabelAt:", ArgumentSemantic.Copy)]
        void RemoveLabelAt(int index);

        // @property(nonatomic, copy) SCIHorizontalLineAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIHorizontalLineAnnotationStyle Style { get; set; }
    }
}