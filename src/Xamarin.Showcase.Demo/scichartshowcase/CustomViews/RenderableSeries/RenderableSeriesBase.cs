using System;
using scichartshowcase.CustomViews.Data.DataSeries;
using Xamarin.Forms;

namespace scichartshowcase.CustomViews.RenderableSeries
{
    public enum RenderableSeriesType
    {
        Line,
        Column,
        Heatmap
    }

    public abstract class RenderableSeriesBase
    {
        public RenderableSeriesType SeriesType { get; set; }
        public DataSeries DataSeries { get; set; }
    }

    public class LineRenderableSeries : RenderableSeriesBase
    {
        public new XYDataSeries<int, int> DataSeries { get; set; }
        public Color Stroke { get; set; }
        public float StrokeThickness { get; set; }

        public LineRenderableSeries() => SeriesType = RenderableSeriesType.Line;
    }

    public class ColumnRenderableSeries : RenderableSeriesBase
    {
        public new XYDataSeries<int, int> DataSeries { get; set; }
        public Color Stroke { get; set; }
        public float StrokeThickness { get; set; }
        public Color FillBrush { get; set; }

        public ColumnRenderableSeries() => SeriesType = RenderableSeriesType.Column;
    }

    public class HeatmapRenderableSeries : RenderableSeriesBase
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int[] Data { get; set; }
        public ColorMap ColorMap { get; set; }

        public HeatmapRenderableSeries(int width, int height)
        {
            Width = width;
            Height = height;

            Data = new int[Width * Height];

            SeriesType = RenderableSeriesType.Heatmap;
        }

        public void AppenData(int[] data)
        {
            var spectrogramSize = Width * Height;
            var fftSize = data.Length;
            var offset = spectrogramSize - fftSize;

            Array.Copy(Data, fftSize, Data, 0, offset);
            Array.Copy(data, 0, Data, offset, fftSize);
        }

        public void UpdateValues(int[] data)
        {
            Data = data;
        }
    }

    public class ColorMap
    {
        public double[] GradientCoordinates { get; set; }
        public Color[] GradientColors { get; set; }
    }
}