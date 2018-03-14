using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIHlDataSeries : SCIDataSeries <SCIHlDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIHlDataSeries : SCIHlDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> highColumn;
        [Export("highColumn", ArgumentSemantic.Strong)]
        new ISCIArrayControllerProtocol HighColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> lowColumn;
        [Export("lowColumn", ArgumentSemantic.Strong)]
        new ISCIArrayControllerProtocol LowColumn { get; set; }
    }
}