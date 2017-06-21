//
//  SCIAxisAreaSizeSyncronization.h
//  SciChart
//
//  Created by Admin on 18/07/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>

typedef NS_OPTIONS(int, SCIAxisSizeSyncMode) {
    SCIAxisSizeSync_Left = 1 << 0,
    SCIAxisSizeSync_Right = 1 << 1,
    SCIAxisSizeSync_Top = 1 << 2,
    SCIAxisSizeSync_Bottom = 1 << 3
};

@protocol SCIChartSurfaceProtocol;

@interface SCIAxisAreaSizeSynchronization : NSObject

-(void) attachSurface:(id<SCIChartSurfaceProtocol>)surface;
-(void) detachSurface:(id<SCIChartSurfaceProtocol>)surface;

@property (nonatomic) SCIAxisSizeSyncMode syncMode;

@end

/** @}*/
