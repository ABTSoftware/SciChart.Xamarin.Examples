//
//  SCIAxisDelta.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIGenericType.h"
@protocol SCIAxisDeltaProtocol <NSObject>

@property (nonatomic) SCIGenericType majorDelta;
@property (nonatomic) SCIGenericType minorDelta;

@end
