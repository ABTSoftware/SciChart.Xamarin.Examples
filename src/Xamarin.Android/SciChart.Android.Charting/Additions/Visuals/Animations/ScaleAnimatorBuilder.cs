using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;

namespace SciChart.Charting.Visuals.Animations
{
    public class ScaleAnimatorBuilder : RenderPassDataTransformationBuilder
    {
        public ScaleAnimatorBuilder(IRenderableSeries renderableSeries) : this(renderableSeries, DefaultZeroLine) { }

        public ScaleAnimatorBuilder(IRenderableSeries renderableSeries, double zeroLine) : base(renderableSeries)
        {
            if (_renderableSeries is FastFixedErrorBarsRenderableSeries) { _transformation = new ScaleHlTransformation(Java.Lang.Class.FromType(typeof(HlRenderPassData)), zeroLine); }
            else if (_renderableSeries is StackedColumnRenderableSeries || _renderableSeries is StackedMountainRenderableSeries) { _transformation = new ScaleStackedXyTransformation(Java.Lang.Class.FromType(typeof(StackedSeriesRenderPassData)), zeroLine); }
            else if (_renderableSeries is XyyRenderableSeriesBase) { _transformation = new ScaleXyyTransformation(Java.Lang.Class.FromType(typeof(XyyRenderPassData)), zeroLine); }
            else if (_renderableSeries is XyzRenderableSeriesBase) { _transformation = new ScaleXyzTransformation(Java.Lang.Class.FromType(typeof(XyzRenderPassData)), zeroLine); }
            else if (_renderableSeries is HlRenderableSeriesBase) { _transformation = new ScaleHlTransformation(Java.Lang.Class.FromType(typeof(HlRenderPassData)), zeroLine); }
            else if (_renderableSeries is OhlcRenderableSeriesBase) { _transformation = new ScaleOhlcTransformation(Java.Lang.Class.FromType(typeof(OhlcRenderPassData)), zeroLine); }
            else if (_renderableSeries is XyRenderableSeriesBase) { _transformation = new ScaleXyTransformation(Java.Lang.Class.FromType(typeof(XyRenderPassData)), zeroLine); }
        }
    }
}