using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyzDataSeries : SCIDataSeries <SCIXyzDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIXyzDataSeries : SCIXyzDataSeriesProtocol
    {
        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> _Nonnull zColumn;
        [Export("zColumn", ArgumentSemantic.Strong)]
        ISCIArrayControllerProtocol ZColumn { get; set; }

        // -(instancetype _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType ZType:(SCIDataType)zType;
        [Export("initWithXType:YType:ZType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType, SCIDataType zType);

        // -(instancetype _Nonnull)initFifoWithXType:(SCIDataType)xType YType:(SCIDataType)yType ZType:(SCIDataType)zType FifoSize:(int)size;
        [Export("initFifoWithXType:YType:ZType:FifoSize:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType, SCIDataType zType, int size);
    }
}