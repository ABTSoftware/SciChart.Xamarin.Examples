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

@end
