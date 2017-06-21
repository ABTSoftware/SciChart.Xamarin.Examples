using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderPassDataProtocol { }

    // @protocol ISCIRenderPassDataProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIRenderPassDataProtocol
    {
        // @required -(SCIIndexRange *)pointRange;
        [Abstract]
        [Export("pointRange")]
        SCIIndexRange PointRange { get; }

        // @required -(id<ISCIPointSeriesProtocol>)pointSeries;
        [Abstract]
        [Export("pointSeries")]
        ISCIPointSeriesProtocol PointSeries { get; }

        // @required -(id<SCIDataSeriesProtocol>)dataSeries;
        [Abstract]
        [Export("dataSeries")]
        ISCIDataSeriesProtocol DataSeries { get; }

        // @required -(id<ISCIRenderableSeriesProtocol>)renderableSeries;
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
