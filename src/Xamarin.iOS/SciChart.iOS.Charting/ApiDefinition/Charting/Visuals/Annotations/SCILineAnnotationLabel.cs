using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCILineAnnotationLabel : UILabel
    [BaseType(typeof(UILabel))]
    interface SCILineAnnotationLabel
    {
        // @property (copy, nonatomic) SCIAnnotationLabelStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIAnnotationLabelStyle Style { get; set; }

        // @property (nonatomic) BOOL isHidden;
        [Export("isHidden")]
        bool IsHidden { get; set; }

        // -(void)applyStyle;
        [Export("applyStyle")]
        void ApplyStyle();
    }
}