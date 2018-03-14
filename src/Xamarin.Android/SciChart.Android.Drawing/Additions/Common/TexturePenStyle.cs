using Android.Content;
using Android.Util;

namespace SciChart.Drawing.Common
{
    public partial class TexturePenStyle
    {
        public TexturePenStyle(Context context, TextureBrushStyle textureBrushStyle, bool antiAliasing = true, float thickness = 1f, float[] strokeDashArray = null) :
            this(textureBrushStyle, antiAliasing, TypedValue.ApplyDimension(ComplexUnitType.Dip, thickness, context.Resources.DisplayMetrics), strokeDashArray)
        {
        }
    }
}