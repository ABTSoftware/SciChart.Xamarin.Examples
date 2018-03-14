using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCICandleStickRenderableSeriesAnimationProtocol {}

    // @protocol SCICandleStickRenderableSeriesAnimationProtocol <SCIOhlcPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCICandleStickRenderableSeriesAnimationProtocol : SCIOhlcPointSeriesAnimatorProtocol
    {
        // @required -(void)animateCandleStickRenderableSeries:(SCIFastCandlestickRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateCandleStickRenderableSeries:")]
        void AnimateCandleStickRenderableSeries(SCIFastCandlestickRenderableSeries renderableSeries);
    }
}