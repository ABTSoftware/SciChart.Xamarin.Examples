using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    //TODO check unsafe data with Andrii
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

        //// -(void * _Nonnull)data;
        //[Export("data")]
        //unsafe void* Data { get; }

        // -(SCIGenericType)genericData;
        [Export("genericData")]
        SCIGenericType GenericData { get; }

        // -(SCIGenericType)valueAtX:(int)x Y:(int)y;
        [Export("valueAtX:Y:")]
        SCIGenericType ValueAtX(int x, int y);

        // -(void)setValue:(SCIGenericType)value AtX:(int)x Y:(int)y;
        [Export("setValue:AtX:Y:")]
        void SetValue(SCIGenericType value, int x, int y);

        // -(void)setValueArray:(SCIGenericType)array AtX:(int)x Y:(int)y Count:(int)count;
        [Export("setValueArray:AtX:Y:Count:")]
        void SetValueArray(SCIGenericType array, int x, int y, int count);
    }
}