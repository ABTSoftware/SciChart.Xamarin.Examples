using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisBase : SCIAxisCore <SCIAxis2DProtocol>
    [BaseType(typeof(SCIAxisCore))]
    interface SCIAxisBase : SCIAxis2DProtocol
    {
        // +(NSString *)defaultAxisId;
        [Static]
        [Export("defaultAxisId")]
        string DefaultAxisId { get; }

        // -(int)minDistanceToBounds;
        [Export("minDistanceToBounds")]
        int MinDistanceToBounds { get; }

        // -(double)zeroRangeGrowBy;
        [Export("zeroRangeGrowBy")]
        double ZeroRangeGrowBy { get; }

        // -(id<SCIRenderSurfaceProtocol>)renderSurface;
        [Export("renderSurface")]
        ISCIRenderSurfaceProtocol RenderSurface { get; }

        // -(id<SCIRangeProtocol>)coerceZeroRange:(id<SCIRangeProtocol>)maximumRange;
        [Export("coerceZeroRange:")]
        ISCIRangeProtocol CoerceZeroRange(ISCIRangeProtocol maximumRange);

        // -(SCIAxisParams *)getAxisParams;
        [Export("getAxisParams")]
        SCIAxisParams AxisParams { get; }

        // -(void)onDrawAxis:(SCITickCoordinates *)tickCoords;
        [Export("onDrawAxis:")]
        void OnDrawAxis(SCITickCoordinates tickCoords);

        // -(void)drawAxisAreaWithContext:(id<ISCIRenderContext2DProtocol>)renderContext;
        [Export("drawAxisAreaWithContext:")]
        void DrawAxisArea(ISCIRenderContext2DProtocol renderContext);

        // -(void)drawBandsWithContext:(id<ISCIRenderContext2DProtocol>)renderContext;
        [Export("drawBandsWithContext:")]
        void DrawBands(ISCIRenderContext2DProtocol renderContext);

        // -(void)drawMinorGridLinesWithContext:(id<ISCIRenderContext2DProtocol>)renderContext;
        [Export("drawMinorGridLinesWithContext:")]
        void DrawMinorGridLines(ISCIRenderContext2DProtocol renderContext);

        // -(void)drawMajorGridLinesWithContext:(id<ISCIRenderContext2DProtocol>)renderContext;
        [Export("drawMajorGridLinesWithContext:")]
        void DrawMajorGridLines(ISCIRenderContext2DProtocol renderContext);
    }
}