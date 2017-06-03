﻿using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("ErrorBars Chart", description:"Demonstrates Error Bars showing point uncertainty", icon: ExampleIcon.ErrorBars)]
    public class ErrorBarsChartView : ExampleBaseView<SingleChartViewLayout>
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
            var data0 = DataManager.Instance.GetFourierSeries(1.0, 0.1);

            var dataSeries = new HlDataSeries<double, double>();

            var xAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};

            var verticalRenderableSeries = new SCIFastErrorBarsRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle( new UIColor( 70.0f / 255.0f, 130.0f / 255.0f, 180.0f / 255.0f, 1.0f), 0.7f)
            };

            var horizontalRenderableSeries = new SCIFastFixedErrorBarsRenderableSeries
            {
                DataSeries = dataSeries,
                ErrorDirection = SCIErrorBarDirection.Horizontal,
                DataPointWidth = 0.5,
                StrokeStyle = new SCISolidPenStyle(UIColor.Red, 0.7f)
            };

            var renderSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(new UIColor(176.0f / 255.0f, 196.0f / 255.0f, 222.0f / 255.0f, 1.0f), 0.7f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Width = 15,
                    Height = 15,
                    StrokeStyle = new SCISolidPenStyle(new UIColor(176.0f / 255.0f, 196.0f / 255.0f, 222.0f / 255.0f, 1.0f), 1.0f),
                    FillStyle = new SCISolidBrushStyle(new UIColor(70.0f / 255.0f, 130.0f / 255.0f, 180.0f / 255.0f, 1.0f))
                }
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(verticalRenderableSeries);
            Surface.RenderableSeries.Add(horizontalRenderableSeries);
            Surface.RenderableSeries.Add(renderSeries);

            Surface.ChartModifiers = new SCIChartModifierCollection(
				new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            );

            Surface.InvalidateElement();
        }

        private void fillDataSeries(HlDataSeries<double, double> dataSeries, XyDataSeries<double, double> sourceData, double scale){
            for (var i = 0; i < sourceData.Count; i++){
                //double y = sourceData.YValues.ValueAt(i) * scale; // should be: sourceData[i] * scale
            }
        }
    }
}