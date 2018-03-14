using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIAxisCoreProtocol { }

	// @protocol SCIAxisCoreProtocol <NSObject, SCIInvalidatableElementProtocol, SCISuspendableProtocol>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SCIAxisCoreProtocol : SCIInvalidatableElementProtocol, SCISuspendableProtocol
    {
        // @required @property (nonatomic, strong) id<SCIRangeProtocol> visibleRange;
        [Abstract]
        [Export("visibleRange", ArgumentSemantic.Strong)]
        ISCIRangeProtocol VisibleRange { get; set; }

        // @required @property (nonatomic, strong) id<SCIRangeProtocol> growBy;
        [Abstract]
        [Export("growBy", ArgumentSemantic.Strong)]
        ISCIRangeProtocol GrowBy { get; set; }

        // @required @property (nonatomic) SCIGenericType minorDelta;
        [Abstract]
        [Export("minorDelta", ArgumentSemantic.Assign)]
        SCIGenericType MinorDelta { get; set; }

        // @required @property (nonatomic) SCIGenericType majorDelta;
        [Abstract]
        [Export("majorDelta", ArgumentSemantic.Assign)]
        SCIGenericType MajorDelta { get; set; }

        // @required -(id<SCIRangeProtocol>)getMaximumRange;
        [Abstract]
        [Export("getMaximumRange")]
        ISCIRangeProtocol MaximumRange { get; }

        // @required @property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;
        [Abstract]
        [Export("parentSurface", ArgumentSemantic.Weak)]
        ISCIChartSurfaceProtocol ParentSurface { get; set; }

        // @required @property (copy, nonatomic) NSString * axisTitle;
        [Abstract]
        [Export("axisTitle")]
        string AxisTitle { get; set; }

        // @required @property (nonatomic) BOOL flipCoordinates;
        [Abstract]
        [Export("flipCoordinates")]
        bool FlipCoordinates { get; set; }

        // @required @property (copy, nonatomic) NSString * textFormatting;
        [Abstract]
        [Export("textFormatting")]
        string TextFormatting { get; set; }

        // @required @property (nonatomic) SCIGenericType minimalZoomConstrain;
        [Abstract]
        [Export("minimalZoomConstrain", ArgumentSemantic.Assign)]
        SCIGenericType MinimalZoomConstrain { get; set; }

        // @required @property (nonatomic) SCIGenericType maximalZoomConstrain;
        [Abstract]
        [Export("maximalZoomConstrain", ArgumentSemantic.Assign)]
        SCIGenericType MaximalZoomConstrain { get; set; }

        // @required @property (nonatomic) int minorsPerMajor;
        [Abstract]
        [Export("minorsPerMajor")]
        int MinorsPerMajor { get; set; }

        // @required @property (nonatomic) int maxAutoTicks;
        [Abstract]
        [Export("maxAutoTicks")]
        int MaxAutoTicks { get; set; }

        // @required @property (nonatomic) BOOL autoTicks;
        [Abstract]
        [Export("autoTicks")]
        bool AutoTicks { get; set; }

        // @required @property (nonatomic, strong) id<SCITickProviderProtocol> tickProvider;
        [Abstract]
        [Export("tickProvider", ArgumentSemantic.Strong)]
        ISCITickProviderProtocol TickProvider { get; set; }

        // @required @property (nonatomic) SCIAutoRange autoRange;
        [Abstract]
        [Export("autoRange", ArgumentSemantic.Assign)]
        SCIAutoRange AutoRange { get; set; }

        // @required @property (copy, nonatomic) NSString * cursorTextFormatting;
        [Abstract]
        [Export("cursorTextFormatting")]
        string CursorTextFormatting { get; set; }

        // @required -(BOOL)isLogarithmicAxis;
        [Abstract]
        [Export("isLogarithmicAxis")]
        bool IsLogarithmicAxis { get; }

        // @required -(BOOL)hasValidVisibleRange;
        [Abstract]
        [Export("hasValidVisibleRange")]
        bool HasValidVisibleRange { get; }

        // @required -(BOOL)hasDefaultVisibleRange;
        [Abstract]
        [Export("hasDefaultVisibleRange")]
        bool HasDefaultVisibleRange { get; }

        // @required @property (nonatomic) BOOL isXAxis;
        [Abstract]
        [Export("isXAxis")]
        bool IsXAxis { get; set; }

        // @required -(void)animateVisibleRangeTo:(id<SCIRangeProtocol>)to AnimationTime:(float)duration;
        [Abstract]
        [Export("animateVisibleRangeTo:AnimationTime:")]
        void AnimateVisibleRangeTo(ISCIRangeProtocol to, float duration);

        // @required -(void)animateVisibleRangeTo:(id<SCIRangeProtocol>)to AnimationTime:(float)duration andVelocity:(float)velocity;
        [Abstract]
        [Export("animateVisibleRangeTo:AnimationTime:andVelocity:")]
        void AnimateVisibleRangeTo(ISCIRangeProtocol to, float duration, float velocity);

        // @required -(void)animateVisibleRangeTo:(id<SCIRangeProtocol>)to AnimationTime:(float)duration velocity:(float)velocity rangeLimit:(id<SCIRangeProtocol>)rangeLimit;
        [Abstract]
        [Export("animateVisibleRangeTo:AnimationTime:velocity:rangeLimit:")]
        void AnimateVisibleRangeTo(ISCIRangeProtocol to, float duration, float velocity, ISCIRangeProtocol rangeLimit);

        // @required @property (nonatomic) BOOL animateVisibleRangeChanges;
        [Abstract]
        [Export("animateVisibleRangeChanges")]
        bool AnimateVisibleRangeChanges { get; set; }

        // @required @property (nonatomic) double animatedChangeDuration;
        [Abstract]
        [Export("animatedChangeDuration")]
        double AnimatedChangeDuration { get; set; }

        // @required -(BOOL)trySetOrAnimateVisibleRange:(id<SCIRangeProtocol>)newRange;
        [Abstract]
        [Export("trySetOrAnimateVisibleRange:")]
        bool TrySetOrAnimateVisibleRange(ISCIRangeProtocol newRange);

        // @required -(BOOL)trySetOrAnimateVisibleRange:(id<SCIRangeProtocol>)newRange duration:(float)duration;
        [Abstract]
        [Export("trySetOrAnimateVisibleRange:duration:")]
        bool TrySetOrAnimateVisibleRange(ISCIRangeProtocol newRange, float duration);

        // @required -(BOOL)isValidRange:(id<SCIRangeProtocol>)range;
        [Abstract]
        [Export("isValidRange:")]
        bool IsValidRange(ISCIRangeProtocol range);

        // @required -(void)validateAxis;
        [Abstract]
        [Export("validateAxis")]
        void ValidateAxis();

        // @required -(id<SCICoordinateCalculatorProtocol>)getCurrentCoordinateCalculator;
        [Abstract]
        [Export("getCurrentCoordinateCalculator")]
        ISCICoordinateCalculatorProtocol CurrentCoordinateCalculator { get; }

        // @required -(double)getAxisSize;
        [Abstract]
        [Export("getAxisSize")]
        double AxisSize { get; }

        // @required -(double)getCoordinate:(SCIGenericType)value;
        [Abstract]
        [Export("getCoordinate:")]
        double GetCoordinate(SCIGenericType value);

        // @required -(SCIGenericType)getDataValue:(double)pixelCoordinate;
        [Abstract]
        [Export("getDataValue:")]
        SCIGenericType GetDataValue(double pixelCoordinate);

        // @required -(double)getAxisOffset;
        [Abstract]
        [Export("getAxisOffset")]
        double AxisOffset { get; }

        // @required -(void)free;
        [Abstract]
        [Export("free")]
        void Free();

        // @required -(id<SCICallbackHelperProtocol>)registerVisibleRangeChangedCallback:(SCIAxisVisibleRangeChanged)callback;
        [Abstract]
        [Export("registerVisibleRangeChangedCallback:")]
        ISCICallbackHelperProtocol RegisterVisibleRangeChangedCallback(SCIAxisVisibleRangeChanged callback);

        // @required @property (nonatomic) UIView * titleCustomView;
        [Abstract]
        [Export("titleCustomView", ArgumentSemantic.Assign)]
        UIView TitleCustomView { get; set; }
    }
}