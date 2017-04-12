using System;
using System.Linq;
using Android.Views;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Interaction with Annotations")]
    public class InteractionWithAnnotationsFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var dataSeries = new OhlcDataSeries<DateTime, double>();

            foreach (var priceBar in DataManager.Instance.GetPriceDataIndu().Take(100))
            {
                dataSeries.Append(priceBar.DateTime, priceBar.Open, priceBar.High, priceBar.Low, priceBar.Close);
            }

            Surface.XAxes.Add(new CategoryDateAxis(Activity) {VisibleRange = new DoubleRange(0, 199)});
            Surface.YAxes.Add(new NumericAxis(Activity) {VisibleRange = new DoubleRange(30, 37)});
            Surface.RenderableSeries.Add(new FastCandlestickRenderableSeries {DataSeries = dataSeries});

            var horizontalLineAnnotation = new HorizontalLineAnnotation(Activity)
            {
                X1Value = 130,
                X2Value = 160,
                Y1Value = 33.9,
                Stroke = new SolidPenStyle(ColorUtil.Blue, 2f.ToDip(Activity)),
                HorizontalGravity = GravityFlags.CenterHorizontal,
                IsEditable = true,
                AnnotationLabels = new AnnotationCollection
                {
                    new LineAnnotationWithLabelsBase.AnnotationLabel(Activity)
                    {
                        LabelPlacement = LabelPlacement.Auto
                    }
                }
            };
            Surface.Annotations = new AnnotationCollection
            {
                new TextAnnotation(Activity)
                {
                    CoordinateMode = AnnotationCoordinateMode.Relative,
                    HorizontalAnchorPoint = HorizontalAnchorPoint.Center,
                    Text = "EUR.USD",
                    FontStyle = new FontStyle(72.ToDip(Activity), 0x77FFFFFF),
                    X1Value = 0.5,
                    Y1Value = 0.5
                },
                new TextAnnotation(Activity)
                {
                    IsEditable = true,
                    Text = "Buy",
                    X1Value = 10d,
                    Y1Value = 30.5d,
                    VerticalAnchorPoint = VerticalAnchorPoint.Bottom,
                    FontStyle = new FontStyle(20.ToDip(Activity), ColorUtil.White),
                },
                new TextAnnotation(Activity)
                {
                    Background = Activity.GetDrawable(Resource.Drawable.example_text_annotation_background),
                    IsEditable = true,
                    Text = "Sell!",
                    X1Value = 50d,
                    Y1Value = 34d,
                    FontStyle = new FontStyle(20.ToDip(Activity), ColorUtil.White),
                },
                new BoxAnnotation(Activity)
                {
                    IsEditable = true,
                    Background = Activity.GetDrawable(Resource.Drawable.example_box_annotation_background_4),
                    X1Value = 50,
                    Y1Value = 35.5,
                    X2Value = 120,
                    Y2Value = 32,
                },
                new LineAnnotation(Activity)
                {
                    IsEditable = true,
                    Stroke = new SolidPenStyle(0xAAFF6600, 2f.ToDip(Activity)),
                    X1Value = 40,
                    Y1Value = 30.5,
                    X2Value = 60,
                    Y2Value = 33.5,
                },
                new LineAnnotation(Activity)
                {
                    IsEditable = true,
                    Stroke = new SolidPenStyle(0xAAFF6600, 2f.ToDip(Activity)),
                    X1Value = 120,
                    Y1Value = 30.5,
                    X2Value = 175,
                    Y2Value = 36,
                },
                new LineArrowAnnotation(Activity)
                {
                    IsEditable = true,
                    HeadLength = 8,
                    HeadWidth = 16,
                    X1Value = 50,
                    Y1Value = 35,
                    X2Value = 80,
                    Y2Value = 31.4,
                },
                new AxisMarkerAnnotation(Activity)
                {
                    IsEditable = true,
                    Y1Value = 32.7
                },
                new AxisMarkerAnnotation(Activity)
                {
                    AnnotationSurface = AnnotationSurfaceEnum.XAxis,
                    FormattedValue = "Horizontal",
                    IsEditable = true,
                    X1Value = 100
                },
                new HorizontalLineAnnotation(Activity)
                {
                    X1Value = 150,
                    Y1Value = 32.2,
                    Stroke = new SolidPenStyle(ColorUtil.Red, 2f.ToDip(Activity)),
                    HorizontalGravity = GravityFlags.Right,
                    IsEditable = true
                },
                horizontalLineAnnotation,
                new VerticalLineAnnotation(Activity)
                {
                    X1Value = 20,
                    Y1Value = 35,
                    Y2Value = 33,
                    Stroke = new SolidPenStyle(ColorUtil.DarkGreen, 2f.ToDip(Activity)),
                    VerticalGravity = GravityFlags.CenterVertical,
                    IsEditable = true,
                },
                new VerticalLineAnnotation(Activity)
                {
                    X1Value = 40,
                    Y1Value = 34,
                    Stroke = new SolidPenStyle(ColorUtil.Green, 2f.ToDip(Activity)),
                    VerticalGravity = GravityFlags.Top,
                    IsEditable = true,
                },
                new TextAnnotation(Activity)
                {
                    X1Value = 50,
                    Y1Value = 37,
                    IsEditable = true,
                    Text = "Rotated text",
                    FontStyle = new FontStyle(20.ToDip(Activity), ColorUtil.White),
                    RotationAngle = 30
                }
            };
        }
    }
}