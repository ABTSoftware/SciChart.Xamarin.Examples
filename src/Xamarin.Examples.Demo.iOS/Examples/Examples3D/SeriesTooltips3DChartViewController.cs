using System;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Series Tooltips 3D Chart", description: "Add Tooltips on a 3D Chart", icon: ExampleIcon.LineChart)]
    class SeriesTooltips3DChartViewController : SingleChartWithModifierTipViewController<SCIChartSurface3D>
    {
        private readonly double CosYAngle = Math.Cos(-65d.ToRadians());
        private readonly double SinYAngle = Math.Sin(-65d.ToRadians());

        public override string ModifierTip => "To rotate chart use scroll with two fingers";

        protected override void InitExample()
        {
            const int segmentsCount = 25;

            var blueColor = 0xFF0084CF;
            var redColor = 0xFFEE1110;
            var rotationAngle = 360 / 45d;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new SCIPointMetadataProvider3D();

            var currentAngle = 0d;
            for (int i = -segmentsCount; i < segmentsCount + 1; i++)
            {
                AppendPoint(dataSeries3D, -4, i, currentAngle);
                AppendPoint(dataSeries3D, 4, i, currentAngle);

                metadataProvider.Metadata.Add(new SCIPointMetadata3D(redColor));
                metadataProvider.Metadata.Add(new SCIPointMetadata3D(blueColor));

                currentAngle = (currentAngle + rotationAngle) % 360;
            }

            var rSeries3D = new SCIPointLineRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                PointMarker = new SCISpherePointMarker3D { Size = 8f },
                MetadataProvider = metadataProvider,
                IsLineStrips = false,
                StrokeThickness = 4f,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.2, 0.2), MaxAutoTicks = 5 };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.2, 0.2) };
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

                Surface.Camera = new SCICamera3D { Position = new SCIVector3(-160, 190, -520), Target = new SCIVector3(-45, 150, 0) };
                Surface.WorldDimensions.AssignX(600, 300, 180);
            }
        }

        private void AppendPoint(XyzDataSeries3D<double, double, double> ds, double x, double y, double currentAngle)
        {
            var radAngle = currentAngle.ToRadians();

            var temp = x * Math.Cos(radAngle);

            var xValue = temp * CosYAngle - y * SinYAngle;
            var yValue = temp * SinYAngle + y * CosYAngle;
            var zValue = x * Math.Sin(radAngle);

            ds.Append(xValue, yValue, zValue);
        }
    }
}
