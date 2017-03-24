using System;
using System.Linq;
using Foundation;
using SciChart.Examples.Demo.Data;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using SciChart.Examples.Demo.Fragments.Base;

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

            Surface.Annotation = new SCIAnnotationCollection(new NSObject[]
            {
                new SCITextAnnotation
                {
                    CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                    //HorizontalAnchorPoint = HorizontalAnchorPoint.Center,
                    Text = "EUR.USD",
                    X1 = 0.5,
                    Y1 = 0.5,
                    Style =
                    {
                        TextStyle = {FontSize = 72},
                        TextColor = UIColor.FromRGB(0xFF, 0xFF, 0xFF)
                    }
                    //FontStyle = new FontStyle.Builder(Activity).WithTextSize(72).WithTextColor(Color.Argb(0x77, 0xFF, 0xFF, 0xFF)).Build(),
                },
                new SCITextAnnotation
                {
                    //Editable = true,
                    Text = "Buy",
                    X1 = 10d,
                    Y1 = 30.5d,
                    //VerticalAnchorPoint = VerticalAnchorPoint.Bottom,
                    Style =
                    {
                        TextStyle = {FontSize = 20},
                        TextColor = UIColor.FromRGB(0xFF, 0xFF, 0xFF)
                    }
                    //FontStyle = new FontStyle.Builder(Activity).WithTextSize(20).WithTextColor(Color.White).Build()
                },
                new SCITextAnnotation
                {
                    //Editable = true,
                    Text = "Sell!",
                    X1 = 50d,
                    Y1 = 34d,
                    Style =
                    {
                        BackgroundColor = UIColor.FromRGBA(0x02, 0x00, 0x5a, 0x7f),
                        TextStyle = {FontSize = 20},
                        TextColor = UIColor.FromRGB(0xFF, 0xFF, 0xFF)
                    },
                    //FontStyle = new FontStyle.Builder(Activity).WithTextSize(20).WithTextColor(Color.White).Build(),
                },
                new SCIBoxAnnotation
                {
                    //Editable = true,
                    //Background = Activity.GetDrawable(Resource.Drawable.example_box_annotation_background_4),
                    Style =
                    {
                        FillBrush = new SCISolidBrushStyle(UIColor.FromRGBA(0x02, 0x00, 0x59, 0x7f)),
                    },
                    X1 = 50,
                    Y1 = 35.5,
                    X2= 120,
                    Y2= 32,
                },
                new SCILineAnnotation
                {
                    //Editable = true,
                    Style =
                    {
                        LinePen = new SCISolidPenStyle(UIColor.FromRGBA(0xFF, 0x66, 0x00, 0xAA), 2f),
                    },
                    //Stroke = new PenStyle.Builder(Activity).WithThickness(2f).WithColor(Color.Argb(0xAA, 0xFF, 0x66, 0x00)).Build(),
                    X1 = 40,
                    Y1 = 30.5,
                    X2 = 60,
                    Y2 = 33.5,
                },
                new SCILineAnnotation
                {
                    //Editable = true,
                    Style =
                    {
                        LinePen = new SCISolidPenStyle(UIColor.FromRGBA(0xFF, 0x66, 0x00, 0xAA), 2f),
                    },
                    //Stroke = new PenStyle.Builder(Activity).WithThickness(2f).WithColor(Color.Argb(0xAA, 0xFF, 0x66, 0x00)).Build(),
                    X1 = 120,
                    Y1 = 30.5,
                    X2 = 175,
                    Y2 = 36,
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
                    //Editable = true,
                    Position = 32.7,
                    Style =
                    {
                        
                    }
                },
                //new SCIAxisMarkerAnnotation
                //{
                //    AnnotationSurface = AnnotationSurfaceEnum.XAxis,
                //    FormattedValue = "Horizontal",
                //    Editable = true,
                //    X1Value = 100
                //},
                //new HorizontalLineAnnotation(Activity)
                //{
                //    X1Value = 150,
                //    Y1Value = 32.2,
                //    Stroke = new PenStyle.Builder(Activity).WithThickness(2f).WithColor(Color.Red).Build(),
                //    HorizontalGravity = GravityFlags.Right,
                //    Editable = true
                //},
                //new HorizontalLineAnnotation(Activity)
                //{
                //    X1Value = 130,
                //    X2Value = 160,
                //    Y1Value = 33.9,
                //    Stroke = new PenStyle.Builder(Activity).WithThickness(2f).WithColor(Color.Blue).Build(),
                //    HorizontalGravity = GravityFlags.CenterHorizontal,
                //    Editable = true
                //},
                //new VerticalLineAnnotation(Activity)
                //{
                //    X1Value = 20,
                //    Y1Value = 35,
                //    Y2Value = 33,
                //    Stroke = new PenStyle.Builder(Activity).WithThickness(2f).WithColor(Color.DarkGreen).Build(),
                //    VerticalGravity = GravityFlags.CenterVertical,
                //    Editable = true,

                //},
                //new VerticalLineAnnotation(Activity)
                //{
                //    X1Value = 40,
                //    Y1Value = 34,
                //    Stroke = new PenStyle.Builder(Activity).WithThickness(2f).WithColor(Color.Green).Build(),
                //    VerticalGravity = GravityFlags.Top,
                //    Editable = true,
                //},
                new SCITextAnnotation
                {
                    X1 = 50,
                    Y1 = 37,
                    //Editable = true,
                    Text = "Rotated text",
                    //FontStyle = new FontStyle.Builder(Activity).WithTextSize(20).WithTextColor(Color.White).Build(),
                    Style =
                    {
                        TextStyle = {FontSize = 20},
                        TextColor = UIColor.FromRGB(0xFF, 0xFF, 0xFF),
                    },
                    //RotationAngle = 30
                }
            });

            Surface.InvalidateElement();
        }
    }
}