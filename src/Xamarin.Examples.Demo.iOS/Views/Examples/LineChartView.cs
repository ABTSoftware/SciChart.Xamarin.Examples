using System;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using SciChart.Examples.Demo.Data;
using System.Collections.Generic;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
	[ExampleDefinition("Line Chart")]
	public class LineChartView : SCIChartSurfaceView
	{
		SCIChartSurface surface;
		public LineChartView()
		{
			surface = new SCIChartSurface(this);

			var backBrush = new SCIBrushSolid(0xFF1e1c1c);

			surface.Style.BackgroundBrush = backBrush;
			surface.Style.SeriesBackgroundBrush = backBrush;

			AddAxes();
			SetData();
			AddModifiers();

			surface.InvalidateElement();
		}

		void AddAxes()
		{
			var axisStyle = GetAxisStyle();

			var xAxis = new SCINumericAxis();
			xAxis.IsXAxis = true;
			xAxis.AxisId = "xAxis";
			xAxis.Style = axisStyle;

			xAxis.AutoRange = SCIAutoRangeMode.Once;
			surface.AttachAxis(xAxis, true);

			var yAxis = new SCINumericAxis();
			yAxis.IsXAxis = false;
			yAxis.AxisId = "yAxis";

			yAxis.Style = axisStyle;
			surface.AttachAxis(yAxis, false);
		}

		public SCIAxisStyle GetAxisStyle()
		{
			var majorGridLinesPen = new SCIPenSolid(0xFF393532, 1);
			var minorGridLinesPen = new SCIPenSolid(0xFF262423, 0.5f);

			var textFormat = new SCITextFormattingStyle();
			textFormat.FontName = "Helvetica";
			textFormat.FontSize = 14;
			textFormat.Color = UIColor.LightTextColor;

			var axisStyle = new SCIAxisStyle();
			axisStyle.MajorTickBrush = majorGridLinesPen;
			axisStyle.MajorGridLineBrush = majorGridLinesPen;
			axisStyle.DrawMajorGridLines = true;
			axisStyle.DrawMajorBands = true;
			axisStyle.DrawMajorTicks = true;
			axisStyle.MinorTickBrush = minorGridLinesPen;
			axisStyle.MinorGridLineBrush = minorGridLinesPen;
			axisStyle.DrawMinorGridLines = true;
			axisStyle.DrawMinorTicks = true;
			axisStyle.LabelStyle = textFormat;

			return axisStyle;
		}

		void SetData()
		{
			var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1);

			var dataSeries = new SCIXyDataSeries<double, double>();
			dataSeries.AppendRange(fourierSeries.XData, fourierSeries.YData, fourierSeries.Count);

			var renderSeries = new SCIFastLineRenderableSeries();
			renderSeries.DataSeries = dataSeries;
			renderSeries.XAxisId = "xAxis";
			renderSeries.YAxisId = "yAxis";
			renderSeries.Style.LinePen = new SCIPenSolid(0xFF99EE99, 0.7f);

			surface.AttachRenderableSeries(renderSeries);
		}

		void AddModifiers()
		{
			var zoomPan = new SCIZoomPanModifier();
			var pinchZoom = new SCIPinchZoomModifier();
			var zoomExtents = new SCIZoomExtentsModifier();

			var modifierGroup = new SCIModifierGroup(new ISCIChartModifierProtocol[] { zoomPan, pinchZoom, zoomExtents});
			surface.ChartModifier = modifierGroup;
		}
	}
}
