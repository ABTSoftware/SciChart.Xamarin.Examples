//
//  SCIThemeableProtocol.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 12/12/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIThemeProviderProtocol.h"

/**
 * Classes which implement SCIThemeableProtocol interface can apply theme provided by SCIThemeProviderProtocol instance
 */
@protocol SCIThemeableProtocol <NSObject>

/**
 * Applies specified theme to current instance
 *
 * @param themeProvider The SCIThemeProviderProtocol instance which provides new theme for current instance
 */
- (void)applyThemeProvider:(id<SCIThemeProviderProtocol>)themeProvider;

@end

/** @} */
