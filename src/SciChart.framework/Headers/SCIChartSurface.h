//
//  SciChartSurface.h
//  SciChart
//
//  Created by Admin on 23.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Visuals
 *  @{
 */

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <QuartzCore/QuartzCore.h>
#import "SCIInvalidatableElement.h"
#import "SCIRenderSurfaceCallbackDelegate.h"
#import "SCIThemeableProtocol.h"
#import "SCIAxisCollection.h"
#import "SCIAnnotationCollection.h"
#import "SCIRenderableSeriesCollection.h"
#import "SCIChartModifierCollection.h"
#import "SCIChartSurfaceView.h"
#import "SCIChartControllerProtocol.h"
#import "SCISuspendableProtocol.h"
#import "SCIAnimationContextInvalidate.h"

@class SCIRenderSurfaceStyle;
@class SCIGestureController;
@protocol SCIAxis2DProtocol;
@protocol SCIDataSeriesProtocol;
@protocol SCIViewportManagerProtocol;
@protocol SCIRenderableSeriesProtocol;
@protocol SCIRenderSurfaceProtocol;
@protocol SCIRenderContext2DProtocol;
@protocol SCIRenderableSeries;

#pragma mark - SCIChartSurface protocol

/**
 @extends SCIInvalidatableElementProtocol
 */
@protocol SCIChartSurfaceProtocol ///
<NSObject, SCIInvalidatableElementProtocol, SCIThemeableProtocol, SCISuspendableProtocol, SCIAnimationContextInvalidate>
/** @{ @} */

/**
 * Defines chart area border thicknes and color.
 * @code
 * surface.renderableSeriesAreaBorder = SCIPenSolid(colorCode: 0xFFF0F050, width: 1)
 * @endcode
 * @see SCIPenStyleProtocol
 */
@property (nonatomic, strong) SCIPenStyle * _Nonnull renderableSeriesAreaBorder;

/**
 * Defines background fill color for chart area
 * @code
 * surface.renderableSeriesAreaFill = SCIBrushSolid(colorCode: 0xFFA0A050)
 * @endcode
 * @see SCIBrushStyleProtocol
 */
@property (nonatomic, strong) SCIBrushStyle * _Nonnull renderableSeriesAreaFill;

/**
 *  Defines the SCIChartModifier, responsible for zoom, pan or tooltip behaviors
 * <p>The SCIChartModifier API allows you to attach one or more modifiers (behaviors) to the SCIChartSurface. Behaviors can include zooming, panning, pinch zoom, legends, tooltips and more</p>
 * <p>It is possible group more than SCIChartModifier using the SCIModifierGroup type. It is also possible to define your own customer SCIChartModifier derived types.</p>
 * @code
 * // Defining ChartModifier in Objective C
 * SCIPinchZoomModifier * pzm = [[SCIPinchZoomModifier alloc] init];
 * SCIZoomExtentsModifier * zem = [[SCIZoomExtentsModifier alloc] init];
 * SCIRolloverModifier * rollover = [[SCIRolloverModifier alloc] init];
 *
 * [rollover setModifierName:@"Rollover Modifier"];
 * [zem setModifierName:@"ZoomExtents Modifier"];
 * [pzm setModifierName:@"PinchZoom Modifier"];
 * [yDragModifier setModifierName:@"YAxis Drag Modifier"];
 * [xDragModifier setModifierName:@"XAxis Drag Modifier"];
 *
 * SCIModifierGroup * gm = [[SCIModifierGroup alloc] initWithChildModifiers:@[xDragModifier, yDragModifier, pzm, zem, rollover]];
 * sciChartSurface.chartModifier = gm;
 * @endcode
 *
 * @code
 * // Defining ChartModifiers in Swift
 * let zem = SCIZoomExtentsModifier()
 * zem.modifierName = extendZoomModifierName
 *
 * let pzm = SCIPinchZoomModifier()
 * pzm.modifierName = pinchZoomModifierName
 *
 * let rollover = SCIRolloverModifier()
 * rollover.modifierName = rolloverModifierName
 *
 * let groupModifier = SCIModifierGroup(childModifiers: [pzm, zem, rollover])
 *
 * chartSurface.chartModifier = groupModifier
 * @endcode
 * @see SCIChartModifierProtocol
 * @see SCIChartModifierBase
 * @see SCIModifierGroup
 * @see SCIXAxisDragModifier
 * @see SCIYAxisDragModifier
 * @see SCIAxisPinchZoomModifier
 * @see SCIZoomPanModifier
 * @see SCIPinchZoomModifier
 * @see SCIZoomExtentsModifier
 * @see SCITooltipModifier
 * @see SCICursorModifier
 * @see SCIRolloverModifier
 * @see SCILegendModifier
 */
@property (nonatomic, strong, nonnull) SCIChartModifierCollection *chartModifiers;

/**
 *  Attaches an annotation or a SCIAnnotationCollection to the SCIChartSurface
 * <p>Annotations can be used to add lines, text, boxes or markers onto the chart. The annotations update position as you zoom and pan the chart</p>
 * @code
 * // Objective-C Example
 * SCIBoxAnnotation * box = [[SCIBoxAnnotation alloc] init];
 * box.xStart = SCIGeneric(2.0);
 * box.yStart = SCIGeneric(2.0);
 * box.xEnd = SCIGeneric(4.0);
 * box.yEnd = SCIGeneric(4.0);
 * box.isEnabled = NO;
 * box.style.fillBrush = [[SCIBrushSolid alloc] initWithColorCode:0x30FF7000];
 *
 * SCILineAnnotation * lineAnnotation = [[SCILineAnnotation alloc] init];
 * lineAnnotation.xStart = SCIGeneric(1.0);
 * lineAnnotation.yStart = SCIGeneric(1.0);
 * lineAnnotation.xEnd = SCIGeneric(2.0);
 * lineAnnotation.yEnd = SCIGeneric(2.0);
 * lineAnnotation.style.linePen = [[SCIPenSolid alloc] initWithColorCode:0xFF4c8aff Width:2];
 *
 * SCITextAnnotation * textAnnotation = [[SCITextAnnotation alloc] init];
 * textAnnotation.xPosition = SCIGeneric(4.0);
 * textAnnotation.yPosition = SCIGeneric(5.0);
 * textAnnotation.text = @"An amazing TextAnnotation";
 * textAnnotation.style.textStyle = textFormatting;
 *
 * SCIAnnotationGroup * annotationGroup = [[SCIAnnotationGroup alloc]initWithChildAnnotations:@[box, lineAnnotation, textAnnotation]];
 * [surface setAnnotation:annotationGroup];
 * @endcode
 *
 * @code
 * // Swift example
 * var box = SCIBoxAnnotation()
 * box.xStart = SCIGeneric(2.0)
 * box.yStart = SCIGeneric(2.0)
 * box.xEnd = SCIGeneric(4.0)
 * box.yEnd = SCIGeneric(4.0)
 * box.isEnabled = false
 * box.style.fillBrush = SCIBrushSolid(colorCode: 0x30FF7000)
 *
 * var lineAnnotation = SCILineAnnotation()
 * lineAnnotation.xStart = SCIGeneric(1.0)
 * lineAnnotation.yStart = SCIGeneric(1.0)
 * lineAnnotation.xEnd = SCIGeneric(2.0)
 * lineAnnotation.yEnd = SCIGeneric(2.0)
 * lineAnnotation.style.linePen = SCIPenSolid(colorCode: 0xFF4c8aff, width: 2)
 *
 * var textAnnotation = SCITextAnnotation()
 * textAnnotation.xPosition = SCIGeneric(4.0)
 * textAnnotation.yPosition = SCIGeneric(5.0)
 * textAnnotation.text = "An amazing TextAnnotation"
 * textAnnotation.style.textStyle = textFormatting
 *
 * var annotationGroup = SCIAnnotationGroup(childAnnotations: [box, lineAnnotation, textAnnotation])
 * surface.annotation = annotationGroup
 * @code
 * @endcode
 * @see SCIAnnotationProtocol
 * @see SCILineAnnotation
 * @see SCIBoxAnnotation
 * @see SCITextAnnotation
 * @see SCIAnnotationGroup
 */
@property (nonatomic, strong, nonnull) SCIAnnotationCollection *annotations;

/**
 *  The collection of XAxes when in a multiple Axis scenario.
 * <p>You can add XAxis to the SCIChartSurface using the SCIChartSurface.attachAxis() function. Ensure that each SCIAxis2D instance has the SCIAxis2D.axisId property set!</p>
 * @see SCIAxisCollection
 * @see SCIAxis2DProtocol
 * @see SCINumericAxis
 * @see SCIDateTimeAxis
 * @see SCILogarithmicNumericAxis
 */
@property (nonatomic, strong, nonnull) SCIAxisCollection * xAxes;

/**
 *  The collection of YAxes when in a multiple Axis scenario.
 * <p>You can add XAxis to the SCIChartSurface using the SCIChartSurface.attachAxis() function. Ensure that each SCIAxis2D instance has the SCIAxis2D.axisId property set!</p>
 * @see SCIAxisCollection
 * @see SCIAxis2DProtocol
 * @see SCINumericAxis
 * @see SCIDateTimeAxis
 * @see SCILogarithmicNumericAxis
 */
@property (nonatomic, strong, nonnull) SCIAxisCollection * yAxes;

/**
 *  Exposes the collection of SCIRenderableSeries on the SCIChartSurface
 * <p>RenderableSeries are the visual representation of the chart series, while SCIDataSeries are the data representation.</p>
 * <p>To add a series to a chart, use SCIChartSurface.attachRenderableSeries. Ensure that SCIRenderableSeries DataSeries is an instance of SCIDataSeries to provide the data</p>
 * @see SCIFastLineRenderableSeries
 * @see SCIDataSeriesProtocol
 */
@property (nonatomic, strong, nonnull) SCIRenderableSeriesCollection * renderableSeries;

/**
 *  Exposes the collection of selected SCIRenderableSeries on the SCIChartSurface
 * <p>RenderableSeries are the visual representation of the chart series, while SCIDataSeries are the data representation.</p>
 * <p>To add a series to a chart, use SCIChartSurface.attachRenderableSeries. Ensure that SCIRenderableSeries DataSeries is an instance of SCIDataSeries to provide the data</p>
 * @see SCIFastLineRenderableSeries
 * @see SCIDataSeriesProtocol
 */
@property (nonatomic, strong, readonly, nonnull) SCIRenderableSeriesCollection * selectedRenderableSeries;

/**
 *  Defines the SCIViewportManager instance which controls the viewport ranges on chart updates.
 * <p>This property is set to default instance which calculates X and YAxis ranges based on the SCIAxis2D.autoRange property</p>
 * @see SCIViewportManager
 */
@property (nonatomic, strong, nonnull) id<SCIViewportManagerProtocol> viewportManager;

/**
 * Text for chat title. If you set the property chartTitleView will be removed.
 */
@property (nonatomic, copy, nullable) NSString * chartTitle;

/**
 * Font for chart title if you use chartTitle.
 */
@property (nonatomic, nullable) UIFont *chartTitleFont;

/**
 * Color text for chart title if you use chartTitle.
 */
@property (nonatomic, nullable) UIColor *chartTitleColor;

/**
 * Text aligment for chart title if you use chartTitle.
 */
@property (nonatomic) NSTextAlignment chartTitleAlignment;

/**
 * Set insets for chartTitleLabel on chartTitleView
 */
-(void)setChartTitleLabelInsets:(UIEdgeInsets)chartTitleLabelInsets;

/**
 * Custom view for chart title. If you set the property another properties (chartTitle, chartTitleFont, chartTitleColor, chartTileAligment) don't work.
 */
@property (nonatomic, weak, nullable) UIView *chartTitleView;

/**
 * @see SCIRenderSurfaceProtocol
 */
@property (nonatomic, weak, nullable) id<SCIRenderSurfaceProtocol> renderSurface;

/**
 * Export current chart surface into UIImage object. It is used for taking screenshots.
 */
-(nonnull UIImage*)exportToUIImage;

/**
 *  Sets the License Key for all SCIChartSurface instances
 *  <p>For instructions of use, please see http://www.scichart.com/licensing-scichart-ios</p>
 *
 *  @param licenseContract <#licenseContract description#>
 */
+(void) setRuntimeLicenseKey:(nonnull NSString *)licenseContract;

/**
 * Sets or gets gestures handler on surface.
 */
@property (nonatomic, strong) SCIGestureController * _Nonnull gestureController;

/**
 * return frame of SciChart surface
 */
-(CGRect)frame;

/**
 * Return frame of charts area
 */
-(CGRect)chartFrame;

@end

#pragma mark - SCIChartSurface default implementation

@interface SCIChartSurface : SCIChartSurfaceView <SCIChartSurfaceProtocol, SCIChartControllerProtocol, SCIRenderSurfaceCallbackDelegateProtocol> {
}


@property(nullable, nonatomic, copy) UIColor *backgroundColor;

@property (nonatomic) BOOL debugWhySciChartDoesntRender;

+ (void)setDisplayLinkRunLoopMode:(NSRunLoopMode _Nonnull )runLoopMode;

+ (NSRunLoopMode _Nonnull )getDisplayLinkRunLoopMode;

@end

/** @}*/
