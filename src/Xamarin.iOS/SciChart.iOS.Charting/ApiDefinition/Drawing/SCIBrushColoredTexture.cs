using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushColoredTexture : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIBrushColoredTexture
    {
        // -(instancetype)initWithTexture:(SCITextureOpenGL *)texture ColorCode:(unsigned int)color;
        [Export("initWithTexture:ColorCode:")]
        IntPtr Constructor(SCITextureOpenGL texture, uint color);

        // -(instancetype)initWithTexture:(SCITextureOpenGL *)texture Color:(UIColor *)color;
        [Export("initWithTexture:Color:")]
        IntPtr Constructor(SCITextureOpenGL texture, UIColor color);

        // @property (readonly, nonatomic, strong) SCITextureOpenGL * texture;
        [Export("texture", ArgumentSemantic.Strong)]
        SCITextureOpenGL Texture { get; }

        // @property (nonatomic) BOOL requireRenderPassData;
        [Export("requireRenderPassData")]
        bool RequireRenderPassData { get; set; }
    }
}