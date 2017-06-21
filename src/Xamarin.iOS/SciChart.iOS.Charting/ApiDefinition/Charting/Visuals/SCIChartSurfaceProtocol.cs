using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIChartSurfaceProtocol { }

    // @protocol SCIChartSurfaceProtocol <NSObject, SCIInvalidatableElementProtocol, SCIThemeableProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIChartSurfaceProtocol : SCIInvalidatableElementProtocol, SCIThemeableProtocol
    {
        // @required @property (nonatomic, strong) SCIPenStyle * _Nonnull renderableSeriesAreaBorder;
        [Abstract]
        [Export("renderableSeriesAreaBorder", ArgumentSemantic.Strong)]
        SCIPenStyle RenderableSeriesAreaBorder { get; set; }

        // @required @property (nonatomic, strong) SCIBrushStyle * _Nonnull renderableSeriesAreaFill;
        [Abstract]
        [Export("renderableSeriesAreaFill", ArgumentSemantic.Strong)]
        SCIBrushStyle RenderableSeriesAreaFill { get; set; }

        // @required @property (nonatomic, strong) SCIChartModifierCollection * _Nonnull chartModifiers;
        [Abstract]
        [Export("chartModifiers", ArgumentSemantic.Strong)]
        SCIChartModifierCollection ChartModifiers { get; set; }

        // @required @property (nonatomic, strong) SCIAnnotationCollection * _Nonnull annotations;
        [Abstract]
        [Export("annotations", ArgumentSemantic.Strong)]
        SCIAnnotationCollection Annotations { get; set; }

        // @required @property (nonatomic, strong) SCIAxisCollection * _Nonnull xAxes;
        [Abstract]
        [Export("xAxes", ArgumentSemantic.Strong)]
        SCIAxisCollection XAxes { get; set; }

        // @required @property (nonatomic, strong) SCIAxisCollection * _Nonnull yAxes;
        [Abstract]
        [Export("yAxes", ArgumentSemantic.Strong)]
        SCIAxisCollection YAxes { get; set; }

        // @required @property (nonatomic, strong) SCIRenderableSeriesCollection * _Nonnull renderableSeries;
        [Abstract]
        [Export("renderableSeries", ArgumentSemantic.Strong)]
        SCIRenderableSeriesCollection RenderableSeries { get; set; }

        // @required @property (readonly, nonatomic, strong) SCIRenderableSeriesCollection * _Nonnull selectedRenderableSeries;
        [Abstract]
        [Export("selectedRenderableSeries", ArgumentSemantic.Strong)]
        SCIRenderableSeriesCollection SelectedRenderableSeries { get; }

        // @required @property (nonatomic, strong) id<SCIViewportManagerProtocol> _Nonnull viewportManager;
        [Abstract]
        [Export("viewportManager", ArgumentSemantic.Strong)]
        SCIViewportManagerProtocol ViewportManager { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable chartTitle;
        [Abstract]
        [NullAllowed, Export("chartTitle")]
        string ChartTitle { get; set; }

        // @required @property (nonatomic) UIFont * _Nullable chartTitleFont;
        [Abstract]
        [NullAllowed, Export("chartTitleFont", ArgumentSemantic.Assign)]
        UIFont ChartTitleFont { get; set; }

        // @required @property (nonatomic) UIColor * _Nullable chartTitleColor;
        [Abstract]
        [NullAllowed, Export("chartTitleColor", ArgumentSemantic.Assign)]
        UIColor ChartTitleColor { get; set; }

        // @required @property (nonatomic) NSTextAlignment chartTitleAlignment;
        [Abstract]
        [Export("chartTitleAlignment", ArgumentSemantic.Assign)]
        UITextAlignment ChartTitleAlignment { get; set; }

        // @required -(void)setChartTitleLabelInsets:(UIEdgeInsets)chartTitleLabelInsets;
        [Abstract]
        [Export("setChartTitleLabelInsets:")]
        void SetChartTitleLabelInsets(UIEdgeInsets chartTitleLabelInsets);

        // @required @property (nonatomic, weak) UIView * _Nullable chartTitleView;
        [Abstract]
        [NullAllowed, Export("chartTitleView", ArgumentSemantic.Weak)]
        UIView ChartTitleView { get; set; }

        // @required @property (nonatomic, weak) id<SCIRenderSurfaceProtocol> _Nullable renderSurface;
        [Abstract]
        [NullAllowed, Export("renderSurface", ArgumentSemantic.Weak)]
        SCIRenderSurfaceProtocol RenderSurface { get; set; }

        // @required -(UIImage * _Nonnull)exportToUIImage;
        [Abstract]
        [Export("exportToUIImage")]
        UIImage ExportToUIImage { get; }

        // @required +(void)setRuntimeLicenseKey:(NSString * _Nonnull)licenseContract;
        [Static]
        [Export("setRuntimeLicenseKey:")]
        void SetRuntimeLicenseKey(string licenseContract);
    }
}