using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIXyyPointSeriesAnimatorProtocol {}

    // @protocol SCIXyyPointSeriesAnimatorProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIXyyPointSeriesAnimatorProtocol
    {
        // @required -(SCIXyyPointSeries * _Nullable)animateXyyPointSeries:(SCIXyyPointSeries * _Nullable)pointSeries withPreviousPointSeries:(SCIXyyPointSeries * _Nullable)previousPointSeries;
        [Abstract]
        [Export("animateXyyPointSeries:withPreviousPointSeries:")]
        [return: NullAllowed]
        SCIXyyPointSeries WithPreviousPointSeries([NullAllowed] SCIXyyPointSeries pointSeries, [NullAllowed] SCIXyyPointSeries previousPointSeries);
    }
}