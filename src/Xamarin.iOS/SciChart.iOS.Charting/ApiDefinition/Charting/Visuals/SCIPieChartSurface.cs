using System;
using CoreGraphics;
using Foundation;
using UIKit;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieChartSurface : UIView<SCIInvalidatableElementProtocol>
    [BaseType(typeof(UIView))]
    interface SCIPieChartSurface : SCIInvalidatableElementProtocol
    {
        //@property(nonatomic, strong, nonnull) SCIPieRenderableSeriesCollection* renderableSeries;
        [Export("renderableSeries")]
        SCIPieRenderableSeriesCollection RenderableSeries { get; set; }

        //@property(nonatomic, strong, nonnull) SCIGestureController* gestureController;
        [Export("gestureController")]
        SCIGestureController GestureController { get; set; }

        //@property(nonatomic, strong, nonnull) SCIChartModifierCollection* chartModifiers;
        [Export("chartModifiers")]
        SCIChartModifierCollection ChartModifiers { get; set; }

        //@property(nonatomic, strong, nullable) SCIPieLayoutManager* layoutManager;
        [Export("layoutManager")]
        SCIPieLayoutManager LayoutManager { get; set; }

        //@property(nonatomic) float holeRadius;
        [Export("holeRadius")]
        float HoleRadius { get; set; }
        //@property(nonatomic) float seriesSpacing;
        [Export("seriesSpacing")]
        float SeriesSpacing { get; set; }
        //@property(nonatomic) float margin;
        [Export("margin")]
        float Margin { get; set; }
        //@property(nonatomic) float seriesMinimumHeight;
        [Export("seriesMinimumHeight")]
        float SeriesMinimumHeight { get; set; }

        // @required +(void)setRuntimeLicenseKey:(NSString * _Nonnull)licenseContract;
        [Static]
        [Export("setRuntimeLicenseKey:")]
        void SetRuntimeLicenseKey(string licenseContract);
    }
}
