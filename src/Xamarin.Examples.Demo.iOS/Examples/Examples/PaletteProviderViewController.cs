using UIKit;
using System;
using CoreGraphics;
using ObjCRuntime;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using System.Linq;
using Foundation;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Palette Provider", description: "Per-point coloring with the PaletteProvider API", icon: ExampleIcon.Themes)]
    public class PaletteProviderViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(150, 165) };
            var yAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                AutoRange = SCIAutoRange.Always,
                LabelProvider = new ThousandsLabelProvider(),
            };

            var dataManager = DataManager.Instance;
            var priceBars = dataManager.GetPriceDataIndu();
            
            var mountainDataSeries = new XyDataSeries<double, double>();
            var lineDataSeries = new XyDataSeries<double, double>();
            var columnDataSeries = new XyDataSeries<double, long>();
            var ohlcDataSeries = new OhlcDataSeries<double, double>();
            var candlestickDataSeries = new OhlcDataSeries<double, double>();
            var scatterDataSeries = new XyDataSeries<double, double>();

            var offset = -1000.0;
            var xValues = Enumerable.Range(0, priceBars.Count).Select(x => (double)x).ToArray();

            mountainDataSeries.Append(xValues, priceBars.LowData);
            lineDataSeries.Append(xValues, priceBars.CloseData.Select(x => x - offset));
            columnDataSeries.Append(xValues, priceBars.CloseData.Select(x => (long)(x + offset * 3)));
            ohlcDataSeries.Append(xValues, priceBars.OpenData, priceBars.HighData, priceBars.LowData, priceBars.CloseData);
            candlestickDataSeries.Append(xValues,
                priceBars.OpenData.Select(x => x + offset),
                priceBars.HighData.Select(x => x + offset),
                priceBars.LowData.Select(x => x + offset),
                priceBars.CloseData.Select(x => x + offset));
            scatterDataSeries.Append(xValues, priceBars.CloseData.Select(x => x + offset * 2.5));

            var boxAnnotation = new SCIBoxAnnotation
            {
                X1Value = 152d,
                Y1Value = 0d,
                X2Value = 158d,
                Y2Value = 1d,
                CoordinateMode = SCIAnnotationCoordinateMode.RelativeY,
                IsEditable = true,
                FillBrush = new SCILinearGradientBrushStyle(new CGPoint(0, 0), new CGPoint(0, 1), 0x550000FF, 0x55FFFF00),
                BorderPen = new SCISolidPenStyle(0xFF279B27, 1),
                AnnotationDragListener = new AnnotationDragListener(),
            };

            var mountainSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = mountainDataSeries,
                AreaStyle = new SCISolidBrushStyle(0x9787CEEB),
                StrokeStyle = new SCISolidPenStyle(0xFFFF00FF, 1),
                ZeroLineY = 6000,
                PaletteProvider = new XyCustomPaletteProvider(0xFFFF0000, boxAnnotation),
            };

            var lineSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = lineDataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFFFF00FF, 1),
                PointMarker = new SCIEllipsePointMarker
                {
                    Size = new CGSize(10, 10),
                    FillStyle = new SCISolidBrushStyle(UIColor.Red),
                    StrokeStyle = new SCISolidPenStyle(UIColor.Orange, 2),
                },
                PaletteProvider = new XyCustomPaletteProvider(0xFFFF0000, boxAnnotation),
            };

            var columnSeries = new SCIFastColumnRenderableSeries
            {
                DataSeries = columnDataSeries,
                StrokeStyle = new SCISolidPenStyle(UIColor.Blue, 1),
                ZeroLineY = 6000,
                FillBrushStyle = new SCISolidBrushStyle(UIColor.Blue),
                PaletteProvider = new XyCustomPaletteProvider(0xFFFF00FF, boxAnnotation),
            };

            var ohlcSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = ohlcDataSeries,
                PaletteProvider = new OhlcCustomPaletteProvider(0xFF0000FF, boxAnnotation),
            };

            var candlestickSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = candlestickDataSeries,
                PaletteProvider = new OhlcCustomPaletteProvider(0xFF00FF00, boxAnnotation),
            };

            var scatterSeries = new SCIXyScatterRenderableSeries
            {
                DataSeries = scatterDataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFFFF00FF, 1),
                PointMarker = new SCISquarePointMarker
                {
                    Size = new CGSize(7, 7),
                    FillStyle = new SCISolidBrushStyle(UIColor.Red),
                    StrokeStyle = new SCISolidPenStyle(UIColor.Orange, 2),
                },
                PaletteProvider = new XyCustomPaletteProvider(0xFF00FF00, boxAnnotation),
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(mountainSeries);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(columnSeries);
                Surface.RenderableSeries.Add(ohlcSeries);
                Surface.RenderableSeries.Add(candlestickSeries);
                Surface.RenderableSeries.Add(scatterSeries);
                Surface.ChartModifiers.Add(CreateDefaultModifiers());
                Surface.Annotations.Add(boxAnnotation);

                SCIAnimations.ScaleSeriesWithZeroLine(mountainSeries, 10500d, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(candlestickSeries, 11700d, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(lineSeries, 12250d, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(columnSeries, 10500d, 3, new SCIElasticEase());
            }
        }

        private class AnnotationDragListener : NSObject, ISCIAnnotationDragListener
        {
            public void OnDragStarted(IISCIAnnotation annotation) => UpdateAnnotation(annotation);
            public void OnDragAnnotation(IISCIAnnotation annotation, nfloat xDelta, nfloat yDelta) => UpdateAnnotation(annotation);
            public void OnDragEnded(IISCIAnnotation annotation) => UpdateAnnotation(annotation);
            
            private void UpdateAnnotation(IISCIAnnotation annotation)
            {
                var annotationBase = Runtime.GetNSObject<SCIAnnotationBase>(annotation.Handle);
                annotationBase.Y1Value = 0d;
                annotationBase.Y2Value = 1d;
            }
        }

        private class XyCustomPaletteProvider : SCIPaletteProviderBase<SCIXyRenderableSeriesBase>, IISCIFillPaletteProvider, IISCIStrokePaletteProvider, IISCIPointMarkerPaletteProvider
        {
            private readonly SCIUnsignedIntegerValues _colors = new SCIUnsignedIntegerValues();
            private readonly uint _color;
            private readonly SCIBoxAnnotation _annotation;

            public XyCustomPaletteProvider(uint color, SCIBoxAnnotation annotation)
            {
                _color = color;
                _annotation = annotation;
            }

            public override void Update()
            {
                var rpd = Runtime.GetNSObject<SCIXyRenderPassData>(RenderableSeries.CurrentRenderPassData.Handle);
                var xValues = rpd.XValues;

                var count = rpd.PointsCount;
                xValues.Count = count;

                var x1 = (double)_annotation.X1Value;
                var x2 = (double)_annotation.X2Value;

                var min = Math.Min(x1, x2);
                var max = Math.Max(x1, x2);

                _colors.Clear();
                for (int i = 0; i < count; i++)
                {
                    var value = xValues.GetValueAt(i);
                    if (value > min && value < max)
                        _colors.Add(_color);
                    else
                        _colors.Add(DefaultColor);
                }
            }

            public SCIUnsignedIntegerValues FillColors => _colors;
            public SCIUnsignedIntegerValues StrokeColors => _colors;
            public SCIUnsignedIntegerValues PointMarkerColors => _colors;
        }

        private class OhlcCustomPaletteProvider : SCIPaletteProviderBase<SCIOhlcRenderableSeriesBase>, IISCIFillPaletteProvider, IISCIStrokePaletteProvider, IISCIPointMarkerPaletteProvider
        {
            private readonly SCIUnsignedIntegerValues _colors = new SCIUnsignedIntegerValues();
            private readonly uint _color;
            private readonly SCIBoxAnnotation _annotation;

            public OhlcCustomPaletteProvider(uint color, SCIBoxAnnotation annotation)
            {
                _color = color;
                _annotation = annotation;
            }

            public override void Update()
            {
                var rpd = Runtime.GetNSObject<SCIOhlcRenderPassData>(RenderableSeries.CurrentRenderPassData.Handle);
                var xValues = rpd.XValues;

                var count = rpd.PointsCount;
                xValues.Count = count;

                var x1 = (double)_annotation.X1Value;
                var x2 = (double)_annotation.X2Value;

                var min = Math.Min(x1, x2);
                var max = Math.Max(x1, x2);

                _colors.Clear();
                for (int i = 0; i < count; i++)
                {
                    var value = xValues.GetValueAt(i);
                    if (value > min && value < max)
                        _colors.Add(_color);
                    else
                        _colors.Add(DefaultColor);
                }
            }

            public SCIUnsignedIntegerValues FillColors => _colors;
            public SCIUnsignedIntegerValues StrokeColors => _colors;
            public SCIUnsignedIntegerValues PointMarkerColors => _colors;
        }
    }
}