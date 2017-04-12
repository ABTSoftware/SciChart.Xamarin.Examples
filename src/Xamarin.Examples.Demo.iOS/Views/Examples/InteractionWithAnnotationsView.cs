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
    [ExampleDefinition("Interaction with Annotations")]
    public class InteractionWithAnnotationsView : ExampleBaseView
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        protected override void UpdateFrame()
        {
            _exampleViewLayout.SciChartSurfaceView.Frame = _exampleViewLayout.Frame;
            _exampleViewLayout.SciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleViewLayout.SciChartSurfaceView);

            var dataSeries = new OhlcDataSeries<DateTime, double>();

            foreach (var priceBar in DataManager.Instance.GetPriceDataIndu().Take(100))
            {
                dataSeries.Append(priceBar.DateTime, priceBar.Open, priceBar.High, priceBar.Low, priceBar.Close);
            }

            var xAxis = new SCIDateTimeAxis {VisibleRange = new SCIDoubleRange(0, 199)};
            var yAxis = new SCINumericAxis {VisibleRange = new SCIDoubleRange(30, 37)};

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(new SCIFastCandlestickRenderableSeries {DataSeries = dataSeries});

            var horizontalLineAnnotation = new SCIHorizontalLineAnnotation
            {
                X1Value = 130,
                //X2Value = 160,
                Y1Value = 33.9,
                Style =
                {
                    LinePen = new SCISolidPenStyle(ColorUtil.Blue, 2f),
                    HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Right
                },
                //HorizontalGravity = GravityFlags.CenterHorizontal,
                IsEditable = true
            };
            horizontalLineAnnotation.AddLabel(new SCILineAnnotationLabel
            {
                Style = {LabelPlacement = SCIAnnotationLabelPlacementMode.TopCenter}
            });

            Surface.Annotation = new SCIAnnotationCollection(new NSObject[]
            {
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                    //HorizontalAnchorPoint = HorizontalAnchorPoint.Center,
                    Text = "EUR.USD",
                    X1Value = 0.5,
                    Y1Value = 0.5,
                    Style = {TextStyle = {FontSize = 72, ColorCode = 0x77FFFFFF}}
                },
                new SCITextAnnotation
                {
                    IsEditable = true,
                    Text = "Buy",
                    X1Value = 10d,
                    Y1Value = 30.5d,
                    //VerticalAnchorPoint = VerticalAnchorPoint.Bottom,
                    Style = {TextStyle = {FontSize = 20, ColorCode = ColorUtil.White}}
                },
                new SCITextAnnotation
                {
                    IsEditable = true,
                    Text = "Sell!",
                    X1Value = 50d,
                    Y1Value = 34d,
                    Style =
                    {
                        TextStyle = {FontSize = 20, ColorCode = ColorUtil.White},
                        BackgroundColor = UIColor.FromRGBA(0x02, 0x00, 0x5A, 0x7F)
                    }
                },
                new SCIBoxAnnotation
                {
                    IsEditable = true,
                    Style = {FillBrush = new SCISolidBrushStyle(UIColor.FromRGBA(0x02, 0x00, 0x59, 0x7F))},
                    X1Value = 50,
                    Y1Value = 35.5,
                    X2Value = 120,
                    Y2Value = 32,
                },
                new SCILineAnnotation
                {
                    IsEditable = true,
                    Style = {LinePen = new SCISolidPenStyle(0xAAFF6600, 2f)},
                    X1Value = 40,
                    Y1Value = 30.5,
                    X2Value = 60,
                    Y2Value = 33.5,
                },
                new SCILineAnnotation
                {
                    IsEditable = true,
                    Style = {LinePen = new SCISolidPenStyle(0xAAFF6600, 2f)},
                    X1Value = 120,
                    Y1Value = 30.5,
                    X2Value = 175,
                    Y2Value = 36,
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
                    IsEditable = true,
                    Position = 32.7,
                },
                new SCIAxisMarkerAnnotation
                {
                    //AnnotationSurface = AnnotationSurfaceEnum.XAxis,
                    FormattedValue = "Horizontal",
                    IsEditable = true,
                    Position = 100
                },
                new SCIHorizontalLineAnnotation
                {
                    X1Value = 150,
                    Y1Value = 32.2,
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
                    X1Value = 20,
                    Y1Value = 35,
                    //Y2Value = 33,
                    Style =
                    {
                        LinePen = new SCISolidPenStyle(ColorUtil.DarkGreen, 2f),
                        VerticalAlignment = SCIVerticalLineAnnotationAlignment.Stretch
                    },
                    //VerticalGravity = GravityFlags.CenterVertical,
                    IsEditable = true,
                },
                new SCIVerticalLineAnnotation
                {
                    X1Value = 40,
                    Y1Value = 34,
                    Style =
                    {
                        LinePen = new SCISolidPenStyle(ColorUtil.Green, 2f),
                        VerticalAlignment = SCIVerticalLineAnnotationAlignment.Top
                    },
                    IsEditable = true,
                },
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
                    }
                    //RotationAngle = 30
                }
            });

            Surface.InvalidateElement();
        }
    }
}