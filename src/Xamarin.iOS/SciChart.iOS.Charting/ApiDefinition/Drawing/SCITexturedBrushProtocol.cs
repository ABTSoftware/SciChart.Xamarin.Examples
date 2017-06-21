using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCITexturedBrushProtocol { }

    // @protocol SCITexturedBrushProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCITexturedBrushProtocol
    {
        // @required @property (readonly, nonatomic, strong) SCITextureOpenGL * texture;
        [Abstract]
        [Export("texture", ArgumentSemantic.Strong)]
        SCITextureOpenGL Texture { get; }
    }
}