//
//  OhlcSeriesInfo.h
//  SciChart
//
//  Created by Admin on 15.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup SeriesInfo
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCISeriesInfo.h"

@interface SCIOhlcSeriesInfo : SCISeriesInfo {
@protected
    SCIGenericType _openValue;
    SCIGenericType _highValue;
    SCIGenericType _lowValue;
    SCIGenericType _closeValue;
}

-(SCIGenericType) openValue;
-(SCIGenericType) highValue;
-(SCIGenericType) lowValue;
-(SCIGenericType) closeValue;


@end

/** @}*/