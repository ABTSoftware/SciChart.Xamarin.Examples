using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIXyyDataSeriesProtocol { }

    // @protocol SCIXyyDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIXyyDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(id<SCIArrayControllerProtocol>)y1Values;
        [Abstract]
        [Export("y1Values")]
        ISCIArrayControllerProtocol Y1Values { get; }

        // @required -(id<SCIArrayControllerProtocol>)y2Values;
        [Abstract]
        [Export("y2Values")]
        ISCIArrayControllerProtocol Y2Values { get; }

        // @required -(SCIDataType)y1Type;
        [Abstract]
        [Export("y1Type")]
        SCIDataType Y1Type { get; }

        // @required -(SCIDataType)y2Type;
        [Abstract]
        [Export("y2Type")]
        SCIDataType Y2Type { get; }

        // @required -(void)appendX:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;
        [Abstract]
        [Export("appendX:Y1:Y2:")]
        void Append_native(SCIGenericType x, SCIGenericType y1, SCIGenericType y2);

        // @required -(void)appendRangeX:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2 Count:(int)count;
        [Abstract]
        [Export("appendRangeX:Y1:Y2:Count:")]
        void AppendRange(SCIGenericType x, SCIGenericType y1, SCIGenericType y2, int count);

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;
        [Abstract]
        [Export("updateAt:X:Y1:Y2:")]
        void UpdateXyy1At_native(int index, SCIGenericType x, SCIGenericType y1, SCIGenericType y2);

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x;
        [Abstract]
        [Export("updateAt:X:")]
        void UpdateXAt_native(int index, SCIGenericType x);

        // @required -(void)updateAt:(int)index Y1:(SCIGenericType)y1;
        [Abstract]
        [Export("updateAt:Y1:")]
        void UpdateYAt_native(int index, SCIGenericType y1);

        // @required -(void)updateAt:(int)index Y2:(SCIGenericType)y2;
        [Abstract]
        [Export("updateAt:Y2:")]
        void UpdateY1At_native(int index, SCIGenericType y2);

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues y1Values:(SCIGenericType)y1Values y2Values:(SCIGenericType)y2Values count:(int)count;
        [Abstract]
        [Export("updateRange:xValues:y1Values:y2Values:count:")]
        void UpdateRangeXyy1At(int index, SCIGenericType xValues, SCIGenericType y1Values, SCIGenericType y2Values, int count);

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;
        [Abstract]
        [Export("updateRange:xValues:count:")]
        void UpdateRangeXAt(int index, SCIGenericType xValues, int count);

        // @required -(void)updateRange:(int)index y1Values:(SCIGenericType)y1Values count:(int)count;
        [Abstract]
        [Export("updateRange:y1Values:count:")]
        void UpdateRangeYAt(int index, SCIGenericType y1Values, int count);

        // @required -(void)updateRange:(int)index y2Values:(SCIGenericType)y2Values count:(int)count;
        [Abstract]
        [Export("updateRange:y2Values:count:")]
        void UpdateRangeY1At(int index, SCIGenericType y2Values, int count);

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;
        [Abstract]
        [Export("insertAt:X:Y1:Y2:")]
        void Insert_native(int index, SCIGenericType x, SCIGenericType y1, SCIGenericType y2);

        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2 Count:(int)count;
        [Abstract]
        [Export("insertRangeAt:X:Y1:Y2:Count:")]
        void InsertRange(int index, SCIGenericType x, SCIGenericType y1, SCIGenericType y2, int count);
    }
}