//
//  AxisInteractivityHelper.h
//  SciChart
//
//  Created by Admin on 16.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIEnumerationConstants.h"
#import "SCIAxisInteractivityHelperProtocol.h"

@protocol SCICoordinateCalculatorProtocol;

#pragma mark - SCIAxisInteractivityHelper default implementation

@interface SCIAxisInteractivityHelper : NSObject <SCIAxisInteractivityHelperProtocol>

- (id)initWithCoordinateCalculator:(id <SCICoordinateCalculatorProtocol>)coordCalculator;

@end

/** @}*/