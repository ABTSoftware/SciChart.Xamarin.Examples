using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIOhlcDataSeries : ISCIOhlcDataSeriesProtocol, INSObjectProtocol { }

    // @interface SCIOhlcDataSeries : SCIDataSeries <SCIOhlcDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIOhlcDataSeries : SCIOhlcDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> openColumn;
        [Export("openColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol OpenColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> highColumn;
        [Export("highColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol HighColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> lowColumn;
        [Export("lowColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol LowColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> closeColumn;
        [Export("closeColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol CloseColumn { get; set; }
    }
}