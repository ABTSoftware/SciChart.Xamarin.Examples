using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCILegendCell : UICollectionViewCell <SCILegendCellProtocol>
    [BaseType(typeof(UIView))]
    interface SCILegendItemView : SCILegendItemViewProtocol
    {
        // @property (nonatomic, weak) UIButton * checkBoxButton __attribute__((iboutlet));
        [Export("checkBoxButton", ArgumentSemantic.Weak)]
        UIButton CheckBoxButton { get; set; }

        // @property (nonatomic, weak) UIView * markerView __attribute__((iboutlet));
        [Export("markerView", ArgumentSemantic.Weak)]
        UIView MarkerView { get; set; }

        // @property (nonatomic, weak) UILabel * seriesNameLabel __attribute__((iboutlet));
        [Export("seriesNameLabel", ArgumentSemantic.Weak)]
        UILabel SeriesNameLabel { get; set; }
    }
}