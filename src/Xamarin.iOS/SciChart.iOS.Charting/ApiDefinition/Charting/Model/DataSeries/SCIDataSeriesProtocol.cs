using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIDataSeriesProtocol { }

    // @protocol SCIDataSeriesProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIDataSeriesProtocol
    {
        // @optional @property (nonatomic) int fifoCapacity;
        [Export("fifoCapacity")]
        int FifoCapacity { get; set; }

        // @optional @property (nonatomic) BOOL acceptUnsortedData;
        [Export("acceptUnsortedData")]
        bool AcceptUnsortedData { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable seriesName;
        [Abstract]
        [NullAllowed, Export("seriesName")]
        string SeriesName { get; set; }

        // @required @property (nonatomic, strong) id<SCIPointSeriesProtocol> _Nullable lastPointSeries;
        [Abstract]
        [NullAllowed, Export("lastPointSeries", ArgumentSemantic.Strong)]
        ISCIPointSeriesProtocol LastPointSeries { get; set; }

        // @required -(void)addObserver:(SCIDataSeriesObserver * _Nonnull)observer;
        [Abstract]
        [Export("addObserver:")]
        void AddObserver(SCIActionBlock observer);

        // @required -(void)removeObserver:(SCIDataSeriesObserver * _Nonnull)observer;
        [Abstract]
        [Export("removeObserver:")]
        void RemoveObserver(SCIActionBlock observer);

        // @required -(SCIDataType)xType;
        [Abstract]
        [Export("xType")]
        SCIDataType XType { get; }

        // @required -(SCIDataType)yType;
        [Abstract]
        [Export("yType")]
        SCIDataType YType { get; }

        // @required -(id<SCIRangeProtocol> _Nonnull)getXRange;
        [Abstract]
        [Export("getXRange")]
        ISCIRangeProtocol XRange { get; }

        // @required -(id<SCIRangeProtocol> _Nonnull)getYRange;
        [Abstract]
        [Export("getYRange")]
        ISCIRangeProtocol YRange { get; }

        // @required -(SCIDataSeriesType)dataSeriesType;
        [Abstract]
        [Export("dataSeriesType")]
        SCIDataSeriesType DataSeriesType { get; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)xValues;
        [Abstract]
        [Export("xValues")]
        ISCIArrayControllerProtocol XValues { get; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)yValues;
        [Abstract]
        [Export("yValues")]
        ISCIArrayControllerProtocol YValues { get; }

        // @required -(SCIGenericType)YMin;
        [Abstract]
        [Export("YMin")]
        SCIGenericType YMin { get; }

        // @required -(SCIGenericType)YMax;
        [Abstract]
        [Export("YMax")]
        SCIGenericType YMax { get; }

        // @required -(SCIGenericType)XMin;
        [Abstract]
        [Export("XMin")]
        SCIGenericType XMin { get; }

        // @required -(SCIGenericType)XMax;
        [Abstract]
        [Export("XMax")]
        SCIGenericType XMax { get; }

        // @required -(BOOL)hasValues;
        [Abstract]
        [Export("hasValues")]
        bool HasValues { get; }

        // @required -(int)count;
        [Abstract]
        [Export("count")]
        int Count { get; }

        // @required -(BOOL)isSorted;
        [Abstract]
        [Export("isSorted")]
        bool IsSorted { get; }

        // @required -(BOOL)isFifo;
        [Abstract]
        [Export("isFifo")]
        bool IsFifo { get; }

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // @required -(SCIIndexRange * _Nonnull)getIndicesRangeWithVisibleRange:(id<SCIRangeProtocol> _Nonnull)visibleRange;
        [Abstract]
        [Export("getIndicesRangeWithVisibleRange:")]
        SCIIndexRange GetIndicesRangeWithVisibleRange(ISCIRangeProtocol visibleRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithXRange:(id<SCIRangeProtocol> _Nonnull)xRange;
        [Abstract]
        [Export("getWindowYRangeWithXRange:")]
        ISCIRangeProtocol GetWindowYRangeWithXRange(ISCIRangeProtocol xRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithXRange:(id<SCIRangeProtocol> _Nonnull)xRange GetPositiveRange:(BOOL)getPositiveRange;
        [Abstract]
        [Export("getWindowYRangeWithXRange:GetPositiveRange:")]
        ISCIRangeProtocol GetWindowYRangeWithXRange(ISCIRangeProtocol xRange, bool getPositiveRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithIndexRange:(SCIIndexRange * _Nonnull)xIndexRange;
        [Abstract]
        [Export("getWindowYRangeWithIndexRange:")]
        ISCIRangeProtocol GetWindowYRangeWithIndexRange(SCIIndexRange xIndexRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithIndexRange:(SCIIndexRange * _Nonnull)xIndexRange GetPositiveRange:(BOOL)getPositiveRange;
        [Abstract]
        [Export("getWindowYRangeWithIndexRange:GetPositiveRange:")]
        ISCIRangeProtocol GetWindowYRangeWithIndexRange(SCIIndexRange xIndexRange, bool getPositiveRange);

        // @required -(int)findIndexForValue:(SCIGenericType)x Mode:(SCIArraySearchMode)searchMode;
        [Abstract]
        [Export("findIndexForValue:Mode:")]
        int FindIndexForValue(SCIGenericType x, SCIArraySearchMode searchMode);

        // @required -(void)removeAt:(int)index;
        [Abstract]
        [Export("removeAt:")]
        void RemoveAt(int index);

        // @required -(void)removeValue:(SCIGenericType)value;
        [Abstract]
        [Export("removeValue:")]
        void RemoveValue(SCIGenericType value);

        // @required -(void)removeRangeFrom:(int)startIndex Count:(int)count;
        [Abstract]
        [Export("removeRangeFrom:Count:")]
        void RemoveRangeFrom(int startIndex, int count);

        // @required -(id<SCIDataSeriesProtocol> _Nullable)clone;
        [Abstract]
        [NullAllowed, Export("clone")]
        ISCIDataSeriesProtocol Clone();

        //// @required -(id<SCIPointSeriesProtocol> _Nonnull)toPointSeriesWithResamplingMode:(SCIResamplingMode)resamplingMode SCIIndexRange:(SCIIndexRange * _Nonnull)indexRange ViewportWidth:(int)viewportWidth IsCategoryAxis:(BOOL)isCategoryAxis VisibleRange:(id<SCIRangeProtocol> _Nonnull)visibleRange Resampler:(id<SCIPointResamplerProtocol> _Nonnull)resampler;
        //[Abstract]
        //[Export("toPointSeriesWithResamplingMode:SCIIndexRange:ViewportWidth:IsCategoryAxis:VisibleRange:Resampler:")]
        // TODO Check this with iOS team
        //SCIPointSeriesProtocol ToPointSeriesWithResamplingMode(SCIResamplingMode resamplingMode, SCIIndexRange indexRange, int viewportWidth, bool isCategoryAxis, SCIRangeProtocol visibleRange, SCIPointResamplerProtocol resampler);

        // @required -(double)getYMinAt:(int)index ExistingYMin:(double)existingYMin;
        [Abstract]
        [Export("getYMinAt:ExistingYMin:")]
        double GetYMinAt(int index, double existingYMin);

        // @required -(double)getYMaxAt:(int)index ExistingYMax:(double)existingYMax;
        [Abstract]
        [Export("getYMaxAt:ExistingYMax:")]
        double GetYMaxAt(int index, double existingYMax);
    }
}