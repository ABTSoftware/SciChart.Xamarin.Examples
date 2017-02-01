using System.Collections.Generic;
using Android.Graphics;
using Android.Util;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Using TooltipModifier Tooltips")]
    public class UsingTooltipModifierTooltipsFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Lissajous Curve", AcceptsUnsortedData = true};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Sinewave", AcceptsUnsortedData = true};

            var ds1Points = DataManager.Instance.GetLissajousCurve(0.8, 0.2, 0.43, 500);
            var ds2Points = DataManager.Instance.GetSinewave(1.5, 1.0, 500);

            var scaledXValues = GetScaledValues(ds1Points.XData);

            ds1.Append(scaledXValues, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);
            
            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);

                var rs1Color = Color.SteelBlue;
                var rs2Color = Color.IndianRed;

                Surface.RenderableSeries = new RenderableSeriesCollection
                {
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds1,
                        StrokeStyle = new SolidPenStyle(Activity, rs1Color, true, 2f),
                        PointMarker = new EllipsePointMarker
                        {
                            Width = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 5, Context.Resources.DisplayMetrics),
                            Height = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 5, Context.Resources.DisplayMetrics),
                            StrokeStyle = new SolidPenStyle(Activity, rs1Color, true, 2f),
                            FillStyle = new SolidBrushStyle(rs1Color)
                        }
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds2,
                            StrokeStyle = new SolidPenStyle(Activity, rs2Color, true, 2f),
                        PointMarker = new EllipsePointMarker
                        {
                            Width = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 5, Context.Resources.DisplayMetrics),
                            Height = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 5, Context.Resources.DisplayMetrics),
                            StrokeStyle = new SolidPenStyle(Activity, rs2Color, true, 2f),
                            FillStyle = new SolidBrushStyle(rs2Color)
                        }
                    },
                };

                Surface.ChartModifiers.Add(new TooltipModifier {UseInterpolation = true});
            }
        }

        private static IList<double> GetScaledValues(IList<double> values)
        {
            var size = values.Count;

            var scaledValues = new List<double>(size);

            for (var i = 0; i < size; i++)
            {
                var value = values[i];
                scaledValues.Add((value + 1)*5);
            }

            return scaledValues;
        }
    }
}