//
//  SCILineAnnotationLabel.h
//  SciChart
//
//  Created by Admin on 20/02/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "SCIAnnotationLabelStyle.h"

@interface SCILineAnnotationLabel : UILabel

@property (nonatomic, copy) SCIAnnotationLabelStyle * style;

-(void) applyStyle;

@end
