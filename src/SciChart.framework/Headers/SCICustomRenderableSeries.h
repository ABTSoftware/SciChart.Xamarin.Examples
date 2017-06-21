//
//  SCICustomRenderableSeries.h
//  SciChart
//
//  Created by Admin on 29/12/16.
//  Copyright © 2016 SciChart. All rights reserved.
//


/** \addtogroup RenderableSeries
 *  @{
 */
#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"

@interface SCICustomRenderableSeries : SCIRenderableSeriesBase

-(SCISeriesInfo*) toSeriesInfoWithHitTest:(SCIHitTestInfo)info;

-(id<SCIHitTestProviderProtocol>) hitTestProvider;

-(UIColor *) seriesColor;

-(void)internalDrawWithContext:(id<SCIRenderContext2DProtocol>)renderContext WithData:(id<SCIRenderPassDataProtocol>)renderPassData;

@end
/** @}*/
