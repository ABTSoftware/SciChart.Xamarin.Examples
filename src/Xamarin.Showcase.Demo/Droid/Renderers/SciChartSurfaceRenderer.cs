using System;
using System.Collections.Concurrent;
using System.Linq;
using Android.Views;
using Java.Lang;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using scichartshowcase.CustomViews;
using scichartshowcase.CustomViews.Data.DataSeries;
using scichartshowcase.CustomViews.RenderableSeries;
using scichartshowcase.CustomViews.Visuals.Axes;
using scichartshowcase.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.Choreographer;

[assembly: ExportRenderer(typeof(SciChartSurfaceView), typeof(SciChartSurfaceRenderer))]
namespace scichartshowcase.Droid.Renderers
{
    public class SciChartSurfaceRenderer : ViewRenderer<SciChartSurfaceView, SciChartSurface>
    {
        XyDataSeries<int, int> samplesDataSeries;
        XyDataSeries<int, int> fftDataSeries;
        UniformHeatmapDataSeries<int, int, int> spectrogramDataSeries;

        // X index - value of last added element into X values
        int lastElement = 0;

        // Number of arrays to pick up from the samples queue
        public int arraysToPickUp = 0;

        protected override void OnElementChanged(ElementChangedEventArgs<SciChartSurfaceView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new SciChartSurface(Android.App.Application.Context));
            }

            if (Control != null)
            {
                var view = (e.NewElement as SciChartSurfaceView);
                view.NativeHandle = Control.Handle;
                view.OnDataSeriesUpdated += (s, arg) =>
                {
                    switch (Element.ChartSeries.SeriesType)
                    {
                        case RenderableSeriesType.Line:
                            var lineSeries = Element.ChartSeries as LineRenderableSeries;
                            if (lineSeries == null)
                                break;
                            UpdateSamplesDataSeries(lineSeries.DataSeries);
                            break;

                        case RenderableSeriesType.Column:
                            var columnSeries = Element.ChartSeries as ColumnRenderableSeries;
                            if (columnSeries == null)
                                break;
                            UpdateFFTDataSeries(columnSeries.DataSeries);
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

                    //Control.InvalidateElement();
                };
            }

            if (e.OldElement != null)
            {
                (e.NewElement as SciChartSurfaceView).NativeHandle = IntPtr.Zero;
            }
        }

        private void UpdateSamplesDataSeries(XYDataSeries<int, int> dataSeries)
        {
            var xArray = new int[dataSeries.YValues.Length];

            for (int i = 0; i < dataSeries.YValues.Length; i++)
            {
                xArray[i] = lastElement++;
            }
            samplesDataSeries.Append(xArray, dataSeries.YValues);
        }

        private void UpdateFFTDataSeries(XYDataSeries<int, int> dataSeries)
        {
            var xArray = new int[dataSeries.YValues.Length];

            for (int i = 0; i < dataSeries.YValues.Length; i++)
            {
                xArray[i] = i;
            }

            if (fftDataSeries.Count == 0)
                fftDataSeries.Append(xArray, dataSeries.YValues);
            else
                fftDataSeries.UpdateRangeYAt(0, dataSeries.YValues);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SciChartSurfaceView.ChartSeriesProperty.PropertyName)
            {
                switch (Element.ChartSeries.SeriesType)
                {
                    case RenderableSeriesType.Line:
                        {
                            var dataSeries = ((LineRenderableSeries)Element.ChartSeries).DataSeries as XYDataSeries<int, int>;

                            samplesDataSeries = new XyDataSeries<int, int>();
                            if (dataSeries.FifoCapacity > 0)
                                samplesDataSeries.FifoCapacity = (Java.Lang.Integer)dataSeries.FifoCapacity;

                            Control.RenderableSeries.Add(new FastLineRenderableSeries { DataSeries = samplesDataSeries });
                            break;
                        }

                    case RenderableSeriesType.Column:
                        {
                            var dataSeries = ((ColumnRenderableSeries)Element.ChartSeries).DataSeries as XYDataSeries<int, int>;

                            fftDataSeries = new XyDataSeries<int, int>();
                            if (dataSeries.FifoCapacity > 0)
                                fftDataSeries.FifoCapacity = (Integer)dataSeries.FifoCapacity;

                            Control.RenderableSeries.Add(new FastColumnRenderableSeries { DataSeries = fftDataSeries, ZeroLineY = -30 });
                            break;
                        }

                    case RenderableSeriesType.Heatmap:
                        {
                            spectrogramDataSeries = new UniformHeatmapDataSeries<int, int, int>(1024, 1024);

                            Control.RenderableSeries.Add(new FastUniformHeatmapRenderableSeries { DataSeries = spectrogramDataSeries });
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

        SciChart.Charting.Visuals.Axes.NumericAxis CommonAxisToNative(CustomViews.Visuals.Axes.AxisBase commonAxis)
        {
            var nativeNumericAxis = new SciChart.Charting.Visuals.Axes.NumericAxis(Context)
            {
                FlipCoordinates = commonAxis.FlipCoordinates,
                DrawMajorBands = commonAxis.DrawMajorBands,
                DrawMinorTicks = commonAxis.DrawMinorTicks,
                DrawMajorGridLines = commonAxis.DrawMajorGridLines,
                DrawMinorGridLines = commonAxis.DrawMinorGridLines,
                DrawLabels = commonAxis.DrawLabels,
                DrawMajorTicks = commonAxis.DrawMajorTicks
            };

            nativeNumericAxis.AxisAlignment = commonAxis.AxisAlignment == CustomViews.Visuals.Axes.AxisAlignment.Left ? SciChart.Charting.Visuals.Axes.AxisAlignment.Left :
                commonAxis.AxisAlignment == CustomViews.Visuals.Axes.AxisAlignment.Top ? SciChart.Charting.Visuals.Axes.AxisAlignment.Top :
                commonAxis.AxisAlignment == CustomViews.Visuals.Axes.AxisAlignment.Right ? SciChart.Charting.Visuals.Axes.AxisAlignment.Right :
                commonAxis.AxisAlignment == CustomViews.Visuals.Axes.AxisAlignment.Bottom ? SciChart.Charting.Visuals.Axes.AxisAlignment.Bottom :
                SciChart.Charting.Visuals.Axes.AxisAlignment.Auto;

            nativeNumericAxis.AutoRange = commonAxis.AutoRange == CustomViews.Data.Ranges.AutoRange.Never ? AutoRange.Never :
                commonAxis.AutoRange == CustomViews.Data.Ranges.AutoRange.Always ? AutoRange.Always : AutoRange.Once;

            if (commonAxis.VisibleRange != null)
            {
                nativeNumericAxis.VisibleRange = new SciChart.Data.Model.DoubleRange(commonAxis.VisibleRange.Min, commonAxis.VisibleRange.Max);
            }

            return nativeNumericAxis;
        }
    }
}