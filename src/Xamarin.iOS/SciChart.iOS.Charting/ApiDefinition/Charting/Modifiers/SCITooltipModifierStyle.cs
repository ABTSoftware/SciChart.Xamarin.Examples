using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCITooltipModifierStyle : NSObject <SCITooltipModifierStyleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCITooltipModifierStyle : SCITooltipModifierStyleProtocol
    {
        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> targetMarker;
        [Export("targetMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol TargetMarker { get; set; }

        // @property (nonatomic) SCITooltipTargetOffsetMode targetOffsetMode;
        [Export("targetOffsetMode", ArgumentSemantic.Assign)]
        SCITooltipTargetOffsetMode TargetOffsetMode { get; set; }

        // @property (nonatomic) float targetOffsetValue;
        [Export("targetOffsetValue")]
        float TargetOffsetValue { get; set; }

        // @property (nonatomic) CGPoint targetCustomOffset;
        [Export("targetCustomOffset", ArgumentSemantic.Assign)]
        CGPoint TargetCustomOffset { get; set; }
    }
}