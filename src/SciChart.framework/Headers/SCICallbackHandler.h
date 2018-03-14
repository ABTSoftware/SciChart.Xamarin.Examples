//
//  SCICallbackHandler.h
//  SciChart
//
//  Created by Admin on 25/07/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol SCICallbackHelperProtocol;

@protocol SCICallbackHandlerProtocol

-(void) addCallback:(id<SCICallbackHelperProtocol>)callback;
-(void) removeCallback:(id<SCICallbackHelperProtocol>)callback;

@property (nonatomic, strong) NSMutableArray * callbacks;

@end

@interface SCICallbackHandler : NSObject <SCICallbackHandlerProtocol>

@end
