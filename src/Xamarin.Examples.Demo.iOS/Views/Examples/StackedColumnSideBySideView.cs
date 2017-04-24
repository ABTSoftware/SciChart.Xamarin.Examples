using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Stacked Column Side By Side Chart")]
    public class StackedColumnSideBySideView : ExampleBaseView
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

            var xAxis = new SCINumericAxis
            {
                AutoTicks = false,
                MajorDelta = 1,
                //MinorDelta = 0.5,
                //TODO Add label provider
                //LabelProvider = new YearsLabelProvider(),
                Style = {DrawMajorBands = true}
            };

            var yAxis = new SCINumericAxis
            {
                AutoRange = SCIAutoRange.Always,
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
                    indiaDataSeries.Append(xValue, double.NaN);
                    usaDataSeries.Append(xValue, double.NaN);
                    indonesiaDataSeries.Append(xValue, double.NaN);
                    brazilDataSeries.Append(xValue, double.NaN);
                }
                pakistanDataSeries.Append(xValue, pakistan[i]);
                nigeriaDataSeries.Append(xValue, nigeria[i]);
                bangladeshDataSeries.Append(xValue, bangladesh[i]);
                russiaDataSeries.Append(xValue, russia[i]);
                japanDataSeries.Append(xValue, japan[i]);
                restOfTheWorldDataSeries.Append(xValue, restOfTheWorld[i]);
                totalDataSeries.Append(xValue, china[i] + india[i] + usa[i] + indonesia[i] + brazil[i] + pakistan[i] + nigeria[i] + bangladesh[i] + russia[i] + japan[i] + restOfTheWorld[i]);
            }

            var columnsCollection = new SCIHorizontallyStackedColumnsCollection();

            columnsCollection.Add(GetRenderableSeries(chinaDataSeries, 0xff3399ff, 0xff2D68BC));
            columnsCollection.Add(GetRenderableSeries(indiaDataSeries, 0xff014358, 0xff013547));
            columnsCollection.Add(GetRenderableSeries(usaDataSeries, 0xff1f8a71, 0xff1B5D46));
            columnsCollection.Add(GetRenderableSeries(indonesiaDataSeries, 0xffbdd63b, 0xff7E952B));
            columnsCollection.Add(GetRenderableSeries(brazilDataSeries, 0xffffe00b, 0xffAA8F0B));
            columnsCollection.Add(GetRenderableSeries(pakistanDataSeries, 0xfff27421, 0xffA95419));
            columnsCollection.Add(GetRenderableSeries(nigeriaDataSeries, 0xffbb0000, 0xff840000));
            columnsCollection.Add(GetRenderableSeries(bangladeshDataSeries, 0xff550033, 0xff370018 ));
            columnsCollection.Add(GetRenderableSeries(russiaDataSeries, 0xff339933, 0xff2D732D));
            columnsCollection.Add(GetRenderableSeries(japanDataSeries, 0xff00aba9, 0xff006C6A));
            columnsCollection.Add(GetRenderableSeries(restOfTheWorldDataSeries, 0xff560068, 0xff3D0049));

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(columnsCollection);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[] {new SCITooltipModifier()});

            Surface.InvalidateElement();
        }

        private SCIStackedColumnRenderableSeries GetRenderableSeries(IDataSeries dataSeries, uint fillColor, uint strokeColor)
        {
            return new SCIStackedColumnRenderableSeries
            {
                DataSeries = dataSeries,
                Style = new SCIColumnSeriesStyle
                {
                    FillBrush = new SCISolidBrushStyle(fillColor),
                    BorderPen = new SCISolidPenStyle(strokeColor, 1f)
                }
            };
        }
    }
}