using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyzPointSeries : NSObject <SCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIXyzPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithSeriesXY:(id<SCIPointSeriesProtocol>)xy XZ:(id<SCIPointSeriesProtocol>)xz;
        [Export("initWithSeriesXY:XZ:")]
        IntPtr Constructor(ISCIPointSeriesProtocol xy, ISCIPointSeriesProtocol xz);

        // -(SCIArrayController *)zValues;
        [Export("zValues")]
        SCIArrayController ZValues { get; }
    }
}