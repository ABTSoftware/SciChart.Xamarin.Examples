using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIStackedSeriesCollectionAnimnationProtocol {}

    // @protocol SCIStackedSeriesCollectionAnimnationProtocol <SCIXyyPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIStackedSeriesCollectionAnimnationProtocol : SCIXyyPointSeriesAnimatorProtocol
    {
        // @required -(void)animateStackedMountainRenderableSeries:(SCIStackedMountainRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateStackedMountainRenderableSeries:")]
        void AnimateStackedMountainRenderableSeries(SCIStackedMountainRenderableSeries renderableSeries);

        // @required -(void)animateStackedColumnRenderableSeries:(SCIStackedColumnRenderableSeries * _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateStackedColumnRenderableSeries:")]
        void AnimateStackedColumnRenderableSeries(SCIStackedColumnRenderableSeries renderableSeries);
    }
}