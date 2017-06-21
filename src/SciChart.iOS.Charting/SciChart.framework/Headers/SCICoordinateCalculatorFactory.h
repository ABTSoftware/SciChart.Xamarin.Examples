//
//  SCICoordinateCalculatorFactory.h
//  SciChart
//
//  Created by Admin on 16.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup CoordinateCalculators
 *  @{
 */

#import <Foundation/Foundation.h>

@protocol SCICoordinateCalculatorProtocol;
@class SCIAxisParams;

@interface SCICoordinateCalculatorFactory : NSObject

+(id<SCICoordinateCalculatorProtocol>) getInstance:(SCIAxisParams*)arg;

@end

/** @}*/
