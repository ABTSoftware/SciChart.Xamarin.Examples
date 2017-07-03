using SciChart.Examples.Demo.Data;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Utils;
using System;
using Xamarin.Examples.Demo.Data;
using System.Linq;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Interaction with Annotations", description: "Demonstrates touch-interaction with Annotations", icon: ExampleIcon.Annotations)]
    public class InteractionWithAnnotationsView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint constraintRight = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint constraintLeft = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint constraintTop = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint constraintBottom = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0);

            this.AddConstraint(constraintRight);
            this.AddConstraint(constraintLeft);
            this.AddConstraint(constraintTop);
            this.AddConstraint(constraintBottom);
        }

        protected override void InitExampleInternal()
        {
            var dataSeries = new OhlcDataSeries<DateTime, double>();

            var marketDataService = new MarketDataService(new DateTime(2000, 08, 01, 12, 00, 00), 5, 5);
            var data = marketDataService.GetHistoricalData(200);

            dataSeries.Append(data.Select(x => x.DateTime), data.Select(x => x.Open), data.Select(x => x.High), data.Select(x => x.Low), data.Select(x => x.Close));

            Surface.XAxes.Add(new SCICategoryDateTimeAxis());
            Surface.YAxes.Add(new SCINumericAxis { VisibleRange = new SCIDoubleRange(30, 37) });
            Surface.RenderableSeries.Add(new SCIFastCandlestickRenderableSeries { DataSeries = dataSeries });
            Surface.ChartModifiers = new SCIChartModifierCollection
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            };

            var horizontalLine1 = new SCIHorizontalLineAnnotation
            {
                X1Value = 150,
                Y1Value = 32.2,
                HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Right,
                Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(ColorUtil.Red, 2f) },
                IsEditable = true
            };
            horizontalLine1.AddLabel(new SCILineAnnotationLabel
            {
                Style =
                {
                    TextStyle = new SCITextFormattingStyle {Color = UIColor.White},
                    LabelPlacement = SCILabelPlacement.Axis,
                    BackgroundColor = ColorUtil.Red.ToColor()
                }
            });

            var horizontalLine2 = new SCIHorizontalLineAnnotation
            {
                X1Value = 130,
                X2Value = 160,
                Y1Value = 33.9,
                HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Center,
                Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(ColorUtil.Blue, 2f) },
                IsEditable = true,
            };
            horizontalLine2.AddLabel(new SCILineAnnotationLabel
            {
                Style =
                {
                    TextStyle = new SCITextFormattingStyle {Color = UIColor.Blue},
                    LabelPlacement = SCILabelPlacement.Top,
                    BackgroundColor = UIColor.Clear
                },
                Text = "Top",
            });
            horizontalLine2.AddLabel(new SCILineAnnotationLabel
            {
                Style =
                {
                    TextStyle = new SCITextFormattingStyle {Color = UIColor.Blue},
                    LabelPlacement = SCILabelPlacement.Left,
                    BackgroundColor = UIColor.Clear
                },
                Text = "Left",
            });
            horizontalLine2.AddLabel(new SCILineAnnotationLabel
            {
                Style =
                {
                    TextStyle = new SCITextFormattingStyle {Color = UIColor.Blue},
                    LabelPlacement = SCILabelPlacement.Right,
                    BackgroundColor = UIColor.Clear
                },
                Text = "Right",
            });

            var verticalLine1 = new SCIVerticalLineAnnotation
            {
                X1Value = 40,
                Y1Value = 34,
                VerticalAlignment = SCIVerticalLineAnnotationAlignment.Top,
                Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(ColorUtil.Green, 2f) },
                IsEditable = true,
            };
            verticalLine1.AddLabel(new SCILineAnnotationLabel
            {
                Style =
                {
                    TextStyle = new SCITextFormattingStyle {Color = UIColor.Green},
                    LabelPlacement = SCILabelPlacement.Top,
                    BackgroundColor = UIColor.Clear
                },
            });

            Surface.Annotations = new SCIAnnotationCollection
            {
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                    Text = "EUR.USD",
                    X1Value = 0.5,
                    Y1Value = 0.5,
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = 0x77FFFFFF.ToColor(),
                        TextStyle = new SCITextFormattingStyle {FontSize = 72 },
                        BackgroundColor = UIColor.Clear
                    },
                },
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Absolute,
                    IsEditable = true,
                    EditableText = false,
                    Text = "Buy!",
                    X1Value = 10d,
                    Y1Value = 30.5d,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Left,
                    Style =
                    {
                        TextStyle = { FontSize = 20 },
                        TextColor = ColorUtil.White.ToColor(),
                        BackgroundColor = UIColor.Clear
                    },
                },
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Absolute,
                    IsEditable = true,
                    EditableText = false,
                    Text = "Sell!",
                    X1Value = 50d,
                    Y1Value = 34d,
                    Style =
                    {
                        TextStyle = { FontSize = 20 },
                        TextColor = ColorUtil.White.ToColor(),
                        BackgroundColor = 0x33FF3333.ToColor()
                    },
                },
                new SCIBoxAnnotation
                {
                    IsEditable = true,
                    Style =
                    {
                        FillBrush = new SCISolidBrushStyle(UIColor.FromRGBA(0xFF, 0x66, 0x00, 0x33)),
                        BorderPen =  new SCISolidPenStyle(UIColor.FromRGBA(0xFF, 0x66, 0x00, 0x77), 1.0f)
                    },
                    X1Value = 50,
                    Y1Value = 35.5,
                    X2Value = 120,
                    Y2Value = 32,
                },
                new SCILineAnnotation
                {
                    IsEditable = true,
                    Style = { LinePen = new SCISolidPenStyle(0xAAFF6600, 2f) },
                    X1Value = 40,
                    Y1Value = 30.5,
                    X2Value = 60,
                    Y2Value = 33.5,
                },
                new SCILineAnnotation
                {
                    IsEditable = true,
                    Style = { LinePen = new SCISolidPenStyle(0xAAFF6600, 2f) },
                    X1Value = 120,
                    Y1Value = 30.5,
                    X2Value = 175,
                    Y2Value = 36,
                },
                // TODO LineArrow annotaiton
                new SCILineAnnotation
                {
                    IsEditable = true,
                    Style = { LinePen = new SCISolidPenStyle(0xAAFF6600, 2f) },
                    X1Value = 50,
                    Y1Value = 35,
                    X2Value = 80,
                    Y2Value = 31.4,
                },
                new SCIAxisMarkerAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Absolute,
                    IsEditable = true,
                    Position = 32.7,
                },
                new SCIAxisMarkerAnnotation
                {
                    Style = {AnnotationSurface = SCIAnnotationSurfaceEnum.XAxis},
                    FormattedValue = "Horizontal",
                    IsEditable = true,
                    Position = 100,
                },

                horizontalLine1,
                horizontalLine2,
                new SCIVerticalLineAnnotation
                {
                    X1Value = 20,
                    Y1Value = 35,
                    Y2Value = 33,
                    VerticalAlignment = SCIVerticalLineAnnotationAlignment.Center,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(ColorUtil.DarkGreen, 2f) },
                    IsEditable = true,
                },
                verticalLine1,
                new SCITextAnnotation
                {
                    X1Value = 50,
                    Y1Value = 37,
                    IsEditable = true,
                    EditableText = false,
                    Text = "Rotated text",
                    Style =
                    {
                        TextStyle = { FontSize = 20 },
                        TextColor = ColorUtil.White.ToColor(),
                        BackgroundColor = UIColor.Clear
                    },
                    //RotationAngle = 30
                }
            };
        }
    }
}