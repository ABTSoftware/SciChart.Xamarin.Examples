using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushLinearGradient : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIBrushLinearGradient : SCIBrush2DProtocol, SCILinearGradientBrushProtocol
    {
        // -(id)initWithColorStart:(UIColor *)startColor Finish:(UIColor *)finishColor Direction:(id)gradientDirection;
        [Export("initWithColorStart:Finish:Direction:")]
        IntPtr Constructor(UIColor startColor, UIColor finishColor, SCILinearGradientDirection gradientDirection);

        // -(id)initWithColorCodeStart:(uint)startColor Finish:(uint)finishColor Direction:(id)gradientDirection;
        [Export("initWithColorCodeStart:Finish:Direction:")]
        IntPtr Constructor(uint startColor, uint finishColor, SCILinearGradientDirection gradientDirection);

        // @property (nonatomic) BOOL requireRenderPassData;
        [Export("requireRenderPassData")]
        bool RequireRenderPassData { get; set; }

        // @property (nonatomic) float minCoord;
        [Export("minCoord")]
        float MinCoord { get; set; }

        // @property (nonatomic) float maxCoord;
        [Export("maxCoord")]
        float MaxCoord { get; set; }

        // @property (nonatomic) int gradientIndex;
        [Export("gradientIndex")]
        int GradientIndex { get; set; }
    }
}