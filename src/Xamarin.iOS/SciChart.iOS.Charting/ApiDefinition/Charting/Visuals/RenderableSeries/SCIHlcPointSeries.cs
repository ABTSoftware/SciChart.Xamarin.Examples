using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIHlcPointSeries : NSObject <SCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIHlcPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithSeriesHigh:(id<SCIPointSeriesProtocol>)high Low:(id<SCIPointSeriesProtocol>)low Close:(id<SCIPointSeriesProtocol>)close;
        [Export("initWithSeriesHigh:Low:Close:")]
        IntPtr Constructor(ISCIPointSeriesProtocol high, ISCIPointSeriesProtocol low, ISCIPointSeriesProtocol close);

        // -(id)initWithCapacity:(int)size;
        [Export("initWithCapacity:")]
        IntPtr Constructor(int size);

        // -(SCIArrayController *)highValues;
        [Export("highValues")]
        SCIArrayController HighValues { get; }

        // -(SCIArrayController *)lowValues;
        [Export("lowValues")]
        SCIArrayController LowValues { get; }

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