using Java.Lang;
using SciChart.Charting3D.Visuals.RenderableSeries;
using SciChart.Charting3D.Visuals.RenderableSeries.MetadataProviders;
using SciChart.Core.Model;
using System.Collections.Generic;
using System.Drawing;

namespace Xamarin.Examples.Demo.Droid.Components
{
    public class PointMetadataProvider3D : MetadataProvider3DBase<BaseRenderableSeries3D>, IStrokeMetadataProvider3D, IPointMetadataProvider3D, IFillMetadataProvider3D
    {
        public List<PointMetadata3D> Metadata { get; } = new List<PointMetadata3D>();

        public void UpdatePointMetadata(IntegerValues pointColors, FloatValues pointScales, int defaultColor, float defaultScale)
        {
            var count = RenderableSeries.CurrentRenderPassData.PointsCount;

            pointColors.Clear();
            pointScales.Clear();

            for (int i = 0; i < count; i++)
            {
                var pointMetadata3D = Metadata[i];

                pointColors.Add(pointMetadata3D.VertexColor.ToArgb());
                pointScales.Add(pointMetadata3D.Scale);
            }
        }

        public void UpdateStrokeColors(IntegerValues strokeColors, int defaultStroke)
        {
            UpdateColorsFromPointMetadata(strokeColors);
        }

        public void UpdateFillColors(IntegerValues fillColors, int defaultFill)
        {
            UpdateColorsFromPointMetadata(fillColors);
        }

        private void UpdateColorsFromPointMetadata(IntegerValues colors)
        {
            var count = RenderableSeries.CurrentRenderPassData.PointsCount;

            colors.Clear();
            for (int i = 0; i < count; i++)
            {
                colors.Add(Metadata[i].VertexColor.ToArgb());
            }
        }
    }

    public struct PointMetadata3D
    {
        public PointMetadata3D(Color vertexColor) : this(vertexColor, 1f)
        {
        }

        public PointMetadata3D(Color vertexColor, float scale)
        {
            VertexColor = vertexColor;
            Scale = scale;
        }

        public Color VertexColor { get; }

        public float Scale { get; }
    }
}