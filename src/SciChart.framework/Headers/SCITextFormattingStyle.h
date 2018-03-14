//
//  SCITextFormattingStyle.h
//  SciChart
//
//  Created by Admin on 20.10.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

/**
 * @typedef SCILabelAlignmentHorizontalMode
 * @abstract Defines axis label horizontal alignment
 
 * @field SCILabelAlignmentHorizontal_Default for top or bottom aligned axis it is equal to SCILabelAlignmentHorizontal_Center, if axis is left align is it equal to SCILabelAlignmentHorizontal_Left and for right aligned axis it is SCILabelAlignmentHorizontal_Right
 
 * @dfield SCILabelAlignmentHorizontal_Center label will not be moved from calculated origin (centred)
 
 * @field SCILabelAlignmentHorizontal_Left default for left aligned axis, for right aligned - label will be flipped to chart surface, for horizontal axes label will be flipped to left from origin point
 
 * @field SCILabelAlignmentHorizontal_Right default for right aligned axis, for left aligned - label will be flipped to chart surface, for horizontal axes label will be flipped to right from origin point
 */
typedef NS_ENUM(NSUInteger, SCILabelAlignmentHorizontalMode) {
    /** For top or bottom aligned axis it is equal to SCILabelAlignmentHorizontal_Center, if axis is left align is it equal to SCILabelAlignmentHorizontal_Left and for right aligned axis it is SCILabelAlignmentHorizontal_Right */
    SCILabelAlignmentHorizontal_Default,
    /** Label will not be moved from calculated origin (centred) */
    SCILabelAlignmentHorizontal_Center,
    /** Default for left aligned axis, for right aligned - label will be flipped to chart surface, for horizontal axes label will be flipped to left from origin point */
    SCILabelAlignmentHorizontal_Left,
    /** Default for right aligned axis, for left aligned - label will be flipped to chart surface, for horizontal axes label will be flipped to right from origin point */
    SCILabelAlignmentHorizontal_Right
};

/**
 * @typedef SCILabelAlignmentVerticalMode
 * @abstract Defines axis label vertical alignment
 * @discussion Possible values:
 * @discussion - SCILabelAlignmentVertical_Default for left or right aligned axis it is equal to SCILabelAlignmentHorizontal_Center, if axis is top align is it equal to SCILabelAlignmentVertical_Top and for bottom aligned axis it is SCILabelAlignmentVertical_Bottom
 * @discussion - SCILabelAlignmentVertical_Center label will not be moved from calculated origin (centred)
 * @discussion - SCILabelAlignmentVertical_Top default for top aligned axis, for bottom aligned - label will be flipped to chart surface, for vertical axes label will be flipped up from origin point
 * @discussion - SCILabelAlignmentVertical_Bottom default for bottom aligned axis, for top aligned - label will be flipped to chart surface, for vertical axes label will be flipped down from origin point
 */
typedef NS_ENUM(NSUInteger, SCILabelAlignmentVerticalMode) {
    /** For left or right aligned axis it is equal to SCILabelAlignmentHorizontal_Center, if axis is top align is it equal to SCILabelAlignmentVertical_Top and for bottom aligned axis it is SCILabelAlignmentVertical_Bottom */
    SCILabelAlignmentVertical_Default,
    /** Label will not be moved from calculated origin (centred) */
    SCILabelAlignmentVertical_Center,
    /** Default for top aligned axis, for bottom aligned - label will be flipped to chart surface, for vertical axes label will be flipped up from origin point */
    SCILabelAlignmentVertical_Top,
    /** Default for bottom aligned axis, for top aligned - label will be flipped to chart surface, for vertical axes label will be flipped down from origin point */
    SCILabelAlignmentVertical_Bottom
};

/**
 * @brief SCITextFormattingStyle class.
 * @discussion Provides properties for styling the text with Font, Size, Color.
 * @see SCIStyleProtocol
 */
@interface SCITextFormattingStyle : NSObject <SCIStyleProtocol, NSCopying>

- (instancetype)initWithFontSize:(float)fontSize andTextColor:(unsigned int)textColor;
- (instancetype)initWithFontSize:(float)fontSize fontName:(NSString*)fontName andTextColor:(UIColor *)textColor;

/**
 * @brief Defines text font
 * @discussion For more iOS supported font names go to http://iosfonts.com/
 * @code
 * textStyle.fontName = "Helvetica"
 * @endcode
 */
@property (nonatomic, copy) NSString * fontName;

/**
 * @brief Defines text size
 */
@property (nonatomic) float fontSize;

/**
 * @brief Get or set text color as UIColor
 */
@property (nonatomic, copy) UIColor * color;
/**
 * @brief Get or set text color as hex color code (color format 0xAARRGGBB)
 */
@property (nonatomic) unsigned int colorCode;
/**
 * @brief Defines text label tranform
 * @discussion While it is safe enough to use "rotation" transform, transform with moving can cause strange layout though
 * @code
 * labelStyle.transform = CGAffineTransformMakeRotation(CGFloat(M_PI_2))
 * @endcode
 */
@property (nonatomic) CGAffineTransform transform;

/**
 * @brief Defines axis label horizontal alignment
 * @discussion Will be moved to SCIAxisStyle in next major version release
 * @see SCILabelAlignmentHorizontalMode
 */
@property (nonatomic) SCILabelAlignmentHorizontalMode alignmentHorizontal;
/**
 * @brief Defines axis label vertical alignment
 * @discussion Will be moved to SCIAxisStyle in next major version release
 * @see SCILabelAlignmentVerticalMode
 */
@property (nonatomic) SCILabelAlignmentVerticalMode alignmentVertical;

/**
 * @brief Returns text font
 * @discussion Generates font from fontName and fontSize
 * @return UIFont instance
 */
-(UIFont*) getFont;

@end

/** @} */
