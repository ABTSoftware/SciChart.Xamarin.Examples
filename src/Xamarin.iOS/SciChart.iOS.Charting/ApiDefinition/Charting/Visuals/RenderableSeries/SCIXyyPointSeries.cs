using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyyPointSeries : NSObject <SCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIXyyPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithSeriesY1:(id<SCIPointSeriesProtocol>)y1 Y2:(id<SCIPointSeriesProtocol>)y2;
        [Export("initWithSeriesY1:Y2:")]
        IntPtr Constructor(ISCIPointSeriesProtocol y1, ISCIPointSeriesProtocol y2);

        // -(SCIArrayController *)y1Values;
        [Export("y1Values")]
        SCIArrayController Y1Values { get; }

        // -(SCIArrayController *)y2Values;
        [Export("y2Values")]
        SCIArrayController Y2Values { get; }
    }
}