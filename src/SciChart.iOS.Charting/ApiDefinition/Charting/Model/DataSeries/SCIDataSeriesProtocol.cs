using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIDataSeriesProtocol : INSObjectProtocol { }

    // @protocol SCIDataSeriesProtocol <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface SCIDataSeriesProtocol
    {
        // @optional @property (nonatomic) int fifoCapacity;
        [Export ("fifoCapacity")]
        int FifoCapacity { get; set; }

        // @optional @property (nonatomic) BOOL acceptUnsortedData;
        [Export ("acceptUnsortedData")]
        bool AcceptUnsortedData { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable seriesName;
        [Abstract]
        [NullAllowed, Export ("seriesName")]
        string SeriesName { get; set; }

        // @required @property (nonatomic, strong) id<SCIPointSeriesProtocol> _Nullable lastPointSeries;
        [Abstract]
        [NullAllowed, Export ("lastPointSeries", ArgumentSemantic.Strong)]
        SCIPointSeriesProtocol LastPointSeries { get; set; }

        // @required @property (copy, nonatomic) SCIActionBlock _Nullable onDataSeriesChanged;
        [Abstract]
        [NullAllowed, Export ("onDataSeriesChanged", ArgumentSemantic.Copy)]
        SCIActionBlock OnDataSeriesChanged { get; set; }

        // @required -(SCIDataType)xType;
        [Abstract]
        [Export ("xType")]
        SCIDataType XType { get; }

        // @required -(SCIDataType)yType;
        [Abstract]
        [Export ("yType")]
        SCIDataType YType { get; }

        // @required -(id<SCIRangeProtocol> _Nonnull)getXRange;
        [Abstract]
        [Export ("getXRange")]
        ISCIRangeProtocol XRange { get; }

        // @required -(id<SCIRangeProtocol> _Nonnull)getYRange;
        [Abstract]
        [Export ("getYRange")]
        ISCIRangeProtocol YRange { get; }

        // @required -(SCIDataSeriesType)dataSeriesType;
        [Abstract]
        [Export ("dataSeriesType")]
        SCIDataSeriesType DataSeriesType { get; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)xValues;
        [Abstract]
        [Export ("xValues")]
        SCIArrayControllerProtocol XValues { get; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)yValues;
        [Abstract]
        [Export ("yValues")]
        SCIArrayControllerProtocol YValues { get; }

        // @required -(BOOL)hasValues;
        [Abstract]
        [Export ("hasValues")]
        bool HasValues { get; }

        // @required -(int)count;
        [Abstract]
        [Export ("count")]
        int Count { get; }

        // @required -(BOOL)isSorted;
        [Abstract]
        [Export ("isSorted")]
        bool IsSorted { get; }

        // @required -(BOOL)isFifo;
        [Abstract]
        [Export ("isFifo")]
        bool IsFifo { get; }

        // @required -(void)clear;
        [Abstract]
        [Export ("clear")]
        void Clear ();

        // @required -(SCIIndexRange * _Nonnull)getIndicesRangeWithVisibleRange:(id<SCIRangeProtocol> _Nonnull)visibleRange;
        [Abstract]
        [Export ("getIndicesRangeWithVisibleRange:")]
        SCIIndexRange GetIndicesRangeWithVisibleRange (SCIRangeProtocol visibleRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithXRange:(id<SCIRangeProtocol> _Nonnull)xRange;
        [Abstract]
        [Export ("getWindowYRangeWithXRange:")]
        SCIRangeProtocol GetWindowYRangeWithXRange (SCIRangeProtocol xRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithXRange:(id<SCIRangeProtocol> _Nonnull)xRange GetPositiveRange:(BOOL)getPositiveRange;
        [Abstract]
        [Export ("getWindowYRangeWithXRange:GetPositiveRange:")]
        SCIRangeProtocol GetWindowYRangeWithXRange (SCIRangeProtocol xRange, bool getPositiveRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithIndexRange:(SCIIndexRange * _Nonnull)xIndexRange;
        [Abstract]
        [Export ("getWindowYRangeWithIndexRange:")]
        SCIRangeProtocol GetWindowYRangeWithIndexRange (SCIIndexRange xIndexRange);

        // @required -(id<SCIRangeProtocol> _Nonnull)getWindowYRangeWithIndexRange:(SCIIndexRange * _Nonnull)xIndexRange GetPositiveRange:(BOOL)getPositiveRange;
        [Abstract]
        [Export ("getWindowYRangeWithIndexRange:GetPositiveRange:")]
        SCIRangeProtocol GetWindowYRangeWithIndexRange (SCIIndexRange xIndexRange, bool getPositiveRange);

        // @required -(void)removeAt:(int)index;
        [Abstract]
        [Export ("removeAt:")]
        void RemoveAt (int index);

        // @required -(void)removeRangeFrom:(int)startIndex Count:(int)count;
        [Abstract]
        [Export ("removeRangeFrom:Count:")]
        void RemoveRangeFrom (int startIndex, int count);

        // @required -(id<SCIDataSeriesProtocol> _Nullable)clone;
        [Abstract]
        [NullAllowed, Export("clone")]
        SCIDataSeriesProtocol Clone();

        // @required -(double)getYMinAt:(int)index ExistingYMin:(double)existingYMin;
        [Abstract]
        [Export ("getYMinAt:ExistingYMin:")]
        double GetYMinAt (int index, double existingYMin);

        // @required -(double)getYMaxAt:(int)index ExistingYMax:(double)existingYMax;
        [Abstract]
        [Export ("getYMaxAt:ExistingYMax:")]
        double GetYMaxAt (int index, double existingYMax);

        // @required -(SCIGenericType)YMin;
        // @required -(SCIGenericType)YMax;
        // @required -(SCIGenericType)XMin;
        // @required -(SCIGenericType)XMax;
        // @required -(int)findIndexForValue:(SCIGenericType)x Mode:(SCIArraySearchMde)searchMode;
        // @required -(void)removeValue:(SCIGenericType)value;
        // @required -(id<SCIPointSeriesProtocol> _Nonnull)toPointSeriesWithResamplingMode:(SCIResamplingMode)resamplingMode SCIIndexRange:(SCIIndexRange * _Nonnull)indexRange ViewportWidth:(int)viewportWidth IsCategoryAxis:(BOOL)isCategoryAxis VisibleRange:(id<SCIRangeProtocol> _Nonnull)visibleRange Resampler:(id<SCIPointResamplerProtocol> _Nonmpler;
    }
}