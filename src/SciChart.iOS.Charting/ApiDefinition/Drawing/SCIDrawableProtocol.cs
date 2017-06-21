using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIDrawableProtocol { }

    // @protocol SCIDrawableProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIDrawableProtocol
    {
        // @required -(void)onDrawWithContext:(id<ISCIRenderContext2DProtocol>)renderContext WithData:(id<ISCIRenderPassDataProtocol>)renderPassData;
        [Abstract]
        [Export("onDrawWithContext:WithData:")]
        void OnDrawWithContext(ISCIRenderContext2DProtocol renderContext, ISCIRenderPassDataProtocol renderPassData);

        // @required -(void)prepareForDrawing;
        [Abstract]
        [Export("prepareForDrawing")]
        void PrepareForDrawing();
    }
}