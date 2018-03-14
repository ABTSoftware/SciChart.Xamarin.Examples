using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIUniformHeatmapSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIUniformHeatmapSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCITextureOpenGL * colorMap;
        [Export("colorMap", ArgumentSemantic.Strong)]
        SCITextureOpenGL ColorMap { get; set; }

        // @property (nonatomic) SCIGenericType minimum;
        [Export("minimum", ArgumentSemantic.Assign)]
        SCIGenericType Minimum { get; set; }

        // @property (nonatomic) SCIGenericType maximum;
        [Export("maximum", ArgumentSemantic.Assign)]
        SCIGenericType Maximum { get; set; }

        // -(instancetype)initWithColorMap:(SCITextureOpenGL *)colorMap;
        [Export("initWithColorMap:")]
        IntPtr Constructor(SCITextureOpenGL colorMap);
    }
}