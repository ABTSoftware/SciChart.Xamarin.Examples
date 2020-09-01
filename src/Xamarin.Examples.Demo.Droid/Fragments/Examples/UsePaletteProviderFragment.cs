using System.Linq;
using System.Drawing;
using Java.Lang;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;
using SciChart.Charting.Visuals.RenderableSeries.PaletteProviders;
using SciChart.Core.Model;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Use PaletteProvider", description: " Demonstrates how to use the PaletteProvider API to color lines and points individually.", icon: ExampleIcon.Themes)]
    public class UsePaletteProviderFragment : ExampleBaseFragment
    {
        private static readonly int DefaultColor = 0x00FFFFFF;
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) {VisibleRange = new DoubleRange(150d, 165d)};
            var yAxis = new NumericAxis(Activity)
            {
                LabelProvider = new ThousandsLabelProvider(),
                GrowBy = new DoubleRange(0, 0.1),
                AutoRange = AutoRange.Always
            };

            var dataManager = DataManager.Instance;
            var priceBars = dataManager.GetPriceDataIndu();

            var mountainDataSeries = new XyDataSeries<double, double>() {SeriesName = "Mountain Series"};
            var lineDataSeries = new XyDataSeries<double, double>() {SeriesName = "Line Series"};
            var columnDataSeries = new XyDataSeries<double, double>() {SeriesName = "Column Series"};
            var scatterDataSeries = new XyDataSeries<double, double>() {SeriesName = "Scatter Series"};
            var candlestickDataSeries = new OhlcDataSeries<double, double>() {SeriesName = "Candlestick Series"};
            var ohlcDataSeries = new OhlcDataSeries<double, double>() {SeriesName = "OHLC Series"};

            var xValues = Enumerable.Range(0, priceBars.Count).Select(x => (double) x).ToArray();

            mountainDataSeries.Append(xValues, priceBars.LowData.Select(x => x - 2000d));
            lineDataSeries.Append(xValues, priceBars.CloseData.Select(x => x + 1000d));
            ohlcDataSeries.Append(xValues, priceBars.OpenData, priceBars.HighData, priceBars.LowData, priceBars.CloseData);
            candlestickDataSeries.Append(xValues, priceBars.OpenData.Select(x => x - 1000d), priceBars.HighData.Select(x => x - 1000d), priceBars.LowData.Select(x => x - 1000d), priceBars.CloseData.Select(x => x - 1000d));
            columnDataSeries.Append(xValues, priceBars.CloseData.Select(x => x - 3000d));
            scatterDataSeries.Append(xValues, priceBars.OpenData.Select(x => x - 2500d));

            var annotation = new BoxAnnotation(Activity)
            {
                X1Value = 152d,
                Y1Value = 0d,
                X2Value = 158d,
                Y2Value = 1d,
                Background = Activity.GetDrawableCompat(Resource.Drawable.example_box_annotation_background_1),
                IsEditable = true,
                CoordinateMode = AnnotationCoordinateMode.RelativeY
            };

            annotation.SetOnAnnotationDragListener(new AnnotationDragListener());

            var mountainSeries = new FastMountainRenderableSeries
            {
                DataSeries = mountainDataSeries,
                AreaStyle = new SolidBrushStyle(0x9787CEEB),
                StrokeStyle = new SolidPenStyle(Color.Magenta),
                PaletteProvider = new XyCustomPaletteProvider(Color.Red, annotation)
            };

            var lineSeries = new FastLineRenderableSeries
            {
                DataSeries = lineDataSeries,
                StrokeStyle = new SolidPenStyle(Color.Blue),
                PointMarker = new EllipsePointMarker()
                    {
                        FillStyle = new SolidBrushStyle(Color.Red),
                        StrokeStyle = new SolidPenStyle(Color.Orange, 2f.ToDip(Activity)),
                        Width = (int) 10f.ToDip(Activity),
                        Height = (int) 10f.ToDip(Activity)
                    },
                PaletteProvider = new XyCustomPaletteProvider(Color.Red, annotation)
            };

            var ohlcSeries = new FastOhlcRenderableSeries()
            {
                DataSeries = ohlcDataSeries,
                PaletteProvider = new OhlcCustomPaletteProvider(Color.CornflowerBlue, annotation)
            };

            var candlestickSeries = new FastCandlestickRenderableSeries
            {
                DataSeries = candlestickDataSeries,
                PaletteProvider = new OhlcCustomPaletteProvider(Color.Green, annotation)
            };

            var columnSeries = new FastColumnRenderableSeries
            {
                DataSeries = columnDataSeries,
                StrokeStyle = new SolidPenStyle(Color.Blue),
                FillBrushStyle = new SolidBrushStyle(Color.Blue),
                ZeroLineY = 6000,
                DataPointWidth = 0.8,
                PaletteProvider = new XyCustomPaletteProvider(Color.Purple, annotation)
            };

            var scatterSeries = new XyScatterRenderableSeries()
            {
                DataSeries = scatterDataSeries,
                PointMarker = new SquarePointMarker()
                    {
                        FillStyle = new SolidBrushStyle(Color.Red),
                        StrokeStyle = new SolidPenStyle(Color.Orange, 2f.ToDip(Activity)),
                        Width = (int) 7f.ToDip(Activity),
                        Height = (int) 7f.ToDip(Activity)
                    },
                PaletteProvider = new XyCustomPaletteProvider(Color.LimeGreen, annotation)
            };


            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);

                Surface.RenderableSeries.Add(mountainSeries);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(ohlcSeries);
                Surface.RenderableSeries.Add(candlestickSeries);
                Surface.RenderableSeries.Add(columnSeries);
                Surface.RenderableSeries.Add(scatterSeries);

                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

                Surface.Annotations.Add(annotation);
            }
        }

        private class AnnotationDragListener : Object, IOnAnnotationDragListener
        {
            public void OnDragDelta(IAnnotation annotation, float horizontalOffset, float verticalOffset)
            {
                UpdateAnnotation((AnnotationBase)annotation);
            }

            public void OnDragEnded(IAnnotation annotation)
            {
                UpdateAnnotation((AnnotationBase)annotation);
            }

            public void OnDragStarted(IAnnotation annotation)
            {
                UpdateAnnotation((AnnotationBase)annotation);
            }

            private void UpdateAnnotation(AnnotationBase annotation)
            {
                annotation.Y1Value = 0d;
                annotation.Y2Value = 1d;

                annotation.ParentSurface.InvalidateElement();
            }
        }

        private class XyCustomPaletteProvider : PaletteProviderBase<XyRenderableSeriesBase>, IFillPaletteProvider, IStrokePaletteProvider, IPointMarkerPaletteProvider
        {
            private readonly IntegerValues _colors = new IntegerValues();

            private readonly int _color;
            private readonly BoxAnnotation _annotation;

            public XyCustomPaletteProvider(Color color, BoxAnnotation annotation)
            {
                _color = color.ToArgb();
                _annotation = annotation;
            }

            public override void Update()
            {
                var xyRenderPassData = (XyRenderPassData) RenderableSeries.CurrentRenderPassData;
                var xValues = xyRenderPassData.XValues;

                var x1 = (double) _annotation.X1Value;
                var x2 = (double) _annotation.X2Value;

                var min = Math.Min(x1, x2);
                var max = Math.Max(x1, x2);

                _colors.Clear();
                for (int i = 0; i < xyRenderPassData.PointsCount(); i++)
                {
                    var value = xValues.Get(i);
                    if(value > min && value < max)
                        _colors.Add(_color);
                    else
                        _colors.Add(DefaultColor);
                }
            }

            public IntegerValues FillColors => _colors;
            public IntegerValues StrokeColors => _colors;
            public IntegerValues PointMarkerColors => _colors;
        }

        private class OhlcCustomPaletteProvider : PaletteProviderBase<OhlcRenderableSeriesBase>, IFillPaletteProvider, IStrokePaletteProvider, IPointMarkerPaletteProvider
        {
            private readonly IntegerValues _colors = new IntegerValues();

            private readonly int _color;
            private readonly BoxAnnotation _annotation;

            public OhlcCustomPaletteProvider(Color color, BoxAnnotation annotation)
            {
                _color = color.ToArgb();
                _annotation = annotation;
            }

            public override void Update()
            {
                var xyRenderPassData = (OhlcRenderPassData)RenderableSeries.CurrentRenderPassData;
                var xValues = xyRenderPassData.XValues;

                var x1 = (double)_annotation.X1Value;
                var x2 = (double)_annotation.X2Value;

                var min = Math.Min(x1, x2);
                var max = Math.Max(x1, x2);

                _colors.Clear();
                for (int i = 0; i < xyRenderPassData.PointsCount(); i++)
                {
                    var value = xValues.Get(i);
                    if (value > min && value < max)
                        _colors.Add(_color);
                    else
                        _colors.Add(DefaultColor);
                }
            }

            public IntegerValues FillColors => _colors;
            public IntegerValues StrokeColors => _colors;
            public IntegerValues PointMarkerColors => _colors;
        }
    }
}