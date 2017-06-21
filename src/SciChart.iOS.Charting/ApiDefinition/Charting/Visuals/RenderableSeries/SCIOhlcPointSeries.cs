using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIOhlcPointSeries : NSObject <ISCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIOhlcPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithSeriesOpen:(id<ISCIPointSeriesProtocol>)open High:(id<ISCIPointSeriesProtocol>)high Low:(id<ISCIPointSeriesProtocol>)low Close:(id<ISCIPointSeriesProtocol>)close;
        [Export("initWithSeriesOpen:High:Low:Close:")]
        IntPtr Constructor(ISCIPointSeriesProtocol open, ISCIPointSeriesProtocol high, ISCIPointSeriesProtocol low, ISCIPointSeriesProtocol close);

        // -(SCIArrayController *)openValues;
        [Export("openValues")]
        SCIArrayController OpenValues { get; }

        // -(SCIArrayController *)highValues;
        [Export("highValues")]
        SCIArrayController HighValues { get; }

        // -(SCIArrayController *)lowValues;
        [Export("lowValues")]
        SCIArrayController LowValues { get; }

        // -(SCIArrayController *)closeValues;
        [Export("closeValues")]
        SCIArrayController CloseValues { get; }
    }
}