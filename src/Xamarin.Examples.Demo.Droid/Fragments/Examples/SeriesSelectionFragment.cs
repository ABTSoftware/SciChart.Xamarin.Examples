using Android.Graphics;
using Android.Runtime;
using SciChart.Android.Core.Additions.Utility;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Object = Java.Lang.Object;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Series Selection")]
    public class SeriesSelectionFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        private const int SeriesPointCount = 50;
        private const int SeriesCount = 80;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) {AutoRange = AutoRange.Always};
            var leftAxis = new NumericAxis(Activity) {AxisAlignment = AxisAlignment.Left, AxisId = AxisAlignment.Left.Name()};
            var rightAxis = new NumericAxis(Activity) {AxisAlignment = AxisAlignment.Right, AxisId = AxisAlignment.Right.Name()};

            var selectedStrokeStyle = new SolidPenStyle(Activity, Color.White, true, 4f);
            var selectedPointMarker = new EllipsePointMarker
            {
                Width = 10.ToDip(Context),
                Height = 10.ToDip(Context),
                FillStyle = new SolidBrushStyle(Color.Argb(0xFF, 0xFF, 0x00, 0xDC)),
                StrokeStyle = new SolidPenStyle(Activity, Color.White)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(leftAxis);
                Surface.YAxes.Add(rightAxis);

                var initialColor = Color.Blue;
                for (var i = 0; i < SeriesCount; i++)
                {
                    var alignment = i%2 == 0 ? AxisAlignment.Left : AxisAlignment.Right;
                    var dataSeries = GenerateDataSeries(alignment, i);

                    var rs = new FastLineRenderableSeries
                    {
                        DataSeries = dataSeries,
                        YAxisId = alignment.Name(),
                        StrokeStyle = new SolidPenStyle(Activity, initialColor, true, 2f),
                    };

                    // Colors are incremented for visual purposes only
                    var newR = initialColor.R == 255 ? 255 : initialColor.R + 5;
                    var newB = initialColor.B == 0 ? 0 : initialColor.B - 2;
                    initialColor = Color.Argb(255, (byte) newR, initialColor.G, (byte) newB);

                    Surface.RenderableSeries.Add(rs);
                }

                Surface.ChartModifiers.Add(new SeriesSelectionModifier
                {
                    SelectedSeriesStyle = new SelectedSeriesStyle(selectedStrokeStyle, selectedPointMarker)
                });
            }
        }

        private static IDataSeries GenerateDataSeries(AxisAlignment alignment, int index)
        {
            var dataSeries = new XyDataSeries<double, double> {SeriesName = $"Series {index}"};

            var gradient = alignment == AxisAlignment.Right ? index : -index;
            var start = alignment == AxisAlignment.Right ? 0d : 14000d;

            var straightLine = DataManager.Instance.GetStraightLine(gradient, start, SeriesPointCount);

            dataSeries.Append(straightLine.XData, straightLine.YData);

            return dataSeries;
        }
    }

    public class SelectedSeriesStyle : SeriesStyleBase<IRenderableSeries>
    {
        private readonly PenStyle _selectedStrokeStyle;
        private readonly IPointMarker _selectedPointMarker;

        private const string Stroke = "Stroke";
        private const string PointMarker = "PointMarker";

        public SelectedSeriesStyle(PenStyle selectedStrokeStyle, IPointMarker selectedPointMarker)
        {
            _selectedStrokeStyle = selectedStrokeStyle;
            _selectedPointMarker = selectedPointMarker;
        }

        protected override void ApplyStyleInternal(IRenderableSeries renderableSeriesToStyle)
        {
            PutPropertyValue(renderableSeriesToStyle, Stroke, renderableSeriesToStyle.StrokeStyle);
            PutPropertyValue(renderableSeriesToStyle, PointMarker, renderableSeriesToStyle.PointMarker.JavaCast<Object>());

            renderableSeriesToStyle.StrokeStyle = _selectedStrokeStyle;
            renderableSeriesToStyle.PointMarker = _selectedPointMarker;
        }

        protected override void DiscardStyleInternal(IRenderableSeries renderableSeriesToStyle)
        {
            renderableSeriesToStyle.StrokeStyle = GetPropertyValue<PenStyle>(renderableSeriesToStyle, Stroke);
            renderableSeriesToStyle.PointMarker = GetPropertyValue<IPointMarker>(renderableSeriesToStyle, PointMarker);
        }
    }
}