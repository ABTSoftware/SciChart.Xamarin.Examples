//
//  DefaultTickLabel.h
//  SciChart
//
//  Created by Admin on 17.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "SCITickLabel.h"

@interface SCIDefaultTickLabel : UILabel <SCITickLabelProtocol>

@property (nonatomic) int cullingPriority;
@property (nonatomic) CGPoint position;

-(BOOL)hasIntersectionWithNext:(UIView*)other;
-(BOOL)fitsInArea:(CGRect)area;

@end
