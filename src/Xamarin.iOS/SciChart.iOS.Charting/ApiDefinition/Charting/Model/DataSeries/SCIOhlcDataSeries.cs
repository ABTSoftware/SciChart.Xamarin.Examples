using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIOhlcDataSeries : SCIDataSeries <SCIOhlcDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIOhlcDataSeries : SCIOhlcDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> openColumn;
        [Export("openColumn", ArgumentSemantic.Strong)]
        ISCIArrayControllerProtocol OpenColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> highColumn;
        [Export("highColumn", ArgumentSemantic.Strong)]
        ISCIArrayControllerProtocol HighColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> lowColumn;
        [Export("lowColumn", ArgumentSemantic.Strong)]
        ISCIArrayControllerProtocol LowColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> closeColumn;
        [Export("closeColumn", ArgumentSemantic.Strong)]
        ISCIArrayControllerProtocol CloseColumn { get; set; }
    }
}