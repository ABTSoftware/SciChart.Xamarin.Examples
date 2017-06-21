using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIHlDataSeriesProtocol : SCIDataSeriesProtocol, INSObjectProtocol { }

    // @protocol SCIHlcDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIHlDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(id<SCIArrayControllerProtocol>)highColumn;
        [Abstract]
        [Export("highColumn")]
        SCIArrayControllerProtocol HighColumn { get; }

        // @required -(id<SCIArrayControllerProtocol>)lowColumn;
        [Abstract]
        [Export("lowColumn")]
        SCIArrayControllerProtocol LowColumn { get; }

        // @required -(SCIDataType)highType;
        [Abstract]
        [Export("highType")]
        SCIDataType HighType { get; }

        // @required -(SCIDataType)lowType;
        [Abstract]
        [Export("lowType")]
        SCIDataType LowType { get; }

        // @required -(void)appendX:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
        // @required -(void)appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;

        // @required -(void)updateAt:(int)index Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
        // @required -(void)updateRangeAt:(int)index Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;
    }
}