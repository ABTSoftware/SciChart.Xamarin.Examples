using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIPenLinearGradient : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIPenLinearGradient
    {
        // @property (nonatomic) BOOL requireRenderPassData;
        [Export("requireRenderPassData")]
        bool RequireRenderPassData { get; set; }

        // -(id)initWithColorStart:(UIColor *)colorStart Finish:(UIColor *)colorFinish Direction:(id)direction Width:(float)width;
        [Export("initWithColorStart:Finish:Direction:Width:")]
        IntPtr Constructor(UIColor colorStart, UIColor colorFinish, NSObject direction, float width);

        // -(id)initWithColorCodeStart:(unsigned int)colorStart Finish:(unsigned int)colorFinish Direction:(id)direction Width:(float)width;
        [Export("initWithColorCodeStart:Finish:Direction:Width:")]
        IntPtr Constructor(uint colorStart, uint colorFinish, NSObject direction, float width);

        // -(void)setDrawingAreaX:(double)X Y:(double)y Width:(double)width Height:(double)height;
        [Export("setDrawingAreaX:Y:Width:Height:")]
        void SetDrawingArea(double X, double y, double width, double height);

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