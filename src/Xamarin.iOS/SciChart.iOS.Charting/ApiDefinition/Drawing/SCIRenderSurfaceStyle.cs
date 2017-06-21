using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderSurfaceStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIRenderSurfaceStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic) BOOL supressCallbacks;
        [Export("supressCallbacks")]
        bool SupressCallbacks { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> backgroundBrush;
        [Export("backgroundBrush", ArgumentSemantic.Strong)]
        SCIBrushStyle BackgroundBrush { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> borderPen;
        [Export("borderPen", ArgumentSemantic.Strong)]
        SCIPenStyle BorderPen { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> seriesBackgroundBrush;
        [Export("seriesBackgroundBrush", ArgumentSemantic.Strong)]
        SCIBrushStyle SeriesBackgroundBrush { get; set; }

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

        // @property (nonatomic) BOOL autoSizeAxes;
        [Export("autoSizeAxes")]
        bool AutoSizeAxes { get; set; }

        // @property (copy, nonatomic) SCIActionBlock layoutChanged;
        [Export("layoutChanged", ArgumentSemantic.Copy)]
        SCIActionBlock LayoutChanged { get; set; }
    }
}