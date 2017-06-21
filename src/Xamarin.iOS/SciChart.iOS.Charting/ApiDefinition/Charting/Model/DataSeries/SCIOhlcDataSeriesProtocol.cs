using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIOhlcDataSeriesProtocol : SCIDataSeriesProtocol, INSObjectProtocol { }

    // @protocol SCIOhlcDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIOhlcDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(id<SCIArrayControllerProtocol>)openValues;
        [Abstract]
        [Export("openValues")]
        SCIArrayControllerProtocol OpenValues { get; }

        // @required -(id<SCIArrayControllerProtocol>)highValues;
        [Abstract]
        [Export("highValues")]
        SCIArrayControllerProtocol HighValues { get; }

        // @required -(id<SCIArrayControllerProtocol>)lowValues;
        [Abstract]
        [Export("lowValues")]
        SCIArrayControllerProtocol LowValues { get; }

        // @required -(id<SCIArrayControllerProtocol>)closeValues;
        [Abstract]
        [Export("closeValues")]
        SCIArrayControllerProtocol CloseValues { get; }

        // @required -(SCIDataType)openType;
        [Abstract]
        [Export("openType")]
        SCIDataType OpenType { get; }

        // @required -(SCIDataType)highType;
        [Abstract]
        [Export("highType")]
        SCIDataType HighType { get; }

        // @required -(SCIDataType)lowType;
        [Abstract]
        [Export("lowType")]
        SCIDataType LowType { get; }

        // @required -(SCIDataType)closeType;
        [Abstract]
        [Export("closeType")]
        SCIDataType CloseType { get; }

        // @required -(void)appendX:(SCIGenericType)x Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close;
        // @required -(void)appendRangeX:(SCIGenericType)x Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close Count:(int)count;

        // @required -(void)updateAt:(int)index Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close;
        // @required -(void)updateRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close;
        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close Count:(int)count;
    }
}