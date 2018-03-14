using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;

namespace SciChart.Charting.Visuals.Animations
{
    public class SweepAnimatorBuilder : RenderPassDataTransformationBuilder
    {
        public SweepAnimatorBuilder(IRenderableSeries renderableSeries) : base(renderableSeries)
        {
            if (_renderableSeries is FastFixedErrorBarsRenderableSeries) { _transformation = new SweepXyTransformation(Java.Lang.Class.FromType(typeof(HlRenderPassData))); }
            else if (_renderableSeries is StackedColumnRenderableSeries || _renderableSeries is StackedMountainRenderableSeries) { throw new Java.Lang.UnsupportedOperationException("Sweep transformation isn't supported with StackedColumn or StackedMountains and inheritors"); }
            else if (_renderableSeries is XyyRenderableSeriesBase) { _transformation = new SweepXyyTransformation(Java.Lang.Class.FromType(typeof(XyyRenderPassData))); }
            else if (_renderableSeries is XyzRenderableSeriesBase) { _transformation = new SweepXyyTransformation(Java.Lang.Class.FromType(typeof(XyyRenderPassData))); }
            else if (_renderableSeries is HlRenderableSeriesBase) { throw new Java.Lang.UnsupportedOperationException("Sweep transformation isn't supported with HlRenderableSeriesBase and inheritors"); }
            else if (_renderableSeries is OhlcRenderableSeriesBase) { throw new Java.Lang.UnsupportedOperationException("Sweep transformation isn't supported with OhlcRenderableSeriesBase and inheritors"); }
            else if (_renderableSeries is XyRenderableSeriesBase) { _transformation = new SweepXyTransformation(Java.Lang.Class.FromType(typeof(XyRenderPassData))); }
        }
    }
}