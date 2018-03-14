using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushTexture : NSObject <SCIBrush2DProtocol, SCITexturedBrushProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIBrushTexture : SCIBrush2DProtocol, SCITexturedBrushProtocol
    {
        // -(instancetype)initWithTexture:(SCITextureOpenGL *)texture;
        [Export("initWithTexture:")]
        IntPtr Constructor(SCITextureOpenGL texture);
    }
}