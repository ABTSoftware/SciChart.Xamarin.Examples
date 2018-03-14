//
//  PoinMarkerClusterizer.h
//  SciChart
//
//  Created by Admin on 27.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup PointMarkers
 *  @{
 */

#import <Foundation/Foundation.h>
#import <QuartzCore/QuartzCore.h>
#import "SCICallbackBlock.h"

@protocol SCIPointMarkerProtocol;
@protocol SCIRenderContext2DProtocol;

typedef struct {
    unsigned char * _data;
    int _width;
    int _height;
    CGSize _area;
    float _spacing;
    float _spacingMultiplier;
} SCIPointMarkerClusreizerInfo;

@interface SCIPointMarkerClusterizer : NSObject <NSCopying> {
    SCIPointMarkerClusreizerInfo info;
}

@property (nonatomic) CGSize area;
@property (nonatomic) float spacing;

-(void) clear;
-(void) purge;

-(void) drawPointMarker:(__unsafe_unretained id<SCIPointMarkerProtocol>)marker
                    AtX:(double)X Y:(double)Y
              ToContext:(__unsafe_unretained id<SCIRenderContext2DProtocol>)context;

@property (nonatomic, copy) SCIActionBlock propertiesChanged;

-(SCIPointMarkerClusreizerInfo*) getClusterizerInfo;

@end

static inline BOOL SCI_markSpot(SCIPointMarkerClusreizerInfo * data, float x, float y) {
    if ( y < 0 || x < 0 || y > data->_area.height || x > data->_area.width) {
        return NO;
    }
    
    if (isnan(x) || isnan(y)) {
        return NO;
    }
    
    int mapX = x * data->_spacingMultiplier;
    int mapY = y * data->_spacingMultiplier;
    
    unsigned char * map = data->_data;
    map += (mapY * data->_width + mapX);
    
    if (*map != 0) {
        return NO;
    } else {
        *map = 1;
        return YES;
    }
}

/**
 * @}
 */
