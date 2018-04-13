using scichartshowcase.CustomViews;
using scichartshowcase.iOS.Renderers;
using SciChart.iOS.Charting;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System;
using scichartshowcase.CustomViews.Data.DataSeries;
using System.Linq;
using scichartshowcase.CustomViews.Visuals.Axes;
using scichartshowcase.CustomViews.Data.Ranges;
using System.Collections.Generic;
using CoreAnimation;
using Foundation;
using System.Collections.Concurrent;
using scichartshowcase.CustomViews.RenderableSeries;

[assembly: ExportRenderer(typeof(SciChartSurfaceView), typeof(SciChartSurfaceRenderer))]
namespace scichartshowcase.iOS.Renderers
{
    public class SciChartSurfaceRenderer : ViewRenderer<SciChartSurfaceView, SCIChartSurface>
    {
        // Width and heigth properties used to update SciChartSurface frame
        double width;
        double height;

        // DisplayLink variabel used to update the chart 
        CADisplayLink displayLink;

        // Queue, used like a buffer of samples
        // Enqueu when new data arrives, dequeue - when we "can" update the screen
        ConcurrentQueue<int[]> samplesQueue = new ConcurrentQueue<int[]>();

        XyDataSeries<int, int> surfaceDataSeries;
        UniformHeatmapDataSeries<int, int, int> spectrogramDataSeries;

        // X index - value of last added element into X values
        int lastElement = 0;

        int arraysToPickUp = 0;

        protected override void OnElementChanged(ElementChangedEventArgs<SciChartSurfaceView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new SCIChartSurface());
            }

            if (Control != null)
            {
                var view = (e.NewElement as SciChartSurfaceView);
                view.NativeHandle = Control.Handle;

                view.OnDataSeriesUpdated += (s, arg) =>
                {
                    // Get the data and set to the data series and re-invalidate

                    switch (Element.ChartSeries.SeriesType)
                    {
                        case RenderableSeriesType.Line:
                            var lineSeries = Element.ChartSeries as LineRenderableSeries;
                            if (lineSeries == null)
                                break;
                            UpdateDataSeries(lineSeries.DataSeries);
                            break;

                        case RenderableSeriesType.Column:
                            var columnSeries = Element.ChartSeries as ColumnRenderableSeries;
                            if (columnSeries == null)
                                break;
                            UpdateDataSeries(columnSeries.DataSeries);
                            break;

                        case RenderableSeriesType.Heatmap:
                            var renderSeries = Element.ChartSeries as HeatmapRenderableSeries;
                            if (renderSeries == null)
                                break;
                            spectrogramDataSeries.UpdateZValues(renderSeries.Data);
                            break;
                        default:
                            break;
                    }
                };
            }

            if (e.NewElement != null)
            {
                SetSize();
            }

            if (Control != null)
            {
                (e.NewElement as SciChartSurfaceView).NativeHandle = Control.Handle;
            }

            if (e.OldElement != null)
            {
                (e.NewElement as SciChartSurfaceView).NativeHandle = IntPtr.Zero;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                width = Element.WidthRequest;
                SetSize();
            }
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                height = Element.HeightRequest;
                SetSize();
            }

            if (e.PropertyName == SciChartSurfaceView.ChartSeriesProperty.PropertyName)
            {
                switch (Element.ChartSeries.SeriesType)
                {
                    case RenderableSeriesType.Line:
                        {
                            var dataSeries = (LineRenderableSeries)Element.ChartSeries;

                            surfaceDataSeries = new XyDataSeries<int, int>();
                            if (dataSeries.DataSeries.FifoCapacity > 0)
                                surfaceDataSeries.FifoCapacity = dataSeries.DataSeries.FifoCapacity;

                            Control.RenderableSeries.Add(new SCIFastLineRenderableSeries { DataSeries = surfaceDataSeries });
                            ConfigureCADisplayLinkForSamples();
                            break;
                        }
                    case RenderableSeriesType.Column:
                        {
                            var dataSeries = (ColumnRenderableSeries)Element.ChartSeries;

                            surfaceDataSeries = new XyDataSeries<int, int>();
                            if (dataSeries.DataSeries.FifoCapacity > 0)
                                surfaceDataSeries.FifoCapacity = dataSeries.DataSeries.FifoCapacity;

                            Control.RenderableSeries.Add(new SCIFastColumnRenderableSeries { DataSeries = surfaceDataSeries });
                            ConfigureCADisplayLinkForFFT();
                            break;
                        }
                    default:
                        break;
                }
            }

            if (e.PropertyName == SciChartSurfaceView.XAxesProperty.PropertyName)
            {
                foreach (var commonAxis in Element.XAxes)
                {
                    switch (commonAxis.AxisType)
                    {
                        case AxisType.NumericAxis:
                            Control.XAxes.Add(CommonAxisToNative(commonAxis));
                            break;
                        default:
                            break;
                    }
                }
            }

            if (e.PropertyName == SciChartSurfaceView.YAxesProperty.PropertyName)
            {
                foreach (var commonAxis in Element.YAxes)
                {
                    switch (commonAxis.AxisType)
                    {
                        case AxisType.NumericAxis:
                            Control.YAxes.Add(CommonAxisToNative(commonAxis));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        SCINumericAxis CommonAxisToNative(CustomViews.Visuals.Axes.AxisBase commonAxis)
        {
            var nativeNumericAxis = new SCINumericAxis
            {
                FlipCoordinates = commonAxis.FlipCoordinates
            };

            nativeNumericAxis.Style = new SCIAxisStyle
            {
                DrawMajorBands = commonAxis.DrawMajorBands,
                DrawMinorTicks = commonAxis.DrawMinorTicks,
                DrawMajorGridLines = commonAxis.DrawMajorGridLines,
                DrawMinorGridLines = commonAxis.DrawMinorGridLines,
                DrawLabels = commonAxis.DrawLabels,
                DrawMajorTicks = commonAxis.DrawMajorTicks
            };

            nativeNumericAxis.AxisAlignment = commonAxis.AxisAlignment == AxisAlignment.Left ? SCIAxisAlignment.Left :
                commonAxis.AxisAlignment == AxisAlignment.Top ? SCIAxisAlignment.Top :
                commonAxis.AxisAlignment == AxisAlignment.Right ? SCIAxisAlignment.Right :
                commonAxis.AxisAlignment == AxisAlignment.Bottom ? SCIAxisAlignment.Bottom :
                SCIAxisAlignment.Default;

            nativeNumericAxis.AutoRange = commonAxis.AutoRange == AutoRange.Never ? SCIAutoRange.Never :
                commonAxis.AutoRange == AutoRange.Always ? SCIAutoRange.Always : SCIAutoRange.Once;

            if (commonAxis.VisibleRange != null)
            {
                nativeNumericAxis.VisibleRange = new SCIDoubleRange(commonAxis.VisibleRange.Min, commonAxis.VisibleRange.Max);
            }

            return nativeNumericAxis;
        }

        #region Private methods

        void SetSize()
        {
            Control.TranslatesAutoresizingMaskIntoConstraints = true;
            Control.Frame = new CoreGraphics.CGRect(0, 0, width, height);
        }

        void UpdateDataSeries(XYDataSeries<int, int> dataSeries)
        {
            samplesQueue.Enqueue(dataSeries.YValues);
            ++arraysToPickUp;
        }

        #endregion

        #region CADisplayLink configuration

        void ConfigureCADisplayLinkForSamples()
        {
            displayLink = CADisplayLink.Create(() =>
            {
                var arraysCount = arraysToPickUp;
                arraysToPickUp = 0;

                for (int j = 0; j < arraysCount; j++)
                {
                    int[] yArray;
                    samplesQueue.TryDequeue(out yArray);
                    if (j == 0)
                    {
                        if (yArray == null)
                            return;

                        var xArray = new int[yArray.Length];

                        for (int i = 0; i < yArray.Length; i++)
                        {
                            xArray[i] = lastElement++;
                        }
                        surfaceDataSeries.Append(xArray, yArray);
                    }
                }
                Control.ZoomExtentsX();
                Control.InvalidateElement();

            });
            displayLink.AddToRunLoop(NSRunLoop.Main, NSRunLoopMode.Common);
        }

        void ConfigureCADisplayLinkForFFT()
        {
            displayLink = CADisplayLink.Create(() =>
            {
                var arraysCount = arraysToPickUp;
                arraysToPickUp = 0;

                for (int j = 0; j < arraysCount; j++)
                {
                    int[] yArray;
                    samplesQueue.TryDequeue(out yArray);
                    if (yArray == null)
                        return;

                    var xArray = new int[yArray.Length];

                    for (int i = 0; i < yArray.Length; i++)
                    {
                        xArray[i] = i;
                    }
                    if (surfaceDataSeries.XValues.Count == 0)
                        surfaceDataSeries.Append(xArray, yArray);
                    else
                        surfaceDataSeries.UpdateRangeYAt(0, yArray);
                }
                Control.InvalidateElement();

            });
            displayLink.AddToRunLoop(NSRunLoop.Main, NSRunLoopMode.Common);
        }

        #endregion
    }
}