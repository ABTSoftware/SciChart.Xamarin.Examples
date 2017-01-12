﻿using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Mountain Chart")]
    public class MountainChartView : ExampleBaseView
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        protected override void UpdateFrame()
        {
            _exampleViewLayout.SciChartSurfaceView.Frame = _exampleViewLayout.Frame;
            _exampleViewLayout.SciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleViewLayout.SciChartSurfaceView);

            var priceData = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new XyDataSeries<DateTime, double> {DataDistributionCalculator = new SCIUserDefinedDistributionCalculator()};
            dataSeries.Append(priceData.TimeData, priceData.CloseData);

            var xAxis = new SCIDateTimeAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};

            var renderSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = dataSeries,
                Style =
                {
                    AreaBrush = new SCIBrushLinearGradient(0xAAFF8D42, 0x88090E11, SCILinearGradientDirection.Vertical),
                    BorderPen = new SCIPenSolid(0xaaffc9a8, 0.7f)
                }
            };

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(renderSeries);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();
        }
    }
}