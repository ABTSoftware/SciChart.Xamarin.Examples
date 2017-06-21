using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushTexture : NSObject <SCIBrush2DProtocol, SCITexturedBrushProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIBrushTexture : SCIBrush2DProtocol, SCITexturedBrushProtocol
    {
        // -(instancetype)initWithTexture:(SCITextureOpenGL *)texture;
        [Export("initWithTexture:")]
        IntPtr Constructor(SCITextureOpenGL texture);

        // @property (nonatomic) BOOL requireRenderPassData;
        [Export("requireRenderPassData")]
        bool RequireRenderPassData { get; set; }
    }
}