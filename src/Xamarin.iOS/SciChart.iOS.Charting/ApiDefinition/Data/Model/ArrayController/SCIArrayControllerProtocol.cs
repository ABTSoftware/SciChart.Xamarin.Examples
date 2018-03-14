using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIArrayControllerProtocol { }

    //TODO check unsafe data with Andrii
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

        //// @required -(void *)data;
        //[Abstract]
        //[Export("data")]
        //unsafe void* Data();

        //// @required -(void *)dataOfType:(SCIDataType)type;
        //[Abstract]
        //[Export("dataOfType:")]
        //unsafe void* DataOfType(SCIDataType type);

        //// @required -(float *)floatData;
        //[Abstract]
        //[Export("floatData")]
        //unsafe float* FloatData();

        //// @required -(double *)doubleData;
        //[Abstract]
        //[Export("doubleData")]
        //unsafe double* DoubleData();

        //// @required -(short *)int16Data;
        //[Abstract]
        //[Export("int16Data")]
        //unsafe short* Int16Data();

        //// @required -(int *)int32Data;
        //[Abstract]
        //[Export("int32Data")]
        //unsafe int* Int32Data();

        //// @required -(long long *)int64Data;
        //[Abstract]
        //[Export("int64Data")]
        //unsafe long* Int64Data();

        //// @required -(char *)byteData;
        //[Abstract]
        //[Export("byteData")]
        //unsafe sbyte* ByteData();

        //// @required -(double *)dateTimeData;
        //[Abstract]
        //[Export("dateTimeData")]
        //unsafe double* DateTimeData();

        // @required -(SCIGenericType)genericData;
        [Abstract]
        [Export("genericData")]
        SCIGenericType GenericData();

        // @required -(SCIGenericType)valueAt:(int)index;
        [Abstract]
        [Export("valueAt:")]
        SCIGenericType ValueAt(int index);

        //// @required -(void)getRangeMin:(double *)outMin max:(double *)outMax;
        //[Abstract]
        //[Export("getRangeMin:max:")]
        //unsafe void GetRangeMin(double* outMin, double* outMax);

        // @required -(void)removeAt:(int)index;
        [Abstract]
        [Export("removeAt:")]
        void RemoveAt(int index);

        // @required -(void)removeValue:(SCIGenericType)value;
        [Abstract]
        [Export("removeValue:")]
        void RemoveValue(SCIGenericType value);

        // @required -(void)removeRangeFrom:(int)index Count:(int)count;
        [Abstract]
        [Export("removeRangeFrom:Count:")]
        void RemoveRangeFrom(int index, int count);

        // @required -(void)setValue:(SCIGenericType)value At:(int)index;
        [Abstract]
        [Export("setValue:At:")]
        void SetValue(SCIGenericType value, int index);

        // @required -(void)setValueArray:(SCIGenericType)array atIndex:(int)index andCount:(int)count;
        [Abstract]
        [Export("setValueArray:atIndex:andCount:")]
        void SetValueArray(SCIGenericType array, int index, int count);

        // @required -(void)insertValue:(SCIGenericType)value At:(int)index;
        [Abstract]
        [Export("insertValue:At:")]
        void InsertValue(SCIGenericType value, int index);

        // @required -(void)insertRange:(SCIGenericType)array At:(int)index Count:(int)count;
        [Abstract]
        [Export("insertRange:At:Count:")]
        void InsertRange(SCIGenericType array, int index, int count);

        // @required -(int)indexOf:(SCIGenericType)value IsSorted:(BOOL)isSorted SearchMode:(SCIArraySearchMode)searchMode;
        [Abstract]
        [Export("indexOf:IsSorted:SearchMode:")]
        int IndexOf(SCIGenericType value, bool isSorted, SCIArraySearchMode searchMode);

        // @required -(BOOL)isEmpty;
        [Abstract]
        [Export("isEmpty")]
        bool IsEmpty();

        // @required -(void)append:(SCIGenericType)value;
        [Abstract]
        [Export("append:")]
        void Append(SCIGenericType value);

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
        [Abstract]
        [Export("appendRange:Count:")]
        void AppendRange(SCIGenericType array, int count);

        //// @required -(void)copyToArray:(void **)data Count:(int *)count Type:(SCIDataType)type;
        //[Abstract]
        //[Export("copyToArray:Count:Type:")]
        //unsafe void CopyToArray(void** data, int* count, SCIDataType type);

        // @required -(void)reverse;
        [Abstract]
        [Export("reverse")]
        void Reverse();
    }
}