//
//  SCIThemeProvider.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 12/12/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIThemeProviderProtocol.h"

typedef NS_ENUM(NSUInteger, SCIKeyTheme) {
    SCIBlackSteelTheme,
    SCIBrightSparkTheme,
    SCIChromeTheme,
    SCIChartV4DarkTheme,
    SCIElectricTheme,
    SCIExpressionDarkTheme,
    SCIExpressionLightTheme,
    SCIOscilloscopeTheme,
};

@interface SCIThemeProvider : NSObject <SCIThemeProviderProtocol>

- (id)initWithThemeKey:(SCIKeyTheme)themeKey;

@end
