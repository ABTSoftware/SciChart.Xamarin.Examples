using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIFixedErrorBarsRenderableSeriesAnimationProtocol {}

    // @protocol SCIFixedErrorBarsRenderableSeriesAnimationProtocol <SCIHlcPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIFixedErrorBarsRenderableSeriesAnimationProtocol : SCIHlcPointSeriesAnimatorProtocol
    {
        // @required -(void)animateFixedErrorBarsRenderableSeries:(SCIFastFixedErrorBarsRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateFixedErrorBarsRenderableSeries:")]
        void AnimateFixedErrorBarsRenderableSeries(SCIFastFixedErrorBarsRenderableSeries renderableSeries);
    }
}