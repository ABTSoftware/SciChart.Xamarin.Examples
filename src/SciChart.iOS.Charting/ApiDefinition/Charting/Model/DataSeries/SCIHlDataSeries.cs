using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIHlDataSeries : ISCIHlDataSeriesProtocol, INSObjectProtocol { }

    // @interface SCIHlcDataSeries : SCIDataSeries <SCIHlcDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIHlDataSeries : SCIHlDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> highColumn;
        [Export("highColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol HighColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> lowColumn;
        [Export("lowColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol LowColumn { get; set; }
    }
}