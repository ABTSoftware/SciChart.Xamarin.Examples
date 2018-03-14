//
//  SCIPieLegendItem.h
//  SciChart
//
//  Created by Admin on 25/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCILegendItem.h"

/** \addtogroup ChartModifiers
 *  @{
 */

@class SCIPieSegment;

/**
 * SCIPieLegendItem model of data which will be shown in pie legend modifier. And those items are generated in SCILegendModifier.
 * @see SCIPieLegendModifier
 */
@interface SCIPieLegendItem : SCILegendItem

/**
 * An instance of SCIPieLegendItem should be created by the initializer.
 * @param segment is SCIPieSegment which sets segment property
 * @see SCILegendCell
 */
-(instancetype)initWithSegment:(SCIPieSegment*)segment;

/**
 * Pie segment which is used for generating data
 * @see SCIPieSegment
 */
@property (nonatomic, weak) SCIPieSegment * segment;

@end

/** @}*/
