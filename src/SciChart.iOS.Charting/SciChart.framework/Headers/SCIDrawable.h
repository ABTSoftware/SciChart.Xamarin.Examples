//
//  SCIDrawable.h
//  SciChart
//
//  Created by Admin on 14.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Visuals
 *  @{
 */

@protocol SCIRenderContext2DProtocol;
@protocol SCIRenderPassDataProtocol;

/**
 */
@protocol SCIDrawableProtocol ///
<NSObject>
/** @{ @} */

@required
-(void) onDrawWithContext:(id<SCIRenderContext2DProtocol>)renderContext WithData:(id<SCIRenderPassDataProtocol>)renderPassData;
-(void) prepareForDrawing;

@end

/** @}*/