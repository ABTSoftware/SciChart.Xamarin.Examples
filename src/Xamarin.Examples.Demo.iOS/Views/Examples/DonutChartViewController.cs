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
    [ExampleDefinition("Donut Chart", description: "Creates a simple donut chart", icon: ExampleIcon.LineChart)]
    public class DonutChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SinglePieChartViewLayout);

        public SCIPieChartSurface Surface => ((SinglePieChartViewLayout)View).SciPieChartSurface;

        SCIDonutRenderableSeries donutSeries = new SCIDonutRenderableSeries();

        protected override void InitExample()
        {
            donutSeries.IsVisible = false;
            donutSeries.Segments.Add(BuildSegmentWithValue(40, "Green", new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829)));
            donutSeries.Segments.Add(BuildSegmentWithValue(10, "Red", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            donutSeries.Segments.Add(BuildSegmentWithValue(20, "Blue", new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD)));
            donutSeries.Segments.Add(BuildSegmentWithValue(15, "Yellow", new SCIRadialGradientBrushStyle(0xffFFFF00, 0xfffed325)));
            donutSeries.DrawLabels = true;

            Surface.RenderableSeries.Add(donutSeries);
            Surface.HoleRadius = 100;
            Surface.BackgroundColor = UIColor.White;

            var legendModifier = new SCIPieLegendModifier();
            legendModifier.Position = SCILegendPosition.Bottom;
			legendModifier.SourceSeries = donutSeries;

            Surface.ChartModifiers.Add(legendModifier);
            Surface.ChartModifiers.Add(new SCIPieSelectionModifier());

            Task.Run(() =>
            {
                donutSeries.StartAnimation();
                donutSeries.IsVisible = true;
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
            drawLabelsSwitch.On = donutSeries.DrawLabels;
            drawLabelsSwitch.AddTarget((sender, e) =>
            {
                donutSeries.DrawLabels = (sender as UISwitch).On;
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
