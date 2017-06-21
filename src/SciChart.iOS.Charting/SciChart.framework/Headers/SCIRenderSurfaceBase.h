//
//  SCIRenderSurfaceBase.h
//  SciChart
//
//  Created by Admin on 22.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Foundation/Foundation.h>
#import "SCIRenderSurface.h"

@interface SCIRenderSurfaceBase : UIView <SCIRenderSurfaceProtocol> {
@protected
    BOOL _multisampling;
}

@property (nonatomic) BOOL multisampling;

-(void) onRenderTimeElapsed;

@property (nonatomic, weak) id<SCIRenderSurfaceCallbackDelegateProtocol> delegate;

@property (nonatomic, weak) UIView * chartFrameView;

-(CGRect)chartFrame;
-(CGPoint)pointInChartFrame:(CGPoint)point;

@property (nonatomic) BOOL reduceCPUFrames;
@property (nonatomic) BOOL reduceGPUFrames;

-(void) addRenderContext:(id<SCIRenderContext2DProtocol>)context;
-(void) addModifierContext:(id<SCIRenderContext2DProtocol>)context;
-(void) addBackgroundContext:(id<SCIRenderContext2DProtocol>)context;

-(BOOL) needRedraw;

@property (nonatomic) BOOL isTransparent;

@property (nonatomic, copy) SCIActionBlock_Pint renderedCallback;

@end
