using System;
using System.Linq;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Components;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using ThemeManager", description: "Change chart theme using the ThemeManager", icon: ExampleIcon.Themes)]
    public class UsingThemeManagerViewController : ExampleBaseViewController
    {
        private const string SCIChart_BerryBlueStyleKey = "SciChart_BerryBlue";

        private static readonly string[] ThemeNames =
        {
            "Black Steel",
            "Bright Spark",
            "Chrome",
            "Chart V4 Dark",
            "Electric",
            "Expression Dark",
            "Expression Light",
            "Oscilloscope",
            "Berry Blue"
        };

        private static readonly string[] ThemeKeys =
        {
            SCIThemeManager.SCIChart_BlackSteelStyleKey,
            SCIThemeManager.SCIChart_Bright_SparkStyleKey,
            SCIThemeManager.SCIChart_ChromeStyleKey,
            SCIThemeManager.SCIChart_SciChartv4DarkStyleKey,
            SCIThemeManager.SCIChart_ElectricStyleKey,
            SCIThemeManager.SCIChart_ExpressionDarkStyleKey,
            SCIThemeManager.SCIChart_ExpressionLightStyleKey,
            SCIThemeManager.SCIChart_OscilloscopeStyleKey,
            SCIChart_BerryBlueStyleKey
        };

		public override Type ExampleViewType => typeof(UsingThemeManagerLayout);

		public SCIChartSurface Surface => ((UsingThemeManagerLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            InitializeUIHandlers();

            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(150, 180) };

            var yRightAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                AxisAlignment = SCIAxisAlignment.Right,
                AutoRange = SCIAutoRange.Always,
                AxisId = "PrimaryAxisId",
                Style =
                {
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                },
                LabelProvider = new ThousandsLabelProvider(),
            };

            var yLeftAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0, 3d),
                AxisAlignment = SCIAxisAlignment.Left,
                AutoRange = SCIAutoRange.Always,
                AxisId = "SecondaryAxisId",
                Style =
                {
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                },
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

            var mountainRenderableSeries = new SCIFastMountainRenderableSeries { DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId" };
            var lineRenderableSeries = new SCIFastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId" };
            var columnRenderableSeries = new SCIFastColumnRenderableSeries { DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickRenderableSeries = new SCIFastCandlestickRenderableSeries { DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId" };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yRightAxis);
                Surface.YAxes.Add(yLeftAxis);
                Surface.RenderableSeries.Add(mountainRenderableSeries);
                Surface.RenderableSeries.Add(lineRenderableSeries);
                Surface.RenderableSeries.Add(columnRenderableSeries);
                Surface.RenderableSeries.Add(candlestickRenderableSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCILegendModifier {ShowCheckBoxes = false},
                    new SCICursorModifier(),
                    new SCIZoomExtentsModifier()
                };
            }

            SCIThemeManager.ApplyDefaultTheme(Surface);
            ((UsingThemeManagerLayout)View).SelectThemeButton.SetTitle(SCIThemeManager.SCIChart_DefaultThemeKey, UIControlState.Normal);
        }

        private void InitializeUIHandlers()
        {
            ((UsingThemeManagerLayout)View).SelectThemeButton.TouchUpInside += (sender, args) =>
            {
                var actionSheetAlert = UIAlertController.Create("Select Theme", null, UIAlertControllerStyle.ActionSheet);

                foreach (var themeName in ThemeNames)
                {
                    var themeAction = UIAlertAction.Create(themeName, UIAlertActionStyle.Default, action =>
                    {
                        SCIThemeManager.ApplyTheme(Surface, ThemeKeys[Array.IndexOf(ThemeNames, themeName)]);
                        ((UsingThemeManagerLayout)View).SelectThemeButton.SetTitle(themeName, UIControlState.Normal);
                    });
                    actionSheetAlert.AddAction(themeAction);
                }

                actionSheetAlert.AddAction(UIAlertAction.Create("Cansel", UIAlertActionStyle.Cancel, null));

                if (actionSheetAlert.PopoverPresentationController != null)
                {
                    actionSheetAlert.PopoverPresentationController.SourceView = View;
                    actionSheetAlert.PopoverPresentationController.SourceRect = ((UIButton)sender).Frame;
                }

                ((UsingThemeManagerLayout)View).Window.RootViewController.PresentViewController(actionSheetAlert, true, null);
            };
        }
    }
}