using System;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Pie Chart", description: "Creates a simple pie chart", icon: ExampleIcon.LineChart)]
    public class PieChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SinglePieChartViewLayout);

        public SCIPieChartSurface Surface => ((SinglePieChartViewLayout)View).SciPieChartSurface;

        protected override void InitExample()
        {
            SCIPieChartSurface.SetRuntimeLicenseKey("");

            var pieSeries = new SCIPieRenderableSeries();

            pieSeries.Segments.Add(BuildSegmentWithValue(40, "Green", new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829)));
            pieSeries.Segments.Add(BuildSegmentWithValue(10, "Red", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            pieSeries.Segments.Add(BuildSegmentWithValue(20, "Blue", new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD)));
            pieSeries.Segments.Add(BuildSegmentWithValue(15, "Yellow", new SCIRadialGradientBrushStyle(0xffFFFF00, 0xfffed325)));

            Surface.RenderableSeries.Add(pieSeries);

            var legendModifier = new SCIPieLegendModifier();
            legendModifier.Position = SCILegendPosition.Bottom;
            legendModifier.PieSeries = pieSeries;

            Surface.ChartModifiers.Add(legendModifier);
        }

        SCIPieSegment BuildSegmentWithValue(double segmentValue, string title, SCIRadialGradientBrushStyle gradientBrush)
        {
            var segment = new SCIPieSegment();
            segment.FillStyle = gradientBrush;
            segment.Value = segmentValue;
            segment.Title = title;

            return segment;
        }
    }
}