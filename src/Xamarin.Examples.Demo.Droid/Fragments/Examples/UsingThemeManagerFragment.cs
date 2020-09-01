using System.Linq;
using Android.Views.Animations;
using Android.Widget;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Themes;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Using ThemeManager", description:"Change chart theme using the ThemeManager", icon: ExampleIcon.Themes)]
    public class UsingThemeManagerFragment : ExampleBaseFragment
    {
        private const int BlackSteel = 0;
        private const int BrightSpark = 1;
        private const int Chrome = 2;
        private const int Electric = 3;
        private const int ExpressionDark = 4;
        private const int ExpressionLight = 5;
        private const int Oscilloscope = 6;
        private const int SciChartV4Dark = 7;

        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);
        public Spinner ThemeSelector => View.FindViewById<Spinner>(Resource.Id.themeSelector);

        public override int ExampleLayoutId => Resource.Layout.Example_Theme_Provider_Chart_Fragment;

        protected override void InitExample()
        {
            InitializeUIHandlers();

            var xAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1), VisibleRange = new DoubleRange(150, 180)};

            var yRightAxis = new NumericAxis(Activity)
            {
                GrowBy = new DoubleRange(0.1, 0.1),
                AxisAlignment = AxisAlignment.Right,
                AutoRange = AutoRange.Always,
                AxisId = "PrimaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new ThousandsLabelProvider(),
            };

            var yLeftAxis = new NumericAxis(Activity)
            {
                GrowBy = new DoubleRange(0, 3d),
                AxisAlignment = AxisAlignment.Left,
                AutoRange = AutoRange.Always,
                AxisId = "SecondaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new BillionsLabelProvider(),
            };

            var dataManager = DataManager.Instance;
            var priceBars = dataManager.GetPriceDataIndu();

            var mountainDataSeries = new XyDataSeries<double, double> {SeriesName = "Mountain Series"};
            var lineDataSeries = new XyDataSeries<double, double> {SeriesName = "Line Series" };
            var columnDataSeries = new XyDataSeries<double, long> {SeriesName = "Column Series" };
            var candlestickDataSeries = new OhlcDataSeries<double, double> {SeriesName = "Candlestick Series"};

            var xValues = Enumerable.Range(0, priceBars.Count).Select(x => (double) x).ToArray();

            mountainDataSeries.Append(xValues, priceBars.LowData.Select(x => x - 1000d));
            lineDataSeries.Append(xValues, dataManager.ComputeMovingAverage(priceBars.CloseData, 50));
            columnDataSeries.Append(xValues, priceBars.VolumeData);
            candlestickDataSeries.Append(xValues, priceBars.OpenData, priceBars.HighData, priceBars.LowData, priceBars.CloseData);

            var mountainSeries = new FastMountainRenderableSeries {DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId"};
            var lineSeries = new FastLineRenderableSeries {DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId"};
            var columnSeries = new FastColumnRenderableSeries {DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickSeries = new FastCandlestickRenderableSeries {DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId"};

            var legendModifier = new LegendModifier(Activity);
            legendModifier.SetShowCheckboxes(false);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yRightAxis);
                Surface.YAxes.Add(yLeftAxis);
                Surface.RenderableSeries.Add(mountainSeries);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(columnSeries);
                Surface.RenderableSeries.Add(candlestickSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    legendModifier,
                    new CursorModifier(),
                    new ZoomExtentsModifier(),
                };

                new ScaleAnimatorBuilder(mountainSeries, 10500d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
                new ScaleAnimatorBuilder(candlestickSeries, 11700d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
                new ScaleAnimatorBuilder(lineSeries, 12250d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
                new ScaleAnimatorBuilder(columnSeries, 10500d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
            }
        }

        private void InitializeUIHandlers()
        {
            ThemeSelector.Adapter = new SpinnerStringAdapter(Activity, Resource.Array.style_list);
            ThemeSelector.SetSelection(7);
            ThemeSelector.ItemSelected += (sender, args) => { SetTheme(args.Position); };
        }

        private void SetTheme(int position)
        {
            int themeId;
            switch (position)
            {
                case BlackSteel:
                    themeId = Resource.Style.SciChart_BlackSteel;
                    break;
                case BrightSpark:
                    themeId = Resource.Style.SciChart_Bright_Spark;
                    break;
                case Chrome:
                    themeId = Resource.Style.SciChart_ChromeStyle;
                    break;
                case Electric:
                    themeId = Resource.Style.SciChart_ElectricStyle;
                    break;
                case ExpressionDark:
                    themeId = Resource.Style.SciChart_ExpressionDarkStyle;
                    break;
                case ExpressionLight:
                    themeId = Resource.Style.SciChart_ExpressionLightStyle;
                    break;
                case Oscilloscope:
                    themeId = Resource.Style.SciChart_OscilloscopeStyle;
                    break;
                case SciChartV4Dark:
                    themeId = Resource.Style.SciChart_SciChartv4DarkStyle;
                    break;

                default:
                    themeId = ThemeManager.DefaultTheme;
                    break;
            }

            Surface.Theme =  themeId;
        }
    }
}