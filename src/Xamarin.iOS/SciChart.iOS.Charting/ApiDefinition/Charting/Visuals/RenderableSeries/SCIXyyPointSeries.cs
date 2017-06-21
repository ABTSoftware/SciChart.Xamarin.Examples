using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyyPointSeries : NSObject <ISCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIXyyPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithSeriesY1:(id<ISCIPointSeriesProtocol>)y1 Y2:(id<ISCIPointSeriesProtocol>)y2;
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