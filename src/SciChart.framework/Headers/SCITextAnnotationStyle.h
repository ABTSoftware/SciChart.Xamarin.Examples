//
//  SCITextAnnotationStyle.h
//  SciChart
//
//  Created by Admin on 05.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

@class UITextView;
@class SCITextFormattingStyle;
@class UIColor;

/**
 * @abstract block which is used for additional text view setup
 * @discussion this block will be called after all other style options applied
 * @param view UITextView in which text is displayed
 */
typedef void (^SCITextAnnotationViewSetupBlock) (UITextView * view);

/**
 * @abstract SCITextAnnotationStyle class
 * @discussion Contains properties for text annotation theming and customization
 * @see SCITextAnnotation
 */
@interface SCITextAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @abstract Defines text annotation text formatting style.
 * @discussion Contains properties for customization of labels font, color etc.
 * @see SCITextFormattingStyle
 */
@property (nonatomic, strong) SCITextFormattingStyle * textStyle;

/**
 * @abstract Defines text annotation text color
 */
@property (nonatomic, strong) UIColor * textColor;

/**
 * @abstract Defines text annotation background color
 */
@property (nonatomic, strong) UIColor * backgroundColor;

/**
 * @abstract viewSetup block used for additional customization of text annotation
 * @discussion Type: void (^SCITextAnnotationViewSetupBlock) (UITextField * view)
 * @see SCITextAnnotationViewSetupBlock
 */
@property (nonatomic, copy) SCITextAnnotationViewSetupBlock viewSetup;

@end

/** @}*/
