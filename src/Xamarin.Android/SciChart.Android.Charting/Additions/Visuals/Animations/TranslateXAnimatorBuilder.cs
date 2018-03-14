using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;

namespace SciChart.Charting.Visuals.Animations
{
    public class TranslateXAnimatorBuilder : RenderPassDataTransformationBuilder
    {
        public TranslateXAnimatorBuilder(IRenderableSeries renderableSeries, float offset) : base(renderableSeries)
        {
            _transformation = new TranslateXTransformation(Java.Lang.Class.FromType(typeof(XSeriesRenderPassData)), offset);
        }
    }
}