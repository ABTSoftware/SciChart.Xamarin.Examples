using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIDefaultTickLabel : UILabel <SCITickLabelProtocol>
    [BaseType(typeof(UILabel))]
    interface SCIDefaultTickLabel : SCITickLabelProtocol
    {
        // @property (nonatomic) int cullingPriority;
        [Export("cullingPriority")]
        int CullingPriority { get; set; }

        // @property (nonatomic) CGPoint position;
        [Export("position", ArgumentSemantic.Assign)]
        CGPoint Position { get; set; }

        // -(BOOL)hasIntersectionWithNext:(UIView *)other;
        [Export("hasIntersectionWithNext:")]
        bool HasIntersectionWithNext(UIView other);

        // -(BOOL)fitsInArea:(CGRect)area;
        [Export("fitsInArea:")]
        bool FitsInArea(CGRect area);
    }
}