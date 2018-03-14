//
//  SCITickCoordinatesProviderDefault.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCITickCoordinatesProvider.h"
#import "SCIAxis2DProtocol.h"

@class SCIArrayController;
@interface SCITickCoordinatesProviderDefault : NSObject <SCITickCoordinatesProviderProtocol> {
    SCIArrayController *_minorTicks;
    SCIArrayController *_majorTicks;
    SCIArrayController *_minorTickCoords;
    SCIArrayController *_majorTickCoords;
    
    double _currOffset;
    double _currAxisSize;
}

@end
