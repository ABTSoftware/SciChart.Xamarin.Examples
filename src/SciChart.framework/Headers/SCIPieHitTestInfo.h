//
//  SCIPieHitTestInfo.h
//  SciChart
//
//  Created by Admin on 24/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol SCIPieRenderableSeriesProtocol;
@class SCIPieSegment;

@interface SCIPieHitTestInfo : NSObject

@property (nonatomic, weak) id<SCIPieRenderableSeriesProtocol> renderableSeries;
@property (nonatomic, weak) SCIPieSegment * segment;
@property (nonatomic) BOOL isHit;
@property (nonatomic) int segmentIndex;

-(instancetype)initWithSeries:(id<SCIPieRenderableSeriesProtocol>)series segment:(SCIPieSegment*)segment isHit:(BOOL)isHit segmentIndex:(int)index;

@end
