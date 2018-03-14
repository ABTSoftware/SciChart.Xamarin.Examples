using Java.Lang;
using SciChart.Core;
using SciChart.Core.Utility;

namespace SciChart.Charting.Visuals.RenderableSeries.PaletteProviders
{
    public abstract class PaletteProviderBase<TRenderableSeries> : Object, IPaletteProvider where TRenderableSeries : Object, IRenderableSeries
    {
        protected TRenderableSeries RenderableSeries { get; set; }

        public void AttachTo(IServiceContainer services)
        {
            RenderableSeries = services.GetService(typeof(IRenderableSeries).ToClass()) as TRenderableSeries;

            if(RenderableSeries == null)
            {
                throw new UnsupportedOperationException(string.Format("Expected instance of {0}", typeof(TRenderableSeries).Name));
            }
        }

        public void Detach()
        {
            RenderableSeries = null;
        }

        public bool IsAttached => RenderableSeries != null;

        public abstract void Update();
    }
}