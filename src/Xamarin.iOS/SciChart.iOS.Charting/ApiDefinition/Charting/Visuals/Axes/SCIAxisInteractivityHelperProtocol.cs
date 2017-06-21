using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIAxisInteractivityHelperProtocol : INSObjectProtocol { }

    // @protocol SCIAxisInteractivityHelperProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIAxisInteractivityHelperProtocol
    {
        // - (id <SCIRangeProtocol>)zoom:(id <SCIRangeProtocol>)initialRange From:(double)fromCoord To:(double)toCoord;
        [Abstract]
        [Export("zoom:From:To:")]
        ISCIRangeProtocol Zoom(ISCIRangeProtocol initialRange, double fromCoord, double toCoord);

        // - (id <SCIRangeProtocol>)zoom:(id <SCIRangeProtocol>)initialRange ByMin:(double)minFraction Max:(double)maxFraction;
        [Abstract]
        [Export("zoom:ByMin:Max:")]
        ISCIRangeProtocol ZoomBy(ISCIRangeProtocol initialRange, double minFraction, double maxFraction);
        
        // - (id <SCIRangeProtocol>)scrollInMinDirection:(id <SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels;
        [Abstract]
        [Export("scrollInMinDirection:ForPixels:")]
        ISCIRangeProtocol ScrollInMinDirection(ISCIRangeProtocol rangeToScroll, double pixels);

        // - (id <SCIRangeProtocol>)scrollInMaxDirection:(id <SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels;
        [Abstract]
        [Export("scrollInMaxDirection:ForPixels:")]
        ISCIRangeProtocol ScrollInMaxDirection(ISCIRangeProtocol rangeToScroll, double pixels);

        // - (id <SCIRangeProtocol>)scroll:(id <SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels AndVelocity:(float *)velocity;
        [Abstract]
        [Export("scroll:ForPixels:AndVelocity:")]
        ISCIRangeProtocol Scroll(ISCIRangeProtocol rangeToScroll, double pixels, float velocity);

        // - (id <SCIRangeProtocol>)clipRange:(id <SCIRangeProtocol>)rangeToClip ToMaximum:(id <SCIRangeProtocol>)maximumRange ClipMode:(SCIClipMode)clipMode;
        [Abstract]
        [Export("clipRange:ToMaximum:ClipMode:")]
        ISCIRangeProtocol ClipRange(ISCIRangeProtocol rangeToClip, ISCIRangeProtocol maximumRange, SCIClipMode clipMode);
    }
}