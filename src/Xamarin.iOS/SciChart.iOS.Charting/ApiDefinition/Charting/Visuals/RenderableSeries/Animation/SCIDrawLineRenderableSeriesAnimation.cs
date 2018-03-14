using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCISweepRenderableSeriesAnimation : SCIAnimation <SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol>
    [BaseType(typeof(SCIAnimation))]
    interface SCISweepRenderableSeriesAnimation : SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol
    {
        // @required -(instancetype _Nonnull)initWithDuration:(float)duration curveAnimation:(SCIAnimationCurve)curveType;
        [Export("initWithDuration:curveAnimation:")]
        IntPtr Constructor(float duration, SCIAnimationCurve curveType);
    }
}