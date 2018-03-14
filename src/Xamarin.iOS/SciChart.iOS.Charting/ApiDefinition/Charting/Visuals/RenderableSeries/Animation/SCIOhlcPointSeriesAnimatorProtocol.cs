using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIOhlcPointSeriesAnimatorProtocol {}

    // @protocol SCIOhlcPointSeriesAnimatorProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIOhlcPointSeriesAnimatorProtocol
    {
        // @required -(SCIOhlcPointSeries * _Nullable)animateOhlcPointSeries:(SCIOhlcPointSeries * _Nullable)pointSeries withPreviousPointSeries:(SCIOhlcPointSeries * _Nullable)previousPointSeries;
        [Abstract]
        [Export("animateOhlcPointSeries:withPreviousPointSeries:")]
        [return: NullAllowed]
        SCIOhlcPointSeries WithPreviousPointSeries([NullAllowed] SCIOhlcPointSeries pointSeries, [NullAllowed] SCIOhlcPointSeries previousPointSeries);
    }

}