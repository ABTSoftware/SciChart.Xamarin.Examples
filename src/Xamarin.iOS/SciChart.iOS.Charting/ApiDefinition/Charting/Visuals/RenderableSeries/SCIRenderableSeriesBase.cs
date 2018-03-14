using Foundation;

namespace SciChart.iOS.Charting
{
    // typedef void (^IterationPassDataHandler)(double, double, double, double, int);
    delegate void IterationPassDataHandler(double arg0, double arg1, double arg2, double arg3, int arg4);

    // @interface SCIRenderableSeriesBase : NSObject <SCIRenderableSeriesProtocol, SCIThemeableProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIRenderableSeriesBase : SCIRenderableSeriesProtocol, SCIThemeableProtocol
    {
        // -(void)invalidateParentSurface;
        [Export("invalidateParentSurface")]
        void InvalidateParentSurface();

        // -(BOOL)isValidForDrawing;
        [Export("isValidForDrawing")]
        bool IsValidForDrawing { get; }

        // -(float)getDatapointWidthFrom:(id<SCIPointSeriesProtocol>)pointSeries Amount:(int)barsAmount Calculator:(id<SCICoordinateCalculatorProtocol>)xCalc WidthFraction:(double)widthFraction;
        [Export("getDatapointWidthFrom:Amount:Calculator:WidthFraction:")]
        float GetDatapointWidthFrom(ISCIPointSeriesProtocol pointSeries, int barsAmount, ISCICoordinateCalculatorProtocol xCalc, double widthFraction);

        // -(void)internalDrawWithContext:(id<SCIRenderContext2DProtocol>)renderContext WithData:(id<SCIRenderPassDataProtocol>)renderPassData;
        [Export("internalDrawWithContext:WithData:")]
        void InternalDrawWithContext(ISCIRenderContext2DProtocol renderContext, ISCIRenderPassDataProtocol renderPassData);

        // -(void)iterationInRenderPassData:(id<SCIRenderPassDataProtocol>)renderPassData withBlock:(IterationPassDataHandler)handler;
        [Export("iterationInRenderPassData:withBlock:")]
        void IterationInRenderPassData(ISCIRenderPassDataProtocol renderPassData, IterationPassDataHandler handler);
    }
}