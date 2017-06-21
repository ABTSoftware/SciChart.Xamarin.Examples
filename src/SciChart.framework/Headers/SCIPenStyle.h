//
//  SCIPenStyle.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 2/17/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIStyleProtocol.h"

@class UIColor;

@protocol SCIPenStyleProtocol///
<SCIStyleProtocol, NSCopying>

@property (nonatomic) float thickness;
@property (nonatomic, nullable) NSArray<NSNumber *> *strokeDashArray;
@property (nonatomic, nonnull) UIColor *color;
@property (nonatomic) unsigned int colorCode;

@end

@interface SCIPenStyle : NSObject <SCIPenStyleProtocol>

@end
