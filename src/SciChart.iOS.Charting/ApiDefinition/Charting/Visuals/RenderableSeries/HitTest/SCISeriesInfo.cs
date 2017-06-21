using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
	// @interface SCISeriesInfo : NSObject
	[BaseType(typeof(NSObject))]
	interface SCISeriesInfo
	{
		// @property (nonatomic, strong) NSNumberFormatter * numberFormatter;
		[Export("numberFormatter", ArgumentSemantic.Strong)]
		NSNumberFormatter NumberFormatter { get; set; }

		// @property (nonatomic, strong) NSDateFormatter * dateTimeFormatter;
		[Export("dateTimeFormatter", ArgumentSemantic.Strong)]
		NSDateFormatter DateTimeFormatter { get; set; }

		// -(instancetype)initWithSeries:(id<SCIRenderableSeriesProtocol>)series HitTest:(SCIHitTestInfo)hitTest;
		[Export("initWithSeries:HitTest:")]
		IntPtr Constructor(SCIRenderableSeriesProtocol series, SCIHitTestInfo hitTest);

		// -(id<SCIRenderableSeriesProtocol>)renderableSeries;
		[Export("renderableSeries")]
		SCIRenderableSeriesProtocol RenderableSeries { get; }

		// -(NSString *)seriesName;
		[Export("seriesName")]
		string SeriesName { get; }

		// -(SCIGenericType)xValue;
		[Export("xValue")]
		SCIGenericType XValue { get; }

		// -(SCIGenericType)yValue;
		[Export("yValue")]
		SCIGenericType YValue { get; }

		// -(SCIDataSeriesType)dataSeriesType;
		[Export("dataSeriesType")]
		SCIDataSeriesType DataSeriesType { get; }

		// -(BOOL)isHit;
		[Export("isHit")]
		bool IsHit { get; }

		// -(int)dataSeriesIndex;
		[Export("dataSeriesIndex")]
		int DataSeriesIndex { get; }

		// -(unsigned int)seriesColor;
		[Export("seriesColor")]
		uint SeriesColor { get; }

		// -(unsigned int)seriesColorAtX:(double)x Y:(double)y;
		[Export("seriesColorAtX:Y:")]
		uint SeriesColorAtX(double x, double y);

		// -(SCITooltipDataView *)createDataSeriesView;
		[Export("createDataSeriesView")]
		SCITooltipDataView CreateDataSeriesView { get; }

		// -(NSString *)fortmatterdValueFromSeriesInfo:(SCIGenericType)data forDataType:(SCIDataType)dataType;
	}
}