using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCITexturedBrushProtocol { }

    // @protocol SCITexturedBrushProtocol <NSObject, NSCopying>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCITexturedBrushProtocol : INSCopying
    {
        // @required @property (readonly, nonatomic, strong) SCITextureOpenGL * texture;
        [Abstract]
        [Export("texture", ArgumentSemantic.Strong)]
        SCITextureOpenGL Texture { get; }
    }
}