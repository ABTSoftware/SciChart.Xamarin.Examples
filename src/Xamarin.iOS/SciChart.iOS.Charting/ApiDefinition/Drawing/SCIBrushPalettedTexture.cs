using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushPalettedTexture : NSObject <SCIBrush2DProtocol, SCITexturedBrushProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIBrushPalettedTexture : SCIBrush2DProtocol, SCITexturedBrushProtocol
    {
        // -(instancetype)initWithTexture:(SCITextureOpenGL *)map Palette:(SCITextureOpenGL *)palette;
        [Export("initWithTexture:Palette:")]
        IntPtr Constructor(SCITextureOpenGL map, SCITextureOpenGL palette);

        // @property (readonly, nonatomic, strong) SCITextureOpenGL * palette;
        [Export("palette", ArgumentSemantic.Strong)]
        SCITextureOpenGL Palette { get; }
    }
}