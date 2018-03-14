using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCITextureBrushStyle : SCIBrushStyle
    [BaseType(typeof(SCIBrushStyle))]
    interface SCITextureBrushStyle
    {
        // -(instancetype _Nonnull)initWithTexture:(SCITextureOpenGL * _Nonnull)texture;
        [Export("initWithTexture:")]
        IntPtr Constructor(SCITextureOpenGL texture);

        // -(instancetype _Nonnull)initWithTexture:(SCITextureOpenGL * _Nonnull)texture colorCode:(unsigned int)color;
        [Export("initWithTexture:colorCode:")]
        IntPtr Constructor(SCITextureOpenGL texture, uint color);

        // -(instancetype _Nonnull)initWithTexture:(SCITextureOpenGL * _Nonnull)texture color:(UIColor * _Nonnull)color;
        [Export("initWithTexture:color:")]
        IntPtr Constructor(SCITextureOpenGL texture, UIColor color);

        // @property (nonatomic, strong) SCITextureOpenGL * _Nonnull texture;
        [Export("texture", ArgumentSemantic.Strong)]
        SCITextureOpenGL Texture { get; set; }
    }
}