//
//  SCIHorizontalLineAnnotationStyle.h
//  SciChart
//
//  Created by Admin on 21/02/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCILineAnnotationStyle.h"

typedef NS_ENUM(NSUInteger, SCIHorizontalLineAnnotationAlignment) {
    SCIHorizontalLineAnnotationAlignment_Stretch,
    SCIHorizontalLineAnnotationAlignment_Left,
    SCIHorizontalLineAnnotationAlignment_Right,
    SCIHorizontalLineAnnotationAlignment_Center
};

@interface SCIHorizontalLineAnnotationStyle : SCILineAnnotationStyle

@property (nonatomic) SCIHorizontalLineAnnotationAlignment horizontalAlignment;

@end
