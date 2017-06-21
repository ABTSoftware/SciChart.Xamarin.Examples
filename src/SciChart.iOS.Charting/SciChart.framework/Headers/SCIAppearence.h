//
//  SCIAppearence.h
//  SciChartDemo
//
//  Created by Mykola Hrybeniuk on 12/6/16.
//  Copyright © 2016 ABT. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SCIAppearence : NSObject

+ (id)appearanceForClass:(Class)thisClass;
- (void)startForwarding:(id)sender;

@end
