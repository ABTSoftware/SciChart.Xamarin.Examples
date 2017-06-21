using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIThemeProviderProtocolTests
    {
        [Test]
        public void TestBindings()
        {
            // TODO:
            //[Export("chartTitleFont")]
            //UIFont ChartTitleFont { get; set; }
            //[Export("chartTitleColor")]
            //UIColor ChartTitleColor { get; set; }
            //[Export("backgroundBrush")]
            //SCIBrushStyle BackgroundBrush { get; set; }
            //[Export("borderPen")]
            //SCIPenStyle BorderPen { get; set; }
            //[Export("seriesBackgroundBrush")]
            //SCIBrushStyle SeriesBackgroundBrush { get; set; }

            ////  RenderableSeries Theme  //
            //[Export("errorBarsLinePenStyle")]
            //SCIPenStyle ErrorBarsLinePenStyle { get; set; }
            //[Export("errorBarsHighPenStyle")]
            //SCIPenStyle ErrorBarsHighPenStyle { get; set; }
            //[Export("errorBarsLowPenStyle")]
            //SCIPenStyle ErrorBarsLowPenStyle { get; set; }
            //[Export("bubbleBrushStyle")]
            //SCIBrushStyle BubbleBrushStyle { get; set; }
            //[Export("bubblePenBorderStyle")]
            //SCIPenStyle BubblePenBorderStyle { get; set; }
            //[Export("impulseLinePenStyle")]
            //SCIPenStyle ImpulseLinePenStyle { get; set; }
            //[Export("mountainAreaBrushStyle")]
            //SCIBrushStyle MountainAreaBrushStyle { get; set; }
            //[Export("mountainBorderPenStyle")]
            //SCIPenStyle MountainBorderPenStyle { get; set; }
            //[Export("stackedMountainAreaBrushStyle")]
            //SCIBrushStyle StackedMountainAreaBrushStyle { get; set; }
            //[Export("stackedMountainBorderPenStyle")]
            //SCIPenStyle StackedMountainBorderPenStyle { get; set; }
            //[Export("stackedColumnBorderPenStyle")]
            //SCIPenStyle StackedColumnBorderPenStyle { get; set; }
            //[Export("stackedColumnFillBrushStyle")]
            //SCIBrushStyle StackedColumnFillBrushStyle { get; set; }
            //[Export("columnBorderPenStyle")]
            //SCIPenStyle ColumnBorderPenStyle { get; set; }
            //[Export("columnFillBrushStyle")]
            //SCIBrushStyle ColumnFillBrushStyle { get; set; }
            //[Export("bandPen1Style")]
            //SCIPenStyle BandPen1Style { get; set; }
            //[Export("bandPen2Style")]
            //SCIPenStyle BandPen2Style { get; set; }
            //[Export("bandBrush1Style")]
            //SCIBrushStyle BandBrush1Style { get; set; }
            //[Export("bandBrush2Style")]
            //SCIBrushStyle BandBrush2Style { get; set; }
            //[Export("linePenStyle")]
            //SCIPenStyle LinePenStyle { get; set; }
            //[Export("ohlcUpWickPenStyle")]
            //SCIPenStyle OhlcUpWickPenStyle { get; set; }
            //[Export("ohlcDownWickPenStyle")]
            //SCIPenStyle OhlcDownWickPenStyle { get; set; }
            //[Export("candleUpWickPen")]
            //SCIPenStyle CandleUpWickPen { get; set; }
            //[Export("candleDownWickPen")]
            //SCIPenStyle CandleDownWickPen { get; set; }
            //[Export("candleUpBodyBrush")]
            //SCIPenStyle CandleUpBodyBrush { get; set; }
            //[Export("candleDownBodyBrush")]
            //SCIPenStyle CandleDownBodyBrush { get; set; }

            ////  Axis Theme  //
            //[Export("axisTickLabelStyle")]
            //SCITextFormattingStyle AxisTickLabelStyle { get; set; }
            //[Export("axisTitleLabelStyle")]
            //SCITextFormattingStyle AxisTitleLabelStyle { get; set; }
            //[Export("axisMajorGridLineBrush")]
            //SCIPenStyle AxisMajorGridLineBrush { get; set; }
            //[Export("axisMinorGridLineBrush")]
            //SCIPenStyle AxisMinorGridLineBrush { get; set; }
            //[Export("axisGridBandBrush")]
            //SCIBrushStyle AxisGridBandBrush { get; set; }
            //[Export("axisMinorTickSize")]
            //float AxisMinorTickSize { get; set; }
            //[Export("axisMajorTickSize")]
            //float AxisMajorTickSize { get; set; }

            ////  Annotation Theme  //
            //[Export("annotationLinePenStyle")]
            //SCIPenStyle AnnotationLinePenStyle { get; set; }
            //[Export("annotationLineResizeMarker")]
            //SCIPointMarkerProtocol AnnotationLineResizeMarker { get; set; }
            //[Export("annotationTextStyle")]
            //SCITextFormattingStyle AnnotationTextStyle { get; set; }
            //[Export("annotationTextBackgroundColor")]
            //UIColor AnnotationTextBackgroundColor { get; set; }
            //[Export("annotationBoxPointMarkerStyle")]
            //SCIPointMarkerProtocol AnnotationBoxPointMarkerStyle { get; set; }
            //[Export("annotationBoxBorderPenStyle")]
            //SCIPenStyle AnnotationBoxBorderPenStyle { get; set; }
            //[Export("annotationBoxFillBrushStyle")]
            //SCIBrushStyle AnnotationBoxFillBrushStyle { get; set; }
            //[Export("annotationAxisMarkerTextStyle")]
            //SCITextFormattingStyle AnnotationAxisMarkerTextStyle { get; set; }
            //[Export("annotationAxisMarkerLineStyle")]
            //SCIPenStyle AnnotationAxisMarkerLineStyle { get; set; }
            //[Export("annotationAxisMarkerBackgroundColor")]
            //UIColor AnnotationAxisMarkerBackgroundColor { get; set; }
            //[Export("annotationAxisMarkerBorderColor")]
            //UIColor AnnotationAxisMarkerBorderColor { get; set; }

            ////  Modifier Theme  //
            //[Export("modifierTooltipStyle")]
            //SCITooltipModifierStyle ModifierTooltipStyle { get; set; }
            //[Export("modifierCursorStyle")]
            //SCICursorModifierStyle ModifierCursorStyle { get; set; }
            //[Export("modifierRolloverStyle")]
            //SCIRolloverModifierStyle ModifierRolloverStyle { get; set; }
            //[Export("modifierLegendBackgroundColor")]
            //UIColor ModifierLegendBackgroundColor { get; set; }
            //[Export("modifierLegendBorderColor")]
            //UIColor ModifierLegendBorderColor { get; set; }
            //[Export("modifierLegendBorderWidth")]
            //float ModifierLegendBorderWidth { get; set; }
            //[Export("modifierLegendCellStyle")]
            //SCILegendCellStyle ModifierLegendCellStyle { get; set; }
        }
    }
}
