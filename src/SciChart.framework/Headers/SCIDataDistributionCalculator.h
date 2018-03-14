//
//  SCIDataDistributionCalculator.h
//  SciChart
//
//  Created by Admin on 08.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIArrayControllerProtocol.h"

@protocol SCIDataDistributionCalculatorProtocol <NSObject>

@required

- (BOOL)dataIsSortedAscending;

- (BOOL)dataIsEvenlySpaced;

- (void)clear;

- (void)onAppendValueInArrayController:(id<SCIArrayControllerProtocol>)array
                              andCount:(int)count
                   acceptsUnsortedData:(BOOL)acceptsUnsortedData;

- (void)onUpdateValueInArrayController:(id<SCIArrayControllerProtocol>)array
                               atIndex:(int)atIndex
                   acceptsUnsortedData:(BOOL)acceptsUnsortedData;

- (void)onInsertValueInArrayController:(id<SCIArrayControllerProtocol>)array
                               atIndex:(int)atIndex
                              andCount:(int)count
                   acceptsUnsortedData:(BOOL)acceptsUnsortedData;


@end
