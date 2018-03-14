using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIOhlcDataSeriesProtocol { }

    // @protocol SCIOhlcDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIOhlcDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(id<SCIArrayControllerProtocol>)openValues;
        [Abstract]
        [Export("openValues")]
        ISCIArrayControllerProtocol OpenValues { get; }

        // @required -(id<SCIArrayControllerProtocol>)highValues;
        [Abstract]
        [Export("highValues")]
        ISCIArrayControllerProtocol HighValues { get; }

        // @required -(id<SCIArrayControllerProtocol>)lowValues;
        [Abstract]
        [Export("lowValues")]
        ISCIArrayControllerProtocol LowValues { get; }

        // @required -(id<SCIArrayControllerProtocol>)closeValues;
        [Abstract]
        [Export("closeValues")]
        ISCIArrayControllerProtocol CloseValues { get; }

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
        [Abstract]
        [Export("appendX:Open:High:Low:Close:")]
        void Append_native(SCIGenericType x, SCIGenericType open, SCIGenericType high, SCIGenericType low, SCIGenericType close);

        // @required -(void)appendRangeX:(SCIGenericType)x Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close Count:(int)count;
        [Abstract]
        [Export("appendRangeX:Open:High:Low:Close:Count:")]
        void AppendRange(SCIGenericType x, SCIGenericType open, SCIGenericType high, SCIGenericType low, SCIGenericType close, int count);

        // @required -(void)updateAt:(int)index Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close;
        [Abstract]
        [Export("updateAt:Open:High:Low:Close:")]
        void Update_native(int index, SCIGenericType open, SCIGenericType high, SCIGenericType low, SCIGenericType close);

        // @required -(void)updateRangeAt:(int)index Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close Count:(int)count;
        [Abstract]
        [Export("updateRangeAt:Open:High:Low:Close:Count:")]
        void UpdateRange(int index, SCIGenericType open, SCIGenericType high, SCIGenericType low, SCIGenericType close, int count);

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close;
        [Abstract]
        [Export("insertAt:X:Open:High:Low:Close:")]
        void Insert_native(int index, SCIGenericType x, SCIGenericType open, SCIGenericType high, SCIGenericType low, SCIGenericType close);

        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Open:(SCIGenericType)open High:(SCIGenericType)high Low:(SCIGenericType)low Close:(SCIGenericType)close Count:(int)count;
        [Abstract]
        [Export("insertRangeAt:X:Open:High:Low:Close:Count:")]
        void InsertRange(int index, SCIGenericType x, SCIGenericType open, SCIGenericType high, SCIGenericType low, SCIGenericType close, int count);
    }
}