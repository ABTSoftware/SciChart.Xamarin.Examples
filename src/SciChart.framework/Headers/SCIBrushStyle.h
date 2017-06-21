//
//  SCIBrushStyle.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 2/18/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIStyleProtocol.h"

@class UIColor;

@protocol SCIBrushStyleProtocol <SCIStyleProtocol, NSCopying>

@property (nonatomic, nonnull) UIColor *color;
@property (nonatomic) unsigned int colorCode;

@end

@interface SCIBrushStyle : NSObject <SCIBrushStyleProtocol>

@end
