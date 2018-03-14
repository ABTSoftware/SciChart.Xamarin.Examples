//
//  SCIThemeColorProvider.h
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
 * Defines a SciChart Theme color provider, which provides theme colors for SCIChartSurface
 */
@interface SCIThemeColorProvider : NSObject <SCIThemeProviderProtocol>

/**
 * Creates theme provider based on specified style
 *
 * @param themeKey The key of style which should be used as base for this theme provider
 */
- (nullable instancetype)initWithThemeKey:(nonnull NSString*)themeKey;

@end

/** @} */
