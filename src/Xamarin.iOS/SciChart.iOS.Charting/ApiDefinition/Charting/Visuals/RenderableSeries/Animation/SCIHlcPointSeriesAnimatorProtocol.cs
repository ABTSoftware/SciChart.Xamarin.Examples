using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIHlcPointSeriesAnimatorProtocol {}

    // @protocol SCIHlcPointSeriesAnimatorProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIHlcPointSeriesAnimatorProtocol
    {
        // @required -(SCIHlcPointSeries * _Nullable)animateHlcPointSeries:(SCIHlcPointSeries * _Nullable)pointSeries withPreviousPointSeries:(SCIHlcPointSeries * _Nullable)previousPointSeries;
        [Abstract]
        [Export("animateHlcPointSeries:withPreviousPointSeries:")]
        [return: NullAllowed]
        SCIHlcPointSeries WithPreviousPointSeries([NullAllowed] SCIHlcPointSeries pointSeries, [NullAllowed] SCIHlcPointSeries previousPointSeries);
    }
}