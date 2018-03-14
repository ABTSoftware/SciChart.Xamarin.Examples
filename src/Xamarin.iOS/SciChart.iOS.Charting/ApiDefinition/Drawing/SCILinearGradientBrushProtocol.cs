using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCILinearGradientBrushProtocol { }

    // @protocol SCILinearGradientBrushProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCILinearGradientBrushProtocol
    {
        // @required @property (nonatomic) float minCoord;
        [Abstract]
        [Export("minCoord")]
        float MinCoord { get; set; }

        // @required @property (nonatomic) float maxCoord;
        [Abstract]
        [Export("maxCoord")]
        float MaxCoord { get; set; }

        // @required -(SCILinearGradientDirection)direction;
        [Abstract]
        [Export("direction")]
        SCILinearGradientDirection Direction { get; }

        // @required @property (nonatomic) float gradientIndex;
        [Abstract]
        [Export("gradientIndex")]
        float GradientIndex { get; set; }

        // TODO Chech unsafe code
        //// @required -(void)getGradientData:(uint **)data size:(int *)size;
        //[Abstract]
        //[Export("getGradientData:size:")]
        //unsafe void Size(uint** data, int* size);
    }
}