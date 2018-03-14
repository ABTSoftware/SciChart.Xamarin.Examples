using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderSurfaceStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIRenderSurfaceStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIBrushStyle * backgroundBrush;
        [Export("backgroundBrush", ArgumentSemantic.Strong)]
        SCIBrushStyle BackgroundBrush { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * renderableSeriesAreaBorder;
        [Export("renderableSeriesAreaBorder", ArgumentSemantic.Strong)]
        SCIPenStyle RenderableSeriesAreaBorder { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * renderableSeriesAreaFill;
        [Export("renderableSeriesAreaFill", ArgumentSemantic.Strong)]
        SCIBrushStyle RenderableSeriesAreaFill { get; set; }

        // @property (nonatomic) float leftAxisAreaSize;
        [Export("leftAxisAreaSize")]
        float LeftAxisAreaSize { get; set; }

        // @property (nonatomic) float rightAxisAreaSize;
        [Export("rightAxisAreaSize")]
        float RightAxisAreaSize { get; set; }

        // @property (nonatomic) float topAxisAreaSize;
        [Export("topAxisAreaSize")]
        float TopAxisAreaSize { get; set; }

        // @property (nonatomic) float bottomAxisAreaSize;
        [Export("bottomAxisAreaSize")]
        float BottomAxisAreaSize { get; set; }

        // @property (nonatomic) BOOL supressCallbacks;
        [Export("supressCallbacks")]
        bool SupressCallbacks { get; set; }

        // @property (copy, nonatomic) SCIActionBlock layoutChanged;
        [Export("layoutChanged", ArgumentSemantic.Copy)]
        SCIActionBlock LayoutChanged { get; set; }
    }
}