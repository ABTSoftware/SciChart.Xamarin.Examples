using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIArrayController2D : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIArrayController2D
    {
        // -(instancetype _Nonnull)initWithType:(SCIDataType)type SizeX:(int)xSize Y:(int)ySize;
        [Export("initWithType:SizeX:Y:")]
        IntPtr Constructor(SCIDataType type, int xSize, int ySize);

        // -(SCIDataType)type;
        [Export("type")]
        SCIDataType Type { get; }

        // -(int)xSize;
        [Export("xSize")]
        int XSize { get; }

        // -(int)ySize;
        [Export("ySize")]
        int YSize { get; }

        // -(int)dataTypeSize;
        [Export("dataTypeSize")]
        int DataTypeSize { get; }

        // -(void * _Nonnull)data;
        // -(SCIGenericType)genericData;
        // -(SCIGenericType)valueAtX:(int)x Y:(int)y;
        // -(void)setValue:(SCIGenericType)value AtX:(int)x Y:(int)y;
    }
}