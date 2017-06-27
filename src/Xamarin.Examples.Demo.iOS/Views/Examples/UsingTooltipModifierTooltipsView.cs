using System.Collections.Generic;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using TooltipModifier Tooltips", description: "Demonstrates a simple tooltip", icon: ExampleIcon.Annotations)]
    public class UsingTooltipModifierTooltipsView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint constraintRight = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint constraintLeft = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint constraintTop = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint constraintBottom = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0);

            this.AddConstraint(constraintRight);
            this.AddConstraint(constraintLeft);
            this.AddConstraint(constraintTop);
            this.AddConstraint(constraintBottom);
        }

        protected override void InitExampleInternal()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), AutoRange = SCIAutoRange.Always };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var ds1 = new XyDataSeries<double, double> { SeriesName = "Lissajous Curve", AcceptUnsortedData = true };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "Sinewave", AcceptUnsortedData = true };

            var ds1Points = DataManager.Instance.GetLissajousCurve(0.8, 0.2, 0.43, 500);
            var ds2Points = DataManager.Instance.GetSinewave(1.5, 1.0, 500);

            var scaledXValues = GetScaledValues(ds1Points.XData);

            ds1.Append(scaledXValues, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);

            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds1,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Width = 5,
                    Height = 5,
                    StrokeStyle = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                    FillStyle = new SCISolidBrushStyle(ColorUtil.SteelBlue)
                }
            });
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds2,
                StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 2f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Width = 5,
                    Height = 5,
                    StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 2f),
                    FillStyle = new SCISolidBrushStyle(0xFFFF3333)
                }
            });

            Surface.ChartModifiers = new SCIChartModifierCollection(
                new SCITooltipModifier
                {
                    Style = { HitTestMode = SCIHitTestMode.Interpolate },
                    //ShowAxisLabels = true,
                    //ShowTooltip = true,
                }
            );
        }

        private static IList<double> GetScaledValues(IList<double> values)
        {
            var size = values.Count;

            var scaledValues = new List<double>(size);

            for (var i = 0; i < size; i++)
            {
                var value = values[i];
                scaledValues.Add((value + 1) * 5);
            }

            return scaledValues;
        }
    }
}