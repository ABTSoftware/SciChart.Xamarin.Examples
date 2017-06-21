//
//  AxisParams.h
//  SciChart
//
//  Created by Admin on 16.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>

@class SCIIndexRange;
@protocol SCIPointSeriesProtocol;
@class SCIArrayController;

@interface SCIAxisParams : NSObject {
    @public
    bool flipCoordinates;
    double size;
    double offset;
    
    double visibleMax;
    double visibleMin;
    
    bool isPolarAxis;
    bool isCategoryAxis;
    
    bool isLogarithmicAxis;
    double logarithmicBase;
    
    bool isXAxis;
    bool isHorizontal;
    
    id<SCIPointSeriesProtocol> categoryPointSeries;
    SCIIndexRange * pointRange;
    double dataPointWidth;
    double barTimeFrame;
}

-(BOOL) equals:(id)obj;

@end

/** @}*/