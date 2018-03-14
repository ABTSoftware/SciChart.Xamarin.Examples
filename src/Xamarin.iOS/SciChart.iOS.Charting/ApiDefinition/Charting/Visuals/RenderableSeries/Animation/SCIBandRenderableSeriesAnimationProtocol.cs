using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIBandRenderableSeriesAnimationProtocol {}

    // @protocol SCIBandRenderableSeriesAnimationProtocol <SCIXyyPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIBandRenderableSeriesAnimationProtocol : SCIXyyPointSeriesAnimatorProtocol
    {
        // @required -(void)animateBandRenderableSeries:(SCIFastBandRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateBandRenderableSeries:")]
        void AnimateBandRenderableSeries(SCIFastBandRenderableSeries renderableSeries);
    }
}