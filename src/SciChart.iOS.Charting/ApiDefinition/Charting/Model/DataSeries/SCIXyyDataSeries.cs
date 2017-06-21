using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIXyyDataSeries : ISCIXyyDataSeriesProtocol, INSObjectProtocol { }

    // @interface SCIXyyDataSeries : SCIDataSeries <SCIXyyDataSeriesProtocol>
    [BaseType(typeof(SCIDataSeries))]
    interface SCIXyyDataSeries : SCIXyyDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> y1Column;
        [Export("y1Column", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol Y1Column { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> y2Column;
        [Export("y2Column", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol Y2Column { get; set; }
    }
}