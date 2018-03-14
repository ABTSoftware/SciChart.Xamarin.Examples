using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIErrorBarsRenderableSeriesAnimationProtocol {}

    // @protocol SCIErrorBarsRenderableSeriesAnimationProtocol <SCIHlcPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIErrorBarsRenderableSeriesAnimationProtocol : SCIHlcPointSeriesAnimatorProtocol
    {
        // @required -(void)animateErrorBarsRenderableSeries:(SCIFastErrorBarsRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateErrorBarsRenderableSeries:")]
        void AnimateErrorBarsRenderableSeries(SCIFastErrorBarsRenderableSeries renderableSeries);
    }
}