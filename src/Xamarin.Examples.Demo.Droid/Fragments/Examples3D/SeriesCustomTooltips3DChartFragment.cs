using Android.Content;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.PointMarkers;
using SciChart.Charting3D.Visuals.RenderableSeries.HitTest;
using SciChart.Charting3D.Visuals.RenderableSeries.Scatter;
using SciChart.Charting3D.Visuals.RenderableSeries.Tooltips;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using System;
using System.Drawing;
using System.Text;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Series Custom Tooltips 3D Chart", description: "Customize Tooltips on a 3D Chart", icon: ExampleIcon.LineChart)]
    class SeriesCustomTooltips3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_With_Modifier_Tip_Fragment;

        protected override void InitExample()
        {
            var dataManager = DataManager.Instance;

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

            var pointMarker3D = new SpherePointMarker3D()
            {
                FillColor = Color.FromArgb(0x88, 0xFF, 0xFF, 0xFF),
                Size = 7f
            };

            var renderableSeries3D = new ScatterRenderableSeries3D()
            {
                PointMarker = pointMarker3D,
                DataSeries = dataSeries3D,
                SeriesInfoProvider = new CustomXyzSeriesInfo3DProvider()
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.2, 0.2), VisibleRange = new DoubleRange(-1.1, 1.1) };
                Surface.YAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.2, 0.2), VisibleRange = new DoubleRange(-1.1, 1.1) };
                Surface.ZAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.2, 0.2), VisibleRange = new DoubleRange(-1.1, 1.1) };

                Surface.Camera = new Camera3D();

                Surface.RenderableSeries.Add(renderableSeries3D);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D() { ReceiveHandledEvents = true, ExecuteOnPointerCount = 2 },
                    new ZoomExtentsModifier3D(),
                    new TooltipModifier3D()
                    {
                        CrosshairMode = CrosshairMode.Lines,
                        CrosshairPlanesFill = 0x33FF6600,
                        ReceiveHandledEvents = true,
                        ExecuteOnPointerCount = 1
                    }
                };
            }
        }
    }

    class CustomXyzSeriesInfo3DProvider : DefaultXyzSeriesInfo3DProvider
    {
        private readonly Java.Lang.Class _tooltipModifier3DClass = Java.Lang.Class.FromType(typeof(TooltipModifier3D));
        protected override ISeriesTooltip3D GetSeriesTooltipInternal(Context context, XyzSeriesInfo3D seriesInfo, Java.Lang.Class modifierType)
        {
            if (modifierType == _tooltipModifier3DClass)
            {
                return new CustomXyzSeriesTooltip3D(context, seriesInfo);
            }
            else
            {
                return base.GetSeriesTooltipInternal(context, seriesInfo, modifierType);
            }
        }
    }

    class CustomXyzSeriesTooltip3D : XyzSeriesTooltip3D
    {
        public CustomXyzSeriesTooltip3D(Context context, XyzSeriesInfo3D seriesInfo) : base(context, seriesInfo)
        {
        }

        protected override void InternalUpdate(XyzSeriesInfo3D seriesInfo)
        {
            var tooltipText = new StringBuilder();
            tooltipText.Append("This is Custom Tooltip").Append(Environment.NewLine);
            tooltipText.Append($"VertexId: {seriesInfo.VertexId}").Append(Environment.NewLine);

            tooltipText.Append($"X: {seriesInfo.FormattedXValue}").Append(Environment.NewLine);
            tooltipText.Append($"Y: {seriesInfo.FormattedYValue}").Append(Environment.NewLine);
            tooltipText.Append($"Z: {seriesInfo.FormattedZValue}");

            Text = tooltipText.ToString();

            SetSeriesColor(seriesInfo.SeriesColor);
        }
    }
}