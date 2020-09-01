using Android.Widget;
using SciChart.Charting.Themes;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.PointMarkers;
using SciChart.Charting3D.Visuals.RenderableSeries.Scatter;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Theme Manager 3D Chart", description: "Styling Chart3D via the ThemeManager", icon: ExampleIcon.Themes)]
    class ThemeManager3DChartFragment : ExampleBaseFragment
    {
        private const int BlackSteel = 0;
        private const int BrightSpark = 1;
        private const int Chrome = 2;
        private const int Electric = 3;
        private const int ExpressionDark = 4;
        private const int ExpressionLight = 5;
        private const int Oscilloscope = 6;
        private const int SciChartV4Dark = 7;
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public Spinner ThemeSelector => View.FindViewById<Spinner>(Resource.Id.themeSelector);

        public override int ExampleLayoutId => Resource.Layout.Example_ThemeManager3D_Fragment;

        protected override void InitExample()
        {
            InitializeUIHandlers();

            var dataManager = DataManager.Instance;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new PointMetadataProvider3D();

            for (int i = 0; i < 1250; i++)
            {
                var x = dataManager.GetGaussianRandomNumber(5, 1.5);
                var y = dataManager.GetGaussianRandomNumber(5, 1.5);
                var z = dataManager.GetGaussianRandomNumber(5, 1.5);

                dataSeries3D.Append(x, y, z);

                var color = dataManager.GetRandomColor();
                var scale = dataManager.GetRandomScale();

                metadataProvider.Metadata.Add(new PointMetadata3D(color, scale));
            }

            var pointMarker3D = new SpherePointMarker3D()
            {
                FillColor = Color.Lime,
                Size = 2f
            };

            var renderableSeries3D = new ScatterRenderableSeries3D()
            {
                PointMarker = pointMarker3D,
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.YAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.ZAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };

                Surface.Camera = new Camera3D();

                Surface.RenderableSeries.Add(renderableSeries3D);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
            }
        }

        private void InitializeUIHandlers()
        {
            ThemeSelector.Adapter = new SpinnerStringAdapter(Activity, Resource.Array.style_list);
            ThemeSelector.SetSelection(7);
            ThemeSelector.ItemSelected += (sender, args) => { SetTheme(args.Position); };
        }

        private void SetTheme(int position)
        {
            int themeId;
            switch (position)
            {
                case BlackSteel:
                    themeId = Resource.Style.SciChart_BlackSteel;
                    break;
                case BrightSpark:
                    themeId = Resource.Style.SciChart_Bright_Spark;
                    break;
                case Chrome:
                    themeId = Resource.Style.SciChart_ChromeStyle;
                    break;
                case Electric:
                    themeId = Resource.Style.SciChart_ElectricStyle;
                    break;
                case ExpressionDark:
                    themeId = Resource.Style.SciChart_ExpressionDarkStyle;
                    break;
                case ExpressionLight:
                    themeId = Resource.Style.SciChart_ExpressionLightStyle;
                    break;
                case Oscilloscope:
                    themeId = Resource.Style.SciChart_OscilloscopeStyle;
                    break;
                case SciChartV4Dark:
                    themeId = Resource.Style.SciChart_SciChartv4DarkStyle;
                    break;

                default:
                    themeId = ThemeManager.DefaultTheme;
                    break;
            }

            Surface.Theme = themeId;
        }
    }
}