using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyzPointSeries : NSObject <ISCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIXyzPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithSeriesXY:(id<ISCIPointSeriesProtocol>)xy XZ:(id<ISCIPointSeriesProtocol>)xz;
        [Export("initWithSeriesXY:XZ:")]
        IntPtr Constructor(ISCIPointSeriesProtocol xy, ISCIPointSeriesProtocol xz);

        // -(SCIArrayController *)zValues;
        [Export("zValues")]
        SCIArrayController ZValues { get; }
    }
}