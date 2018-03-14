using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;

namespace SciChart.Charting.Visuals.Animations
{
    public class WaveAnimatorBuilder : RenderPassDataTransformationBuilder
    {
        public WaveAnimatorBuilder(IRenderableSeries renderableSeries) : this(renderableSeries, DefaultZeroLine, DefaultDurationOfStepData) { }

        public WaveAnimatorBuilder(IRenderableSeries renderableSeries, double zeroLine, float durationOfStepData) : base(renderableSeries)
        {
            if (_renderableSeries is FastFixedErrorBarsRenderableSeries) { _transformation = new WaveHlTransformation(Java.Lang.Class.FromType(typeof(HlRenderPassData)), zeroLine, durationOfStepData); }
            else if (_renderableSeries is StackedColumnRenderableSeries || _renderableSeries is StackedMountainRenderableSeries) { _transformation = new WaveStackedXyTransformation(Java.Lang.Class.FromType(typeof(StackedSeriesRenderPassData)), zeroLine, durationOfStepData); }
            else if (_renderableSeries is XyyRenderableSeriesBase) { _transformation = new WaveXyyTransformation(Java.Lang.Class.FromType(typeof(XyyRenderPassData)), zeroLine, durationOfStepData); }
            else if (_renderableSeries is XyzRenderableSeriesBase) { _transformation = new WaveXyTransformation(Java.Lang.Class.FromType(typeof(XyzRenderPassData)), zeroLine, durationOfStepData); }
            else if (_renderableSeries is HlRenderableSeriesBase) { _transformation = new WaveHlTransformation(Java.Lang.Class.FromType(typeof(HlRenderPassData)), zeroLine, durationOfStepData); }
            else if (_renderableSeries is OhlcRenderableSeriesBase) { _transformation = new WaveOhlcTransformation(Java.Lang.Class.FromType(typeof(OhlcRenderPassData)), zeroLine, durationOfStepData); }
            else if (_renderableSeries is XyRenderableSeriesBase) { _transformation = new WaveXyTransformation(Java.Lang.Class.FromType(typeof(XyRenderPassData)), zeroLine, durationOfStepData); }
        }
    }
}