//
//  SCIThemeProviderProtocol.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 12/12/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@protocol SCIPointMarkerProtocol;
@class SCITooltipModifierStyle, SCICursorModifierStyle, SCIRolloverModifierStyle, SCITextFormattingStyle, SCILegendCellStyle, SCIPenStyle, SCIBrushStyle;

@protocol SCIThemeProviderProtocol <NSObject>

// ChartSurface Theme
@property (nonatomic) UIFont *chartTitleFont;
@property (nonatomic) UIColor *chartTitleColor;
@property (nonatomic) SCIBrushStyle *backgroundBrush;
@property (nonatomic) SCIPenStyle *strokeStyle;
@property (nonatomic) SCIBrushStyle *seriesBackgroundBrush;

//RenderableSeries Theme
@property (nonatomic) SCIPenStyle *errorBarsLinePenStyle;
@property (nonatomic) SCIPenStyle *errorBarsHighPenStyle;
@property (nonatomic) SCIPenStyle *errorBarsLowPenStyle;

@property (nonatomic) SCIBrushStyle *bubbleBrushStyle;
@property (nonatomic) SCIPenStyle *bubblePenBorderStyle;

@property (nonatomic) SCIPenStyle *impulseLinePenStyle;

@property (nonatomic) SCIBrushStyle *mountainAreaBrushStyle;
@property (nonatomic) SCIPenStyle *mountainStrokeStyle;

@property (nonatomic) SCIBrushStyle *stackedMountainAreaBrushStyle;
@property (nonatomic) SCIPenStyle *stackedMountainStrokeStyle;

@property (nonatomic) SCIPenStyle *stackedColumnBorderPenStyle;
@property (nonatomic) SCIBrushStyle *stackedColumnFillBrushStyle;

@property (nonatomic) SCIPenStyle *columnBorderPenStyle;
@property (nonatomic) SCIBrushStyle *columnFillBrushStyle;

@property (nonatomic) SCIPenStyle *bandStrokeStyle;
@property (nonatomic) SCIPenStyle *bandStrokeY1Style;
@property (nonatomic) SCIBrushStyle *bandFillBrushStyle;
@property (nonatomic) SCIBrushStyle *bandFillBrushY1Style;

@property (nonatomic) SCIPenStyle *linePenStyle;

@property (nonatomic) SCIPenStyle *ohlcUpWickPenStyle;
@property (nonatomic) SCIPenStyle *ohlcDownWickPenStyle;

@property (nonatomic) SCIPenStyle *candleUpWickPen;
@property (nonatomic) SCIPenStyle *candleDownWickPen;
@property (nonatomic) SCIBrushStyle *candleUpBodyBrush;
@property (nonatomic) SCIBrushStyle *candleDownBodyBrush;

//Axis Theme
@property (nonatomic) SCITextFormattingStyle *axisTickLabelStyle;
@property (nonatomic) SCITextFormattingStyle *axisTitleLabelStyle;
@property (nonatomic) SCIPenStyle *axisMajorGridLineBrush;
@property (nonatomic) SCIPenStyle *axisMinorGridLineBrush;
@property (nonatomic) SCIBrushStyle *axisGridBandBrush;
@property (nonatomic) CGFloat axisMinorTickSize;
@property (nonatomic) CGFloat axisMajorTickSize;

//Annotation Theme
@property (nonatomic) SCIPenStyle *annotationLinePenStyle;
@property (nonatomic) id<SCIPointMarkerProtocol> annotationLineResizeMarker;
@property (nonatomic) SCITextFormattingStyle *annotationTextStyle;
@property (nonatomic) UIColor *annotationTextBackgroundColor;
@property (nonatomic) id<SCIPointMarkerProtocol> annotationBoxPointMarkerStyle;
@property (nonatomic) SCIPenStyle *annotationBoxBorderPenStyle;
@property (nonatomic) SCIBrushStyle *annotationBoxFillBrushStyle;
@property (nonatomic) SCITextFormattingStyle *annotationAxisMarkerTextStyle;
@property (nonatomic) SCIPenStyle *annotationAxisMarkerLineStyle;
@property (nonatomic) UIColor *annotationAxisMarkerBackgroundColor;
@property (nonatomic) UIColor *annotationAxisMarkerBorderColor;

//Modifier Theme
@property (nonatomic) SCITooltipModifierStyle *modifierTooltipStyle;
@property (nonatomic) SCICursorModifierStyle *modifierCursorStyle;
@property (nonatomic) SCIRolloverModifierStyle *modifierRolloverStyle;
@property (nonatomic) UIColor *modifierLegendBackgroundColor;
@property (nonatomic) UIColor *modifierLegendBorderColor;
@property (nonatomic) float modifierLegendBorderWidth;
@property (nonatomic) SCILegendCellStyle *modifierLegendCellStyle;

@end
