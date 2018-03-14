using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIUniformHeatmapDataSeries : NSObject <SCIUniformHeatmapDataSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIUniformHeatmapDataSeries : SCIUniformHeatmapDataSeriesProtocol
    {
        // @property (nonatomic, strong) id<SCIPointSeriesProtocol> _Nonnull lastPointSeries;
        [Export("lastPointSeries", ArgumentSemantic.Strong)]
        new ISCIPointSeriesProtocol LastPointSeries { get; set; }

        // @property (nonatomic, strong) id<SCIDataDistributionCalculatorProtocol> _Nonnull dataDistributionCalculator;
        [Export("dataDistributionCalculator", ArgumentSemantic.Strong)]
        ISCIDataDistributionCalculatorProtocol DataDistributionCalculator { get; set; }

        // -(void)dataSeriesChanged;
        [Export("dataSeriesChanged")]
        void DataSeriesChanged();

        // -(instancetype _Nonnull)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ SizeX:(int)sizeX Y:(int)sizeY StartX:(SCIGenericType)startX StepX:(SCIGenericType)stepX StartY:(SCIGenericType)startY StepY:(SCIGenericType)stepY;
        [Export("initWithTypeX:Y:Z:SizeX:Y:StartX:StepX:StartY:StepY:")]
        IntPtr Constructor(SCIDataType typeX, SCIDataType typeY, SCIDataType typeZ, int sizeX, int sizeY, SCIGenericType startX, SCIGenericType stepX, SCIGenericType startY, SCIGenericType stepY);

        // -(instancetype _Nonnull)initWithZValues:(SCIArrayController2D * _Nonnull)array2D StartX:(SCIGenericType)startX StepX:(SCIGenericType)stepX StartY:(SCIGenericType)startY StepY:(SCIGenericType)stepY;
        [Export("initWithZValues:StartX:StepX:StartY:StepY:")]
        IntPtr Constructor(SCIArrayController2D array2D, SCIGenericType startX, SCIGenericType stepX, SCIGenericType startY, SCIGenericType stepY);

        // -(instancetype _Nonnull)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ SizeX:(int)sizeX Y:(int)sizeY RangeX:(id<SCIRangeProtocol> _Nonnull)rangeX Y:(id<SCIRangeProtocol> _Nonnull)rangeY;
        [Export("initWithTypeX:Y:Z:SizeX:Y:RangeX:Y:")]
        IntPtr Constructor(SCIDataType typeX, SCIDataType typeY, SCIDataType typeZ, int sizeX, int sizeY, ISCIRangeProtocol rangeX, ISCIRangeProtocol rangeY);
    }
}