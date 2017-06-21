using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITextureOpenGL : NSObject
    [BaseType(typeof(NSObject))]
    interface SCITextureOpenGL
    {
        // @property(nonatomic) NSArray<UIColor*>* colors;
        [Export("colors")]
        UIColor[] Colors { get; set; }

        // @property(nonatomic) NSArray<NSNumber *> *stops;
        [Export("stops")]
        NSNumber[] Stops { get; set; }

        // -(instancetype)initWithId:(GLuint)textureId;
        [Export("initWithId:")]
        IntPtr Constructor(uint textureId);

        // -(instancetype)initWithImage:(UIImage *)image;
        [Export("initWithImage:")]
        IntPtr Constructor(UIImage image);

        // -(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count;
        [Export("initWithGradientCoords:Colors:Count:")]
        IntPtr Constructor(IntPtr coords, IntPtr colors, int count);

        // -(BOOL)isValid;
        [Export("isValid")]
        bool IsValid { get; }
    }
}