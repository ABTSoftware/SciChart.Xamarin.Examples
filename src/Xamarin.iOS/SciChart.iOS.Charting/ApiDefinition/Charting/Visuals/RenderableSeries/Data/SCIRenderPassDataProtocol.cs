using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderPassDataProtocol { }

    // @protocol SCIRenderPassDataProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIRenderPassDataProtocol
    {
        // @required -(SCIIndexRange *)pointRange;
        [Abstract]
        [Export("pointRange")]
        SCIIndexRange PointRange { get; }

        // @required -(id<SCIPointSeriesProtocol>)pointSeries;
        [Abstract]
        [Export("pointSeries")]
        ISCIPointSeriesProtocol PointSeries { get; }

        // @required -(id<SCIDataSeriesProtocol>)dataSeries;
        [Abstract]
        [Export("dataSeries")]
        ISCIDataSeriesProtocol DataSeries { get; }

        // @required -(id<SCIRenderableSeriesProtocol>)renderableSeries;
        [Abstract]
        [Export("renderableSeries")]
        ISCIRenderableSeriesProtocol RenderableSeries { get; }

        // @required -(BOOL)isVerticalChart;
        [Abstract]
        [Export("isVerticalChart")]
        bool IsVerticalChart { get; }

        // @required -(id<SCICoordinateCalculatorProtocol>)yCoordinateCalculator;
        [Abstract]
        [Export("yCoordinateCalculator")]
        ISCICoordinateCalculatorProtocol YCoordinateCalculator { get; }

        // @required -(id<SCICoordinateCalculatorProtocol>)xCoordinateCalculator;
        [Abstract]
        [Export("xCoordinateCalculator")]
        ISCICoordinateCalculatorProtocol XCoordinateCalculator { get; }
    }
}