using Android.Content;
using Android.Util;

namespace SciChart.Drawing.Common
{
    public partial class LinearGradientPenStyle
    {
        public LinearGradientPenStyle(Context context, LinearGradientBrushStyle linearGradientBrushStyle, bool antiAliasing = true, float thickness = 1f, float[] strokeDashArray = null) :
            this(linearGradientBrushStyle, antiAliasing, TypedValue.ApplyDimension(ComplexUnitType.Dip, thickness, context.Resources.DisplayMetrics), strokeDashArray)
        {
        }
    }
}