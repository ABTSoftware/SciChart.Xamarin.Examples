//
//  SCIMultiSurfaceModifier.h
//  SciChart
//
//  Created by Admin on 08/07/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIChartModifierProtocol.h"
#import "SCIGestureEventsHandlerProtocol.h"

@interface SCIMultiSurfaceModifier : NSObject <SCIChartModifierProtocol, SCIGestureEventsHandlerProtocol>

-(nonnull instancetype)initWithModifierType:(nonnull Class<SCIChartModifierProtocol, SCIGestureEventsHandlerProtocol>)modifier;
-(nullable id<SCIChartModifierProtocol, SCIGestureEventsHandlerProtocol>)modifierForSurface:(nullable id<SCIChartSurfaceProtocol>)surface;

-(void)disconnectSurface:(nonnull id<SCIChartSurfaceProtocol>)surface;
-(void)disconnectSurfaces;

@end

/** @}*/
