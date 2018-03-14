using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIXyDataSeriesProtocol { }

    // @protocol SCIXyDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIXyDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(void)appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y Count:(int)count;
        [Abstract]
        [Export("appendRangeX:Y:Count:")]
        void AppendRange(SCIGenericType x, SCIGenericType y, int count);

        // @required -(void)appendX:(SCIGenericType)x Y:(SCIGenericType)y;
        [Abstract]
        [Export("appendX:Y:")]
        void Append_native(SCIGenericType x, SCIGenericType y);

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y;
        [Abstract]
        [Export("updateAt:X:Y:")]
        void UpdateXyAt_native(int index, SCIGenericType x, SCIGenericType y);

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x;
        [Abstract]
        [Export("updateAt:X:")]
        void UpdateXAt_native(int index, SCIGenericType x);

        // @required -(void)updateAt:(int)index Y:(SCIGenericType)y;
        [Abstract]
        [Export("updateAt:Y:")]
        void UpdateYAt_native(int index, SCIGenericType y);

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues yValues:(SCIGenericType)yValues count:(int)count;
        [Abstract]
        [Export("updateRange:xValues:yValues:count:")]
        void UpdateRangeXyAt(int index, SCIGenericType xValues, SCIGenericType yValues, int count);

        // @required -(void)updateRange:(int)index yValues:(SCIGenericType)yValues count:(int)count;
        [Abstract]
        [Export("updateRange:yValues:count:")]
        void UpdateRangeYAt(int index, SCIGenericType yValues, int count);

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;
        [Abstract]
        [Export("updateRange:xValues:count:")]
        void UpdateRangeXAt(int index, SCIGenericType xValues, int count);

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y;
        [Abstract]
        [Export("insertAt:X:Y:")]
        void Insert_native(int index, SCIGenericType x, SCIGenericType y);

        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Count:(int)count;
        [Abstract]
        [Export("insertRangeAt:X:Y:Count:")]
        void InsertRange(int index, SCIGenericType x, SCIGenericType y, int count);
    }
}