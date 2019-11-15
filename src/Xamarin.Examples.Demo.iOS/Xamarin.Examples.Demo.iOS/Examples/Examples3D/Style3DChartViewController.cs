using Foundation;
using System.Linq;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Style 3D Chart", description: "Styling of a SciChart3DSurface, Axis, grid lines, tick lines and background", icon: ExampleIcon.Themes)]
    class Style3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            var font = "RobotoCondensed-BoldItalic";
            // TODO (@Andriy): Make sure font is working fine

            var something = new[] { 1.0, 2.0 };
            var numbers = something.Select(x => new NSNumber(x)).ToArray();

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D
                {   
                    MinorsPerMajor = 5,
                    MaxAutoTicks = 7,
                    TextSize = 13f,
                    TextColor = 0xFF00FF00,
                    TextFont = font,
                    AxisBandsStyle = new SCISolidBrushStyle(0xFF556B2F),
                    MajorTickLineStyle = new SCISolidPenStyle(0xFF00FF00, 1),
                    MajorTickLineLength = 8f,
                    MinorTickLineStyle = new SCISolidPenStyle(0xFFC71585),
                    MinorTickLineLength = 4f,
                    MajorGridLineStyle = new SCISolidPenStyle(0xFF00FF00),
                    MinorGridLineStyle = new SCISolidPenStyle(0xFF9400D3),
                };
                Surface.YAxis = new SCINumericAxis3D
                {
                    MinorsPerMajor = 5,
                    MaxAutoTicks = 7,
                    TextSize = 13f,
                    TextColor = 0xFFB22222,
                    TextFont = font,
                    AxisBandsStyle = new SCISolidBrushStyle(0xFFFF6347),
                    MajorTickLineStyle = new SCISolidPenStyle(0xFFB22222),
                    MajorTickLineLength = 8f,
                    MinorTickLineStyle = new SCISolidPenStyle(0xFFCD5C5C),
                    MinorTickLineLength = 4f,
                    MajorGridLineStyle = new SCISolidPenStyle(0xFF006400),
                    MinorGridLineStyle = new SCISolidPenStyle(0xFF8CBED6)
                };
                Surface.ZAxis = new SCINumericAxis3D
                {
                    MinorsPerMajor = 5,
                    MaxAutoTicks = 7,
                    TextSize = 13f,
                    TextColor = 0xFFDB7093,
                    TextFont = font,
                    AxisBandsStyle = new SCISolidBrushStyle(0xFFADFF2F),
                    MajorTickLineStyle = new SCISolidPenStyle(0xFFDB7093),
                    MajorTickLineLength = 8f,
                    MinorTickLineStyle = new SCISolidPenStyle(0xFF7FFF00),
                    MinorTickLineLength = 4f,
                    MajorGridLineStyle = new SCISolidPenStyle(0xFFF5F5DC),
                    MinorGridLineStyle = new SCISolidPenStyle(0xFFA52A2A)
                };

                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
            }
        }
    }
}