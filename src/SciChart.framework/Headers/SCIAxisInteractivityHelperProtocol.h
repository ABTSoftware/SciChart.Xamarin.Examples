/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIEnumerationConstants.h"

@protocol SCIRangeProtocol;

#pragma mark - SCIAxisInteractivityHelper protocol

/**
 *
 */
@protocol SCIAxisInteractivityHelperProtocol ///
        <NSObject>
/** @{ @} */

- (id <SCIRangeProtocol>)zoom:(id <SCIRangeProtocol>)initialRange From:(double)fromCoord To:(double)toCoord;

- (id <SCIRangeProtocol>)zoom:(id <SCIRangeProtocol>)initialRange ByMin:(double)minFraction Max:(double)maxFraction;

- (id <SCIRangeProtocol>)scrollInMinDirection:(id <SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels;

- (id <SCIRangeProtocol>)scrollInMaxDirection:(id <SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels;

- (id <SCIRangeProtocol>)scroll:(id <SCIRangeProtocol>)rangeToScroll ForPixels:(double)pixels AndVelocity:(float *)velocity;

- (id <SCIRangeProtocol>)clipRange:(id <SCIRangeProtocol>)rangeToClip ToMaximum:(id <SCIRangeProtocol>)maximumRange ClipMode:(SCIClipMode)clipMode;

@end