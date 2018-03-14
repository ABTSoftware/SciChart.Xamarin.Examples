//
//  SCIRenderSurface.h
//  SciChart
//
//  Created by Admin on 17.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//
#import "SCIInvalidatableElement.h"
#import <QuartzCore/QuartzCore.h>
#import "SCICallbackBlock.h"
#import "SCIAnimationContextInvalidate.h"
@protocol SCIRenderContext2DProtocol;
@class FrameworkElement;
@protocol SCIRenderSurfaceCallbackDelegateProtocol;
@class UIView;
@class SCIRenderSurfaceStyle;
@protocol SCIRenderSurfaceProtocol <NSObject, SCIInvalidatableElementProtocol, SCIAnimationContextInvalidate>
@property (nonatomic, weak) id<SCIRenderSurfaceCallbackDelegateProtocol> delegate;
@property (nonatomic) BOOL multisampling;
-(void) clear;
-(void) free;
-(void) clearRenderSurface;
-(void) clearModifiers;
-(id<SCIRenderContext2DProtocol>) modifierContext;
-(id<SCIRenderContext2DProtocol>) backgroundContext;
/**
 Context is used for drawing axis grid lines.
 @return Return context in which axis grind lines should be drawn.
 */
-(id<SCIRenderContext2DProtocol>) secondaryContext;
/**
 Render context is used for drawing renderable series in different render loop. There are two render loops in which the context can be used.
 It is animation render loop and main render loop.
 */
-(id<SCIRenderContext2DProtocol>) renderContext;
@property (nonatomic, weak) UIView * chartFrameView;
-(CGRect)frame;
-(CGRect)chartFrame;
-(BOOL) isPointWithinBounds:(CGPoint)point;
-(CGPoint)pointInChartFrame:(CGPoint)point;
-(void) drawBackground:(id<SCIRenderContext2DProtocol>)context Style:(SCIRenderSurfaceStyle*)style;
@property (nonatomic) BOOL reduceCPUFrames;
@property (nonatomic) BOOL reduceGPUFrames;
@property (nonatomic, copy) SCIActionBlock_Pint renderedCallback;
@property (nonatomic) BOOL isTransparent;
@end
