using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIOpenGLBrushProtocol { }

    // @protocol SCIOpenGLBrushProtocol <NSObject, SCIPathColorProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIOpenGLBrushProtocol : SCIPathColorProtocol
    {
        // @required -(BOOL)hasAlpha;
        [Abstract]
        [Export("hasAlpha")]
        bool HasAlpha { get; }

        //// @required -(void)apply:(SCIShaderAttributes *)attributes;
        //[Abstract]
        //[Export("apply:")]
        //void Apply(SCIShaderAttributes attributes);

        // @required -(NSUInteger)shaderType;
        [Abstract]
        [Export("shaderType")]
        nuint ShaderType { get; }

        // @required -(_Bool)equalsToBrush:(id<SCIOpenGLBrushProtocol>)otherBrush;
        [Abstract]
        [Export("equalsToBrush:")]
        bool EqualsToBrush(ISCIOpenGLBrushProtocol otherBrush);

        //// @required -(void)getColorCode:(uint *)color TextureX:(float *)tx Y:(float *)ty AtX:(double)x Y:(double)y;
        //[Abstract]
        //[Export("getColorCode:TextureX:Y:AtX:Y:")]
        //// TODO discuss this with Andrii
        //unsafe void GetColorCode(uint* color, float* tx, float* ty, double x, double y);

        // @required -(BOOL)variativeColor;
        [Abstract]
        [Export("variativeColor")]
        bool VariativeColor { get; }

        // @required @property (nonatomic) BOOL requireRenderPassData;
        [Abstract]
        [Export("requireRenderPassData")]
        bool RequireRenderPassData { get; set; }

        // @required -(void)setRenderPassData:(id<SCIRenderPassDataProtocol>)data;
        [Abstract]
        [Export("setRenderPassData:")]
        void SetRenderPassData(ISCIRenderPassDataProtocol data);

        // @required -(void)setDrawingAreaX:(double)x Y:(double)y Width:(double)width Height:(double)height;
        [Abstract]
        [Export("setDrawingAreaX:Y:Width:Height:")]
        void SetDrawingAreaX(double x, double y, double width, double height);
    }
}