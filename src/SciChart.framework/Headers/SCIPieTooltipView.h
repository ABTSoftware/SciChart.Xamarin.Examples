//
//  SCIPieTooltipView.h
//  SciChart
//
//  Created by Admin on 25/09/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface SCIPieTooltipView : UIView

@property (weak, nonatomic) IBOutlet UILabel *tooltipText;

+(SCIPieTooltipView *) createInstance;

@end
