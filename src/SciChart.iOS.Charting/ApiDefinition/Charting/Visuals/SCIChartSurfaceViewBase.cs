using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIResizeAxesAreasRequest) (float left, float right, float top, float bottom);
    delegate void SCIResizeAxesAreasRequest(float left, float right, float top, float bottom);

    // @interface SCIChartSurfaceViewBase : UIView
    [BaseType(typeof(UIView))]
    interface SCIChartSurfaceViewBase
    {
        // @property (nonatomic, weak) id<SCIRenderSurfaceProtocol> renderSurface __attribute__((iboutlet));
        [Export("renderSurface", ArgumentSemantic.Weak)]
        SCIRenderSurfaceProtocol RenderSurface { get; set; }

        // @property (nonatomic, weak) UIView * renderSurfaceSizeView __attribute__((iboutlet));
        [Export("renderSurfaceSizeView", ArgumentSemantic.Weak)]
        UIView RenderSurfaceSizeView { get; set; }

        // @property (nonatomic, weak) SCIAxisArea * leftAxesArea __attribute__((iboutlet));
        [Export("leftAxesArea", ArgumentSemantic.Weak)]
        SCIAxisArea LeftAxesArea { get; set; }

        // @property (nonatomic, weak) SCIAxisArea * rightAxesArea __attribute__((iboutlet));
        [Export("rightAxesArea", ArgumentSemantic.Weak)]
        SCIAxisArea RightAxesArea { get; set; }

        // @property (nonatomic, weak) SCIAxisArea * topAxesArea __attribute__((iboutlet));
        [Export("topAxesArea", ArgumentSemantic.Weak)]
        SCIAxisArea TopAxesArea { get; set; }

        // @property (nonatomic, weak) SCIAxisArea * bottomAxesArea __attribute__((iboutlet));
        [Export("bottomAxesArea", ArgumentSemantic.Weak)]
        SCIAxisArea BottomAxesArea { get; set; }

        // @property (nonatomic, weak) UILabel * chartTitleLabel __attribute__((iboutlet));
        [Export("chartTitleLabel", ArgumentSemantic.Weak)]
        UILabel ChartTitleLabel { get; set; }

        // @property (nonatomic, weak) UIView * chartTitleHolderView __attribute__((iboutlet));
        [Export("chartTitleHolderView", ArgumentSemantic.Weak)]
        UIView ChartTitleHolderView { get; set; }

        // @property (nonatomic) float leftAxisAreaSize;
        [Export("leftAxisAreaSize")]
        float LeftAxisAreaSize { get; set; }

        // @property (nonatomic) float rightAxisAreaSize;
        [Export("rightAxisAreaSize")]
        float RightAxisAreaSize { get; set; }

        // @property (nonatomic) float topAxisAreaSize;
        [Export("topAxisAreaSize")]
        float TopAxisAreaSize { get; set; }

        // @property (nonatomic) float bottomAxisAreaSize;
        [Export("bottomAxisAreaSize")]
        float BottomAxisAreaSize { get; set; }

        // @property (nonatomic) float leftAxisAreaForcedSize;
        [Export("leftAxisAreaForcedSize")]
        float LeftAxisAreaForcedSize { get; set; }

        // @property (nonatomic) float rightAxisAreaForcedSize;
        [Export("rightAxisAreaForcedSize")]
        float RightAxisAreaForcedSize { get; set; }

        // @property (nonatomic) float topAxisAreaForcedSize;
        [Export("topAxisAreaForcedSize")]
        float TopAxisAreaForcedSize { get; set; }

        // @property (nonatomic) float bottomAxisAreaForcedSize;
        [Export("bottomAxisAreaForcedSize")]
        float BottomAxisAreaForcedSize { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * leftPanelSize __attribute__((iboutlet));
        [Export("leftPanelSize", ArgumentSemantic.Weak)]
        NSLayoutConstraint LeftPanelSize { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * leftPanelSizeLimit __attribute__((iboutlet));
        [Export("leftPanelSizeLimit", ArgumentSemantic.Weak)]
        NSLayoutConstraint LeftPanelSizeLimit { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * rightPanelSize __attribute__((iboutlet));
        [Export("rightPanelSize", ArgumentSemantic.Weak)]
        NSLayoutConstraint RightPanelSize { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * rightPanelSizeLimit __attribute__((iboutlet));
        [Export("rightPanelSizeLimit", ArgumentSemantic.Weak)]
        NSLayoutConstraint RightPanelSizeLimit { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * topPanelSize __attribute__((iboutlet));
        [Export("topPanelSize", ArgumentSemantic.Weak)]
        NSLayoutConstraint TopPanelSize { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * topPanelSizeLimit __attribute__((iboutlet));
        [Export("topPanelSizeLimit", ArgumentSemantic.Weak)]
        NSLayoutConstraint TopPanelSizeLimit { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * bottomPanelSize __attribute__((iboutlet));
        [Export("bottomPanelSize", ArgumentSemantic.Weak)]
        NSLayoutConstraint BottomPanelSize { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * bottomPanelSizeLimit __attribute__((iboutlet));
        [Export("bottomPanelSizeLimit", ArgumentSemantic.Weak)]
        NSLayoutConstraint BottomPanelSizeLimit { get; set; }

        // -(void)setChartTitleLabelInsets:(UIEdgeInsets)chartTitleLabelInsets;
        [Export("setChartTitleLabelInsets:")]
        void SetChartTitleLabelInsets(UIEdgeInsets chartTitleLabelInsets);
    }
}