using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCILinearGradientBrushProtocol : INSObjectProtocol { }

    // @protocol SCILinearGradientBrushProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
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

        // @required @property (nonatomic) int gradientIndex;
        [Abstract]
        [Export("gradientIndex")]
        int GradientIndex { get; set; }
    }
}