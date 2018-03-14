using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCISpritePointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCISpritePointMarker
    {
        // @property (nonatomic, strong) SCITextureBrushStyle * textureBrush;
        [Export("textureBrush", ArgumentSemantic.Strong)]
        SCITextureBrushStyle TextureBrush { get; set; }
    }
}