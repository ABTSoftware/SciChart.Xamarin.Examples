using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIAxisCoreProtocol : INSObjectProtocol { }

    // @protocol SCIAxisCoreProtocol <NSObject, SCIInvalidatableElementProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIAxisCoreProtocol : SCIInvalidatableElementProtocol
    {
        // @property(nonatomic, strong) id <SCIRangeProtocol> visibleRange;
        [Abstract]
        [Export("visibleRange", ArgumentSemantic.Strong)]
        ISCIRangeProtocol VisibleRange { get; set; }

        // @property (nonatomic, strong) id<SCIRangeProtocol> growBy;
        [Abstract]
        [Export("growBy", ArgumentSemantic.Strong)]
        ISCIRangeProtocol GrowBy { get; set; }

        // @property (nonatomic) int minorDelta;
        [Abstract]
        [Export("minorDelta")]
        int MinorDelta { get; set; }

        // @property (nonatomic) int majorDelta;
        [Abstract]
        [Export("majorDelta")]
        int MajorDelta { get; set; }

        // -(id<SCIRangeProtocol>)getMaximumRange;
        [Abstract]
        [Export("getMaximumRange")]
        ISCIRangeProtocol GetMaximumRange();

        // @property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;
        [Abstract]
        [Export("parentSurface", ArgumentSemantic.Weak)]
        ISCIChartSurfaceProtocol ParentSurface { get; set; }

        // @property (copy, nonatomic) NSString *axisTitle;
        [Abstract]
        [Export("axisTitle")]
        string AxisTitle { get; set; }

        // @property (nonatomic) BOOL flipCoordinates;
        [Abstract]
        [Export("flipCoordinates")]
        bool FlipCoordinates { get; set; }

        // @property (copy, nonatomic) NSString *textFormatting;
        [Abstract]
        [Export("textFormatting")]
        string TextFormatting { get; set; }

        // @property(nonatomic) int minorsPerMajor;
        [Abstract]
        [Export("minorsPerMajor")]
        int MinorsPerMajor { get; set; }

        // @property(nonatomic) int maxAutoTicks;
        [Abstract]
        [Export("maxAutoTicks")]
        int MaxAutoTicks { get; set; }

        // @property(nonatomic) BOOL autoTicks;
        [Abstract]
        [Export("autoTicks")]
        bool AutoTicks { get; set; }

        // @property(nonatomic, strong) id<SCITickProviderProtocol> tickProvider;
        [Abstract]
        [Export("tickProvider", ArgumentSemantic.Strong)]
        ISCITickProviderProtocol TickProvider { get; set; }

        // @property(nonatomic) SCIAutoRange autoRange;
        [Abstract]
        [Export("autoRange", ArgumentSemantic.Assign)]
        SCIAutoRange AutoRange { get; set; }

        // @property(nonatomic, copy) NSString* cursorTextFormatting;
        [Abstract]
        [Export("cursorTextFormatting")]
        string CursorTextFormatting { get; set; }

        // - (BOOL)isLogarithmicAxis;
        [Abstract]
        [Export("isLogarithmicAxis")]
        bool IsLogarithmicAxis { get; }

        // - (BOOL)hasValidVisibleRange;
        [Abstract]
        [Export("hasValidVisibleRange")]
        bool HasValidVisibleRange { get; }

        // - (BOOL)hasDefaultVisibleRange;
        [Abstract]
        [Export("hasDefaultVisibleRange")]
        bool HasDefaultVisibleRange { get; }

        // @property(nonatomic) BOOL isXAxis;
        [Abstract]
        [Export("isXAxis")]
        bool IsXAxis { get; set; }

        // - (void)`:(id<SCIRangeProtocol>)to AnimationTime:(float)duration;
        [Abstract]
        [Export("animateVisibleRangeTo:AnimationTime:")]
        void AnimateVisibleRangeTo(ISCIRangeProtocol to, float duration);

        // - (void)animateVisibleRangeTo:(id<SCIRangeProtocol>)to AnimationTime:(float)duration andVelocity:(float)velocity;
        [Abstract]
        [Export("animateVisibleRangeTo:AnimationTime:andVelocity:")]
        void AnimateVisibleRangeTo(ISCIRangeProtocol to, float duration, float velocity);

        // @property(nonatomic) BOOL animateVisibleRangeChanges;
        [Abstract]
        [Export("animateVisibleRangeChanges")]
        bool AnimateVisibleRangeChanges { get; set; }

        // @property(nonatomic) double animatedChangeDuration;
        [Abstract]
        [Export("animatedChangeDuration")]
        double AnimatedChangeDuration { get; set; }

        // - (BOOL)trySetOrAnimateVisibleRange:(id<SCIRangeProtocol>)newRange;
        [Abstract]
        [Export("trySetOrAnimateVisibleRange:")]
        bool TrySetOrAnimateVisibleRange(ISCIRangeProtocol newRange);

        // - (BOOL)trySetOrAnimateVisibleRange:(id<SCIRangeProtocol>)newRange duration:(float)duration;
        [Abstract]
        [Export("trySetOrAnimateVisibleRange:duration:")]
        bool TrySetOrAnimateVisibleRange(ISCIRangeProtocol newRange, float duration);

        // - (BOOL)isValidRange:(id<SCIRangeProtocol>)range;
        [Abstract]
        [Export("isValidRange:")]
        bool IsValidRange(ISCIRangeProtocol range);

        // - (void)validateAxis;
        [Abstract]
        [Export("validateAxis")]
        void ValidateAxis();

        // - (id<SCICoordinateCalculatorProtocol>)getCurrentCoordinateCalculator;
        [Abstract]
        [Export("getCurrentCoordinateCalculator")]
        ISCICoordinateCalculatorProtocol CurrentCoordinateCalculator();

        // - (double)getAxisSize;
        [Abstract]
        [Export("getAxisSize")]
        double AxisSize { get; }

        // - (double)getAxisOffset;
        [Abstract]
        [Export("getAxisOffset")]
        double AxisOffset { get; }

        // - (void)free;
        [Abstract]
        [Export("free")]
        void Free();

        // - (id<SCICallbackHelperProtocol>)registerVisibleRangeChangedCallback:(SCIAxisVisibleRangeChanged)callback;
        [Abstract]
        [Export("registerVisibleRangeChangedCallback:")]
        ISCICallbackHelperProtocol RegisterVisibleRangeChangedCallback(SCIAxisVisibleRangeChanged callback);

        // @property(nonatomic) UIView* titleCustomView;
        [Abstract]
        [Export("titleCustomView")]
        UIView TitleCustomView { get; set; }

        // Bounded in Extras
        // @property(nonatomic) SCIGenericType minimalZoomConstrain;

        // Bounded in Extras
        // @property(nonatomic) SCIGenericType maximalZoomConstrain;
        
        // Bounded in Extras
        // - (double)getCoordinate:(SCIGenericType)value;

        // Bounded in Extras
        // - (SCIGenericType)getDataValue:(double)pixelCoordinate;
    }
}