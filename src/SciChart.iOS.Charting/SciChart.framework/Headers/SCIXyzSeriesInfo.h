//
//  XyzSeriesInfo.h
//  SciChart
//
//  Created by Admin on 12.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup SeriesInfo
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCISeriesInfo.h"

@interface SCIXyzSeriesInfo : SCISeriesInfo {
    @protected
    SCIGenericType _zValue;
}

-(SCIGenericType) zValue;

@end

/** @}*/