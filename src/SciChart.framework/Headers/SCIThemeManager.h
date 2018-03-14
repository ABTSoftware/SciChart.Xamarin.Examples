//
//  SCIThemeManager.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 6/26/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>

@protocol SCIThemeProviderProtocol, SCIThemeableProtocol;

static NSString * _Nonnull const SCIChart_BlackSteelStyleKey = @"SciChart_BlackSteel";
static NSString * _Nonnull const SCIChart_SciChartv4DarkStyleKey = @"SciChart_SciChartv4Dark";
static NSString * _Nonnull const SCIChart_Bright_SparkStyleKey = @"SciChart_Bright_Spark";
static NSString * _Nonnull const SCIChart_ChromeStyleKey = @"SciChart_Chrome";
static NSString * _Nonnull const SCIChart_ElectricStyleKey = @"SciChart_Electric";
static NSString * _Nonnull const SCIChart_ExpressionLightStyleKey = @"SciChart_ExpressionLight";
static NSString * _Nonnull const SCIChart_OscilloscopeStyleKey = @"SciChart_Oscilloscope";
static NSString * _Nonnull const SCIChart_ExpressionDarkStyleKey = @"SciChart_ExpressionDark";

static NSString * _Nonnull const SCIChart_DefaultThemeKey = @"SciChart_SciChartv4Dark";

/**
 * Provides API for automatic theme management
 */
@interface SCIThemeManager : NSObject

/**
 * Get SCIThemeProviderProtocol instance by themeKey
 * @param themeKey The id of theme to get
 * @return SCIThemeProviderProtocol instance
 */
+ (nullable id<SCIThemeProviderProtocol>)themeProviderWith:(nonnull NSString*)themeKey;

/**
 * Removes cached SCIThemeProviderProtocol instance by its themeKey
 * @param themeKey The themeKey of theme to remove
 */
+ (void)removeThemeByThemeKey:(nonnull NSString*)themeKey;

/**
 * Creates and adds theme from specified style
 * @param themeKey The theme style to create SCIThemeProviderProtocol from
 */
+ (void)addThemeByThemeKey:(nonnull NSString*)themeKey;

/**
 * Apply theme to specified SCIThemeableProtocol instance
 * @param themeable The target to apply theme to
 * @param themeKey The theme id
 */
+ (void)applyThemeToThemeable:(nonnull id<SCIThemeableProtocol>)themeable withThemeKey:(nonnull NSString*)themeKey;

/**
 * Apply default theme to specified SCIThemeableProtocol instance
 * @param themeable The target to apply theme to
 */
+ (void)applyDefaultThemeToThemeable:(nonnull id<SCIThemeableProtocol>)themeable;

@end

/** @} */
