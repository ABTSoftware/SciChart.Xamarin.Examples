using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIAxis2DProtocol { }

    // @protocol SCIAxis2DProtocol <NSObject, SCIAxisCoreProtocol, SCIDrawableProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    // TODO check properties like IsPolar etc... they should be readonly on the obj-c side as well as in xamarin.
    interface SCIAxis2DProtocol : SCIAxisCoreProtocol, SCIDrawableProtocol
    {
        // @required @property (copy, nonatomic) NSString * axisId;
        [Abstract]
        [Export("axisId")]
        string AxisId { get; set; }

        // @required -(id<SCIRangeProtocol>)getDataRange;
        [Abstract]
        [Export("getDataRange")]
        ISCIRangeProtocol GetDataRange();

        // @required @property (nonatomic, strong) id<SCILabelProviderProtocol> labelProvider;
        [Abstract]
        [Export("labelProvider", ArgumentSemantic.Strong)]
        ISCILabelProviderProtocol LabelProvider { get; set; }

        // @required -(BOOL)isHorizontalAxis;
        [Abstract]
        [Export("isHorizontalAxis")]
        bool IsHorizontalAxis { get; }

        // @required @property (nonatomic) BOOL isStaticAxis;
        [Abstract]
        [Export("isStaticAxis")]
        bool IsStaticAxis { get; set; }

        // @required @property (nonatomic) SCIAxisAlignment axisAlignment;
        [Abstract]
        [Export("axisAlignment", ArgumentSemantic.Assign)]
        SCIAxisAlignment AxisAlignment { get; set; }

        // @required @property (copy, nonatomic) SCIActionBlock onAxisAlignmentChanged;
        [Abstract]
        [Export("onAxisAlignmentChanged", ArgumentSemantic.Copy)]
        // TODO discuss with team, might be an event
        SCIActionBlock OnAxisAlignmentChanged { get; set; }

        // @required -(BOOL)isCategoryAxis;
        [Abstract]
        [Export("isCategoryAxis")]
        bool IsCategoryAxis { get; }

        // @required -(BOOL)isPolarAxis;
        [Abstract]
        [Export("isPolarAxis")]
        bool IsPolarAxis { get; }

        // @required @property (nonatomic) BOOL isCenterAxis;
        [Abstract]
        [Export("isCenterAxis")]
        bool IsCenterAxis { get; set; }

        // @required @property (nonatomic) BOOL isPrimaryAxis;
        [Abstract]
        [Export("isPrimaryAxis")]
        bool IsPrimaryAxis { get; set; }

        // @required @property (nonatomic) BOOL isVisible;
        [Abstract]
        [Export("isVisible")]
        bool IsVisible { get; set; }

        // @required -(BOOL)isAxisFlipped;
        [Abstract]
        [Export("isAxisFlipped")]
        bool IsAxisFlipped { get; }

        // @required @property (nonatomic, strong) id<SCIRangeProtocol> visibleRangeLimit;
        [Abstract]
        [Export("visibleRangeLimit", ArgumentSemantic.Strong)]
        ISCIRangeProtocol VisibleRangeLimit { get; set; }

        // @required @property (nonatomic) SCIRangeClipMode visibleRangeLimitMode;
        [Abstract]
        [Export("visibleRangeLimitMode", ArgumentSemantic.Assign)]
        SCIRangeClipMode VisibleRangeLimitMode { get; set; }

        // @required @property (nonatomic) BOOL isLabelCullingEnabled;
        [Abstract]
        [Export("isLabelCullingEnabled")]
        bool IsLabelCullingEnabled { get; set; }

        // @required -(id<SCIAxisInteractivityHelperProtocol>)getCurrentInteractivityHelper;
        [Abstract]
        [Export("getCurrentInteractivityHelper")]
        ISCIAxisInteractivityHelperProtocol GetCurrentInteractivityHelper();

        // @required -(id<SCIRangeProtocol>)calculateYRangeWithRenderPassInfo:(SCIRenderPassInfo *)renderPassInfo;
        [Abstract]
        [Export("calculateYRangeWithRenderPassInfo:")]
        ISCIRangeProtocol CalculateYRangeWithRenderPassInfo(SCIRenderPassInfo renderPassInfo);

        // @required -(id<SCIRangeProtocol>)getWindowedYRangeWithXRanges:(NSDictionary *)xRanges;
        [Abstract]
        [Export("getWindowedYRangeWithXRanges:")]
        ISCIRangeProtocol GetWindowedYRangeWithXRanges(NSDictionary xRanges);

        // @required -(void)onBeginRenderPass;
        [Abstract]
        [Export("onBeginRenderPass")]
        void OnBeginRenderPass();

        // @required -(void)scrollByPixels:(double)pixelsToScroll ClipMode:(SCIClipMode)clipMode;
        [Abstract]
        [Export("scrollByPixels:ClipMode:")]
        void ScrollByPixels(double pixelsToScroll, SCIClipMode clipMode);

        // @required -(void)scrollByPixels:(double)pixelsToScroll ClipMode:(SCIClipMode)clipMode AnimationTime:(float)duration Velocity:(float)velocity;
        [Abstract]
        [Export("scrollByPixels:ClipMode:AnimationTime:Velocity:")]
        void ScrollByPixels(double pixelsToScroll, SCIClipMode clipMode, float duration, float velocity);

        // @required -(void)scrollByDataPoints:(int)pointAmount;
        [Abstract]
        [Export("scrollByDataPoints:")]
        void ScrollByDataPoints(int pointAmount);

        // @required -(void)scrollByDataPoints:(int)pointAmount AnimationTime:(float)duration;
        [Abstract]
        [Export("scrollByDataPoints:AnimationTime:")]
        void ScrollByDataPoints(int pointAmount, float duration);

        // @required -(void)zoomFrom:(double)fromCoord To:(double)toCoord;
        [Abstract]
        [Export("zoomFrom:To:")]
        void ZoomFrom(double fromCoord, double toCoord);

        // @required -(void)zoomFrom:(double)fromCoord To:(double)toCoord AnimationTime:(float)duration;
        [Abstract]
        [Export("zoomFrom:To:AnimationTime:")]
        void ZoomFrom(double fromCoord, double toCoord, float duration);

        // @required -(void)zoomByFractionMin:(double)minFraction Max:(double)maxFraction;
        [Abstract]
        [Export("zoomByFractionMin:Max:")]
        void ZoomByFractionMin(double minFraction, double maxFraction);

        // @required -(void)zoomByFractionMin:(double)minFraction Max:(double)maxFraction AnimationTime:(float)duration;
        [Abstract]
        [Export("zoomByFractionMin:Max:AnimationTime:")]
        void ZoomByFractionMin(double minFraction, double maxFraction, float duration);

        // @required -(void)scrollToPixels:(double)pixelsToScroll WithVisibleRange:(id<SCIRangeProtocol>)startVisibleRange WithLimit:(id<SCIRangeProtocol>)rangeLimit;
        [Abstract]
        [Export("scrollToPixels:WithVisibleRange:WithLimit:")]
        void ScrollToPixels(double pixelsToScroll, ISCIRangeProtocol startVisibleRange, ISCIRangeProtocol rangeLimit);

        // @required -(void)assertDataType:(SCIDataType)type;
        [Abstract]
        [Export("assertDataType:")]
        void AssertDataType(SCIDataType type);

        // @required -(NSString *)formatText:(SCIGenericType)value;
        [Abstract]
        [Export("formatText:")]
        string FormatText(SCIGenericType value);

        // @required -(NSString *)formatCursorText:(SCIGenericType)value;
        [Abstract]
        [Export("formatCursorText:")]
        string FormatCursorText(SCIGenericType value);

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // @required -(id<SCIRangeProtocol>)getUndefinedRange;
        [Abstract]
        [Export("getUndefinedRange")]
        ISCIRangeProtocol UndefinedRange { get; }

        // @required -(id<SCIRangeProtocol>)getDefaultNonZeroRange;
        [Abstract]
        [Export("getDefaultNonZeroRange")]
        ISCIRangeProtocol DefaultNonZeroRange { get; }

        // TODO Add bindings for SCIAxisPanelProtocol
        //// @required -(id<SCIAxisPanelProtocol>)axisPanel;
        //[Abstract]
        //[Export("axisPanel")]
        //SCIAxisPanelProtocol AxisPanel { get; }

        // @required @property (copy, nonatomic) SCIAxisStyle * style;
        [Abstract]
        [Export("style", ArgumentSemantic.Copy)]
        SCIAxisStyle Style { get; set; }

        // @required -(SCIAxisHitTestProvider *)hitTestProvider;
        [Abstract]
        [Export("hitTestProvider")]
        SCIAxisHitTestProvider HitTestProvider { get; }

        // @required -(CGRect)frame;
        [Abstract]
        [Export("frame")]
        CGRect Frame { get; }

        // @required -(BOOL)isPointWithinBounds:(CGPoint)point;
        [Abstract]
        [Export("isPointWithinBounds:")]
        bool IsPointWithinBounds(CGPoint point);
    }
}