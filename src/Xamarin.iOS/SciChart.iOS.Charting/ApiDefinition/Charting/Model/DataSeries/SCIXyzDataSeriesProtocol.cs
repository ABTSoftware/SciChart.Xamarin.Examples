using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIXyzDataSeriesProtocol { }

    // @protocol SCIXyzDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIXyzDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(SCIDataType)zType;
        [Abstract]
        [Export("zType")]
        SCIDataType ZType { get; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)zValues;
        [Abstract]
        [Export("zValues")]
        SCIArrayControllerProtocol ZValues { get; }

        // @required -(void)appendX:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z;
        [Abstract]
        [Export("appendX:Y:Z:")]
        void Append_native(SCIGenericType x, SCIGenericType y, SCIGenericType z);

        // @required -(void)appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z Count:(int)count;
        [Abstract]
        [Export("appendRangeX:Y:Z:Count:")]
        void AppendRange(SCIGenericType x, SCIGenericType y, SCIGenericType z, int count);

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z;
        [Abstract]
        [Export("updateAt:X:Y:Z:")]
        void UpdateXyzAt_native(int index, SCIGenericType x, SCIGenericType y, SCIGenericType z);

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x;
        [Abstract]
        [Export("updateAt:X:")]
        void UpdateXAt_native(int index, SCIGenericType x);

        // @required -(void)updateAt:(int)index Y:(SCIGenericType)y;
        [Abstract]
        [Export("updateAt:Y:")]
        void UpdateYAt_native(int index, SCIGenericType y);

        // @required -(void)updateAt:(int)index Z:(SCIGenericType)z;
        [Abstract]
        [Export("updateAt:Z:")]
        void UpdateZAt_native(int index, SCIGenericType z);

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues yValues:(SCIGenericType)yValues zValues:(SCIGenericType)zValues count:(int)count;
        [Abstract]
        [Export("updateRange:xValues:yValues:zValues:count:")]
        void UpdateRangeXyzAt(int index, SCIGenericType xValues, SCIGenericType yValues, SCIGenericType zValues, int count);

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;
        [Abstract]
        [Export("updateRange:xValues:count:")]
        void UpdateRangeXAt(int index, SCIGenericType xValues, int count);

        // @required -(void)updateRange:(int)index yValues:(SCIGenericType)yValues count:(int)count;
        [Abstract]
        [Export("updateRange:yValues:count:")]
        void UpdateRangeYAt(int index, SCIGenericType yValues, int count);

        // @required -(void)updateRange:(int)index zValues:(SCIGenericType)zValues count:(int)count;
        [Abstract]
        [Export("updateRange:zValues:count:")]
        void UpdateRangeZAt(int index, SCIGenericType zValues, int count);

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z;
        [Abstract]
        [Export("insertAt:X:Y:Z:")]
        void Insert_native(int index, SCIGenericType x, SCIGenericType y, SCIGenericType z);

        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z Count:(int)count;
        [Abstract]
        [Export("insertRangeAt:X:Y:Z:Count:")]
        void InsertRange(int index, SCIGenericType x, SCIGenericType y, SCIGenericType z, int count);
    }
}