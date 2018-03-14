//
//  SCINumericTickProvider.h
//  SciChart
//
//  Created by Admin on 20.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import  "SCITickProvider.h"

@protocol SCIRangeProtocol;
@protocol SCIAxisDeltaProtocol;

@interface SCINumericTickProvider : NSObject <SCITickProviderProtocol>

-(SCIArrayController*) calculateMajorTicksWithRange:(id<SCIRangeProtocol>)tickRange Delta:(id<SCIAxisDeltaProtocol>)tickDelta;
-(SCIArrayController*) calculateMinorTicksWithRange:(id<SCIRangeProtocol>)tickRange Delta:(id<SCIAxisDeltaProtocol>)tickDelta;

@end
