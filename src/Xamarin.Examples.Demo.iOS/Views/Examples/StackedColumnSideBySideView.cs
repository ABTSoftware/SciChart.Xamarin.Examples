using System;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Stacked Column Side By Side Chart")]
    public class StackedColumnSideBySideView : ExampleBaseView
    {
        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis
            {
                IsXAxis = true,
                AutoTicks = false,
                //MajorDelta = 1,
                //MinorDelta = 0.5,
                //LabelProvider = new YearsLabelProvider(),
                Style = {DrawMajorBands = true}
            };

            var yAxis = new SCINumericAxis
            {
                AutoRange = SCIAutoRangeMode.Always,
                AxisTitle = "billions of People",
                GrowBy = new SCIDoubleRange(0, 0.1),
                Style = { DrawMajorBands = true }
            };

            var china = new[] { 1.269, 1.330, 1.356, 1.304 };
            var india = new[] { 1.004, 1.173, 1.236, 1.656 };
            var usa = new[] { 0.282, 0.310, 0.319, 0.439 };
            var indonesia = new[] { 0.214, 0.243, 0.254, 0.313 };
            var brazil = new[] { 0.176, 0.201, 0.203, 0.261 };
            var pakistan = new[] { 0.146, 0.184, 0.196, 0.276 };
            var nigeria = new[] { 0.123, 0.152, 0.177, 0.264 };
            var bangladesh = new[] { 0.130, 0.156, 0.166, 0.234 };
            var russia = new[] { 0.147, 0.139, 0.142, 0.109 };
            var japan = new[] { 0.126, 0.127, 0.127, 0.094 };
            var restOfTheWorld = new[] { 2.466, 2.829, 3.005, 4.306 };

            var chinaDataSeries = new XyDataSeries<double, double> {SeriesName = "China"};
            var indiaDataSeries = new XyDataSeries<double, double> {SeriesName = "India"};
            var usaDataSeries = new XyDataSeries<double, double> {SeriesName = "USA"};
            var indonesiaDataSeries = new XyDataSeries<double, double> {SeriesName = "Indonesia"};
            var brazilDataSeries = new XyDataSeries<double, double> {SeriesName = "Brazil"};
            var pakistanDataSeries = new XyDataSeries<double, double> {SeriesName = "Pakistan"};
            var nigeriaDataSeries = new XyDataSeries<double, double> {SeriesName = "Nigeria"};
            var bangladeshDataSeries = new XyDataSeries<double, double> {SeriesName = "Bangladesh"};
            var russiaDataSeries = new XyDataSeries<double, double> {SeriesName = "Russia"};
            var japanDataSeries = new XyDataSeries<double, double> {SeriesName = "Japan"};
            var restOfTheWorldDataSeries = new XyDataSeries<double, double> {SeriesName = "Rest Of The World"};
            var totalDataSeries = new XyDataSeries<double, double> {SeriesName = "Total"};

            for (var i = 0; i < 4; i++)
            {
                double xValue = i;
                chinaDataSeries.Append(xValue, china[i]);
                if (i != 2)
                {
                    indiaDataSeries.Append(xValue, india[i]);
                    usaDataSeries.Append(xValue, usa[i]);
                    indonesiaDataSeries.Append(xValue, indonesia[i]);
                    brazilDataSeries.Append(xValue, brazil[i]);
                }
                else
                {
                    indiaDataSeries.Append(xValue, Double.NaN);
                    usaDataSeries.Append(xValue, Double.NaN);
                    indonesiaDataSeries.Append(xValue, Double.NaN);
                    brazilDataSeries.Append(xValue, Double.NaN);
                }
                pakistanDataSeries.Append(xValue, pakistan[i]);
                nigeriaDataSeries.Append(xValue, nigeria[i]);
                bangladeshDataSeries.Append(xValue, bangladesh[i]);
                russiaDataSeries.Append(xValue, russia[i]);
                japanDataSeries.Append(xValue, japan[i]);
                restOfTheWorldDataSeries.Append(xValue, restOfTheWorld[i]);
                totalDataSeries.Append(xValue, china[i] + india[i] + usa[i] + indonesia[i] + brazil[i] + pakistan[i] + nigeria[i] + bangladesh[i] + russia[i] + japan[i] + restOfTheWorld[i]);
            }

            var columnsCollection = new SCIStackedHorizontalColumnGroupSeries();

            columnsCollection.AddSeries(GetRenderableSeries(chinaDataSeries, UIColor.FromRGB(0x2D, 0x68, 0xBC), UIColor.FromRGB(0x33, 0x99, 0xff)));
            columnsCollection.AddSeries(GetRenderableSeries(indiaDataSeries, UIColor.FromRGB(0x01, 0x35, 0x47), UIColor.FromRGB(0x01, 0x43, 0x58)));
            columnsCollection.AddSeries(GetRenderableSeries(usaDataSeries, UIColor.FromRGB(0x1B, 0x5D, 0x46), UIColor.FromRGB(0x1f, 0x8a, 0x71)));
            columnsCollection.AddSeries(GetRenderableSeries(indonesiaDataSeries, UIColor.FromRGB(0x7E, 0x95, 0x2B), UIColor.FromRGB(0xbd, 0xd6, 0x3b)));
            columnsCollection.AddSeries(GetRenderableSeries(brazilDataSeries, UIColor.FromRGB(0xAA, 0x8F, 0x0B), UIColor.FromRGB(0xff, 0xe0, 0x0b)));
            columnsCollection.AddSeries(GetRenderableSeries(pakistanDataSeries, UIColor.FromRGB(0xA9, 0x54, 0x19), UIColor.FromRGB(0xf2, 0x74, 0x21)));
            columnsCollection.AddSeries(GetRenderableSeries(nigeriaDataSeries, UIColor.FromRGB(0x84, 0x00, 0x00), UIColor.FromRGB(0xbb, 0x00, 0x00)));
            columnsCollection.AddSeries(GetRenderableSeries(bangladeshDataSeries, UIColor.FromRGB(0x37, 0x00, 0x18), UIColor.FromRGB(0x55, 0x00, 0x33)));
            columnsCollection.AddSeries(GetRenderableSeries(russiaDataSeries, UIColor.FromRGB(0x2D, 0x73, 0x2D), UIColor.FromRGB(0x33, 0x99, 0x33)));
            columnsCollection.AddSeries(GetRenderableSeries(japanDataSeries, UIColor.FromRGB(0x00, 0x6C, 0x6A), UIColor.FromRGB(0x00, 0xab, 0xa9)));
            columnsCollection.AddSeries(GetRenderableSeries(restOfTheWorldDataSeries, UIColor.FromRGB(0x3D, 0x00, 0x49), UIColor.FromRGB(0x56, 0x00, 0x68)));

            Surface = new SCIChartSurface(this);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
			Surface.AttachRenderableSeries(columnsCollection);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[] {new SCITooltipModifier()});

            Surface.InvalidateElement();
        }

        private SCIStackedColumnRenderableSeries GetRenderableSeries(IDataSeries dataSeries, UIColor strokeColor, UIColor fillColor)
        {
            return new SCIStackedColumnRenderableSeries
			{
				DataSeries = dataSeries,
				Style = new SCIColumnSeriesStyle
				{
					FillBrush = new SCIBrushSolid(fillColor),
					BorderPen = new SCIPenSolid(strokeColor, 1f)
				}
			};
        }
    }
}