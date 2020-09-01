using System.Drawing;
using SciChart.Charting3D.Common.Utils;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Style 3D Chart", description: "Styling of a SciChart3DSurface, Axis, grid lines, tick lines and background", icon: ExampleIcon.Themes)]
    class Style3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            var font = "RobotoCondensed-BoldItalic";
            FontUtil3D.RegisterFont($"/system/fonts/{font}.ttf");

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D()
                {   
                    MinorsPerMajor = 5,
                    MaxAutoTicks = 7,
                    TextSize = 13f.ToSp(Activity),
                    TextColor = Color.Lime.ToArgb(),
                    TextFont = font,
                    AxisBandsStyle = new SolidBrushStyle(Color.DarkOliveGreen),
                    MajorTickLineStyle = new SolidPenStyle(Activity, Color.Lime),
                    MajorTickLineLength = 8f,
                    MinorTickLineStyle = new SolidPenStyle(Activity, Color.MediumVioletRed),
                    MinorTickLineLength = 4f,
                    MajorGridLineStyle = new SolidPenStyle(Activity, Color.Lime),
                    MinorGridLineStyle = new SolidPenStyle(Activity, Color.DarkViolet)

                };
                Surface.YAxis = new NumericAxis3D()
                {
                    MinorsPerMajor = 5,
                    MaxAutoTicks = 7,
                    TextSize = 13f.ToSp(Activity),
                    TextColor = Color.Firebrick.ToArgb(),
                    TextFont = font,
                    AxisBandsStyle = new SolidBrushStyle(Color.Tomato),
                    MajorTickLineStyle = new SolidPenStyle(Activity, Color.Firebrick),
                    MajorTickLineLength = 8f,
                    MinorTickLineStyle = new SolidPenStyle(Activity, Color.IndianRed),
                    MinorTickLineLength = 4f,
                    MajorGridLineStyle = new SolidPenStyle(Activity, Color.DarkGreen),
                    MinorGridLineStyle = new SolidPenStyle(Activity, Color.DarkBlue)

                };
                Surface.ZAxis = new NumericAxis3D()
                {
                    MinorsPerMajor = 5,
                    MaxAutoTicks = 7,
                    TextSize = 13f.ToSp(Activity),
                    TextColor = Color.PaleVioletRed.ToArgb(),
                    TextFont = font,
                    AxisBandsStyle = new SolidBrushStyle(Color.GreenYellow),
                    MajorTickLineStyle = new SolidPenStyle(Activity, Color.PaleVioletRed),
                    MajorTickLineLength = 8f,
                    MinorTickLineStyle = new SolidPenStyle(Activity, Color.Chartreuse),
                    MinorTickLineLength = 4f,
                    MajorGridLineStyle = new SolidPenStyle(Activity, Color.Beige),
                    MinorGridLineStyle = new SolidPenStyle(Activity, Color.Brown)

                };

                Surface.Camera = new Camera3D();

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
            }
        }
    }
}