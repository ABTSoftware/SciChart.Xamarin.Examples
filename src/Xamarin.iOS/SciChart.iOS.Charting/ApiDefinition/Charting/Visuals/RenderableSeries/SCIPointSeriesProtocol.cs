using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIPointSeriesProtocol { }

    // @protocol SCIPointSeriesProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIPointSeriesProtocol
    {
        // @required -(SCIArrayController *)xValues;
        [Abstract]
        [Export("xValues")]
        SCIArrayController XValues { get; }

        // @required -(SCIArrayController *)yValues;
        [Abstract]
        [Export("yValues")]
        SCIArrayController YValues { get; }

        // @required -(SCIArrayController *)indices;
        [Abstract]
        [Export("indices")]
        SCIArrayController Indices { get; }

        // @required -(int)count;
        [Abstract]
        [Export("count")]
        int Count { get; }

        // @required -(SCIDoubleRange *)getYRange;
        [Abstract]
        [Export("getYRange")]
        SCIDoubleRange YRange { get; }

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();
    }
}