using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using SciChart.Examples.Demo.Data;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Utils;

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
            var dataSeries = new OhlcDataSeries<double, double>();

            var i = 0;
            foreach (var priceBar in DataManager.Instance.GetPriceDataIndu())
            {
                dataSeries.Append(i, priceBar.Open, priceBar.High, priceBar.Low, priceBar.Close);
                i += 1;
            }

            var xAxis = new SCINumericAxis { VisibleRange = new SCIDoubleRange(0, 190) };
            var yAxis = new SCINumericAxis { VisibleRange = new SCIDoubleRange(30, 37), AxisId = "yaxis" };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(new SCIFastCandlestickRenderableSeries { DataSeries = dataSeries, YAxisId = "yaxis" });

            var horizontalLineAnnotation = new SCIHorizontalLineAnnotation
            {
                X1Value = 130,
                X2Value = 160,
                YValue = 33.9,
                Style =
                {
                    LinePen = new SCISolidPenStyle(ColorUtil.Blue, 2f),
                    HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Center
                },
                //HorizontalGravity = GravityFlags.CenterHorizontal,
                IsEditable = true,
                XAxisId = xAxis.AxisId,
                YAxisId = yAxis.AxisId

            };
            horizontalLineAnnotation.AddLabel(new SCILineAnnotationLabel
            {
                Style = { LabelPlacement = SCILabelPlacement.Top, BackgroundColor = UIColor.Clear },
                Text = "Top",
                TextColor = UIColor.Blue
            });
            horizontalLineAnnotation.AddLabel(new SCILineAnnotationLabel
            {
                Style = { LabelPlacement = SCILabelPlacement.Left, BackgroundColor = UIColor.Clear },
                Text = "Left",
                TextColor = UIColor.Blue
            });
            horizontalLineAnnotation.AddLabel(new SCILineAnnotationLabel
            {
                Style = { LabelPlacement = SCILabelPlacement.Bottom, BackgroundColor = UIColor.Clear },
                Text = "Bottom",
                TextColor = UIColor.Blue
            });
            horizontalLineAnnotation.AddLabel(new SCILineAnnotationLabel
            {
                Style = { LabelPlacement = SCILabelPlacement.Right, BackgroundColor = UIColor.Clear },
                Text = "Right",
                TextColor = UIColor.Blue
            });

            var verticalLineAnnotaion = new SCIVerticalLineAnnotation
            {
                XValue = 40,
                Y1Value = 34,
                Style =
                    {
                        LinePen = new SCISolidPenStyle(ColorUtil.Green, 2f),
                        VerticalAlignment = SCIVerticalLineAnnotationAlignment.Top

                    },
                IsEditable = true,
                XAxisId = xAxis.AxisId,
                YAxisId = yAxis.AxisId
            };

			verticalLineAnnotaion.AddLabel(new SCILineAnnotationLabel
			{
                Style = { LabelPlacement = SCILabelPlacement.Top, BackgroundColor = UIColor.Clear },
				Text = "40",
				TextColor = UIColor.Blue
			});

            Surface.Annotations = new SCIAnnotationCollection(
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Center,
                    Text = "EUR.USD",
                    X1Value = 0.5,
                    Y1Value = 0.5,
                    Style = { TextStyle = { FontSize = 72, ColorCode = 0x77FFFFFF }, BackgroundColor = UIColor.Clear },
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                },
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Absolute,
                    IsEditable = true,
                    Text = "Buy!",
                    X1Value = 10d,
                    Y1Value = 30.5d,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Left,
                    Style = { TextStyle = { FontSize = 20, ColorCode = 0xFFFFFFFF }, BackgroundColor = UIColor.Clear },
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                },
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Absolute,
                    IsEditable = true,
                    Text = "Sell!",
                    X1Value = 50d,
                    Y1Value = 34d,
                    Style = { TextStyle = { FontSize = 20, ColorCode = ColorUtil.White }, BackgroundColor = UIColor.Clear },
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                },
                new SCIBoxAnnotation
                {
                    IsEditable = true,
                    Style = { FillBrush = new SCISolidBrushStyle(UIColor.FromRGBA(0xFF, 0x66, 0x00, 0x33)),
                              BorderPen =  new SCISolidPenStyle(UIColor.FromRGBA(0xFF, 0x66, 0x00, 0x77), 1.0f)},
                    X1Value = 50,
                    Y1Value = 35.5,
                    X2Value = 120,
                    Y2Value = 32,
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                },
                new SCILineAnnotation
                {
                    IsEditable = true,
                    Style = { LinePen = new SCISolidPenStyle(0xAAFF6600, 2f) },
                    X1Value = 40,
                    Y1Value = 30.5,
                    X2Value = 60,
                    Y2Value = 33.5,
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                },
                new SCILineAnnotation
                {
                    IsEditable = true,
                    Style = { LinePen = new SCISolidPenStyle(0xAAFF6600, 2f) },
                    X1Value = 120,
                    Y1Value = 30.5,
                    X2Value = 175,
                    Y2Value = 36,
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                },
                //new LineArrowAnnotation(Activity)
                //{
                //    Editable = true,
                //    HeadLength = 8,
                //    HeadWidth = 16,
                //    X1Value = 50,
                //    Y1Value = 35,
                //    X2Value = 80,
                //    Y2Value = 31.4,
                //},
                new SCIAxisMarkerAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Absolute,
                    IsEditable = true,
                    YAxisId = yAxis.AxisId,
                    Position = 32.7,
                },
                new SCIAxisMarkerAnnotation
                {
                    FormattedValue = "Horizontal",
                    IsEditable = true,
                    Position = 100,
                    XAxisId = xAxis.AxisId
                },
                new SCIHorizontalLineAnnotation
                {
                    X1Value = 150,
                    YValue = 32.2,
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId,
                    Style =
                    {
                        LinePen = new SCISolidPenStyle(ColorUtil.Red, 2f),
                        HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Right
                    },
                    IsEditable = true
                },
                horizontalLineAnnotation,
                new SCIVerticalLineAnnotation
                {
                    XValue = 20,
                    Y1Value = 35,
                    Y2Value = 33,
                    Style =
                    {
                        LinePen = new SCISolidPenStyle(ColorUtil.DarkGreen, 2f),
                    VerticalAlignment = SCIVerticalLineAnnotationAlignment.Center
                    },
                    IsEditable = true,
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                },
                verticalLineAnnotaion,
                new SCITextAnnotation
                {
                    X1Value = 50,
                    Y1Value = 37,
                    IsEditable = true,
                    Text = "Rotated text",
                    Style =
                    {
                        TextStyle =
                        {
                            FontSize = 20,
                            ColorCode = ColorUtil.White,
                        }
                    },
                    XAxisId = xAxis.AxisId,
                    YAxisId = yAxis.AxisId
                    //RotationAngle = 30
                }
            );
        }
    }
}