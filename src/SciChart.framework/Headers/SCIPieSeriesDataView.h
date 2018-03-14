//
//  SCIPieSeriesDataView.h
//  SciChart
//
//  Created by Admin on 30/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup SeriesInfo
 *  @{
 */

#import <UIKit/UIKit.h>
#import "SCITooltipDataView.h"

@class SCIPieSeriesInfo;

@interface SCIPieSeriesDataView : SCITooltipDataView

-(void) setData:(SCIPieSeriesInfo *)data;

@property (weak, nonatomic) IBOutlet UILabel *nameLabel;
@property (weak, nonatomic) IBOutlet UILabel *dataLabel;

+(SCITooltipDataView *) createInstance;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *nameHeightConstraint;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *nameWidthConstraint;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataHeightConstraint;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataWidthConstraint;

@end

/** @}*/
