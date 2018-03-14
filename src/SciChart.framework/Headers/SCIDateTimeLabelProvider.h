//
//  DateTimeLabelProvider.h
//  SciChart
//
//  Created by Admin on 02.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCILabelProviderBase.h"

@interface SCIDateTimeLabelProvider : SCILabelProviderBase {
    NSDateFormatter *_formatter;
}
/**
 * Change default time zone for date formatter in current label provider.
 */
@property (nonatomic, nullable) NSTimeZone *timeZone;

@end
