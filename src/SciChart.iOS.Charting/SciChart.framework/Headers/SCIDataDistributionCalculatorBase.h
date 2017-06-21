//
//  BaseDataDistributionCalculator.h
//  SciChart
//
//  Created by Admin on 08.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIDataDistributionCalculator.h"

@interface SCIDataDistributionCalculatorBase : NSObject <SCIDataDistributionCalculatorProtocol> {
@protected
    BOOL _dataIsSortedAscending;
    BOOL _dataIsEvenlySpaced;
}

@property (nonatomic) BOOL dataIsSortedAscending;
@property (nonatomic) BOOL dataIsEvenlySpaced;

@end
