using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIAxisInteractivityHelperProtocol { }

    // @protocol SCIAxisInteractivityHelperProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIAxisInteractivityHelperProtocol
    {
        // @required -(id<SCIRangeProtocol>)zoom:(id<SCIRangeProtocol>)initialRange From:(double)fromCoord To:(double)toCoord;
        [Abstract]
        [Export("zoom:From:To:")]
        ISCIRangeProtocol Zoom(ISCIRangeProtocol initialRange, double fromCoord, double toCoord);

        // @required -(id<SCIRangeProtocol>)zoom:(id<SCIRangeProtocol>)initialRange ByMin:(double)minFraction Max:(double)maxFraction;
        [Abstract]
        [Export("zoom:ByMin:Max:")]
        ISCIRangeProtocol ZoomBy(ISCIRangeProtocol initialRange, double minFraction, double maxFraction);

        // @required -(id<SCIRangeProtocol>)scrollInMinDirection:(id<SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels;
        [Abstract]
        [Export("scrollInMinDirection:ForPixels:")]
        ISCIRangeProtocol ScrollInMinDirection(ISCIRangeProtocol rangeToScroll, double pixels);

        // @required -(id<SCIRangeProtocol>)scrollInMaxDirection:(id<SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels;
        [Abstract]
        [Export("scrollInMaxDirection:ForPixels:")]
        ISCIRangeProtocol ScrollInMaxDirection(ISCIRangeProtocol rangeToScroll, double pixels);

        // @required -(id<SCIRangeProtocol>)scroll:(id<SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels AndVelocity:(float *)velocity;
        [Abstract]
        [Export("scroll:ForPixels:AndVelocity:")]
        ISCIRangeProtocol Scroll(ISCIRangeProtocol rangeToScroll, double pixels, float velocity);

        // @required -(id<SCIRangeProtocol>)clipRange:(id<SCIRangeProtocol>)rangeToClip ToMaximum:(id<SCIRangeProtocol>)maximumRange ClipMode:(SCIClipMode)clipMode;
        [Abstract]
        [Export("clipRange:ToMaximum:ClipMode:")]
        ISCIRangeProtocol ClipRange(ISCIRangeProtocol rangeToClip, ISCIRangeProtocol maximumRange, SCIClipMode clipMode);
    }
}