//
//  SCIBoxAnnotationStyle.h
//  SciChart
//
//  Created by Admin on 12.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIAnnotationStyleEnums.h"
#import "SCIStyleProtocol.h"

@class SCIPenStyle, SCIBrushStyle;
@protocol SCIPointMarkerProtocol;

/**
 * @abstract SCIBoxAnnotationStyle class
 * @discussion Contains properties for box annotation theming and customization
 * @see SCIBoxAnnotation
 */
@interface SCIBoxAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @abstract Point marker that will be displayed on box corners when interaction with annotation started
 */
@property (nonatomic, strong) id<SCIPointMarkerProtocol> resizeMarker;
/**
 * @abstract Pen with which outline of box annotation is drawn on chart surface
 * @discussion Defines line width and color
 */
@property (nonatomic, strong) SCIPenStyle *borderPen;
/**
 * @abstract Brush with which box annotation is drawn on chart surface
 * @discussion Defines rectangle color
 */
@property (nonatomic, strong) SCIBrushStyle *fillBrush;

/**
 * @abstract Defines width of box "hit body"
 * @discussion It is maximal distance from box edge at which user can select box annotation by tapping
 * @discussion The greater value the easier to select box annotation by tapping on it
 */
@property (nonatomic) double selectRadius;
/**
 * @abstract Defines width of box corners' point markers "hit body"
 * @discussion It maximal distance from box corners at which user can tap and pan to start interactaction with annotation
 * @discussion The greater value, the easier will be to resize or move box annotation by dragging it's corners
 */
@property (nonatomic) double resizeRadius;

/**
 * @abstract Defines layer (above or below chart) on which annotation is displayed
 * @see SCIAnnotationSurfaceEnum
 */
@property (nonatomic) SCIAnnotationSurfaceEnum annotationSurface;

@end

/** @}*/
