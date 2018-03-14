using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIBubbleRenderableSeriesAnimationProtocol {}

    // @protocol SCIBubbleRenderableSeriesAnimationProtocol <SCIXyzPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIBubbleRenderableSeriesAnimationProtocol : SCIXyzPointSeriesAnimatorProtocol
    {
        // @required -(void)animateBubbleRenderableSeries:(SCIBubbleRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateBubbleRenderableSeries:")]
        void AnimateBubbleRenderableSeries(SCIBubbleRenderableSeries renderableSeries);
    }
}
