using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIThemeProviderProtocol { }

    // @protocol SCIThemeProviderProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIThemeProviderProtocol
    {
        // @required @property (readonly, nonatomic) float majorTickLinesLength;
        [Abstract]
        [Export("majorTickLinesLength")]
        float MajorTickLinesLength { get; }

        // @required @property (readonly, nonatomic) float minorTickLinesLength;
        [Abstract]
        [Export("minorTickLinesLength")]
        float MinorTickLinesLength { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * renderableSeriesAreaFillStyle;
        [Abstract]
        [Export("renderableSeriesAreaFillStyle")]
        SCIBrushStyle RenderableSeriesAreaFillStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * renderableSeriesAreaBorderStyle;
        [Abstract]
        [Export("renderableSeriesAreaBorderStyle")]
        SCIPenStyle RenderableSeriesAreaBorderStyle { get; }

        // @required @property (readonly, nonatomic) SCITextFormattingStyle * tickTextStyle;
        [Abstract]
        [Export("tickTextStyle")]
        SCITextFormattingStyle TickTextStyle { get; }

        // @required @property (readonly, nonatomic) SCITextFormattingStyle * axisTitleTextStyle;
        [Abstract]
        [Export("axisTitleTextStyle")]
        SCITextFormattingStyle AxisTitleTextStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * majorGridLinesStyle;
        [Abstract]
        [Export("majorGridLinesStyle")]
        SCIPenStyle MajorGridLinesStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * minorGridLinesStyle;
        [Abstract]
        [Export("minorGridLinesStyle")]
        SCIPenStyle MinorGridLinesStyle { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * axisBandsStyle;
        [Abstract]
        [Export("axisBandsStyle")]
        SCIBrushStyle AxisBandsStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * rolloverLineStyle;
        [Abstract]
        [Export("rolloverLineStyle")]
        SCIPenStyle RolloverLineStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * crossPointerLineStyle;
        [Abstract]
        [Export("crossPointerLineStyle")]
        SCIPenStyle CrossPointerLineStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * cursorLineStyle;
        [Abstract]
        [Export("cursorLineStyle")]
        SCIPenStyle CursorLineStyle { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * rubberBandFillStyle;
        [Abstract]
        [Export("rubberBandFillStyle")]
        SCIBrushStyle RubberBandFillStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * rubberBandStrokeStyle;
        [Abstract]
        [Export("rubberBandStrokeStyle")]
        SCIPenStyle RubberBandStrokeStyle { get; }

        // @required @property (readonly, nonatomic) SCITextFormattingStyle * defaultAxisMarkerAnnotationStyle;
        [Abstract]
        [Export("defaultAxisMarkerAnnotationStyle")]
        SCITextFormattingStyle DefaultAxisMarkerAnnotationStyle { get; }

        // @required @property (readonly, nonatomic) SCITextFormattingStyle * axisTooltipTextStyle;
        [Abstract]
        [Export("axisTooltipTextStyle")]
        SCITextFormattingStyle AxisTooltipTextStyle { get; }

        // @required @property (readonly, nonatomic) SCITextFormattingStyle * defaultLabelTextStyle;
        [Abstract]
        [Export("defaultLabelTextStyle")]
        SCITextFormattingStyle DefaultLabelTextStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultLineSeriesColor;
        [Abstract]
        [Export("defaultLineSeriesColor")]
        SCIPenStyle DefaultLineSeriesColor { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * defaultMountainFillColor;
        [Abstract]
        [Export("defaultMountainFillColor")]
        SCIBrushStyle DefaultMountainFillColor { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultMountainLineColor;
        [Abstract]
        [Export("defaultMountainLineColor")]
        SCIPenStyle DefaultMountainLineColor { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * defaultColumnFillStyle;
        [Abstract]
        [Export("defaultColumnFillStyle")]
        SCIBrushStyle DefaultColumnFillStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultColumnLineStyle;
        [Abstract]
        [Export("defaultColumnLineStyle")]
        SCIPenStyle DefaultColumnLineStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultCandleStrokeUpStyle;
        [Abstract]
        [Export("defaultCandleStrokeUpStyle")]
        SCIPenStyle DefaultCandleStrokeUpStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultCandleStrokeDownStyle;
        [Abstract]
        [Export("defaultCandleStrokeDownStyle")]
        SCIPenStyle DefaultCandleStrokeDownStyle { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * defaultCandleFillUpStyle;
        [Abstract]
        [Export("defaultCandleFillUpStyle")]
        SCIBrushStyle DefaultCandleFillUpStyle { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * defaultCandleFillDownStyle;
        [Abstract]
        [Export("defaultCandleFillDownStyle")]
        SCIBrushStyle DefaultCandleFillDownStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultUpBandLineStyle;
        [Abstract]
        [Export("defaultUpBandLineStyle")]
        SCIPenStyle DefaultUpBandLineStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultDownBandLineStyle;
        [Abstract]
        [Export("defaultDownBandLineStyle")]
        SCIPenStyle DefaultDownBandLineStyle { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * defaultUpBandFillStyle;
        [Abstract]
        [Export("defaultUpBandFillStyle")]
        SCIBrushStyle DefaultUpBandFillStyle { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * defaultDownBandFillStyle;
        [Abstract]
        [Export("defaultDownBandFillStyle")]
        SCIBrushStyle DefaultDownBandFillStyle { get; }

        // @required @property (readonly, nonatomic) SCIPenStyle * defaultLineAnnotationStyle;
        [Abstract]
        [Export("defaultLineAnnotationStyle")]
        SCIPenStyle DefaultLineAnnotationStyle { get; }

        // @required @property (readonly, nonatomic) SCITextFormattingStyle * defaultTextAnnotationStyle;
        [Abstract]
        [Export("defaultTextAnnotationStyle")]
        SCITextFormattingStyle DefaultTextAnnotationStyle { get; }

        // @required @property (readonly, nonatomic) SCIBrushStyle * defaultTextAnnotationBackgroundStyle;
        [Abstract]
        [Export("defaultTextAnnotationBackgroundStyle")]
        SCIBrushStyle DefaultTextAnnotationBackgroundStyle { get; }

        // @required @property (readonly, nonatomic) id<SCIPointMarkerProtocol> defaultAnnotationGrip;
        [Abstract]
        [Export("defaultAnnotationGrip")]
        SCIPointMarkerProtocol DefaultAnnotationGrip { get; }

        // @required @property (readonly, nonatomic) NSDictionary * sciChartSurfaceBackground;
        [Abstract]
        [Export("sciChartSurfaceBackground")]
        NSDictionary SciChartSurfaceBackground { get; }

        // @required @property (readonly, nonatomic) NSDictionary * legendBackground;
        [Abstract]
        [Export("legendBackground")]
        NSDictionary LegendBackground { get; }

        // @required @property (readonly, nonatomic) NSDictionary * labelBackground;
        [Abstract]
        [Export("labelBackground")]
        NSDictionary LabelBackground { get; }

        // @required @property (readonly, nonatomic) NSDictionary * axisTooltipBackground;
        [Abstract]
        [Export("axisTooltipBackground")]
        NSDictionary AxisTooltipBackground { get; }
    }
}