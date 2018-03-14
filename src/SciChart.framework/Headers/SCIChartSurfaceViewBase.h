//
//  SciChartSurfaceViewBase.h
//  SciChart
//
//  Created by Admin on 27.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Visuals
 *  @{
 */

#import <Foundation/Foundation.h>
#import <UIKit/UiKit.h>
#import "SCICallbackBlock.h"

@protocol SCIRenderSurfaceProtocol;
@class SCIAxisArea;

@interface SCIChartSurfaceViewBase : UIView

@property (weak, nonatomic) IBOutlet id<SCIRenderSurfaceProtocol> renderSurface;
@property (weak, nonatomic) IBOutlet UIView *renderSurfaceSizeView;

@property (weak, nonatomic) IBOutlet SCIAxisArea *leftAxesArea;
@property (weak, nonatomic) IBOutlet SCIAxisArea *rightAxesArea;
@property (weak, nonatomic) IBOutlet SCIAxisArea *topAxesArea;
@property (weak, nonatomic) IBOutlet SCIAxisArea *bottomAxesArea;
@property (weak, nonatomic) IBOutlet UILabel *chartTitleLabel;
@property (weak, nonatomic) IBOutlet UIView *chartTitleHolderView;

@property (nonatomic) float leftAxisAreaSize;
@property (nonatomic) float rightAxisAreaSize;
@property (nonatomic) float topAxisAreaSize;
@property (nonatomic) float bottomAxisAreaSize;

@property (nonatomic) float leftAxisAreaForcedSize;
@property (nonatomic) float rightAxisAreaForcedSize;
@property (nonatomic) float topAxisAreaForcedSize;
@property (nonatomic) float bottomAxisAreaForcedSize;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *leftPanelSize;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *leftPanelSizeLimit;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *rightPanelSize;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *rightPanelSizeLimit;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *topPanelSize;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *topPanelSizeLimit;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *bottomPanelSize;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *bottomPanelSizeLimit;


-(void) setChartTitleLabelInsets:(UIEdgeInsets)chartTitleLabelInsets;

@end

/** @}*/
