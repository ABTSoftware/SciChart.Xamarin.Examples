using SciChart.Charting.Model;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Legend;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Multiple series Pie Chart", description: "Demonstrates how to create a PieDonut Chart with multiple series", icon: ExampleIcon.PieChart)]
    public class MultiplePieDonutChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId { get { return Resource.Layout.Example_Single_Pie_Chart_With_Legend_Fragment; } }

        private SciPieChartSurface Surface => View.FindViewById<SciPieChartSurface>(Resource.Id.pieChart);
        private SciChartLegend Legend => View.FindViewById<SciChartLegend>(Resource.Id.pieChartLegend);

        protected override void InitExample()
        {
            var pieSeries = new PieRenderableSeries
            {
                SeriesName = "HowPeopleTravel",
                SegmentsCollection = new PieSegmentCollection
                {
                    new PieSegment { Value = 34, Title = "Ecologic", FillStyle = createRadialBrush(0xff84BC3D.ToColor(), 0xff5B8829.ToColor()) },
                    new PieSegment { Value = 34.4, Title = "Municipal", FillStyle = createRadialBrush(0xffe04a2f.ToColor(), 0xffB7161B.ToColor()) },
                    new PieSegment { Value = 31.6, Title = "Personal", FillStyle = createRadialBrush(0xff4AB6C1.ToColor(), 0xff2182AD.ToColor()) },
                }
            };

            var donutSeries = new DonutRenderableSeries
            {
                SeriesName = "DetailedGroup",
                SegmentsCollection = new PieSegmentCollection
                {
                    new PieSegment { Value = 28.8, Title = "Walking", FillStyle = createRadialBrush(0xff84BC3D.ToColor(), 0xff5B8829.ToColor()) },
                    new PieSegment { Value = 5.2, Title = "Bicycle", FillStyle = createRadialBrush(0xff84BC3D.ToColor(), 0xff5B8829.ToColor()) },
                    new PieSegment { Value = 12.3, Title = "Metro", FillStyle = createRadialBrush(0xffe04a2f.ToColor(), 0xffB7161B.ToColor()) },
                    new PieSegment { Value = 3.5, Title = "Tram", FillStyle = createRadialBrush(0xffe04a2f.ToColor(), 0xffB7161B.ToColor()) },
                    new PieSegment { Value = 5.9, Title = "Rail", FillStyle = createRadialBrush(0xffe04a2f.ToColor(), 0xffB7161B.ToColor()) },
                    new PieSegment { Value = 9.7, Title = "Bus", FillStyle = createRadialBrush(0xffe04a2f.ToColor(), 0xffB7161B.ToColor()) },
                    new PieSegment { Value = 3.0, Title = "Taxi", FillStyle = createRadialBrush(0xffe04a2f.ToColor(), 0xffB7161B.ToColor()) },
                    new PieSegment { Value = 23.2, Title = "Car", FillStyle = createRadialBrush(0xff4AB6C1.ToColor(), 0xff2182AD.ToColor()) },
                    new PieSegment { Value = 3.1, Title = "Motorcycle", FillStyle = createRadialBrush(0xff4AB6C1.ToColor(), 0xff2182AD.ToColor()) },
                    new PieSegment { Value = 5.3, Title = "Other", FillStyle = createRadialBrush(0xff4AB6C1.ToColor(), 0xff2182AD.ToColor()) },
                }
            };

            Surface.RenderableSeries.Add(pieSeries);
            Surface.RenderableSeries.Add(donutSeries);
            Surface.ChartModifiers = new PieChartModifierCollection
            {
                new PieChartLegendModifier(Legend).WithSourceSeries(pieSeries).WithShowCheckBoxes(false),
                new PieChartTooltipModifier()
            };

            pieSeries.Animate(800);
            donutSeries.Animate(800);
        }

        private BrushStyle createRadialBrush(Color centerColor, Color edgeColor)
        {
            var fillStyle = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, new[] { centerColor, edgeColor }, new[] { 0f, 1f });
            return fillStyle;
        }
    }
}