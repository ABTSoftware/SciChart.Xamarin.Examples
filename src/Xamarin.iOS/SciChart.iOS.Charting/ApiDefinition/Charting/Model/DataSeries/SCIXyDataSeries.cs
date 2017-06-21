using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIXyDataSeries : ISCIXyDataSeriesProtocol, INSObjectProtocol { }

    // @interface SCIXyDataSeries : SCIDataSeries <SCIXyDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIXyDataSeries : SCIXyDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);
    }
}