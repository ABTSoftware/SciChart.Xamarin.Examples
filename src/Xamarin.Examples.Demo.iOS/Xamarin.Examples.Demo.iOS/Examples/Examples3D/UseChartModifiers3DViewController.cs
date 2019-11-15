using System;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    class ButtonsPanel : UIView
    {
        public UIButton rotateHorizontal { get; } = new UIButton(UIButtonType.System) { TranslatesAutoresizingMaskIntoConstraints = false };
        public UIButton rotateVertical { get; } = new UIButton(UIButtonType.System) { TranslatesAutoresizingMaskIntoConstraints = false };

        public ButtonsPanel()
        {
            rotateHorizontal.SetTitle("Rotate Horizontal", UIControlState.Normal);
            rotateVertical.SetTitle("Rotate Vertical", UIControlState.Normal);

            AddSubviews(rotateHorizontal, rotateVertical);
            rotateHorizontal.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 8).Active = true;
            rotateHorizontal.TopAnchor.ConstraintEqualTo(TopAnchor, 8).Active = true;
            rotateHorizontal.BottomAnchor.ConstraintEqualTo(BottomAnchor, -8).Active = true;

            rotateHorizontal.TrailingAnchor.ConstraintEqualTo(rotateVertical.LeadingAnchor, -8).Active = true;

            rotateVertical.TopAnchor.ConstraintEqualTo(TopAnchor, 8).Active = true;
            rotateVertical.BottomAnchor.ConstraintEqualTo(BottomAnchor, -8).Active = true;
            rotateVertical.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 8).Active = true;

            rotateHorizontal.WidthAnchor.ConstraintEqualTo(rotateVertical.WidthAnchor).Active = true;
        }
    }

    [Example3DDefinition("Use Chart Modifiers 3D", description: "Demonstrates PinchZoomModifier3D, OrbitModifier3D and ZoomExtentsModifier3D", icon: ExampleIcon.ZoomPan)]
    class UseChartModifiers3DViewController : SingleChartWithTopPanelViewController<SCIChartSurface3D>
    {
        public override UIView ProvidePanel()
        {
            var panel = new ButtonsPanel();
            panel.rotateHorizontal.TouchUpInside += (sender, args) =>
            {
                var yaw = Surface.Camera.OrbitalYaw;
                Surface.Camera.OrbitalYaw = yaw < 360 ? yaw + 90 : 360 - yaw;
            };
            panel.rotateVertical.TouchUpInside += (sender, args) =>
            {
                var pitch = Surface.Camera.OrbitalPitch;
                Surface.Camera.OrbitalPitch = pitch < 89 ? pitch + 90 : -90;
            };

            return panel;
        }

        protected override void InitExample()
        {
            const int count = 25;   
            var dataManager = DataManager.Instance;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new SCIPointMetadataProvider3D();
            for (int x = 0; x < count; x++)
            {
                var color = dataManager.GetRandomColor();
                for (int z = 1; z < count; z++)
                {
                    var y = Math.Pow(z, 0.3);
                    dataSeries3D.Append(x, y, z);

                    var metadata = new SCIPointMetadata3D((uint)color.ToArgb(), 2);
                    metadataProvider.Metadata.Add(metadata);
                }
            }

            var renderableSeries3D = new SCIScatterRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider,
                PointMarker = new SCISpherePointMarker3D { FillColor = ColorUtil.Lime, Size = 5f },
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(renderableSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
            }
        }
    }
}