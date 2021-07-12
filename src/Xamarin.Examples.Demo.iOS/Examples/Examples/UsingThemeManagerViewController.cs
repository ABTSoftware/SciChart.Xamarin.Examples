using System.Linq;
using UIKit;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using System.Collections.Generic;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Using ThemeManager", description: "Change chart theme using the ThemeManager", icon: ExampleIcon.Themes)]
    public class UsingThemeManagerViewController : SingleChartWithTopPanelViewController<SCIChartSurface>
    {
        private static readonly Dictionary<string, string> _themesDictionary = new Dictionary<string, string>
        {
            { "Black Steel", SCIThemeManager.BlackSteel },
            { "Bright Spark", SCIThemeManager.BrightSpark },
            { "Chrome", SCIThemeManager.Chrome },
            { "Chart V4 Dark", SCIThemeManager.V4Dark },
            { "Electric", SCIThemeManager.Electric },
            { "Expression Dark", SCIThemeManager.ExpressionDark },
            { "Expression Light", SCIThemeManager.ExpressionLight },
            { "Oscilloscope", SCIThemeManager.Oscilloscope },
        };
        private readonly UIButton SelectThemeButton = new UIButton(UIButtonType.RoundedRect);

        public override UIView ProvidePanel()
        {
            SelectThemeButton.SetTitle("Select Theme", UIControlState.Normal);
            SelectThemeButton.TouchUpInside += (sender, args) =>
            {
                var actionSheetAlert = UIAlertController.Create("Select Theme", null, UIAlertControllerStyle.ActionSheet);

                foreach (var themeName in _themesDictionary.Keys)
                {
                    var themeAction = UIAlertAction.Create(themeName, UIAlertActionStyle.Default, action => SetTheme(themeName));
                    actionSheetAlert.AddAction(themeAction);
                }
                actionSheetAlert.AddAction(UIAlertAction.Create("Cansel", UIAlertActionStyle.Cancel, null));

                if (actionSheetAlert.PopoverPresentationController != null)
                {
                    actionSheetAlert.PopoverPresentationController.SourceView = View;
                    actionSheetAlert.PopoverPresentationController.SourceRect = ((UIButton)sender).Frame;
                }

                View.Window.RootViewController.PresentViewController(actionSheetAlert, true, null);
            };

            return SelectThemeButton;
        }

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(150, 180) };
            
            var yRightAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                AxisAlignment = SCIAxisAlignment.Right,
                AutoRange = SCIAutoRange.Always,
                AxisId = "PrimaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new ThousandsLabelProvider(),
            };

            var yLeftAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0, 3d),
                AxisAlignment = SCIAxisAlignment.Left,
                AutoRange = SCIAutoRange.Always,
                AxisId = "SecondaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new BillionsLabelProvider(),
            };

            var dataManager = DataManager.Instance;
            var priceBars = dataManager.GetPriceDataIndu();

            var mountainDataSeries = new XyDataSeries<double, double> { SeriesName = "Mountain Series" };
            var lineDataSeries = new XyDataSeries<double, double> { SeriesName = "Line Series" };
            var columnDataSeries = new XyDataSeries<double, long> { SeriesName = "Column Series" };
            var candlestickDataSeries = new OhlcDataSeries<double, double> { SeriesName = "Candlestick Series" };

            var xValues = Enumerable.Range(0, priceBars.Count).Select(x => (double)x).ToArray();

            mountainDataSeries.Append(xValues, priceBars.LowData.Select(x => x - 1000d));
            lineDataSeries.Append(xValues, dataManager.ComputeMovingAverage(priceBars.CloseData, 50));
            columnDataSeries.Append(xValues, priceBars.VolumeData);
            candlestickDataSeries.Append(xValues, priceBars.OpenData, priceBars.HighData, priceBars.LowData, priceBars.CloseData);

            var mountainSeries = new SCIFastMountainRenderableSeries { DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId" };
            var lineSeries = new SCIFastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId" };
            var columnSeries = new SCIFastColumnRenderableSeries { DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickSeries = new SCIFastCandlestickRenderableSeries { DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId" };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yRightAxis);
                Surface.YAxes.Add(yLeftAxis);
                Surface.RenderableSeries = new SCIRenderableSeriesCollection { mountainSeries, lineSeries, columnSeries, candlestickSeries };
                Surface.ChartModifiers.Add(CreateDefaultModifiers());
                Surface.ChartModifiers.Add(new SCILegendModifier { ShowCheckBoxes = false });

                SCIAnimations.ScaleSeriesWithZeroLine(mountainSeries, 10500, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(lineSeries, 11700, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(columnSeries, 12250, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(candlestickSeries, 10500, 3, new SCIElasticEase());

            }
            SetTheme(_themesDictionary.ElementAt(3).Key);
        }

        private void SetTheme(string themeName)
        {
            SCIThemeManager.ApplyTheme(_themesDictionary[themeName], Surface);
            SelectThemeButton.SetTitle(themeName, UIControlState.Normal);
        }    }
}