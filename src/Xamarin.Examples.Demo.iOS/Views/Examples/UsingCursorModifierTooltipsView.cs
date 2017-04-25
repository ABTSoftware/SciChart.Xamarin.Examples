﻿using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using CursorModifier Tooltips",  description:"Demonstrates Cursors on the Chart")]
    public class UsingCursorModifierTooltipsView : ExampleBaseView
    {
        private const int PointsCount = 500;

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

            var xAxis = new SCINumericAxis {VisibleRange = new SCIDoubleRange(3, 6)};
            var yAxis = new SCINumericAxis {AutoRange = SCIAutoRange.Always, GrowBy = new SCIDoubleRange(0.05d, 0.05d) };

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Green Series"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Red Series"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "Gray Series"};
            var ds4 = new XyDataSeries<double, double> {SeriesName = "Gold Series"};

            var data1 = DataManager.Instance.GetNoisySinewave(300, 1, PointsCount, 0.25);
            var data2 = DataManager.Instance.GetSinewave(100, 2, PointsCount);
            var data3 = DataManager.Instance.GetSinewave(200, 1.5, PointsCount);
            var data4 = DataManager.Instance.GetSinewave(50, 0.1, PointsCount);

            ds1.Append(data1.XData, data1.YData);
            ds2.Append(data2.XData, data2.YData);
            ds3.Append(data3.XData, data3.YData);
            ds4.Append(data4.XData, data4.YData);

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds1, Style = {LinePen = new SCISolidPenStyle(0xFF177B17, 2f)}});
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds2, Style = {LinePen = new SCISolidPenStyle(0xFFDD0909, 2f)}});
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds3, Style = {LinePen = new SCISolidPenStyle(0xFF808080, 2f)}});
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds4, Style = {LinePen = new SCISolidPenStyle(0xFFFFD700, 2f)}, IsVisible = false});

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCICursorModifier
                {
                    //ShowAxisLabels = true,
                    //ShowTooltip = true,
                }
            });

            Surface.InvalidateElement();
        }
    }
}