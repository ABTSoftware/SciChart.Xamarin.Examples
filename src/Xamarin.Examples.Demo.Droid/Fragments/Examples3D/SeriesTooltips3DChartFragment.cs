using Java.Lang;
using SciChart.Charting3D.Common.Math;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.PointMarkers;
using SciChart.Charting3D.Visuals.RenderableSeries.PointLine;
using SciChart.Data.Model;
using Xamarin.Examples.Demo;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Series Tooltips 3D Chart", description: "Add Tooltips on a 3D Chart", icon: ExampleIcon.LineChart)]
    class SeriesTooltips3DChartFragment : ExampleBaseFragment
    {
        private readonly double CosYAngle = Math.Cos(Math.ToRadians(-65));
        private readonly double SinYAngle = Math.Sin(Math.ToRadians(-65));

        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_With_Modifier_Tip_Fragment;

        protected override void InitExample()
        {
            const int segmentsCount = 25;

            var blueColor = Color.FromArgb(0, 0x84, 0xCF);
            var redColor = Color.FromArgb(0xEE, 0x11, 0x10);
            var rotationAngle = 360 / 45d;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new PointMetadataProvider3D();

            var currentAngle = 0d;
            for (int i = -segmentsCount; i < segmentsCount + 1; i++)
            {
                AppendPoint(dataSeries3D, -4, i, currentAngle);
                AppendPoint(dataSeries3D, 4, i, currentAngle);

                metadataProvider.Metadata.Add(new PointMetadata3D(redColor));
                metadataProvider.Metadata.Add(new PointMetadata3D(blueColor));

                currentAngle = (currentAngle + rotationAngle) % 360;
            }

            var pointMarker3D = new SpherePointMarker3D()
            {
                Size = 8f
            };

            var renderableSeries3D = new PointLineRenderableSeries3D()
            {
                PointMarker = pointMarker3D,
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider,
                IsLineStrips = false,
                StrokeThickness = 4f.ToDip(Activity)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.WorldDimensions.Assign(600, 300, 180);

                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.2, 0.2) };
                Surface.YAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.ZAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(-9, 9) };

                Surface.Camera = new Camera3D()
                {
                    Position = new Vector3(-160, 190, -520),
                    Target = new Vector3(-45, 150, 0),
                    ZoomToFitOnAttach = false
                };

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

        private void AppendPoint(XyzDataSeries3D<double, double, double> ds, double x, double y, double currentAngle)
        {
            var radAngle = Math.ToRadians(currentAngle);

            var temp = x * Math.Cos(radAngle);

            var xValue = temp * CosYAngle - y * SinYAngle;
            var yValue = temp * SinYAngle + y * CosYAngle;
            var zValue = x * Math.Sin(radAngle);

            ds.Append(xValue, yValue, zValue);
        }
    }
}