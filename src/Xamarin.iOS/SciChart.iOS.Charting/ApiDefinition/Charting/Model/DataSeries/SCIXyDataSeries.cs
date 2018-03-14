using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyDataSeries : SCIDataSeries <SCIXyDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIXyDataSeries : SCIXyDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);
    }
}