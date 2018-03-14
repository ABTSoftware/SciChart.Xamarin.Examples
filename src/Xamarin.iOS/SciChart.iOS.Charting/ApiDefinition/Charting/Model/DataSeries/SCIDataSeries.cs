﻿using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIDataSeries : NSObject <SCIDataSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDataSeries : SCIDataSeriesProtocol
    {
        // -(id _Nonnull)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType;
        [Export("initWithXType:YType:")]
        IntPtr Constructor(SCIDataType xType, SCIDataType yType);

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> _Nonnull xColumn;
        [Export("xColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol XColumn { get; set; }

        // @property (nonatomic, strong) id<SCIArrayControllerProtocol> _Nonnull yColumn;
        [Export("yColumn", ArgumentSemantic.Strong)]
        SCIArrayControllerProtocol YColumn { get; set; }

        // @property (nonatomic, strong) id<SCIDataDistributionCalculatorProtocol> _Nullable dataDistributionCalculator;
        [NullAllowed, Export("dataDistributionCalculator", ArgumentSemantic.Strong)]
        ISCIDataDistributionCalculatorProtocol DataDistributionCalculator { get; set; }

        // -(void)dataSeriesChanged;
        [Export("dataSeriesChanged")]
        void DataSeriesChanged();

        // -(void)clearColumns;
        [Export("clearColumns")]
        void ClearColumns();
    }

    // @interface XColumnEvents (SCIDataSeries)
    [Category]
    [BaseType(typeof(SCIDataSeries))]
    interface SCIDataSeries_XColumnEvents
    {
        // -(void)onUpdateXColumnAtIndex:(int)atIndex;
        [Export("onUpdateXColumnAtIndex:")]
        void OnUpdateXColumnAtIndex(int atIndex);

        // -(void)onAppendXColumnWithPreviousCount:(int)previousCount;
        [Export("onAppendXColumnWithPreviousCount:")]
        void OnAppendXColumnWithPreviousCount(int previousCount);

        // -(void)onInsertXColumnWithPreviousCount:(int)previousCount atIndex:(int)atIndex;
        [Export("onInsertXColumnWithPreviousCount:atIndex:")]
        void OnInsertXColumnWithPreviousCount(int previousCount, int atIndex);
    }
}