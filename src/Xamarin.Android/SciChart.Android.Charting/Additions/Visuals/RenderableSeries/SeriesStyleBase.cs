using System;
using Android.Runtime;
using Java.Lang;
using Object = Java.Lang.Object;

namespace SciChart.Charting.Visuals.RenderableSeries
{
    public abstract class SeriesStyleBase<T> : SeriesStyleBase where T : class, IRenderableSeries
    {
        protected SeriesStyleBase() : base(Class.FromType(typeof(T)))
        {
        }

        protected sealed override void ApplyStyleInternal(Object renderableSeriesToStyle)
        {
            ApplyStyleInternal(renderableSeriesToStyle.JavaCast<T>());
        }

        protected abstract void ApplyStyleInternal(T renderableSeriesToStyle);

        protected sealed override void DiscardStyleInternal(Object renderableSeriesToStyle)
        {
            DiscardStyleInternal(renderableSeriesToStyle.JavaCast<T>());
        }

        protected abstract void DiscardStyleInternal(T renderableSeriesToStyle);

        protected TProperty GetPropertyValue<TProperty>(IRenderableSeries rsToStyle, string propertyName) where TProperty : class
        {
            return GetPropertyValue(rsToStyle, propertyName, Class.FromType(typeof (TProperty))) as TProperty;
        }
    }
}