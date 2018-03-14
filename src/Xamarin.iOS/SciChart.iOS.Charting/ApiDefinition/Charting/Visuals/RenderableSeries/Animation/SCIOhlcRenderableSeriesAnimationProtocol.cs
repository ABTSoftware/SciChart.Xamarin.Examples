using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIOhlcRenderableSeriesAnimationProtocol {}

    // @protocol SCIOhlcRenderableSeriesAnimationProtocol <SCIOhlcPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIOhlcRenderableSeriesAnimationProtocol : SCIOhlcPointSeriesAnimatorProtocol
    {
        // @required -(void)animateOhlcRenderableSeries:(SCIFastOhlcRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateOhlcRenderableSeries:")]
        void AnimateOhlcRenderableSeries(SCIFastOhlcRenderableSeries renderableSeries);
    }
}