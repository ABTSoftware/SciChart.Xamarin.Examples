using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderPassData : NSObject <ISCIRenderPassDataProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIRenderPassData : SCIRenderPassDataProtocol
    {
        // -(id)initWithPointRange:(SCIIndexRange *)pointRange PointSeries:(id<ISCIPointSeriesProtocol>)pointSeries DataSeries:(id<SCIDataSeriesProtocol>)dataSeries RenderableSeries:(id<ISCIRenderableSeriesProtocol>)renderableSeries YCalculator:(id<SCICoordinateCalculatorProtocol>)yCalculator XCalculator:(id<SCICoordinateCalculatorProtocol>)xCalculator;
        [Export("initWithPointRange:PointSeries:DataSeries:RenderableSeries:YCalculator:XCalculator:")]
        IntPtr Constructor(SCIIndexRange pointRange,
            ISCIPointSeriesProtocol pointSeries, ISCIDataSeriesProtocol dataSeries, ISCIRenderableSeriesProtocol renderableSeries,
            ISCICoordinateCalculatorProtocol yCalculator, ISCICoordinateCalculatorProtocol xCalculator);
    }
}