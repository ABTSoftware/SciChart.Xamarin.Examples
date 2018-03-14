//
//  BaseDataDistributionCalculator.h
//  SciChart
//
//  Created by Admin on 08.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIDataDistributionCalculator.h"

@interface SCIDataDistributionCalculatorBase : NSObject <SCIDataDistributionCalculatorProtocol>

@property BOOL dataIsSortedAscending;
@property BOOL dataIsEvenlySpaced;

@end
