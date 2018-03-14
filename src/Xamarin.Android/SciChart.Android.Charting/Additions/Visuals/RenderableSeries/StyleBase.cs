using Android.Runtime;
using Java.Lang;
using Object = Java.Lang.Object;
using SciChart.Core.Framework;

namespace SciChart.Charting.Visuals.RenderableSeries
{
    public abstract class StyleBase<T> : StyleBase where T : class, ISuspendable 
    {
        protected StyleBase() : base(Class.FromType(typeof(T))) { }

        protected sealed override void ApplyStyleInternal(Object objectToStyle)
        {
            ApplyStyleInternal(objectToStyle.JavaCast<T>());
        }

        protected abstract void ApplyStyleInternal(T objectToStyle);

        protected sealed override void DiscardStyleInternal(Object objectToStyle)
        {
            DiscardStyleInternal(objectToStyle.JavaCast<T>());
        }

        protected abstract void DiscardStyleInternal(T objectToStyle);

        protected TProperty GetPropertyValue<TProperty>(T objectToStyle, string propertyName) where TProperty : class
        {
            return GetPropertyValue(objectToStyle.JavaCast<Object>(), propertyName, Class.FromType(typeof(TProperty))) as TProperty;
        }

        protected void PutPropertyValue(T objectToStyle, string propertyName, Object propertyValue)
        {
            PutPropertyValue(objectToStyle.JavaCast<Object>(), propertyName, propertyValue);
        }
    }
}