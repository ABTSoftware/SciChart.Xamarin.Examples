//
//  SCIPieHitTestProvider.h
//  SciChart
//
//  Created by Admin on 24/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <QuartzCore/QuartzCore.h>

@class SCIPieHitTestInfo;
@protocol SCIPieRenderableSeriesProtocol;

@interface SCIPieHitTestProvider : NSObject

-(instancetype)initWithParent:(id<SCIPieRenderableSeriesProtocol>)parent;
-(SCIPieHitTestInfo*)hitTestAtPoint:(CGPoint)point;

@end
