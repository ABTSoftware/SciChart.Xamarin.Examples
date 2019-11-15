using System;
using System.Text;
using ObjCRuntime;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Custom Series Tooltips 3D Chart", description: "Customize Tooltips on a 3D Chart", icon: ExampleIcon.LineChart)]
    class SeriesCustomTooltips3DChartViewController : SingleChartWithModifierTipViewController<SCIChartSurface3D>
    {
        public override string ModifierTip => "To rotate chart use scroll with two fingers";

        protected override void InitExample()
        {
            var random = new Random();
            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            for (int i = 0; i < 500; i++)
            {
                var m1 = random.Next(2) == 0 ? -1 : 1;
                var m2 = random.Next(2) == 0 ? -1 : 1;

                var x1 = random.NextDouble() * m1;
                var x2 = random.NextDouble() * m2;

                var temp = 1 - x1 * x1 - x2 * x2;

                var x = 2 * x1 * Math.Sqrt(temp);
                var y = 2 * x2 * Math.Sqrt(temp);
                var z = 1 - 2 * (x1 * x1 + x2 * x2);

                dataSeries3D.Append(x, y, z);
            }

            var rSeries3D = new SCIScatterRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                PointMarker = new SCISpherePointMarker3D { FillColor = 0x88FFFFFF, Size = 7f },
                
            };
            rSeries3D.SeriesInfoProvider = new CustomXyzSeriesInfo3DProvider();

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.2, 0.2), VisibleRange = new SCIDoubleRange(-1.1, 1.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.2, 0.2), VisibleRange = new SCIDoubleRange(-1.1, 1.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.2, 0.2), VisibleRange = new SCIDoubleRange(-1.1, 1.1) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers = new SCIChartModifier3DCollection
                {
                    new SCIPinchZoomModifier3D(),
                    new SCIOrbitModifier3D(defaultNumberOfTouches: 2) { ReceiveHandledEvents = true },
                    new SCIZoomExtentsModifier3D(),
                    new SCITooltipModifier3D
                    {
                        CrosshairMode = SCICrosshairMode.Lines,
                        CrosshairPlanesFill = 0x33FF6600.ToUIColor(),
                        ReceiveHandledEvents = true,
                        ExecuteOnPointerCount = 1
                    }
                };

                Surface.Camera = new SCICamera3D();
            }
        }
    }

    class CustomXyzSeriesInfo3DProvider : SCIDefaultXyzSeriesInfo3DProvider
    {
        protected override IISCISeriesTooltip3D GetSeriesTooltipInternal(SCISeriesInfo3D seriesInfo, Class modifierType)
        {
            if (modifierType.Name == typeof(SCITooltipModifier3D).ToClass().Name)
            {
                return new CustomXyzSeriesTooltip3D((SCIXyzSeriesInfo3D)seriesInfo);
            }
            return base.GetSeriesTooltipInternal(seriesInfo, modifierType);
        }
    }

    class CustomXyzSeriesTooltip3D : SCIXyzSeriesTooltip3D
    {
        public CustomXyzSeriesTooltip3D(SCIXyzSeriesInfo3D seriesInfo) : base(seriesInfo) { }

        protected override void InternalUpdate(SCISeriesInfo3D seriesInfo)
        {
            var xyzSeriesInfo = (SCIXyzSeriesInfo3D)seriesInfo;

            var tooltipText = new StringBuilder();
            tooltipText.Append("This is Custom Tooltip").Append(Environment.NewLine);
            tooltipText.Append($"VertexId: {xyzSeriesInfo.VertexId}").Append(Environment.NewLine);

            tooltipText.Append($"X: {seriesInfo.FormattedXValue}").Append(Environment.NewLine);
            tooltipText.Append($"Y: {seriesInfo.FormattedYValue}").Append(Environment.NewLine);
            tooltipText.Append($"Z: {seriesInfo.FormattedZValue}");

            Text = tooltipText.ToString();

            SetSeriesColor(xyzSeriesInfo.SeriesColor.ColorARGBCode());
        }
    }
}