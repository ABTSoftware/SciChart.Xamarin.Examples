using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIThemeProviderProtocol { }

    // @protocol SCIThemeProviderProtocol<NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIThemeProviderProtocol
    {
        //  ChartSurface Theme  //

        // @property(nonatomic) UIFont* chartTitleFont;
        [Abstract]
        [Export("chartTitleFont")]
        UIFont ChartTitleFont { get; set; }

        //@property(nonatomic) UIColor* chartTitleColor;
        [Abstract]
        [Export("chartTitleColor")]
        UIColor ChartTitleColor { get; set; }

        //@property(nonatomic) SCIBrushStyle* backgroundBrush;
        [Abstract]
        [Export("backgroundBrush")]
        SCIBrushStyle BackgroundBrush { get; set; }

        //@property(nonatomic) SCIPenStyle* borderPen;
        [Abstract]
        [Export("borderPen")]
        SCIPenStyle BorderPen { get; set; }

        //@property(nonatomic) SCIBrushStyle* seriesBackgroundBrush;
        [Abstract]
        [Export("seriesBackgroundBrush")]
        SCIBrushStyle SeriesBackgroundBrush { get; set; }


        //  RenderableSeries Theme  //

        //@property(nonatomic) SCIPenStyle* errorBarsLinePenStyle;
        [Abstract]
        [Export("errorBarsLinePenStyle")]
        SCIPenStyle ErrorBarsLinePenStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* errorBarsHighPenStyle;
        [Abstract]
        [Export("errorBarsHighPenStyle")]
        SCIPenStyle ErrorBarsHighPenStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* errorBarsLowPenStyle;
        [Abstract]
        [Export("errorBarsLowPenStyle")]
        SCIPenStyle ErrorBarsLowPenStyle { get; set; }

        //@property(nonatomic) SCIBrushStyle* bubbleBrushStyle;
        [Abstract]
        [Export("bubbleBrushStyle")]
        SCIBrushStyle BubbleBrushStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* bubblePenBorderStyle;
        [Abstract]
        [Export("bubblePenBorderStyle")]
        SCIPenStyle BubblePenBorderStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* impulseLinePenStyle;
        [Abstract]
        [Export("impulseLinePenStyle")]
        SCIPenStyle ImpulseLinePenStyle { get; set; }

        //@property(nonatomic) SCIBrushStyle* mountainAreaBrushStyle;
        [Abstract]
        [Export("mountainAreaBrushStyle")]
        SCIBrushStyle MountainAreaBrushStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* mountainBorderPenStyle;
        [Abstract]
        [Export("mountainBorderPenStyle")]
        SCIPenStyle MountainBorderPenStyle { get; set; }

        //@property(nonatomic) SCIBrushStyle* stackedMountainAreaBrushStyle;
        [Abstract]
        [Export("stackedMountainAreaBrushStyle")]
        SCIBrushStyle StackedMountainAreaBrushStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* stackedMountainBorderPenStyle;
        [Abstract]
        [Export("stackedMountainBorderPenStyle")]
        SCIPenStyle StackedMountainBorderPenStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* stackedColumnBorderPenStyle;
        [Abstract]
        [Export("stackedColumnBorderPenStyle")]
        SCIPenStyle StackedColumnBorderPenStyle { get; set; }

        //@property(nonatomic) SCIBrushStyle* stackedColumnFillBrushStyle;
        [Abstract]
        [Export("stackedColumnFillBrushStyle")]
        SCIBrushStyle StackedColumnFillBrushStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* columnBorderPenStyle;
        [Abstract]
        [Export("columnBorderPenStyle")]
        SCIPenStyle ColumnBorderPenStyle { get; set; }

        //@property(nonatomic) SCIBrushStyle* columnFillBrushStyle;
        [Abstract]
        [Export("columnFillBrushStyle")]
        SCIBrushStyle ColumnFillBrushStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* bandPen1Style;
        [Abstract]
        [Export("bandPen1Style")]
        SCIPenStyle BandPen1Style { get; set; }

        //@property(nonatomic) SCIPenStyle* bandPen2Style;
        [Abstract]
        [Export("bandPen2Style")]
        SCIPenStyle BandPen2Style { get; set; }

        //@property(nonatomic) SCIBrushStyle* bandBrush1Style;
        [Abstract]
        [Export("bandBrush1Style")]
        SCIBrushStyle BandBrush1Style { get; set; }

        //@property(nonatomic) SCIBrushStyle* bandBrush2Style;
        [Abstract]
        [Export("bandBrush2Style")]
        SCIBrushStyle BandBrush2Style { get; set; }

        //@property(nonatomic) SCIPenStyle* linePenStyle;
        [Abstract]
        [Export("linePenStyle")]
        SCIPenStyle LinePenStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* ohlcUpWickPenStyle;
        [Abstract]
        [Export("ohlcUpWickPenStyle")]
        SCIPenStyle OhlcUpWickPenStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* ohlcDownWickPenStyle;
        [Abstract]
        [Export("ohlcDownWickPenStyle")]
        SCIPenStyle OhlcDownWickPenStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* candleUpWickPen;
        [Abstract]
        [Export("candleUpWickPen")]
        SCIPenStyle CandleUpWickPen { get; set; }

        //@property(nonatomic) SCIPenStyle* candleDownWickPen;
        [Abstract]
        [Export("candleDownWickPen")]
        SCIPenStyle CandleDownWickPen { get; set; }

        //@property(nonatomic) SCIBrushStyle* candleUpBodyBrush;
        [Abstract]
        [Export("candleUpBodyBrush")]
        SCIPenStyle CandleUpBodyBrush { get; set; }

        //@property(nonatomic) SCIBrushStyle* candleDownBodyBrush;
        [Abstract]
        [Export("candleDownBodyBrush")]
        SCIPenStyle CandleDownBodyBrush { get; set; }


        //  Axis Theme  //

        //@property(nonatomic) SCITextFormattingStyle* axisTickLabelStyle;
        [Abstract]
        [Export("axisTickLabelStyle")]
        SCITextFormattingStyle AxisTickLabelStyle { get; set; }

        //@property(nonatomic) SCITextFormattingStyle* axisTitleLabelStyle;
        [Abstract]
        [Export("axisTitleLabelStyle")]
        SCITextFormattingStyle AxisTitleLabelStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* axisMajorGridLineBrush;
        [Abstract]
        [Export("axisMajorGridLineBrush")]
        SCIPenStyle AxisMajorGridLineBrush { get; set; }

        //@property(nonatomic) SCIPenStyle* axisMinorGridLineBrush;
        [Abstract]
        [Export("axisMinorGridLineBrush")]
        SCIPenStyle AxisMinorGridLineBrush { get; set; }

        //@property(nonatomic) SCIBrushStyle* axisGridBandBrush;
        [Abstract]
        [Export("axisGridBandBrush")]
        SCIBrushStyle AxisGridBandBrush { get; set; }

        //@property(nonatomic) CGFloat axisMinorTickSize;
        [Abstract]
        [Export("axisMinorTickSize")]
        float AxisMinorTickSize { get; set; }

        //@property(nonatomic) CGFloat axisMajorTickSize;
        [Abstract]
        [Export("axisMajorTickSize")]
        float AxisMajorTickSize { get; set; }


        //  Annotation Theme  //

        //@property(nonatomic) SCIPenStyle* annotationLinePenStyle;
        [Abstract]
        [Export("annotationLinePenStyle")]
        SCIPenStyle AnnotationLinePenStyle { get; set; }

        //@property(nonatomic) id<SCIPointMarkerProtocol> annotationLineResizeMarker;
        [Abstract]
        [Export("annotationLineResizeMarker")]
        SCIPointMarkerProtocol AnnotationLineResizeMarker { get; set; }

        //@property(nonatomic) SCITextFormattingStyle* annotationTextStyle;
        [Abstract]
        [Export("annotationTextStyle")]
        SCITextFormattingStyle AnnotationTextStyle { get; set; }

        //@property(nonatomic) UIColor* annotationTextBackgroundColor;
        [Abstract]
        [Export("annotationTextBackgroundColor")]
        UIColor AnnotationTextBackgroundColor { get; set; }

        //@property(nonatomic) id<SCIPointMarkerProtocol> annotationBoxPointMarkerStyle;
        [Abstract]
        [Export("annotationBoxPointMarkerStyle")]
        SCIPointMarkerProtocol AnnotationBoxPointMarkerStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* annotationBoxBorderPenStyle;
        [Abstract]
        [Export("annotationBoxBorderPenStyle")]
        SCIPenStyle AnnotationBoxBorderPenStyle { get; set; }

        //@property(nonatomic) SCIBrushStyle* annotationBoxFillBrushStyle;
        [Abstract]
        [Export("annotationBoxFillBrushStyle")]
        SCIBrushStyle AnnotationBoxFillBrushStyle { get; set; }

        //@property(nonatomic) SCITextFormattingStyle* annotationAxisMarkerTextStyle;
        [Abstract]
        [Export("annotationAxisMarkerTextStyle")]
        SCITextFormattingStyle AnnotationAxisMarkerTextStyle { get; set; }

        //@property(nonatomic) SCIPenStyle* annotationAxisMarkerLineStyle;
        [Abstract]
        [Export("annotationAxisMarkerLineStyle")]
        SCIPenStyle AnnotationAxisMarkerLineStyle { get; set; }

        //@property(nonatomic) UIColor* annotationAxisMarkerBackgroundColor;
        [Abstract]
        [Export("annotationAxisMarkerBackgroundColor")]
        UIColor AnnotationAxisMarkerBackgroundColor { get; set; }

        //@property(nonatomic) UIColor* annotationAxisMarkerBorderColor;
        [Abstract]
        [Export("annotationAxisMarkerBorderColor")]
        UIColor AnnotationAxisMarkerBorderColor { get; set; }


        //  Modifier Theme  //

        //@property(nonatomic) SCITooltipModifierStyle* modifierTooltipStyle;
        [Abstract]
        [Export("modifierTooltipStyle")]
        SCITooltipModifierStyle ModifierTooltipStyle { get; set; }

        //@property(nonatomic) SCICursorModifierStyle* modifierCursorStyle;
        [Abstract]
        [Export("modifierCursorStyle")]
        SCICursorModifierStyle ModifierCursorStyle { get; set; }

        //@property(nonatomic) SCIRolloverModifierStyle* modifierRolloverStyle;
        [Abstract]
        [Export("modifierRolloverStyle")]
        SCIRolloverModifierStyle ModifierRolloverStyle { get; set; }

        //@property(nonatomic) UIColor* modifierLegendBackgroundColor;
        [Abstract]
        [Export("modifierLegendBackgroundColor")]
        UIColor ModifierLegendBackgroundColor { get; set; }

        //@property(nonatomic) UIColor* modifierLegendBorderColor;
        [Abstract]
        [Export("modifierLegendBorderColor")]
        UIColor ModifierLegendBorderColor { get; set; }

        //@property(nonatomic) float modifierLegendBorderWidth;
        [Abstract]
        [Export("modifierLegendBorderWidth")]
        float ModifierLegendBorderWidth { get; set; }

        //@property(nonatomic) SCILegendCellStyle* modifierLegendCellStyle;
        [Abstract]
        [Export("modifierLegendCellStyle")]
        SCILegendCellStyle ModifierLegendCellStyle { get; set; }
    }
}