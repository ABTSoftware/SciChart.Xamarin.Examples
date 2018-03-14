//
//  SCIGestureController.h
//  SciChart
//
//  Created by Admin on 04.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@protocol SCIChartSurfaceProtocol;

@interface SCIGestureController : NSObject <UIGestureRecognizerDelegate>

-(id) initWithParent:(id<SCIChartSurfaceProtocol>)parent View:(UIView*)view;

-(void) enablePinchGesture;
-(void) enablePanGesture;
-(void) enableTapGesture;
-(void) enableDoubleTapGesture;

-(void) disablePinchGesture;
-(void) disablePanGesture;
-(void) disableTapGesture;
-(void) disableDoubleTapGesture;

-(void)handlePinchGestureWith:(UIPinchGestureRecognizer*)gesture;
-(void)handlePanGestureWith:(UIPanGestureRecognizer*)gesture;
-(void)handleTapGestureWith:(UITapGestureRecognizer*)gesture;
-(void)handleTapGestureToCancelAnimationWith:(UITapGestureRecognizer*)gesture;
-(void)handleDoubleTapGestureWith:(UITapGestureRecognizer*)gesture;

@end

/** @}*/
