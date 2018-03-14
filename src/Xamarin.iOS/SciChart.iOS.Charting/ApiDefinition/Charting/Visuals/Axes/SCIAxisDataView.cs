using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisDataView : SCITooltipDataView
    [BaseType(typeof(SCITooltipDataView))]
    interface SCIAxisDataView
    {
        // @property (nonatomic) NSNumberFormatter * formatter;
        [Export("formatter", ArgumentSemantic.Assign)]
        NSNumberFormatter Formatter { get; set; }

        // @property (nonatomic, weak) UILabel * dataLabel __attribute__((iboutlet));
        [Export("dataLabel", ArgumentSemantic.Weak)]
        UILabel DataLabel { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * heightConstraint __attribute__((iboutlet));
        [Export("heightConstraint", ArgumentSemantic.Weak)]
        NSLayoutConstraint HeightConstraint { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * widthConstraint __attribute__((iboutlet));
        [Export("widthConstraint", ArgumentSemantic.Weak)]
        NSLayoutConstraint WidthConstraint { get; set; }

        // -(void)setData:(SCIAxisInfo *)data;
        [Export("setData:")]
        void SetData(SCIAxisInfo data);

        // +(SCIAxisDataView *)createInstance;
        [Static]
        [Export("createInstance")]
        SCIAxisDataView CreateInstance();
    }
}