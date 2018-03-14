using Android.Graphics;

namespace SciChart.Drawing.Common
{
    public partial class SolidBrushStyle
    {
        public SolidBrushStyle(Color color) : this(color.ToArgb())
        {
        }

        public SolidBrushStyle(uint color) : this((int) color)
        {
        }
    }
}