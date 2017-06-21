//
//  SCIThemebleProtocol.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 12/12/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIThemeProviderProtocol.h"

@protocol SCIThemebleProtocol <NSObject>

- (void)applyThemeWithThemeProvider:(id<SCIThemeProviderProtocol>)themeProvider;

@end
