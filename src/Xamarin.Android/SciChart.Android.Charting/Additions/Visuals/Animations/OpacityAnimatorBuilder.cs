using Android.Animation;
using SciChart.Charting.Visuals.RenderableSeries;

namespace SciChart.Charting.Visuals.Animations
{
    public class OpacityAnimatorBuilder : AnimatorBuilderBase
    {
        public OpacityAnimatorBuilder(IRenderableSeries renderableSeries) : base(renderableSeries)
        {
        }

        public override Animator Build()
        {
            return AnimationsHelper.CreateOpacityAnimator(_renderableSeries, Duration, StartDelay, Interpolator, Evaluator, Values);
        }
    }
}