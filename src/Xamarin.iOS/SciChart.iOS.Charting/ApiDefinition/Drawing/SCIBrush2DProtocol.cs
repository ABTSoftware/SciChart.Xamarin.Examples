using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIBrush2DProtocol { }

    // @protocol SCIBrush2DProtocol <NSObject, SCIOpenGLBrushProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIBrush2DProtocol : SCIOpenGLBrushProtocol
    {
    }
}