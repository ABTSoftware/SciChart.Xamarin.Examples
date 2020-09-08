using System.Threading.Tasks;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Nested Pie Chart", description: "Creates a simple donut chart", icon: ExampleIcon.LineChart)]
    public class NestedPieChartsViewController : SingleChartViewController<SCIPieChartSurface>
    {
        protected override void InitExample()
        {
            var pieSeries = new SCIDonutRenderableSeries
            {
                SegmentsCollection = new SCIPieSegmentCollection 
                {
                    new SCIPieSegment { Value = 34, Title = "Ecologic", FillStyle = new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829) },
                    new SCIPieSegment { Value = 34.4, Title = "Municipal", FillStyle = new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B) },
                    new SCIPieSegment { Value = 31.6, Title = "Personal", FillStyle = new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD) },
                },
            };

            var donutSeries = new SCIDonutRenderableSeries
            {
                SegmentsCollection = new SCIPieSegmentCollection 
                {
                    new SCIPieSegment { Value = 28.8, Title = "Walking", FillStyle = new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829) },
                    new SCIPieSegment { Value = 5.2, Title = "Bycicle", FillStyle = new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829) },
                    new SCIPieSegment { Value = 12.3, Title = "Metro", FillStyle = new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B) },
                    new SCIPieSegment { Value = 3.5, Title = "Tram", FillStyle = new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B) },
                    new SCIPieSegment { Value = 5.9, Title = "Rail", FillStyle = new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B) },
                    new SCIPieSegment { Value = 9.7, Title = "Bus", FillStyle = new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B) },
                    new SCIPieSegment { Value = 3, Title = "Taxi", FillStyle = new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B) },
                    new SCIPieSegment { Value = 23.1, Title = "Car", FillStyle = new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD) },
                    new SCIPieSegment { Value = 3.1, Title = "Motor", FillStyle = new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD) },
                    new SCIPieSegment { Value = 5.3, Title = "Other", FillStyle = new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD) },
                },
            };

            Surface.RenderableSeries.Add(pieSeries);
            Surface.RenderableSeries.Add(donutSeries);
            Surface.ChartModifiers.Add(new SCIPieChartLegendModifier
            {
                SourceSeries = pieSeries,
                Position = SCIAlignment.Bottom | SCIAlignment.CenterHorizontal,
                Margins = new UIEdgeInsets(17, 17, 17, 17),
            });
            Surface.ChartModifiers.Add(new SCIPieChartTooltipModifier());

            pieSeries.Scale = 0;
            donutSeries.Scale = 0;
            pieSeries.Animate(0.7);
            donutSeries.Animate(0.7);
        }
    }
}
