using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIPen2DProtocol { }

    // @protocol SCIPen2DProtocol <NSObject, SCIOpenGLBrushProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIPen2DProtocol : SCIOpenGLBrushProtocol
    {
        // @required -(float)strokeThickness;
        [Abstract]
        [Export("strokeThickness")]
        float StrokeThickness { get; }
    }
}