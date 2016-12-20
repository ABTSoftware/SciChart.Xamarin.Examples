using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Helpers
{
    public class StyleHelper
    {
        public static SCIAxisStyle GetDefaultAxisStyle()
        {
            var textFormat = new SCITextFormattingStyle {FontSize = 14, Color = UIColor.LightTextColor};
            var majorGridLinesPen = new SCIPenSolid(0xFF393532, 1);
            var minorGridLinesPen = new SCIPenSolid(0xFF262423, 0.5f);

            var axisStyle = new SCIAxisStyle
            {
                MajorTickBrush = majorGridLinesPen,
                MajorGridLineBrush = majorGridLinesPen,
                DrawMajorBands = true,
                MinorTickBrush = minorGridLinesPen,
                MinorGridLineBrush = minorGridLinesPen,
                DrawMinorGridLines = true,
                LabelStyle = textFormat,
            };

            return axisStyle;
        }

        public static void SetSurfaceDefaultStyle(SCIChartSurface surface)
        {
            var seriesBackgroundBrush = new SCIBrushSolid(0xFF1e1c1c);

            surface.Style.BackgroundBrush = seriesBackgroundBrush;
            surface.Style.SeriesBackgroundBrush = seriesBackgroundBrush;
        }
    }
}