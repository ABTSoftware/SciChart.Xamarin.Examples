//
//  SCICustomAnnotationStyle.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 2/4/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIStyleProtocol.h"
@protocol SCIPointMarkerProtocol;

/**
 * @abstract SCICustomAnnotationStyle class
 * @discussion Contains properties for custom annotation theming and customization
 * @see SCICustomAnnotation
 */
@interface SCICustomAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @abstract Point marker that will be displayed on custom annotation's corners when interaction with annotation started
 */
@property (nonatomic, strong) id<SCIPointMarkerProtocol> resizeMarker;

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

@end
