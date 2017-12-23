using SciChart.Charting.Model;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Legend;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Pie Chart", description: "Demonstrates a simple Pie Chart", icon: ExampleIcon.PieChart)]
    public class PieChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId { get { return Resource.Layout.Example_Single_Pie_Chart_With_Legend_Fragment; } }

        private SciPieChartSurface Surface => View.FindViewById<SciPieChartSurface>(Resource.Id.pieChart);
        private SciChartLegend Legend => View.FindViewById<SciChartLegend>(Resource.Id.pieChartLegend);

        protected override void InitExample()
        {
            var pieSeries = new PieRenderableSeries
            {
                SegmentsCollection = new PieSegmentCollection
                {
                    new PieSegment { Value = 40, Title = "Green", FillStyle = CreateRadialBrush(0xff84BC3D.ToColor(), 0xff5B8829.ToColor()) },
                    new PieSegment { Value = 10, Title = "Red", FillStyle = CreateRadialBrush(0xffe04a2f.ToColor(), 0xffB7161B.ToColor()) },
                    new PieSegment { Value = 20, Title = "Blue", FillStyle = CreateRadialBrush(0xff4AB6C1.ToColor(), 0xff2182AD.ToColor()) },
                    new PieSegment { Value = 15, Title = "Yellow", FillStyle = CreateRadialBrush(0xffFFFF00.ToColor(), 0xfffed325.ToColor()) },
                }
            };

            Surface.RenderableSeries.Add(pieSeries);
            Surface.ChartModifiers = new PieChartModifierCollection
            {
                new PieChartLegendModifier(Legend).WithSourceSeries(pieSeries),
                new PieSegmentSelectionModifier()
            };

            pieSeries.Animate(800);
        }

        private BrushStyle CreateRadialBrush(int centerColor, int edgeColor)
        {
            var fillStyle = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, new[] { centerColor, edgeColor }, new[] { 0f, 1f });
            return fillStyle;
        }
    }
}