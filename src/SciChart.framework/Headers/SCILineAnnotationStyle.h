//
//  SCILineAnnotationStyle.h
//  SciChart
//
//  Created by Admin on 30.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIAnnotationStyleEnums.h"
#import "SCIStyleProtocol.h"

@class SCIPenStyle;
@protocol SCIPointMarkerProtocol;

/**
 * @abstract SCILineAnnotationStyle class
 * @discussion Contains properties for line annotation theming and customization
 * @see SCILineAnnotation
 */
@interface SCILineAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @abstract Point marker that will be displayed on line ends when interaction with annotation started
 * @see SCIPointMarkerProtocol
 */
@property (nonatomic, strong) id<SCIPointMarkerProtocol> resizeMarker;

/**
 * @abstract Pen with which line annotation is drawn on chart surface
 * @discussion Defines line width and color
 * @see SCIPen2DProtocol
 */
@property (nonatomic, strong) SCIPenStyle *linePen;

/**
 * @abstract Defines width of line's "hit body"
 * @discussion It is distance at which user should tap to select line annotation
 * @discussion The greater value the easier to select line annotation by tapping on it
 */
@property (nonatomic) double selectRadius;

/**
 * @abstract Defines width of line ends' point markers "hit body"
 * @discussion It's distance at which user should tap and pan at line ends' point markers to interact with line annotation
 * @discussion The greater value, the easier will be to resize or move line annotation by dragging it's ends
 */
@property (nonatomic) double resizeRadius;

/**
 * @abstract Defines layer (above chart or below chart) on which annotation is displayed
 * @see SCIAnnotationSurfaceEnum
 */
@property (nonatomic) SCIAnnotationSurfaceEnum annotationSurface;

@end

/** @}*/
