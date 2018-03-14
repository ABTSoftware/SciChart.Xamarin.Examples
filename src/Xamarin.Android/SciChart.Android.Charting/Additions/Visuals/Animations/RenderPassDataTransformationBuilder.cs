using Android.Animation;
using SciChart.Charting.Visuals.RenderableSeries;

namespace SciChart.Charting.Visuals.Animations
{
    public abstract class RenderPassDataTransformationBuilder : AnimatorBuilderBase
    {
        protected static readonly double DefaultZeroLine = 0d;
        protected static readonly float DefaultDurationOfStepData = 0.5f;

        protected IRenderPassDataTransformation _transformation;

        protected RenderPassDataTransformationBuilder(IRenderableSeries renderableSeries) : base(renderableSeries)
        {
        }

        public override Animator Build()
        {
            return AnimationsHelper.CreateAnimator(_renderableSeries, _transformation, Duration, StartDelay, Interpolator, Evaluator, Values);
        }
    }
}