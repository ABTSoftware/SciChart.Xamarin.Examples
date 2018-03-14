using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIHlDataSeriesProtocol { }

    // @protocol SCIHlDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIHlDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(id<SCIArrayControllerProtocol>)highColumn;
        [Abstract]
        [Export("highColumn")]
        ISCIArrayControllerProtocol HighColumn { get; }

        // @required -(id<SCIArrayControllerProtocol>)lowColumn;
        [Abstract]
        [Export("lowColumn")]
        ISCIArrayControllerProtocol LowColumn { get; }

        // @required -(SCIDataType)highType;
        [Abstract]
        [Export("highType")]
        SCIDataType HighType { get; }

        // @required -(SCIDataType)lowType;
        [Abstract]
        [Export("lowType")]
        SCIDataType LowType { get; }

        // @required -(void)appendX:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
        [Abstract]
        [Export("appendX:Y:High:Low:")]
        void Append_native(SCIGenericType x, SCIGenericType y, SCIGenericType high, SCIGenericType low);

        // @required -(void)appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;
        [Abstract]
        [Export("appendRangeX:Y:High:Low:Count:")]
        void AppendRange(SCIGenericType x, SCIGenericType y, SCIGenericType high, SCIGenericType low, int count);

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
        [Abstract]
        [Export("updateAt:X:Y:High:Low:")]
        void Update(int index, SCIGenericType x, SCIGenericType y, SCIGenericType high, SCIGenericType low);

        // @required -(void)updateAt:(int)index Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
        [Abstract]
        [Export("updateAt:Y:High:Low:")]
        void Update_native(int index, SCIGenericType y, SCIGenericType high, SCIGenericType low);

        // @required -(void)updateRangeAt:(int)index Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;
        [Abstract]
        [Export("updateRangeAt:Y:High:Low:Count:")]
        void UpdateRange(int index, SCIGenericType y, SCIGenericType high, SCIGenericType low, int count);

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
        [Abstract]
        [Export("insertAt:X:Y:High:Low:")]
        void Insert_native(int index, SCIGenericType x, SCIGenericType y, SCIGenericType high, SCIGenericType low);

        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;
        [Abstract]
        [Export("insertRangeAt:X:Y:High:Low:Count:")]
        void InsertRange(int index, SCIGenericType x, SCIGenericType y, SCIGenericType high, SCIGenericType low, int count);
    }
}