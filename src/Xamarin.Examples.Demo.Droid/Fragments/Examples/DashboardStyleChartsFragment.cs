using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Dashboard Style Charts")]
    public class DashboardStyleChartsFragment : ExampleBaseFragment
    {
        public TabLayout TabLayout => View.FindViewById<TabLayout>(Resource.Id.tabLayout);
        public ViewPager ViewPager => View.FindViewById<ViewPager>(Resource.Id.viewpager);

        private readonly IList<ChartTypeModel> _chartTypesSource = new List<ChartTypeModel>();
        private static readonly int[] SeriesColors = new int[DashboardDataHelper.Colors.Length];

        public override int ExampleLayoutId => Resource.Layout.Example_Dashboard_Style_Charts_Fragment;

        protected override void InitExample()
        {
            for (int i = 0; i < DashboardDataHelper.Colors.Length; i++)
            {
                int color = Resources.GetColor(DashboardDataHelper.Colors[i]);
                SeriesColors[i] = color;
            }

            _chartTypesSource.Add(ChartTypeModelFactory.NewHorizontallyStackedColumns(Activity));
            _chartTypesSource.Add(ChartTypeModelFactory.NewVerticallyStackedColumns(Activity, false));
            _chartTypesSource.Add(ChartTypeModelFactory.NewVerticallyStackedColumns(Activity, true));
            _chartTypesSource.Add(ChartTypeModelFactory.NewVerticallyStackedMountains(Activity, false));
            _chartTypesSource.Add(ChartTypeModelFactory.NewVerticallyStackedMountains(Activity, true));

            //this line fixes swiping lag of the viewPager by caching the pages
            ViewPager.OffscreenPageLimit = 5;
            ViewPager.Adapter = new ViewPagerAdapter(Activity.BaseContext, _chartTypesSource);
            TabLayout.SetupWithViewPager(ViewPager);
        }

        class ViewPagerAdapter : PagerAdapter
        {
            private readonly Context _context;
            private readonly IList<ChartTypeModel> _chartTypesSource;

            public ViewPagerAdapter(Context context, IList<ChartTypeModel> chartTypesSource)
            {
                _context = context;
                _chartTypesSource = chartTypesSource;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                var inflater = LayoutInflater.From(_context);
                var chartView = inflater.Inflate(Resource.Layout.Example_Single_Chart_Fragment, container, false);

                var chartTypeModel = _chartTypesSource[position];

                UpdateSurface(chartTypeModel, chartView);
                container.AddView(chartView);

                return chartView;
            }

            private void UpdateSurface(ChartTypeModel chartTypeModel, View chartView)
            {
                var surface = (SciChartSurface) chartView.FindViewById(Resource.Id.chart);
                var xAxis = new NumericAxis(_context);
                var yAxis = new NumericAxis(_context);

                var seriesCollection = chartTypeModel.SeriesCollection;

                using (surface.SuspendUpdates())
                {
                    surface.XAxes.Add(xAxis);
                    surface.YAxes.Add(yAxis);
                    surface.RenderableSeries.Add(seriesCollection);
                }
            }

            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
            {
                container.RemoveView(container);
            }

            public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
            {
                var chartTypeModel = _chartTypesSource[position];
                return chartTypeModel.TypeName;
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object @object)
            {
                return view == @object;
            }

            public override int Count => _chartTypesSource.Count;
        }

        private static class ChartTypeModelFactory
        {
            public static ChartTypeModel NewHorizontallyStackedColumns(Context context)
            {
                var seriesCollection = new HorizontallyStackedColumnsCollection();
                for (var i = 0; i < 5; i++)
                {
                    var dataSeries = new XyDataSeries<double, double> {SeriesName = "Series " + (i + 1) };
                    dataSeries.Append(DashboardDataHelper.XValues, DashboardDataHelper.YValues[i]);

                    var rSeries = new StackedColumnRenderableSeries
                    {
                        DataSeries = dataSeries,
                        StrokeStyle = new SolidPenStyle(context, new Color(SeriesColors[i * 2])),
                        FillBrushStyle = new LinearGradientBrushStyle(0,0,0,1, new Color(SeriesColors[i * 2 + 1]), new Color(SeriesColors[i * 2]), TileMode.Clamp)

                    };
                    seriesCollection.Add(rSeries);
                }

                const string name = "Stacked columns side-by-side";
                return new ChartTypeModel(seriesCollection, name);
            }

            public static ChartTypeModel NewVerticallyStackedColumns(Context context, bool isOneHundredPercent)
            {
                var collection = new VerticallyStackedColumnsCollection {IsOneHundredPercent = isOneHundredPercent};
                for (var i = 0; i < 5; i++)
                {
                    var dataSeries = new XyDataSeries<double, double> { SeriesName = "Series " + (i + 1) };
                    dataSeries.Append(DashboardDataHelper.XValues, DashboardDataHelper.YValues[i]);

                    var rSeries = new StackedColumnRenderableSeries
                    {
                        DataSeries = dataSeries,
                        StrokeStyle = new SolidPenStyle(context, new Color(SeriesColors[i * 2])),
                        FillBrushStyle = new LinearGradientBrushStyle(0, 0, 0, 1, new Color(SeriesColors[i * 2 + 1]), new Color(SeriesColors[i * 2]), TileMode.Clamp)

                    };
                    collection.Add(rSeries);
                }

                var name = isOneHundredPercent ? "100% " : "";
                name += "Stacked columns";
                return new ChartTypeModel(collection, name);
            }

            public static ChartTypeModel NewVerticallyStackedMountains(Context context, bool isOneHundredPercent)
            {
                var collection = new VerticallyStackedMountainsCollection {IsOneHundredPercent = isOneHundredPercent};
                for (var i = 0; i < 5; i++)
                {
                    var dataSeries = new XyDataSeries<double, double> { SeriesName = "Series " + (i + 1) };
                    dataSeries.Append(DashboardDataHelper.XValues, DashboardDataHelper.YValues[i]);

                    var rSeries = new StackedMountainRenderableSeries
                    {
                        DataSeries = dataSeries,
                        StrokeStyle = new SolidPenStyle(context, new Color(SeriesColors[i * 2])),
                        AreaStyle = new LinearGradientBrushStyle(0, 0, 0, 1, new Color(SeriesColors[i * 2 + 1]), new Color(SeriesColors[i * 2]), TileMode.Clamp)

                    };
                    collection.Add(rSeries);
                }

                var name = isOneHundredPercent ? "100% " : "";
                name += "Stacked mountains";
                return new ChartTypeModel(collection, name);
            }
        }

        static class DashboardDataHelper
        {
            public static double[] XValues { get; } = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};

            public static double[][] YValues { get; } =
                {
                    new double[] {10, 13, 7, 16, 4, 6, 20, 14, 16, 10, 24, 11},
                    new double[] {12, 17, 21, 15, 19, 18, 13, 21, 22, 20, 5, 10},
                    new double[] {7, 30, 27, 24, 21, 15, 17, 26, 22, 28, 21, 22},
                    new double[] {16, 10, 9, 8, 22, 14, 12, 27, 25, 23, 17, 17},
                    new double[] {7, 24, 21, 11, 19, 17, 14, 27, 26, 22, 28, 16}
                };

            public static int[] Colors { get; } =
                {
                    Resource.Color.dashboard_chart_blue_series_0, Resource.Color.dashboard_chart_blue_series_1,
                    Resource.Color.dashboard_chart_orange_series_0, Resource.Color.dashboard_chart_orange_series_1,
                    Resource.Color.dashboard_chart_red_series_0, Resource.Color.dashboard_chart_red_series_1,
                    Resource.Color.dashboard_chart_green_series_0, Resource.Color.dashboard_chart_green_series_1,
                    Resource.Color.dashboard_chart_violet_series_0, Resource.Color.dashboard_chart_violet_series_1
                };
        }

        class ChartTypeModel
        {
            public ChartTypeModel(StackedSeriesCollectionBase seriesCollection, string header)
            {
                SeriesCollection = seriesCollection;
                TypeName = new Java.Lang.String(header);
            }

            public StackedSeriesCollectionBase SeriesCollection { get; }
            public Java.Lang.String TypeName { get; }
        }
    }
}