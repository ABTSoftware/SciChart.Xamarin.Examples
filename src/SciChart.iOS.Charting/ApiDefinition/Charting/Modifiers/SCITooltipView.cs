using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITooltipView : UIView
    [BaseType(typeof(UIView))]
    interface SCITooltipView
    {
        // @property (nonatomic, weak) UIView * dataView __attribute__((iboutlet));
        [Export("dataView", ArgumentSemantic.Weak)]
        UIView DataView { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * dataViewWidth __attribute__((iboutlet));
        [Export("dataViewWidth", ArgumentSemantic.Weak)]
        NSLayoutConstraint DataViewWidth { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * dataViewHeight __attribute__((iboutlet));
        [Export("dataViewHeight", ArgumentSemantic.Weak)]
        NSLayoutConstraint DataViewHeight { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * dataViewLeftBorder __attribute__((iboutlet));
        [Export("dataViewLeftBorder", ArgumentSemantic.Weak)]
        NSLayoutConstraint DataViewLeftBorder { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * dataViewTopBorder __attribute__((iboutlet));
        [Export("dataViewTopBorder", ArgumentSemantic.Weak)]
        NSLayoutConstraint DataViewTopBorder { get; set; }

        // @property (nonatomic) CGSize fixedSize;
        [Export("fixedSize", ArgumentSemantic.Assign)]
        CGSize FixedSize { get; set; }

        // @property (nonatomic) float contentPadding;
        [Export("contentPadding")]
        float ContentPadding { get; set; }

        // -(void)addDataView:(SCITooltipDataView *)view;
        [Export("addDataView:")]
        void AddDataView(SCITooltipDataView view);

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();

        // +(SCITooltipView *)createInstance;
        [Static]
        [Export("createInstance")]
        SCITooltipView CreateInstance();
    }
}