using System.Linq;
using Android.Graphics;

namespace SciChart.Charting.Visuals.RenderableSeries
{
    public partial class ColorMap
    {
        public ColorMap(Color[] colors, float[] stops) : this(colors.Select(color => color.ToArgb()).ToArray(), stops)
        {
            
        }

        public ColorMap(Color startColor, Color endColor) : this(startColor.ToArgb(), endColor.ToArgb())
        {
            
        }
    }
}