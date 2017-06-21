using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILegendCellStyle : NSObject
    [BaseType(typeof(NSObject))]
    interface SCILegendCellStyle
    {
        // @property (nonatomic) UIFont * seriesNameFont;
        [Export("seriesNameFont", ArgumentSemantic.Assign)]
        UIFont SeriesNameFont { get; set; }

        // @property (nonatomic) UIColor * seriesNameTextColor;
        [Export("seriesNameTextColor", ArgumentSemantic.Assign)]
        UIColor SeriesNameTextColor { get; set; }

        // @property (nonatomic) UIImage * checkedBoxImage;
        [Export("checkedBoxImage", ArgumentSemantic.Assign)]
        UIImage CheckedBoxImage { get; set; }

        // @property (nonatomic) UIImage * uncheckedBoxImage;
        [Export("uncheckedBoxImage", ArgumentSemantic.Assign)]
        UIImage UncheckedBoxImage { get; set; }

        // @property (nonatomic) CGFloat borderWidthMarkerView;
        [Export("borderWidthMarkerView")]
        nfloat BorderWidthMarkerView { get; set; }

        // @property (nonatomic) UIColor * borderColorMarkerView;
        [Export("borderColorMarkerView", ArgumentSemantic.Assign)]
        UIColor BorderColorMarkerView { get; set; }

        // @property (nonatomic) CGFloat cornerRadiusMarkerView;
        [Export("cornerRadiusMarkerView")]
        nfloat CornerRadiusMarkerView { get; set; }

        // @property (nonatomic) CGSize sizeMarkerView;
        [Export("sizeMarkerView", ArgumentSemantic.Assign)]
        CGSize SizeMarkerView { get; set; }
    }
}