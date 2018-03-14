using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIScatterRenderableSeriesAnimationProtocol {}

    // @protocol SCIScatterRenderableSeriesAnimationProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIScatterRenderableSeriesAnimationProtocol
    {
        // @required -(void)animateScatterRenderableSeries:(SCIXyScatterRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateScatterRenderableSeries:")]
        void AnimateScatterRenderableSeries(SCIXyScatterRenderableSeries renderableSeries);
    }
}