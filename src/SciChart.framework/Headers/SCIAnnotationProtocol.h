//
//  SCIAnnotation.h
//  SciChart
//
//  Created by Admin on 28.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Annotations 
 *  @{
 */

#import "SCIGestureEventsHandlerProtocol.h"
#import "SCISuspendableProtocol.h"
#import "SCIGenericType.h"

@class SCIAxisCollection;
@protocol SCIAxis2DProtocol;
@protocol SCIChartSurfaceProtocol;

/**
 \extends SCIGestureEventsHandler
 * Defines the protocol to an annotation, a custom drawable element under the SCIChartSurface
 * @discussion Mind that for annotation to be drawn it has to be attached to SciChartSurface. If you need multiple annotations on surface use SCIAnnotationGroup
 @see SCIChartSurfaceProtocol
 @see SCIAnnotationGroup
 @extends SCIGestureEventsHandlerProtocol
 */
@protocol SCIAnnotationProtocol ///
<SCIGestureEventsHandlerProtocol, SCISuspendableProtocol>
 /** @{ @} */

/**
 * Gets or sets the parent that this Annotation belongs to
 * @see SCIChartSurfaceProtocol
 */
@property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;

/**
 * Gets the primary XAxis instance on the parent
 * @see SCIAxis2DProtocol, SCIChartSurfaceProtocol
 */
-(id<SCIAxis2DProtocol>) xAxis;

/**
 * Gets the primary YAxis instance on the parent
 * @see SCIAxis2DProtocol, SCIChartSurfaceProtocol
 */
-(id<SCIAxis2DProtocol>) yAxis;

/**
 * Gets the XAxis instance on the parent by Id
 * @param axisId XAxis Id
 * @see SCIAxisCollection, SCIChartSurface
 */
-(id<SCIAxis2DProtocol>) getXAxis:(NSString*)axisId;

/**
 * Gets the YAxis instance on the parent by Id
 * @param axisId YAxis Id
 * @see SCIAxisCollection, SCIChartSurface
 */
-(id<SCIAxis2DProtocol>) getYAxis:(NSString*)axisId;

/**
 * Called when the Annotation should be drawn
 */
-(void)draw;

/**
 * Called when the Annotation is attached to parent surface
 */
-(void)onAttached;

/**
 * Called when the Annotation is detached from its parent surface
 */
-(void)onDetached;

/**
 * Gets or sets whether the current annotation is attached
 */
@property (nonatomic) BOOL isAttached;

/**
 * Gets or sets whether the current annotation is enabled
 */
@property (nonatomic) BOOL isEditable;

/**
 * Gets or sets the name of current annotation
 */
@property (nonatomic, copy) NSString * annotationName;

/**
 * Gets or sets the visibility of an annotation
 */
@property (nonatomic) BOOL isHidden;

/**
 * Gets or sets the selected state of an annotation
 */
@property (nonatomic) BOOL isSelected;


@property (nonatomic) SCIGenericType x1;

@property (nonatomic) SCIGenericType y1;

@property (nonatomic) SCIGenericType x2;

@property (nonatomic) SCIGenericType y2;

/**
 * Gets or sets the ID of the X-Axis which this Annotation is measured against
 */
@property (nonatomic, copy) NSString * xAxisId;

/**
 * Gets or sets the ID of the Y-Axis which this Annotation is measured against
 */
@property (nonatomic, copy) NSString * yAxisId;

@end

/** @}*/
