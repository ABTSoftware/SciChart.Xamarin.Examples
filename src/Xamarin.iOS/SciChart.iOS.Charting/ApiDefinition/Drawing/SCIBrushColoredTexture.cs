using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushColoredTexture : NSObject <SCIBrush2DProtocol, SCITexturedBrushProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIBrushColoredTexture : SCIBrush2DProtocol, SCITexturedBrushProtocol
    {
        // -(instancetype)initWithTexture:(SCITextureOpenGL *)texture ColorCode:(unsigned int)color;
        [Export("initWithTexture:ColorCode:")]
        IntPtr Constructor(SCITextureOpenGL texture, uint color);

        // -(instancetype)initWithTexture:(SCITextureOpenGL *)texture Color:(UIColor *)color;
        [Export("initWithTexture:Color:")]
        IntPtr Constructor(SCITextureOpenGL texture, UIColor color);
    }
}