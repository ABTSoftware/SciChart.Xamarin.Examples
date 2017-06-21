//
//  SCITooltipDataView.h
//  SciChart
//
//  Created by Admin on 15.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <UIKit/UIKit.h>

@class SCITextFormattingStyle;

@interface SCITooltipDataView : UIView

-(void) applyHeadLineStyle:(SCITextFormattingStyle*)style;
-(void) applyDataLineStyle:(SCITextFormattingStyle*)style;

-(void) setColor:(UIColor*)color;

-(CGSize) getTransformedViewSize:(UIView*)view;

@end

/** @}*/