using System;
using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
	interface ISCIUniformHeatmapDataSeries : ISCIUniformHeatmapDataSeriesProtocol, INSObjectProtocol { }

	// @interface SCIUniformHeatmapDataSeries : NSObject <SCIUniformHeatmapDataSeriesProtocol>
	[BaseType(typeof(NSObject))]
	interface SCIUniformHeatmapDataSeries : SCIUniformHeatmapDataSeriesProtocol
	{
		// @property (nonatomic, strong) id<SCIPointSeriesProtocol> lastPointSeries;
		[Export("lastPointSeries", ArgumentSemantic.Strong)]
		SCIPointSeriesProtocol LastPointSeries { get; set; }

		// @property (nonatomic, strong) id<SCIDataDistributionCalculatorProtocol> dataDistributionCalculator;
		[Export("dataDistributionCalculator", ArgumentSemantic.Strong)]
		SCIDataDistributionCalculatorProtocol DataDistributionCalculator { get; set; }

		// @property (copy, nonatomic) SCIActionBlock onDataSeriesChanged;
		[Export("onDataSeriesChanged", ArgumentSemantic.Copy)]
		SCIActionBlock OnDataSeriesChanged { get; set; }

		// -(void)dataSeriesChanged;
		[Export("dataSeriesChanged")]
		void DataSeriesChanged();

		// -(id)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ SizeX:(int)sizeX Y:(int)sizeY RangeX:(id<SCIRangeProtocol>)rangeX Y:(id<SCIRangeProtocol>)rangeY;
		[Export("initWithTypeX:Y:Z:SizeX:Y:RangeX:Y:")]
		IntPtr Constructor(SCIDataType typeX, SCIDataType typeY, SCIDataType typeZ, int sizeX, int sizeY, ISCIRangeProtocol rangeX, ISCIRangeProtocol rangeY);

        // -(id)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ SizeX:(int)sizeX Y:(int)sizeY StartX:(SCIGenericType)startX StepX:(SCIGenericType)stepX StartY:(SCIGenericType)startY StepY:(SCIGenericType)stepY;
        // -(id)initWithZValues:(SCIArrayController2D *)array2D StartX:(SCIGenericType)startX StepX:(SCIGenericType)stepX StartY:(SCIGenericType)startY StepY:(SCIGenericType)stepY;
	}
}