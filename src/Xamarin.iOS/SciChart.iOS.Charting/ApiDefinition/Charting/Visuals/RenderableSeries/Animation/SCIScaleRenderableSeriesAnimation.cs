using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIScaleRenderableSeriesAnimation : SCIAnimation <SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIColumnRenderableSeriesAnimationProtocol, SCIScatterRenderableSeriesAnimationProtocol, SCIOhlcRenderableSeriesAnimationProtocol, SCICandleStickRenderableSeriesAnimationProtocol, SCIStackedSeriesCollectionAnimnationProtocol, SCIBubbleRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol, SCIErrorBarsRenderableSeriesAnimationProtocol, SCIFixedErrorBarsRenderableSeriesAnimationProtocol>
    [BaseType(typeof(SCIAnimation))]
    interface SCIScaleRenderableSeriesAnimation : SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIColumnRenderableSeriesAnimationProtocol, SCIScatterRenderableSeriesAnimationProtocol, SCIOhlcRenderableSeriesAnimationProtocol, SCICandleStickRenderableSeriesAnimationProtocol, SCIStackedSeriesCollectionAnimnationProtocol, SCIBubbleRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol, SCIErrorBarsRenderableSeriesAnimationProtocol, SCIFixedErrorBarsRenderableSeriesAnimationProtocol
    {
        // @required -(instancetype _Nonnull)initWithDuration:(float)duration curveAnimation:(SCIAnimationCurve)curveType;
        [Export("initWithDuration:curveAnimation:")]
        IntPtr Constructor(float duration, SCIAnimationCurve curveType);
    }
}