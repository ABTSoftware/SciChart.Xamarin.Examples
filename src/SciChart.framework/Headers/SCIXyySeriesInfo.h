//
//  XyySeriesInfo.h
//  SciChart
//
//  Created by Admin on 18.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup SeriesInfo
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCISeriesInfo.h"

@interface SCIXyySeriesInfo : SCISeriesInfo {
@protected
    SCIGenericType _y2Value;
}

-(SCIGenericType) y1Value;
-(SCIGenericType) y2Value;

@end

/** @}*/