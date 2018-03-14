using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIBaseRenderableSeriesAnimationProtocol {}

    // @protocol SCIBaseRenderableSeriesAnimationProtocol <SCIAnimationProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIBaseRenderableSeriesAnimationProtocol : SCIAnimationProtocol
    {
        // @required @property (nonatomic) id<SCIRenderableSeriesProtocol> _Nullable parentRenderableSeries;
        [Abstract]
        [NullAllowed, Export("parentRenderableSeries", ArgumentSemantic.Assign)]
        SCIRenderableSeriesProtocol ParentRenderableSeries { get; set; }
    }

    interface ISCIPointSeriesAnimatorProtocol {}

    // @protocol SCIPointSeriesAnimatorProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIPointSeriesAnimatorProtocol
    {
        // @required -(id<SCIPointSeriesProtocol> _Nullable)animatePointSeries:(id<SCIPointSeriesProtocol> _Nullable)pointSeries withPreviousPointSeries:(id<SCIPointSeriesProtocol> _Nullable)previousPointSeries;
        [Abstract]
        [Export("animatePointSeries:withPreviousPointSeries:")]
        [return: NullAllowed]
        SCIPointSeriesProtocol WithPreviousPointSeries([NullAllowed] ISCIPointSeriesProtocol pointSeries, [NullAllowed] ISCIPointSeriesProtocol previousPointSeries);
    }

    interface ISCIRenderableSeriesAnimationProtocol {}

    // @protocol SCIRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIPointSeriesAnimatorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIRenderableSeriesAnimationProtocol : SCIBaseRenderableSeriesAnimationProtocol, SCIPointSeriesAnimatorProtocol
    {
        // @required -(void)animateRenderableSeries:(id<SCIRenderableSeriesProtocol> _Nonnull)renderableSeries;
        [Abstract]
        [Export("animateRenderableSeries:")]
        void AnimateRenderableSeries(ISCIRenderableSeriesProtocol renderableSeries);
    }
}