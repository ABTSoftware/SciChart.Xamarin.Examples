using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILegendCell : UICollectionViewCell <ISCILegendCellProtocol>
    [BaseType(typeof(UICollectionViewCell))]
    interface SCILegendCell : SCILegendCellProtocol
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

        // -(void)setCustomStyleForCell:(SCILegendCellStyle *)style;
        [Export("setCustomStyleForCell:")]
        void SetCustomStyleForCell(SCILegendCellStyle style);

        // +(CGSize)preferredLayoutSizeFittingSize:(CGSize)size forItem:(SCILegendItem *)item withCustomStyle:(SCILegendCellStyle *)style;
        //[Static]
        //[Export("preferredLayoutSizeFittingSize:forItem:withCustomStyle:")]
        //CGSize PreferredLayoutSizeFittingSize(CGSize size, SCILegendItem item, SCILegendCellStyle style);
    }
}