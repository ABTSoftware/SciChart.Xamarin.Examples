//
//  SCIChartModifierBase.h
//  SciChart
//
//  Created by Admin on 04.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIChartModifierProtocol.h"

@protocol SCIChartSurfaceProtocol;
@protocol SCIAxis2DProtocol;
@class SCIAxisCollection;

@interface SCIChartModifierBase : NSObject <SCIChartModifierProtocol>

@end

/** @}*/
