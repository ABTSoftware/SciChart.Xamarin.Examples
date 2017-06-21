using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIAxis2DProtocol  { }

    // @protocol SCIAxis2DProtocol <NSObject, SCIAxisCoreProtocol, SCIDrawableProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIAxis2DProtocol : SCIAxisCoreProtocol, SCIDrawableProtocol
    {
        // @property(nonatomic, copy) NSString* axisId;
        [Abstract]
        [Export("axisId")]
        string AxisId { get; set; }

        // - (id<SCIRangeProtocol>)getDataRange;
        [Abstract]
        [Export("getDataRange")]
        ISCIRangeProtocol GetDataRange();

        // @property(nonatomic, strong) id<SCILabelProviderProtocol> labelProvider;
        [Abstract]
        [Export("labelProvider", ArgumentSemantic.Strong)]
        ISCILabelProviderProtocol LabelProvider { get; set; }

        // - (BOOL)isHorizontalAxis;
        [Abstract]
        [Export("isHorizontalAxis")]
        bool IsHorizontalAxis { get; }

        // @property(nonatomic) BOOL isStaticAxis;
        [Abstract]
        [Export("isStaticAxis")]
        bool IsStaticAxis { get; set; }

        // @property(nonatomic) SCIAxisAlignment axisAlignment;
        [Abstract]
        [Export("axisAlignment", ArgumentSemantic.Assign)]
        SCIAxisAlignment AxisAlignment { get; set; }

        // TODO should be an event
        // @property(nonatomic, copy) SCIActionBlock onAxisAlignmentChanged;
        [Abstract]
        [Export("onAxisAlignmentChanged")]
        int OnAxisAlignmentChanged { get; set; }

        // - (BOOL)isCategoryAxis;
        [Abstract]
        [Export("isCategoryAxis")]
        bool IsCategoryAxis { get; }

        // - (BOOL)isPolarAxis;
        [Abstract]
        [Export("isPolarAxis")]
        bool IsPolarAxis { get; }

        // @property(nonatomic) BOOL isCenterAxis;
        [Abstract]
        [Export("isCenterAxis")]
        bool IsCenterAxis { get; }

        // @property(nonatomic) BOOL isPrimaryAxis;
        [Abstract]
        [Export("isPrimaryAxis")]
        bool IsPrimaryAxis { get; set; }

        // @property(nonatomic) BOOL isVisible;
        [Abstract]
        [Export("isVisible")]
        bool IsVisible { get; set; }

        // - (BOOL)isAxisFlipped;
        [Abstract]
        [Export("isAxisFlipped")]
        bool IsAxisFlipped { get; }        
        
        // @property(nonatomic, strong) id<SCIRangeProtocol> visibleRangeLimit;
        [Abstract]
        [Export("visibleRangeLimit", ArgumentSemantic.Strong)]
        ISCIRangeProtocol VisibleRangeLimit { get; set; }

        // @property(nonatomic) SCIRangeClipMode visibleRangeLimitMode;
        [Abstract]
        [Export("visibleRangeLimitMode")]
        SCIRangeClipMode VisibleRangeLimitMode { get; set; }

        // @property(nonatomic) BOOL isLabelCullingEnabled;
        [Abstract]
        [Export("isLabelCullingEnabled")]
        bool IsLabelCullingEnabled { get; set; }

        // - (id<SCIAxisInteractivityHelperProtocol>)getCurrentInteractivityHelper;
        [Abstract]
        [Export("getCurrentInteractivityHelper")]
        ISCIAxisInteractivityHelperProtocol GetCurrentInteractivityHelper();

        // - (id<SCIRangeProtocol>)calculateYRangeWithRenderPassInfo:(SCIRenderPassInfo*)renderPassInfo;
        [Abstract]
        [Export("calculateYRangeWithRenderPassInfo:")]
        ISCIRangeProtocol CalculateYRangeWithRenderPassInfo(SCIRenderPassInfo renderPassInfo);

        //TODO Wrap NSDictionary with c# Dictionary
        // - (id<SCIRangeProtocol>)getWindowedYRangeWithXRanges:(NSDictionary*)xRanges;
        [Abstract]
        [Export("getWindowedYRangeWithXRanges:")]
        ISCIRangeProtocol GetWindowedYRangeWithXRanges(NSDictionary xRanges);

        // - (void)onBeginRenderPass;
        [Abstract]
        [Export("onBeginRenderPass")]
        void OnBeginRenderPass();
        
        // - (void)scrollByPixels:(double)pixelsToScroll ClipMode:(SCIClipMode)clipMode;
        [Abstract]
        [Export("scrollByPixels:ClipMode:")]
        void ScrollByPixels(double pixelsToScroll, SCIClipMode clipMode);

        // - (void)scrollByPixels:(double)pixelsToScroll ClipMode:(SCIClipMode)clipMode AnimationTime:(float)duration Velocity:(float)velocity;
        [Abstract]
        [Export("scrollByPixels:ClipMode:AnimationTime:Velocity:")]
        void ScrollByPixels(double pixelsToScroll, SCIClipMode clipMode, float duration, float velocity);

        // - (void)scrollByDataPoints:(int)pointAmount;
        [Abstract]
        [Export("scrollByDataPoints:")]
        void ScrollByDataPoints(int pointAmount);

        // - (void)scrollByDataPoints:(int)pointAmount AnimationTime:(float)duration;
        [Abstract]
        [Export("scrollByDataPoints:AnimationTime:")]
        void ScrollByDataPoints(int pointAmount, float duration);

        // - (void)zoomFrom:(double)fromCoord To:(double)toCoord;
        [Abstract]
        [Export("zoomFrom:To:")]
        void ZoomFrom(double fromCoord, double toCoord);

        // - (void)zoomFrom:(double)fromCoord To:(double)toCoord AnimationTime:(float)duration;
        [Abstract]
        [Export("zoomFrom:To:AnimationTime:")]
        void ZoomFrom(double fromCoord, double toCoord, float duration);

        // - (void)zoomByFractionMin:(double)minFraction Max:(double)maxFraction;
        [Abstract]
        [Export("zoomByFractionMin:Max:")]
        void ZoomByFractionMin(double minFraction, double maxFraction);

        // - (void)zoomByFractionMin:(double)minFraction Max:(double)maxFraction AnimationTime:(float)duration;
        [Abstract]
        [Export("zoomByFractionMin:Max:AnimationTime:")]
        void ZoomByFractionMin(double minFraction, double maxFraction, float duration);

        // - (void)scrollToPixels:(double)pixelsToScroll WithVisibleRange:(id<SCIRangeProtocol>)startVisibleRange WithLimit:(id<SCIRangeProtocol>)rangeLimit;
        [Abstract]
        [Export("scrollToPixels:WithVisibleRange:WithLimit:")]
        void ScrollToPixels(double pixelsToScroll, ISCIRangeProtocol startVisibleRange, ISCIRangeProtocol rangeLimit);

        // - (void)assertDataType:(SCIDataType)type;
        [Abstract]
        [Export("assertDataType:")]
        void AssertDataType(SCIDataType type);

        // - (void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // - (id<SCIRangeProtocol>)getUndefinedRange;
        [Abstract]
        [Export("getUndefinedRange")]
        ISCIRangeProtocol GetUndefinedRange();

        // - (id<SCIRangeProtocol>)getDefaultNonZeroRange;
        [Abstract]
        [Export("getDefaultNonZeroRange")]
        ISCIRangeProtocol GetDefaultNonZeroRange();

        // TODO ADD SCIAxisPanelProtocol binding
        // - (id<SCIAxisPanelProtocol>)axisPanel;
        // [Abstract]
        // [Export("axisPanel:"]
        // SCIAxisPanelProtocol AxisPanel { get; }

        // @property(nonatomic, copy) SCIAxisStyle* style;
        [Abstract]
        [Export("style", ArgumentSemantic.Copy)]
        SCIAxisStyle Style { get; set; }

        // - (SCIAxisHitTestProvider*)hitTestProvider;
        [Abstract]
        [Export("hitTestProvider")]
        SCIAxisHitTestProvider HitTestProvider { get; }
        
        // - (CGRect)frame;
        [Abstract]
        [Export("frame")]
        CGRect Frame { get; }
        
        // - (BOOL)isPointWithinBounds:(CGPoint)point;
        [Abstract]
        [Export("isPointWithinBounds:")]
        bool IsPointWithinBounds(CGPoint point);

        // Bounded in Extras
        // - (NSString*)formatText:(SCIGenericType)value;

        // Bounded in Extras
        // - (NSString*)formatCursorText:(SCIGenericType)value;
    }
}