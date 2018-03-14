using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderPassData : NSObject <SCIRenderPassDataProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIRenderPassData : SCIRenderPassDataProtocol
    {
        // -(id)initWithPointRange:(SCIIndexRange *)pointRange PointSeries:(id<SCIPointSeriesProtocol>)pointSeries DataSeries:(id<SCIDataSeriesProtocol>)dataSeries RenderableSeries:(id<SCIRenderableSeriesProtocol>)renderableSeries YCalculator:(id<SCICoordinateCalculatorProtocol>)yCalculator XCalculator:(id<SCICoordinateCalculatorProtocol>)xCalculator;
        [Export("initWithPointRange:PointSeries:DataSeries:RenderableSeries:YCalculator:XCalculator:")]
        IntPtr Constructor(SCIIndexRange pointRange, ISCIPointSeriesProtocol pointSeries, ISCIDataSeriesProtocol dataSeries, ISCIRenderableSeriesProtocol renderableSeries, ISCICoordinateCalculatorProtocol yCalculator, ISCICoordinateCalculatorProtocol xCalculator);
    }
}