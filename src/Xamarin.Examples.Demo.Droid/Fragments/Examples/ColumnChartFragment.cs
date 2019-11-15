using Android.Graphics;
using Android.Views.Animations;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.PaletteProviders;
using SciChart.Core.Model;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Column Chart", description: "Create a simple Column Chart", icon: ExampleIcon.ColumnChart)]
    public class ColumnChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1) };
            var yAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0, 0.1) };

            var dataSeries = new XyDataSeries<double, double>();

            var yValues = new[]{ 50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60 };
            for (var i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            var rSeries = new FastColumnRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(0xFF232323, 0.4f.ToDip(Activity)),
                FillBrushStyle = new LinearGradientBrushStyle(0, 0, 1, 1, Color.LightSteelBlue, Color.SteelBlue),
                PaletteProvider = new ColumnPaletteProvider(),
                DataPointWidth = 0.7f,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

                new WaveAnimatorBuilder(rSeries) { Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350 }.Start();
            }
        }

        private class ColumnPaletteProvider : PaletteProviderBase<FastColumnRenderableSeries>, IFillPaletteProvider
        {
            private readonly IntegerValues _colors = new IntegerValues();
            private readonly uint[] _desiredColors = { 0xFFa9d34f, 0xFFfc9930, 0xFFd63b3f };

            public override void Update()
            {
                _colors.Clear();

                var pointsCount = RenderableSeries.CurrentRenderPassData.PointsCount();
                for (int i = 0; i < pointsCount; i++)
                {
                    _colors.Add((int)_desiredColors[i % 3]);                    
                }
            }

            public IntegerValues FillColors => _colors;
        }
    }
}