//
//  SCIVerticalLineAnnotationStyle.h
//  SciChart
//
//  Created by Admin on 21/02/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCILineAnnotationStyle.h"

typedef NS_ENUM(NSUInteger, SCIVerticalLineAnnotationAlignment) {
    SCIVerticalLineAnnotationAlignment_Stretch,
    SCIVerticalLineAnnotationAlignment_Bottom,
    SCIVerticalLineAnnotationAlignment_Top,
    SCIVerticalLineAnnotationAlignment_Center,
};

@interface SCIVerticalLineAnnotationStyle : SCILineAnnotationStyle

@property (nonatomic) SCIVerticalLineAnnotationAlignment verticalAlignment;

@end
