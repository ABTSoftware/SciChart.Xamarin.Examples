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
    [ExampleDefinition("Nested Pie Chart", description: "Creates a simple donut chart", icon: ExampleIcon.LineChart)]
    public class NestedPieChartsViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SinglePieChartViewLayout);

        public SCIPieChartSurface Surface => ((SinglePieChartViewLayout)View).SciPieChartSurface;

        SCIPieRenderableSeries pieSeries = new SCIPieRenderableSeries();
        SCIPieRenderableSeries donutSeries = new SCIPieRenderableSeries();

        protected override void InitExample()
        {
            pieSeries.IsVisible = false;
            pieSeries.Segments.Add(BuildSegmentWithValue(34, "Ecologic", new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829)));
            pieSeries.Segments.Add(BuildSegmentWithValue(34.4, "Municipal", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            pieSeries.Segments.Add(BuildSegmentWithValue(31.6, "Personal", new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD)));
            pieSeries.DrawLabels = true;

            donutSeries.IsVisible = false;
            donutSeries.Segments.Add(BuildSegmentWithValue(28.8, "Walking", new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829)));
            donutSeries.Segments.Add(BuildSegmentWithValue(5.2, "Bycicle", new SCIRadialGradientBrushStyle(0xff84BC3D, 0xff5B8829)));
            donutSeries.Segments.Add(BuildSegmentWithValue(12.3, "Metro", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            donutSeries.Segments.Add(BuildSegmentWithValue(3.5, "Tram", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            donutSeries.Segments.Add(BuildSegmentWithValue(5.9, "Rail", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            donutSeries.Segments.Add(BuildSegmentWithValue(9.7, "Bus", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            donutSeries.Segments.Add(BuildSegmentWithValue(3, "Taxi", new SCIRadialGradientBrushStyle(0xffe04a2f, 0xffB7161B)));
            donutSeries.Segments.Add(BuildSegmentWithValue(23.1, "Car", new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD)));
            donutSeries.Segments.Add(BuildSegmentWithValue(3.1, "Motor", new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD)));
            donutSeries.Segments.Add(BuildSegmentWithValue(5.3, "Other", new SCIRadialGradientBrushStyle(0xff4AB6C1, 0xff2182AD)));
            donutSeries.DrawLabels = true;

            var legendModifier = new SCIPieLegendModifier();
            legendModifier.Position = SCILegendPosition.Bottom;
            legendModifier.SourceSeries = pieSeries;

            Surface.ChartModifiers.Add(legendModifier);

            Surface.RenderableSeries.Add(pieSeries);
            Surface.RenderableSeries.Add(donutSeries);

            Task.Run(() =>
            {
                pieSeries.StartAnimation();
                pieSeries.IsVisible = true;
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
            drawLabelsSwitch.On = pieSeries.DrawLabels;
            drawLabelsSwitch.AddTarget((sender, e) =>
            {
                pieSeries.DrawLabels = (sender as UISwitch).On;
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