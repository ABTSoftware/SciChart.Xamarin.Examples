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

@protocol SCIRenderContext2DProtocol;
@class FrameworkElement;
@protocol SCIRenderSurfaceCallbackDelegateProtocol;
@class UIView;
@class SCIRenderSurfaceStyle;

@protocol SCIRenderSurfaceProtocol <NSObject, SCIInvalidatableElementProtocol>

@property (nonatomic, weak) id<SCIRenderSurfaceCallbackDelegateProtocol> delegate;
@property (nonatomic) BOOL multisampling;

-(void) clear;
-(void) free;
-(void) clearRenderSurface;
-(void) clearModifiers;

-(id<SCIRenderContext2DProtocol>) renderContext;
-(id<SCIRenderContext2DProtocol>) modifierContext;
-(id<SCIRenderContext2DProtocol>) backgroundContext;

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

//@BEGINDELETE
-(void) resetWatermark;
//@ENDDELETE

@end
