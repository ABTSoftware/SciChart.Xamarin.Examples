using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIXyzPointSeriesAnimatorProtocol {}

    // @protocol SCIXyzPointSeriesAnimatorProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIXyzPointSeriesAnimatorProtocol
    {
        // @required -(SCIXyzPointSeries * _Nullable)animateXyzPointSeries:(SCIXyzPointSeries * _Nullable)pointSeries withPreviousPointSeries:(SCIXyzPointSeries * _Nullable)previousPointSeries;
        [Abstract]
        [Export("animateXyzPointSeries:withPreviousPointSeries:")]
        [return: NullAllowed]
        SCIXyzPointSeries WithPreviousPointSeries([NullAllowed] SCIXyzPointSeries pointSeries, [NullAllowed] SCIXyzPointSeries previousPointSeries);
    }
}