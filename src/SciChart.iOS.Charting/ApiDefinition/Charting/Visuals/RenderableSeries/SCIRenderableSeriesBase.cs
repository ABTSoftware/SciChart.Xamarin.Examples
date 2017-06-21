using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // typedef void(^IterationPassDataHandler)(double xValue, double yValue, double xCoordinate, double yCoordinate, int index);
    delegate void IterationPassDataHandler(double xValue, double yValue, double xCoordinate, double yCoordinate, int index);

    // @interface SCIRenderableSeriesBase : NSObject <ISCIRenderableSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIRenderableSeriesBase : SCIRenderableSeriesProtocol
    {
        // - (void)invalidateParentSurface;
        [Export("invalidateParentSurface")]
        void InvalidateParentSurface();

        // - (BOOL)isValidForDrawing;
        [Export("isValidForDrawing")]
        bool IsValidForDrawing { get; }

        // - (float)getDatapointWidthFrom:(id <SCIPointSeriesProtocol>)pointSeries Amount:(int)barsAmount Calculator:(id <SCICoordinateCalculatorProtocol>)xCalc WidthFraction:(double)widthFraction;
        [Export("getDatapointWidthFrom:Amount:Calculator:WidthFraction:")]
        float GetDatapointWidthFrom(ISCIPointSeriesProtocol pointSeries, int barsAmount, ISCICoordinateCalculatorProtocol xCalc, double widthFraction);

        // - (void)internalDrawWithContext:(id <SCIRenderContext2DProtocol>)renderContext WithData:(id <SCIRenderPassDataProtocol>)renderPassData;
        [Export("internalDrawWithContext:WithData:")]
        void InternalDrawWithContext(ISCIRenderContext2DProtocol renderContext, ISCIRenderPassDataProtocol renderPassData);

        // - (void)iterationInRenderPassData:(id <SCIRenderPassDataProtocol>)renderPassData withBlock:(IterationPassDataHandler)handler;
        [Export("iterationInRenderPassData:withBlock:")]
        void IterationInRenderPassData(ISCIRenderPassDataProtocol renderPassData, IterationPassDataHandler handler);
    }
}