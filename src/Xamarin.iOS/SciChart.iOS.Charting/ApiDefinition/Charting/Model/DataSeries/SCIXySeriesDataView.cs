using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIXySeriesDataView
    [BaseType(typeof(NSObject))]
    interface SCIXySeriesDataView
    {
        // -(void)setData:(SCISeriesInfo *)data;
        [Export("setData:")]
        void SetData(SCISeriesInfo data);

        // @property (nonatomic, weak) UILabel * nameLabel __attribute__((iboutlet));
        [Export("nameLabel", ArgumentSemantic.Weak)]
        UILabel NameLabel { get; set; }

        // @property (nonatomic, weak) UILabel * dataLabel __attribute__((iboutlet));
        [Export("dataLabel", ArgumentSemantic.Weak)]
        UILabel DataLabel { get; set; }

        // +(SCITooltipDataView *)createInstance;
        [Static]
        [Export("createInstance")]
        SCITooltipDataView CreateInstance { get; }

        // @property (nonatomic, weak) NSLayoutConstraint * nameHeightConstraint __attribute__((iboutlet));
        [Export("nameHeightConstraint", ArgumentSemantic.Weak)]
        NSLayoutConstraint NameHeightConstraint { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * nameWidthConstraint __attribute__((iboutlet));
        [Export("nameWidthConstraint", ArgumentSemantic.Weak)]
        NSLayoutConstraint NameWidthConstraint { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * dataHeightConstraint __attribute__((iboutlet));
        [Export("dataHeightConstraint", ArgumentSemantic.Weak)]
        NSLayoutConstraint DataHeightConstraint { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * dataWidthConstraint __attribute__((iboutlet));
        [Export("dataWidthConstraint", ArgumentSemantic.Weak)]
        NSLayoutConstraint DataWidthConstraint { get; set; }
    }
}