using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIMountainRenderableSeriesAnimationProtocol {}

    // @protocol SCIMountainRenderableSeriesAnimationProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIMountainRenderableSeriesAnimationProtocol
    {
        // @required -(void)animateMountainRenderableSeries:(SCIBaseMountainRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateMountainRenderableSeries:")]
        void AnimateMountainRenderableSeries(SCIBaseMountainRenderableSeries renderableSeries);
    }
}