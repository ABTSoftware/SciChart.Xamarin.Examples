using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIPointSeriesProtocol : INSObjectProtocol { }

    // @protocol ISCIPointSeriesProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
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