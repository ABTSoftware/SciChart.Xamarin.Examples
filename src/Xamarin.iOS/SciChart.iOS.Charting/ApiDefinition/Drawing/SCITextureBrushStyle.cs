using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    [BaseType(typeof(SCIBrushStyle))]
    interface SCITextureBrushStyle : SCIBrushStyle
    {
        // -(instancetype)initWithTexture:(SCITextureOpenGL *)texture;
        [Export("initWithTexture:")]
        IntPtr Constructor(SCITextureOpenGL texture);
    }
}
