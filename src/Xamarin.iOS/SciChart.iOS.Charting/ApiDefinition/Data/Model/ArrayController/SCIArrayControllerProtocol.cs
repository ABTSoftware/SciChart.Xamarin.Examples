using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIArrayControllerProtocol
    {
    }

    // @protocol SCIArrayControllerProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIArrayControllerProtocol
    {
        // @required -(id)initWithType:(SCIDataType)type;
        [Export("initWithType:")]
        IntPtr Constructor(SCIDataType type);

        // @required -(id)initWithType:(SCIDataType)type Size:(int)size;
        [Export("initWithType:Size:")]
        IntPtr Constructor(SCIDataType type, int size);

        // @required -(SCIDataType)type;
        [Abstract]
        [Export("type")]
        SCIDataType Type { get; }

        // @required -(int)count;
        // @required -(void)setCount:(int)count;
        [Abstract]
        [Export("count")]
        int Count { get; set; }

        // @required -(int)dataTypeSize;
        [Abstract]
        [Export("dataTypeSize")]
        int DataTypeSize();

        // @required -(void *)data;
        // @required -(void *)dataOfType:(SCIDataType)type;
        // @required -(float *)floatData;
        // @required -(double *)doubleData;
        // @required -(short *)int16Data;
        // @required -(int *)int32Data;
        // @required -(long long *)int64Data;
        // @required -(char *)byteData;
        // @required -(double *)dateTimeData;

        // @required -(SCIGenericType)genericData;
        // @required -(SCIGenericType)valueAt:(int)index;

        // @required -(void)getRangeMin:(double *)outMin max:(double *)outMax;
        [Abstract]
        [Export("getRangeMin:max:")]
        unsafe void GetRangeMin(out double outMin, out double outMax);

        // @required -(void)removeAt:(int)index;
        [Abstract]
        [Export("removeAt:")]
        void RemoveAt(int index);

        // @required -(void)removeValue:(SCIGenericType)value;

        // @required -(void)removeRangeFrom:(int)index Count:(int)count;
        [Abstract]
        [Export("removeRangeFrom:Count:")]
        void RemoveRangeFrom(int index, int count);

        // @required -(void)setValue:(SCIGenericType)value At:(int)index;
        // @required -(void)setValueArray:(SCIGenericType)array atIndex:(int)index andCount:(int)count;
        // @required -(void)insertValue:(SCIGenericType)value At:(int)index;
        // @required -(void)insertRange:(SCIGenericType)array At:(int)index Count:(int)count;
        // @required -(int)indexOf:(SCIGenericType)value IsSorted:(BOOL)isSorted SearchMode:(SCIArraySearchMode)searchMode;

        // @required -(BOOL)isEmpty;
        [Abstract]
        [Export("isEmpty")]
        bool IsEmpty();

        // @required -(void)append:(SCIGenericType)value;

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // @required -(void)purge;
        [Abstract]
        [Export("purge")]
        void Purge();

        // @required -(int)currentMaxSize;
        [Abstract]
        [Export("currentMaxSize")]
        int CurrentMaxSize();

        // @required -(void)appendRange:(NSArray *)array;
        [Abstract]
        [Export("appendRange:")]
        void AppendRange(NSObject[] array);

        // @required -(void)appendRange:(SCIGenericType)array Count:(int)count;
        // @required -(void)copyToArray:(void **)data Count:(int *)count Type:(SCIDataType)type;

        // @required -(void)reverse;
        [Abstract]
        [Export("reverse")]
        void Reverse();
    }
}