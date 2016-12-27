using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Line Chart")]
    public class LineChartView : ExampleBaseView
    {
        public SCIChartSurface Surface;
		public SCIChartSurfaceView SurfaceView = new SCIChartSurfaceView();

        public override void InitExample()
        {
			var layoutView = SingleChartView.Create();
			layoutView.Frame = this.Frame;
			layoutView.TranslatesAutoresizingMaskIntoConstraints = true;
			this.Add(layoutView);

			SurfaceView.Frame = layoutView.SciChartSurfaceView.Frame;
			SurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;

			layoutView.SciChartSurfaceView.Add(SurfaceView);



			Surface = new SCIChartSurface(SurfaceView);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1);

            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(fourierSeries.XData, fourierSeries.YData);

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCINumericAxis {IsXAxis = true, GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var renderSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                Style = {LinePen = new SCIPenSolid(0xFF99EE99, 0.7f)}
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