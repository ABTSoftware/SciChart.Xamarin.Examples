//
//  SCIAnnotationLabelStyle.h
//  SciChart
//
//  Created by Admin on 20/02/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIStyleProtocol.h"
#import "SCIAnnotationStyleEnums.h"
#import "SCITextFormattingStyle.h"

typedef NS_ENUM(NSUInteger, SCILabelPlacement) {
    SCILabelPlacement_Left,
    SCILabelPlacement_TopLeft,
    SCILabelPlacement_BottomLeft,
    SCILabelPlacement_Right,
    SCILabelPlacement_TopRight,
    SCILabelPlacement_BottomRight,
    SCILabelPlacement_Bottom,
    SCILabelPlacement_Top,
    SCILabelPlacement_Axis,
    SCILabelPlacement_Auto
};

/**
 * @abstract block which is used for additional label view setup
 * @discussion this block will be called after all other style options applied
 */
typedef void (^SCIAnnotationLabelSetupBlock) (UILabel * label);

@interface SCIAnnotationLabelStyle : NSObject <SCIStyleProtocol>

/**
 * Changes border width of label. Default is 0.0f.
 */
@property (nonatomic) float borderWidth;
/**
 * Changes corner radius of label. Default is 2.0f.
 */
@property (nonatomic) float cornerRadius;
/**
 * Changes opacity of background. Default is 0.7f.
 */
@property (nonatomic) float backgroundOpacity;

/**
 * Defines distance in pixels from label view border to text
 */
@property (nonatomic) float contentPadding;

@property (nonatomic) float alignmentMargin;

/**
 * Changes background colour of label.
 */
@property (nonatomic, strong) UIColor * backgroundColor;
/**
 * Changes border colour of label
 */
@property (nonatomic, strong) UIColor * borderColor;

/**
 * @abstract This block is used for additional customization of toltip view
 * @discussion Type: typedef void (^SCITooltipViewSetupBlock) (SCITooltipView * view);
 * @see SCITooltipViewSetupBlock
 */
@property (nonatomic, copy) SCIAnnotationLabelSetupBlock labelSetup;

/**
 * @abstract Defines label text formatting style.
 * @discussion Contains properties for customization of labels font, color etc.
 * @see SCITextFormattingStyle
 */
@property (nonatomic, strong) SCITextFormattingStyle * textStyle;

@property (nonatomic) SCILabelPlacement labelPlacement;

@end

/** @}*/
