using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIOhlcPointSeries : NSObject <SCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIOhlcPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithSeriesOpen:(id<SCIPointSeriesProtocol>)open High:(id<SCIPointSeriesProtocol>)high Low:(id<SCIPointSeriesProtocol>)low Close:(id<SCIPointSeriesProtocol>)close;
        [Export("initWithSeriesOpen:High:Low:Close:")]
        IntPtr Constructor(ISCIPointSeriesProtocol open, ISCIPointSeriesProtocol high, ISCIPointSeriesProtocol low, ISCIPointSeriesProtocol close);

        // -(id)initWithCapacity:(int)size;
        [Export("initWithCapacity:")]
        IntPtr Constructor(int size);

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

        // -(id<SCIPointSeriesProtocol>)openPointSeries;
        [Export("openPointSeries")]
        ISCIPointSeriesProtocol OpenPointSeries { get; }

        // -(id<SCIPointSeriesProtocol>)highPointSeries;
        [Export("highPointSeries")]
        ISCIPointSeriesProtocol HighPointSeries { get; }

        // -(id<SCIPointSeriesProtocol>)lowPointSeries;
        [Export("lowPointSeries")]
        ISCIPointSeriesProtocol LowPointSeries { get; }

        // -(id<SCIPointSeriesProtocol>)closePointSeries;
        [Export("closePointSeries")]
        ISCIPointSeriesProtocol ClosePointSeries { get; }
    }
}