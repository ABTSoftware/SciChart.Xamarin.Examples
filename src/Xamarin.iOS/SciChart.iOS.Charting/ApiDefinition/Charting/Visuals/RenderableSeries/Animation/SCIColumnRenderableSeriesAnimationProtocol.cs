using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIColumnRenderableSeriesAnimationProtocol {}

    // @protocol SCIColumnRenderableSeriesAnimationProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIColumnRenderableSeriesAnimationProtocol
    {
        // @required -(void)animateColumnRenderableSeries:(SCIBaseColumnRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateColumnRenderableSeries:")]
        void AnimateColumnRenderableSeries(SCIBaseColumnRenderableSeries renderableSeries);
    }
}