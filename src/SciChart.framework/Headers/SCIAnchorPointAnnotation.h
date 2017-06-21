//
//  SCIAnchorPointAnnotation.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 4/21/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIAnnotationBase.h"

/**
 * Enumeration constants used by {@link SCIAnchorPointAnnotation} to define horizontal alignment around the X1,Y1 coordinates
 */
typedef NS_ENUM(NSUInteger, SCIHorizontalAnchorPoint) {
    /**
     * Align Left
     */
    SCIHorizontalAnchorPoint_Left,
    
    /**
     * Align Center
     */
    SCIHorizontalAnchorPoint_Center,
    
    /**
     * Align Right
     */
    SCIHorizontalAnchorPoint_Right
};

/**
 * Enumeration constants used by {@link SCIAnchorPointAnnotation} to define vertical alignment around the X1,Y1 coordinates
 */
typedef NS_ENUM(NSUInteger, SCIVerticalAnchorPoint) {
    /**
     * Align Top
     */
    SCIVerticalAnchorPoint_Top,
    
    /**
     * Align Center
     */
    SCIVerticalAnchorPoint_Center,
    
    /**
     * Align Bottom
     */
    SCIVerticalAnchorPoint_Bottom
};

@interface SCIAnchorPointAnnotation : SCIAnnotationBase

@property (nonatomic) SCIHorizontalAnchorPoint horizontalAnchorPoint;
@property (nonatomic) SCIVerticalAnchorPoint verticalAnchorPoint;

@end
