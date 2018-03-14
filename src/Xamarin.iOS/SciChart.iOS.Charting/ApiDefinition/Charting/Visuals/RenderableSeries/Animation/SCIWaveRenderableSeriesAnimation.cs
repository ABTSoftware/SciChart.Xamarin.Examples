using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIWaveRenderableSeriesAnimation : SCIAnimation <SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIColumnRenderableSeriesAnimationProtocol, SCIScatterRenderableSeriesAnimationProtocol, SCIOhlcRenderableSeriesAnimationProtocol, SCICandleStickRenderableSeriesAnimationProtocol, SCIStackedSeriesCollectionAnimnationProtocol, SCIBubbleRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol, SCIErrorBarsRenderableSeriesAnimationProtocol, SCIFixedErrorBarsRenderableSeriesAnimationProtocol>
    [BaseType(typeof(SCIAnimation))]
    interface SCIWaveRenderableSeriesAnimation : SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIColumnRenderableSeriesAnimationProtocol, SCIScatterRenderableSeriesAnimationProtocol, SCIOhlcRenderableSeriesAnimationProtocol, SCICandleStickRenderableSeriesAnimationProtocol, SCIStackedSeriesCollectionAnimnationProtocol, SCIBubbleRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol, SCIErrorBarsRenderableSeriesAnimationProtocol, SCIFixedErrorBarsRenderableSeriesAnimationProtocol
    {
        // @required -(instancetype _Nonnull)initWithDuration:(float)duration curveAnimation:(SCIAnimationCurve)curveType;
        [Export("initWithDuration:curveAnimation:")]
        IntPtr Constructor(float duration, SCIAnimationCurve curveType);

        // @property (nonatomic) float durationOfStepData;
        [Export("durationOfStepData")]
        float DurationOfStepData { get; set; }
    }
}