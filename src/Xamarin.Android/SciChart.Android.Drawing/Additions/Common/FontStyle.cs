using Android.Content;
using Android.Graphics;
using Android.Util;

namespace SciChart.Drawing.Common
{
    public partial class FontStyle
    {
        public FontStyle(Typeface typeface, float textSize, uint textColor)
            : this(typeface, textSize, (int) textColor)
        {
        }

        public FontStyle(Typeface typeface, float textSize, Color textColor)
            : this(typeface, textSize, textColor.ToArgb())
        {
        }

        public FontStyle(Context context, Typeface typeface, float textSize, Color textColor, ComplexUnitType unit = ComplexUnitType.Dip)
            : this(typeface, TypedValue.ApplyDimension(unit, textSize, context.Resources.DisplayMetrics), textColor.ToArgb())
        {
        }

        public FontStyle(float textSize, uint textColor)
            : this(textSize, (int) textColor)
        {
        }

        public FontStyle(float textSize, Color textColor)
            : this(textSize, textColor.ToArgb())
        {
        }

        public FontStyle(Context context, float textSize, Color textColor, ComplexUnitType unit = ComplexUnitType.Dip)
            : this(TypedValue.ApplyDimension(unit, textSize, context.Resources.DisplayMetrics), textColor.ToArgb())
        {
        }
    }
}