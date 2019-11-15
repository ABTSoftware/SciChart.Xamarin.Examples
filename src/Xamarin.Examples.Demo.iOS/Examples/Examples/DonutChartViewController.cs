using System.Threading.Tasks;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Donut Chart", description: "Creates a simple donut chart", icon: ExampleIcon.LineChart)]
    public class DonutChartViewController : SingleChartViewController<SCIPieChartSurface>
    {
        protected override void InitExample()
        {
            var rSeries = new SCIDonutRenderableSeries
            {
                IsVisible = false,
                Segments = new SCIPieSegmentCollection 
                {
                    new SCIPieSegment { Value = 40, Title = "Green", FillStyle = new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829), CenterOffset = 1 },
                    new SCIPieSegment { Value = 10, Title = "Red", FillStyle = new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B), CenterOffset = 1 },
                    new SCIPieSegment { Value = 20, Title = "Blue", FillStyle = new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD), CenterOffset = 1 },
                    new SCIPieSegment { Value = 15, Title = "Yellow", FillStyle = new SCIRadialGradientBrushStyle(0xffFFFF00, 0xfffed325), CenterOffset = 1 },
                },
            };

            Surface.HoleRadius = 100;
            Surface.RenderableSeries.Add(rSeries);
            Surface.ChartModifiers.Add(new SCIPieLegendModifier
            {
                SourceSeries = rSeries,
                Position = SCIAlignment.Bottom | SCIAlignment.CenterHorizontal,
                Margins = new UIEdgeInsets(17, 17, 17, 17),
            });
            Surface.ChartModifiers.Add(new SCIPieSelectionModifier { SelectionMode = SCIPieSelectionModifierSelectionMode.SingleSelectDeselectOnDoubleTap });

            Task.Run(() =>
            {
                rSeries.StartAnimation();
                rSeries.IsVisible = true;
            });
        }
    }
}