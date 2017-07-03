using System;
using System.Collections.Generic;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Dashboard Style Charts", description: "Beautiful stacked charts with dynamic switching between chart type", icon: ExampleIcon.StackedColumns100)]
    public class DashboardStyleChartsView : ExampleBaseView<DashboardStyleChartsLayout>
    {
        private readonly DashboardStyleChartsLayout _dashboardLayout = DashboardStyleChartsLayout.Create();
        public override DashboardStyleChartsLayout ExampleViewLayout => _dashboardLayout;

        public SCIChartSurface Chart => _dashboardLayout.ChartView;

        private readonly List<ChartTypeModel> _examples = new List<ChartTypeModel>
        {
            ChartTypeFactory.NewHorizontallyStackedColumns(),
            ChartTypeFactory.NewVerticallyStackedColumns(false),
            ChartTypeFactory.NewVerticallyStackedColumns(true),
            ChartTypeFactory.NewVerticallyMountains(false),
            ChartTypeFactory.NewVerticallyMountains(true),
        };

        protected override void UpdateFrame()
        {
        }

        protected override void InitExampleInternal()
        {
            _dashboardLayout.ChartSelectorView.ValueChanged += (sender, e) =>
            {
                InitChart((sender as UISegmentedControl).SelectedSegment);
            };

            var xAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };
            var yAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };

            Chart.XAxes.Add(xAxis);
            Chart.YAxes.Add(yAxis);

            InitChart(_dashboardLayout.ChartSelectorView.SelectedSegment);
        }

        private void InitChart(nint selectedSegment)
        {
            var model = _examples[(int)selectedSegment];

            using (Chart.SuspendUpdates())
            {
                Chart.RenderableSeries.Clear();
                Chart.RenderableSeries.Add(model.SeriesCollection);
            }
        }

        static class ChartTypeFactory
        {
            public static ChartTypeModel NewHorizontallyStackedColumns()
            {
                var seriesCollection = new SCIHorizontallyStackedColumnsCollection();
                for (var i = 0; i < 5; i++)
                {
                    var dataSeries = new XyDataSeries<double, double>() { SeriesName = "Series " + (i + 1) };

                    dataSeries.Append(DashboardDataHelper.XValues, DashboardDataHelper.YValues[i]);

                    var rSeries = new SCIStackedColumnRenderableSeries()
                    {
                        DataSeries = dataSeries,
                        StrokeStyle = new SCISolidPenStyle(DashboardDataHelper.Colors[i * 2], 2f),
                        FillBrushStyle = new SCILinearGradientBrushStyle(DashboardDataHelper.Colors[i * 2 + 1], DashboardDataHelper.Colors[i * 2], SCILinearGradientDirection.Horizontal)
                    };

                    seriesCollection.Add(rSeries);
                }

                const string name = "Stacked columns side-by-side";
                return new ChartTypeModel(seriesCollection, name);
            }

            public static ChartTypeModel NewVerticallyStackedColumns(bool isOneHundredPercent)
            {
                var seriesCollection = new SCIVerticallyStackedColumnsCollection() { IsOneHundredPercentSeries = isOneHundredPercent };

                for (var i = 0; i < 5; i++)
                {
                    var dataSeries = new XyDataSeries<double, double>() { SeriesName = "Series " + (i + 1) };

                    dataSeries.Append(DashboardDataHelper.XValues, DashboardDataHelper.YValues[i]);

                    var rSeries = new SCIStackedColumnRenderableSeries()
                    {
                        DataSeries = dataSeries,
                        StrokeStyle = new SCISolidPenStyle(DashboardDataHelper.Colors[i * 2], 2f),
                        FillBrushStyle = new SCILinearGradientBrushStyle(DashboardDataHelper.Colors[i * 2 + 1], DashboardDataHelper.Colors[i * 2], SCILinearGradientDirection.Horizontal)
                    };

                    seriesCollection.Add(rSeries);
                }

                var name = (isOneHundredPercent ? "100%" : "") + "Stacked columns";
                return new ChartTypeModel(seriesCollection, name);
            }

            public static ChartTypeModel NewVerticallyMountains(bool isOneHundredPercent)
            {
                var seriesCollection = new SCIVerticallyStackedMountainsCollection() { IsOneHundredPercentSeries = isOneHundredPercent };

                for (var i = 0; i < 5; i++)
                {
                    var dataSeries = new XyDataSeries<double, double>() { SeriesName = "Series " + (i + 1) };

                    dataSeries.Append(DashboardDataHelper.XValues, DashboardDataHelper.YValues[i]);

                    var rSeries = new SCIStackedMountainRenderableSeries()
                    {
                        DataSeries = dataSeries,
                        StrokeStyle = new SCISolidPenStyle(DashboardDataHelper.Colors[i * 2], 2f),
                        AreaStyle = new SCILinearGradientBrushStyle(DashboardDataHelper.Colors[i * 2 + 1], DashboardDataHelper.Colors[i * 2], SCILinearGradientDirection.Horizontal)
                    };

                    seriesCollection.Add(rSeries);
                }

                var name = (isOneHundredPercent ? "100%" : "") + "Stacked mountains";
                return new ChartTypeModel(seriesCollection, name);
            }
        }

        class ChartTypeModel
        {
            public ChartTypeModel(SCIStackedSeriesCollectionBase seriesCollection, string header)
            {
                SeriesCollection = seriesCollection;
                TypeName = header;
            }

            public SCIStackedSeriesCollectionBase SeriesCollection { get; private set; }
            public string TypeName { get; private set; }
        }

        static class DashboardDataHelper
        {
            public static double[] XValues { get; } = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            public static double[][] YValues { get; } =
            {
                new double[] {10, 13, 7, 16, 4, 6, 20, 14, 16, 10, 24, 11},
                new double[] {12, 17, 21, 15, 19, 18, 13, 21, 22, 20, 5, 10},
                new double[] {7, 30, 27, 24, 21, 15, 17, 26, 22, 28, 21, 22},
                new double[] {16, 10, 9, 8, 22, 14, 12, 27, 25, 23, 17, 17},
                new double[] {7, 24, 21, 11, 19, 17, 14, 27, 26, 22, 28, 16}
            };

            public static uint[] Colors { get; } =
            {
                0xff226fb7, 0xff1b5790,
                0xffff9a2e, 0xffd27f26,
                0xffdc443f, 0xffbd3a36,
                0xffaad34f, 0xff91b443,
                0xff8562b4, 0xff664b8a
            };
        }
    }
}