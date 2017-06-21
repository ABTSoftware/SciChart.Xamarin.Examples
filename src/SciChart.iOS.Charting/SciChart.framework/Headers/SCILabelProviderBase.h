//
//  LabelProviderBase.h
//  SciChart
//
//  Created by Admin on 20.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCILabelProviderProtocol.h"

@protocol SCIAxisCoreProtocol;

@interface SCILabelProviderBase : NSObject <SCILabelProviderProtocol>

@property (nonatomic, weak) id<SCIAxisCoreProtocol> parentAxis;

@end
