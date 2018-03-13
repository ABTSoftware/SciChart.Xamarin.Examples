using System;
using System.Collections.Generic;
using System.ComponentModel;
using scichartshowcase.CustomViews.Data.DataSeries;
using scichartshowcase.CustomViews.RenderableSeries;
using scichartshowcase.CustomViews.Visuals.Axes;
using Xamarin.Forms;

namespace scichartshowcase.CustomViews
{
    public class SciChartSurfaceView : View
    {
        public IntPtr NativeHandle;

        public event EventHandler OnDataSeriesUpdated;

        public static readonly BindableProperty ChartSeriesProperty = BindableProperty.Create(
            propertyName: "ChartSeries",
            returnType: typeof(RenderableSeriesBase),
            declaringType: typeof(SciChartSurfaceView),
            defaultValue: null);

        public RenderableSeriesBase ChartSeries
        {
            get { return (RenderableSeriesBase)GetValue(ChartSeriesProperty); }
            set
            {
                SetValue(ChartSeriesProperty, value);
            }
        }

        public static readonly BindableProperty XAxesProperty = BindableProperty.Create(
            propertyName: "XAxes",
            returnType: typeof(List<AxisBase>),
            declaringType: typeof(SciChartSurfaceView),
            defaultValue: null);

        public List<AxisBase> XAxes
        {
            get { return (List<AxisBase>)GetValue(XAxesProperty); }
            set
            {
                SetValue(XAxesProperty, value);
            }
        }

        public static readonly BindableProperty YAxesProperty = BindableProperty.Create(
            propertyName: "YAxes",
            returnType: typeof(List<AxisBase>),
            declaringType: typeof(SciChartSurfaceView),
            defaultValue: null);

        public List<AxisBase> YAxes
        {
            get { return (List<AxisBase>)GetValue(YAxesProperty); }
            set
            {
                SetValue(YAxesProperty, value);
            }
        }

        public void UpdateDataSeries()
        {
            OnDataSeriesUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}