using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIUniformHeatmapSeriesStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIUniformHeatmapSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCITextureOpenGL * colorMap;
        [Export("colorMap", ArgumentSemantic.Strong)]
        SCITextureOpenGL ColorMap { get; set; }

        // -(instancetype)initWithPalette:(SCITextureOpenGL *)colorMap;
        [Export("initWithColorMap:")]
        IntPtr Constructor(SCITextureOpenGL colorMap);
    }
}