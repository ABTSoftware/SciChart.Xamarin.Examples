//
//  XySeriesDataView.h
//  SciChart
//
//  Created by Admin on 08.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup SeriesInfo
 *  @{
 */

#import <UIKit/UIKit.h>
#import "SCITooltipDataView.h"

@class SCISeriesInfo;

@interface SCIXySeriesDataView : SCITooltipDataView

-(void) setData:(SCISeriesInfo *)data;

@property (weak, nonatomic) IBOutlet UILabel *nameLabel;
@property (weak, nonatomic) IBOutlet UILabel *dataLabel;

+(SCITooltipDataView *) createInstance;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *nameHeightConstraint;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *nameWidthConstraint;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataHeightConstraint;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *dataWidthConstraint;

@end

/** @}*/
