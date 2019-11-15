using System;
using System.Linq;
using UIKit;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;
using Xamarin.Examples.Demo.Data;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Interaction with Annotations", description: "Demonstrates touch-interaction with Annotations", icon: ExampleIcon.Annotations)]
    public class InteractionWithAnnotationsViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var dataSeries = new OhlcDataSeries<DateTime, double>();

            var marketDataService = new MarketDataService(new DateTime(2000, 08, 01, 12, 00, 00), 5, 5);
            var data = marketDataService.GetHistoricalData(200);

            dataSeries.Append(data.Select(x => x.DateTime), data.Select(x => x.Open), data.Select(x => x.High), data.Select(x => x.Low), data.Select(x => x.Close));

            Surface.XAxes.Add(new SCICategoryDateAxis());
            Surface.YAxes.Add(new SCINumericAxis { VisibleRange = new SCIDoubleRange(30, 37) });
            Surface.RenderableSeries.Add(new SCIFastCandlestickRenderableSeries { DataSeries = dataSeries });
            Surface.ChartModifiers.Add(CreateDefaultModifiers());

            var horizontalLine1 = new SCIHorizontalLineAnnotation
            {
                X1Value = 150,
                Y1Value = 32.2,
                HorizontalAlignment = SCIAlignment.Right,
                Stroke = new SCISolidPenStyle(ColorUtil.Red, 2),
                IsEditable = true
            };
            horizontalLine1.AnnotationLabels.Add(new SCIAnnotationLabel { LabelPlacement = SCILabelPlacement.Axis });

            var horizontalLine2 = new SCIHorizontalLineAnnotation
            {
                X1Value = 130,
                X2Value = 160,
                Y1Value = 33.9,
                HorizontalAlignment = SCIAlignment.Center,
                Stroke = new SCISolidPenStyle(ColorUtil.Blue, 2),
                IsEditable = true,
            };
            horizontalLine2.AnnotationLabels.Add(new SCIAnnotationLabel { Text = "Top", LabelPlacement = SCILabelPlacement.Top });
            horizontalLine2.AnnotationLabels.Add(new SCIAnnotationLabel { Text = "Left", LabelPlacement = SCILabelPlacement.Left });
            horizontalLine2.AnnotationLabels.Add(new SCIAnnotationLabel { Text = "Right", LabelPlacement = SCILabelPlacement.Right });

            var verticalLine1 = new SCIVerticalLineAnnotation
            {
                X1Value = 20,
                Y1Value = 35,
                Y2Value = 33,
                VerticalAlignment = SCIAlignment.CenterVertical,
                Stroke = new SCISolidPenStyle(0xFF006400, 2),
                IsEditable = true,
            };
            var verticalLine2 = new SCIVerticalLineAnnotation
            {
                X1Value = 40,
                Y1Value = 34,
                VerticalAlignment = SCIAlignment.Top,
                Stroke = new SCISolidPenStyle(0xFF006400, 2),
                IsEditable = true,
            };
            verticalLine2.AnnotationLabels.Add(new SCIAnnotationLabel { LabelPlacement = SCILabelPlacement.Top });

            Surface.Annotations = new SCIAnnotationCollection
            {
                new SCITextAnnotation
                {
                    X1Value = 0.5,
                    Y1Value = 0.5,
                    CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                    Text = "EUR.USD",
                    FontStyle = new SCIFontStyle(72, 0x77FFFFFF),
                },
                new SCITextAnnotation
                {
                    X1Value = 10d,
                    Y1Value = 30.5d,
                    IsEditable = true,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                    Text = "Buy!",
                    FontStyle = new SCIFontStyle(20, UIColor.White),
                },
                new SCITextAnnotation
                {
                    X1Value = 50d,
                    Y1Value = 34d,
                    IsEditable = true,
                    Text = "Sell!",
                    FontStyle = new SCIFontStyle(20, UIColor.White),
                },
                new SCITextAnnotation
                {
                    X1Value = 80d,
                    Y1Value = 36d,
                    IsEditable = true,
                    RotationAngle = -30,
                    Text = "Rotated text",
                    FontStyle = new SCIFontStyle(20, UIColor.White),
                },
                new SCIBoxAnnotation
                {
                    X1Value = 50,
                    Y1Value = 35.5,
                    X2Value = 120,
                    Y2Value = 32,
                    IsEditable = true,
                    FillBrush = new SCISolidBrushStyle(0x33FF6600),
                    BorderPen = new SCISolidPenStyle(0x77FF6600, 1)
                },
                new SCILineAnnotation
                {
                    X1Value = 40,
                    Y1Value = 30.5,
                    X2Value = 60,
                    Y2Value = 33.5,
                    IsEditable = true,
                    Stroke = new SCISolidPenStyle(0xAAFF6600, 2f)
                },
                new SCILineAnnotation
                {
                    X1Value = 120,
                    Y1Value = 30.5,
                    X2Value = 175,
                    Y2Value = 36,
                    IsEditable = true,
                    Stroke = new SCISolidPenStyle(0xAAFF6600, 2f)
                },
                new SCILineArrowAnnotation
                {
                    IsEditable = true,
                    X1Value = 50,
                    Y1Value = 35,
                    X2Value = 80,
                    Y2Value = 31.4,
                    Stroke = new SCISolidPenStyle(0xAAFF6600, 2f)
                },
                new SCIAxisMarkerAnnotation
                {
                    Y1Value = 32.7,
                    IsEditable = true,
                    CoordinateMode = SCIAnnotationCoordinateMode.Absolute
                },
                new SCIAxisMarkerAnnotation
                {
                    X1Value = 100,
                    IsEditable = true,
                    FormattedValue = "Horizontal",
                    AnnotationSurface = SCIAnnotationSurfaceEnum.XAxis
                },
                horizontalLine1,
                horizontalLine2,
                verticalLine1,
                verticalLine2
            };
        }
    }
}