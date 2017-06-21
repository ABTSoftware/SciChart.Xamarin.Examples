//
//  SCITooltipView.h
//  SciChart
//
//  Created by Admin on 08.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <UIKit/UIKit.h>

@class SCITooltipDataView;

@interface SCITooltipView : UIView

@property (weak, nonatomic) IBOutlet UIView *dataView;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataViewWidth;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataViewHeight;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataViewLeftBorder;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataViewTopBorder;


@property (nonatomic) CGSize fixedSize;
@property (nonatomic) float contentPadding;

-(void)addDataView:(SCITooltipDataView*)view;
-(void)removeAll;

+(SCITooltipView *) createInstance;

@end

/** @}*/