//
//  SCIPieSegment.h
//  SciChart
//
//  Created by Admin on 07/09/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@class SCIBrushStyle;
@class SCIPenStyle;
@class SCITextFormattingStyle;

/** \addtogroup RenderableSeries
 *  @{
 */

/**
 Segment of Pie or Donut renderable series
 @see SCIPieRenderableSeries
 @see SCIDonutRenderableSeries
 */
@interface SCIPieSegment : NSObject

/**
 Gets or sets fill style for segment
 @see SCIBrushStyle
 */
@property (nonatomic, nullable) SCIBrushStyle * fillStyle;
/**
 Gets or sets selected fill style for segment
 @see SCIBrushStyle
 */
@property (nonatomic, nullable) SCIBrushStyle * selectedFillStyle;

/**
 Gets or sets stroke style for segment
 @see SCIPenStyle
 */
@property (nonatomic, nullable) SCIPenStyle * strokeStyle;
/**
 Gets or sets selected stroke style for segment
 @see SCIPenStyle
 */
@property (nonatomic, nullable) SCIPenStyle * selectedStrokeStyle;

/**
 Gets or sets outline style for segment
 @see SCIPenStyle
 */
@property (nonatomic, nullable) SCIPenStyle * outlineStyle;
/**
 Gets or sets selected outline style for segment
 @see SCIPenStyle
 */
@property (nonatomic, nullable) SCIPenStyle * selectedOutlineStyle;

/**
 Gets or sets text style for segment
 @see SCITextFormattingStyle
 */
@property (nonatomic, nullable) SCITextFormattingStyle * titleStyle;
/**
 Gets or sets selected text style for segment
 @see SCITextFormattingStyle
 */
@property (nonatomic, nullable) SCITextFormattingStyle * selectedTitleStyle;

/**
 offset in points for segment from center of series
 */
@property (nonatomic) double centerOffset;

/**
 Gets or sets selected state for segment
 */
@property (nonatomic) BOOL isSelected;

/**
 Value for segment. Has influence on relative size of segment in renderable series
 */
@property (nonatomic) double value;
/**
 Title associated with segment.
 */
@property (nonatomic, strong, nullable) NSString * title;

/**
 Returns fill style depending on selected state
 */
-(SCIBrushStyle * _Nullable) getFillStyle;
/**
 Returns stroke style depending on selected state
 */
-(SCIPenStyle * _Nullable) getStrokeStyle;
/**
 Returns outline style depending on selected state
 */
-(SCIPenStyle * _Nullable) getOutlineStyle;
/**
 Returns text style depending on selected state
 */
-(SCITextFormattingStyle * _Nullable) getTextStyle;

/**
 Returns color associated with segment. By default it is taken from fill style
 */
-(UIColor * _Nullable)segmentColor;

@end

/** @}*/
