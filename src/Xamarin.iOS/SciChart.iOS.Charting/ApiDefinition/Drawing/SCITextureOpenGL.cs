using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // TODO check all commented unsafe code in SCITextureOpenGL with iOS team
    // @interface SCITextureOpenGL : NSObject
    [BaseType(typeof(NSObject))]
    interface SCITextureOpenGL
    {
        // @property (nonatomic) NSArray<UIColor *> * colors;
        [Export("colors", ArgumentSemantic.Assign)]
        UIColor[] Colors { get; set; }

        // @property (nonatomic) NSArray<NSNumber *> * stops;
        [Export("stops", ArgumentSemantic.Assign)]
        NSNumber[] Stops { get; set; }

        // @property (nonatomic) CGSize textureSize;
        [Export("textureSize", ArgumentSemantic.Assign)]
        CGSize TextureSize { get; set; }

        // -(instancetype)initWithId:(GLuint)textureId;
        [Export("initWithId:")]
        IntPtr Constructor(uint textureId);

        //// -(instancetype)initWithByteData:(GLubyte *)data Width:(int)width Height:(int)height;
        //[Export("initWithByteData:Width:Height:")]
        //unsafe IntPtr Constructor(byte* data, int width, int height);

        //// -(instancetype)initWithByteData:(GLubyte *)data Width:(int)width Height:(int)height WrapParameter:(GLint)wrapParameter;
        //[Export("initWithByteData:Width:Height:WrapParameter:")]
        //unsafe IntPtr Constructor(byte* data, int width, int height, int wrapParameter);

        // -(instancetype)initWithImage:(UIImage *)image;
        [Export("initWithImage:")]
        IntPtr Constructor(UIImage image);

        //// -(instancetype)initWithFloatData:(GLfloat *)data Width:(int)width Height:(int)height;
        //[Export("initWithFloatData:Width:Height:")]
        //unsafe IntPtr Constructor(float* data, int width, int height);

        //// -(instancetype)initWithGradientCoords:(float *)coords Colors:(uint *)colors Count:(int)count;
        //[Export("initWithGradientCoords:Colors:Count:")]
        //unsafe IntPtr Constructor(float* coords, uint* colors, int count);

        // -(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count;
        [Export("initWithGradientCoords:Colors:Count:")]
        IntPtr Constructor(IntPtr coords, IntPtr colors, int count);

        //// -(instancetype)initWithGradientCoords:(float *)coords Colors:(uint *)colors Count:(int)count Detalization:(int)detalization;
        //[Export("initWithGradientCoords:Colors:Count:Detalization:")]
        //unsafe IntPtr Constructor(float* coords, uint* colors, int count, int detalization);

        //// -(instancetype)initWithByteData:(GLubyte *)data Width:(int)width Height:(int)height Context:(id<SCIRenderContext2DProtocol>)context;
        //[Export("initWithByteData:Width:Height:Context:")]
        //unsafe IntPtr Constructor(byte* data, int width, int height, SCIRenderContext2DProtocol context);

        // -(instancetype)initWithImage:(UIImage *)image Context:(id<SCIRenderContext2DProtocol>)context;
        [Export("initWithImage:Context:")]
        IntPtr Constructor(UIImage image, SCIRenderContext2DProtocol context);

        //// -(instancetype)initWithFloatData:(GLfloat *)data Width:(int)width Height:(int)height Context:(id<SCIRenderContext2DProtocol>)context;
        //[Export("initWithFloatData:Width:Height:Context:")]
        //unsafe IntPtr Constructor(float* data, int width, int height, SCIRenderContext2DProtocol context);

        //// -(instancetype)initWithGradientCoords:(float *)coords Colors:(uint *)colors Count:(int)count Context:(id<SCIRenderContext2DProtocol>)context;
        //[Export("initWithGradientCoords:Colors:Count:Context:")]
        //unsafe IntPtr Constructor(float* coords, uint* colors, int count, SCIRenderContext2DProtocol context);

        //// -(instancetype)initWithGradientCoords:(float *)coords Colors:(uint *)colors Count:(int)count Detalization:(int)detalization Context:(id<SCIRenderContext2DProtocol>)context;
        //[Export("initWithGradientCoords:Colors:Count:Detalization:Context:")]
        //unsafe IntPtr Constructor(float* coords, uint* colors, int count, int detalization, SCIRenderContext2DProtocol context);

        //// -(void)updateWithByteData:(GLubyte *)data Width:(int)width Height:(int)height;
        //[Export("updateWithByteData:Width:Height:")]
        //unsafe void UpdateWithByteData(byte* data, int width, int height);

        //// -(void)updateWithFloatData:(GLfloat *)data Width:(int)width Height:(int)height;
        //[Export("updateWithFloatData:Width:Height:")]
        //unsafe void UpdateWithFloatData(float* data, int width, int height);

        // -(GLuint)textureId;
        [Export("textureId")]
        uint TextureId { get; }

        // -(BOOL)isValid;
        [Export("isValid")]
        bool IsValid { get; }
    }
}