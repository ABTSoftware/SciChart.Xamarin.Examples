using System.Linq;
using Android.Graphics;

namespace SciChart.Drawing.Common
{
    public partial class RadialGradientBrushStyle
    {
        public RadialGradientBrushStyle(float centerX, float centerY, float radiusX, float radiusY, Color[] colors, float[] stops) : 
            this (centerX, centerY, radiusX, radiusY, colors.Select(x => x.ToArgb()).ToArray(), stops)
        {

        }

        public RadialGradientBrushStyle(float centerX, float centerY, float radiusX, float radiusY, Color startColor, Color endColor) : 
            this(centerX, centerY, radiusX, radiusY, startColor.ToArgb(), endColor.ToArgb())
        {

        }
    }
}