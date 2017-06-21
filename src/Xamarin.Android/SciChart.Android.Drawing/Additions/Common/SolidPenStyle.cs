using Android.Content;
using Android.Graphics;
using Android.Util;

namespace SciChart.Drawing.Common
{
    public partial class SolidPenStyle
    {
        public SolidPenStyle(uint color, float thickness = 1f)
            : this((int) color, true, thickness, null)
        {
        }

        public SolidPenStyle(Color color, float thickness = 1f)
            : this(color.ToArgb(), true, thickness, null)
        {
        }

        public SolidPenStyle(Context context, uint color, bool antiAliasing = true, float thickness = 1f, ComplexUnitType unit = ComplexUnitType.Dip, float[] strokeDashArray = null)
            : this((int)color, antiAliasing, TypedValue.ApplyDimension(unit, thickness, context.Resources.DisplayMetrics), strokeDashArray)
        {
        }

        public SolidPenStyle(Context context, Color color, bool antiAliasing = true, float thickness = 1f, ComplexUnitType unit = ComplexUnitType.Dip, float[] strokeDashArray = null)
            : this(color.ToArgb(), antiAliasing, TypedValue.ApplyDimension(unit, thickness, context.Resources.DisplayMetrics), strokeDashArray)
        {
        }
    }
}