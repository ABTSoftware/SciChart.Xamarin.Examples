using Android.Animation;
using Android.Views.Animations;
using SciChart.Charting.Visuals.RenderableSeries;

namespace SciChart.Charting.Visuals.Animations
{
    public abstract class AnimatorBuilderBase
    {
        protected readonly IRenderableSeries _renderableSeries;

        public float[] Values { get; set; } = { 0f, 1f };
        public long Duration { get; set; } = 1000L;
        public long StartDelay { get; set; } = 0L;

        public ITimeInterpolator Interpolator = new LinearInterpolator();
        public ITypeEvaluator Evaluator = new FloatEvaluator();

        protected AnimatorBuilderBase(IRenderableSeries renderableSeries)
        {
            _renderableSeries = renderableSeries;
        }

        public abstract Animator Build();

        public void Start()
        {
            var suspender = _renderableSeries.SuspendUpdates();

            var animator = Build();
            animator.AnimationStart += (sender, args) => suspender.Dispose();

            animator.Cancel();
            animator.Start();
        }
    }
}