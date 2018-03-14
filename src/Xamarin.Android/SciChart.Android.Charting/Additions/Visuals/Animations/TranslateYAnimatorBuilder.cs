using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;

namespace SciChart.Charting.Visuals.Animations
{
    public class TranslateYAnimatorBuilder : RenderPassDataTransformationBuilder
    {
        public TranslateYAnimatorBuilder(IRenderableSeries renderableSeries, float offset) : base(renderableSeries)
        {
            if (_renderableSeries is FastFixedErrorBarsRenderableSeries) { _transformation = new TranslateHlTransformation(Java.Lang.Class.FromType(typeof(HlRenderPassData)), offset); }
            else if (_renderableSeries is StackedColumnRenderableSeries || _renderableSeries is StackedMountainRenderableSeries) { _transformation = new TranslateStackedXyTransformation(Java.Lang.Class.FromType(typeof(StackedSeriesRenderPassData)), offset); }
            else if (_renderableSeries is XyyRenderableSeriesBase) { _transformation = new TranslateXyyTransformation(Java.Lang.Class.FromType(typeof(XyyRenderPassData)), offset); }
            else if (_renderableSeries is XyzRenderableSeriesBase) { _transformation = new TranslateXyTransformation(Java.Lang.Class.FromType(typeof(XyzRenderPassData)), offset); }
            else if (_renderableSeries is HlRenderableSeriesBase) { _transformation = new TranslateHlTransformation(Java.Lang.Class.FromType(typeof(HlRenderPassData)), offset); }
            else if (_renderableSeries is OhlcRenderableSeriesBase) { _transformation = new TranslateOhlcTransformation(Java.Lang.Class.FromType(typeof(OhlcRenderPassData)), offset); }
            else if (_renderableSeries is XyRenderableSeriesBase) { _transformation = new TranslateXyTransformation(Java.Lang.Class.FromType(typeof(XyRenderPassData)), offset); }
        }
    }
}