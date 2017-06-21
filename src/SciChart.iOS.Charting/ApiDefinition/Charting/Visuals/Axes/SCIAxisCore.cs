using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisCore : NSObject <SCIAxisCoreProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIAxisCore : SCIAxisCoreProtocol
    {
        // @property (nonatomic, strong) id<SCITickCoordinatesProviderProtocol> tickCoordinatesProvider;
        [Export("tickCoordinatesProvider", ArgumentSemantic.Strong)]
        ISCITickCoordinatesProviderProtocol TickCoordinatesProvider { get; set; }

        // @property (nonatomic) BOOL isStaticAxis;
        [Export("isStaticAxis")]
        bool IsStaticAxis { get; set; }

        // @property (nonatomic, strong) id<SCILabelProviderProtocol> labelProvider;
        [Export("labelProvider", ArgumentSemantic.Strong)]
        ISCILabelProviderProtocol LabelProvider { get; set; }

        // -(BOOL)isCategoryAxis;
        [Export("isCategoryAxis")]
        bool IsCategoryAxis { get; }

        // -(id<SCIRangeProtocol>)getUndefinedRange;
        [Export("getUndefinedRange")]
        ISCIRangeProtocol UndefinedRange();

        // -(id<SCIRangeProtocol>)getDefaultNonZeroRange;
        [Export("getDefaultNonZeroRange")]
        ISCIRangeProtocol DefaultNonZeroRange();

        // -(BOOL)isRangeOfValidType:(id<SCIRangeProtocol>)range;
        [Export("isRangeOfValidType:")]
        bool IsRangeOfValidType(ISCIRangeProtocol range);

        // -(void)coerceVisibleRange;
        [Export("coerceVisibleRange")]
        void CoerceVisibleRange();

        // -(BOOL)isVisibleRangeValid;
        [Export("isVisibleRangeValid")]
        bool IsVisibleRangeValid { get; }

        // -(SCITickCoordinates *)CalculateTicks;
        [Export("CalculateTicks")]
        SCITickCoordinates CalculateTicks { get; }

        // -(void)calculateDelta;
        [Export("calculateDelta")]
        void CalculateDelta();

        // -(id<SCIDeltaCalculatorProtocol>)getDeltaCalculator;
        [Export("getDeltaCalculator")]
        ISCIDeltaCalculatorProtocol DeltaCalculator { get; }

        // -(uint)getMaxAutoTicks;
        [Export("getMaxAutoTicks")]
        uint getMaxAutoTicks();

        // -(void)assertRangeType:(id<SCIRangeProtocol>)range;
        [Export("assertRangeType:")]
        void AssertRangeType(ISCIRangeProtocol range);
    }
}