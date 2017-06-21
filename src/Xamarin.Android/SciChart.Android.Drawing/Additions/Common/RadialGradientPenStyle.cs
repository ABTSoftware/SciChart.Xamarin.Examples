using Android.Content;
using Android.Util;

namespace SciChart.Drawing.Common
{
    public partial class RadialGradientPenStyle
    {
        public RadialGradientPenStyle(Context context, RadialGradientBrushStyle radialGradientBrushStyle, bool antiAliasing = true, float thickness = 1f, float[] strokeDashArray = null) :
            this(radialGradientBrushStyle, antiAliasing, TypedValue.ApplyDimension(ComplexUnitType.Dip, thickness, context.Resources.DisplayMetrics), strokeDashArray)
        {
        }
    }
}