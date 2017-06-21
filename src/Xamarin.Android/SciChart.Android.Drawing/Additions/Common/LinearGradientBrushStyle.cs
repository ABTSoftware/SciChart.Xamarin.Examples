using System.Linq;
using Android.Graphics;

namespace SciChart.Drawing.Common
{
    public partial class LinearGradientBrushStyle
    {
        public LinearGradientBrushStyle(float x0, float y0, float x1, float y1, Color[] colors, float[] stops)
            : this(x0, y0, x1, y1, colors.Select(x => x.ToArgb()).ToArray(), stops)
        {
        }

        public LinearGradientBrushStyle(float x0, float y0, float x1, float y1, uint[] colors, float[] stops)
            : this(x0, y0, x1, y1, colors.Select(x => (int) x).ToArray(), stops)
        {
        }

        public LinearGradientBrushStyle(float x0, float y0, float x1, float y1, Color startColor, Color endColor)
            : this(x0, y0, x1, y1, startColor.ToArgb(), endColor.ToArgb())
        {
        }

        public LinearGradientBrushStyle(float x0, float y0, float x1, float y1, uint startColor, uint endColor)
            : this(x0, y0, x1, y1, (int) startColor, (int) endColor)
        {
        }
    }
}