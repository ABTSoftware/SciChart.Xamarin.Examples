using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIOpenGLBrushProtocol : INSObjectProtocol, ISCIPathColorProtocol { }

    // @protocol SCIOpenGLBrushProtocol <NSObject, SCIPathColorProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIOpenGLBrushProtocol : SCIPathColorProtocol
    {
        // @required -(BOOL)hasAlpha;
        [Abstract]
        [Export("hasAlpha")]
        bool HasAlpha { get; }

        // @required -(NSUInteger)shaderType;
        [Abstract]
        [Export("shaderType")]
        nuint ShaderType { get; }

        // @required -(_Bool)equalsToBrush:(id<SCIOpenGLBrushProtocol>)otherBrush;
        [Abstract]
        [Export("equalsToBrush:")]
        bool EqualsToBrush(ISCIOpenGLBrushProtocol otherBrush);

        // @required -(BOOL)variativeColor;
        [Abstract]
        [Export("variativeColor")]
        bool VariativeColor { get; }

        // @required @property (nonatomic) BOOL requireRenderPassData;
        [Abstract]
        [Export("requireRenderPassData")]
        bool RequireRenderPassData { get; set; }

        // @required -(void)setRenderPassData:(id<ISCIRenderPassDataProtocol>)data;
        [Abstract]
        [Export("setRenderPassData:")]
        void SetRenderPassData(ISCIRenderPassDataProtocol data);

        // @required -(void)setDrawingAreaX:(double)x Y:(double)y Width:(double)width Height:(double)height;
        [Abstract]
        [Export("setDrawingAreaX:Y:Width:Height:")]
        void SetDrawingArea(double x, double y, double width, double height);
    }
}