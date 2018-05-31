using System;
using System.Threading.Tasks;
using CoreGraphics;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Pie Chart", description: "Creates a simple pie chart", icon: ExampleIcon.LineChart)]
    public class PieChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SinglePieChartViewLayout);

        public SCIPieChartSurface Surface => ((SinglePieChartViewLayout)View).SciPieChartSurface;

        SCIPieRenderableSeries pieSeries = new SCIPieRenderableSeries();

        protected override void InitExample()
        {
            pieSeries.IsVisible = false;
            pieSeries.Segments.Add(BuildSegmentWithValue(40, "Green", new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829)));
            pieSeries.Segments.Add(BuildSegmentWithValue(10, "Red", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            pieSeries.Segments.Add(BuildSegmentWithValue(20, "Blue", new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD)));
            pieSeries.Segments.Add(BuildSegmentWithValue(15, "Yellow", new SCIRadialGradientBrushStyle(0xffFFFF00, 0xfffed325)));
            pieSeries.DrawLabels = true;

            Surface.RenderableSeries.Add(pieSeries);

            var legendModifier = new SCIPieLegendModifier();
            legendModifier.Position = SCILegendPosition.Bottom;
			legendModifier.SourceSeries = pieSeries;

            Surface.ChartModifiers.Add(legendModifier);
            Surface.ChartModifiers.Add(new SCIPieSelectionModifier());

            Task.Run(() =>
            {
                pieSeries.StartAnimation();
                pieSeries.IsVisible = true;
            });
        }

        SCIPieSegment BuildSegmentWithValue(double segmentValue, string title, SCIRadialGradientBrushStyle gradientBrush)
        {
            var segment = new SCIPieSegment();
            segment.FillStyle = gradientBrush;
            segment.Value = segmentValue;
            segment.Title = title;
            segment.CenterOffset = 1;
            return segment;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var drawLabelsSwitch = new UISwitch(new CGRect(View.Frame.Size.Width - 180, 20, 0, 0));
            drawLabelsSwitch.On = pieSeries.DrawLabels;
            drawLabelsSwitch.AddTarget((sender, e) =>
            {
                pieSeries.DrawLabels = (sender as UISwitch).On;
                Surface.InvalidateElement();
            }, UIControlEvent.ValueChanged);

            var drawLabelsLabel = new UILabel(new CGRect(View.Frame.Size.Width - 120, 20, 110, 30));
            drawLabelsLabel.Text = "Draw Labels";
            drawLabelsLabel.TextColor = UIColor.White;

            Surface.AddSubview(drawLabelsLabel);
            Surface.AddSubview(drawLabelsSwitch);
        }
    }
}