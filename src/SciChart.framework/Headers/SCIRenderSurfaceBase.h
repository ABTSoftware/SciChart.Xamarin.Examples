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

-(void) onRenderTimeElapsed;

-(void) addRenderContext:(id<SCIRenderContext2DProtocol>)context;
-(void) addSecondaryRenderContext:(id<SCIRenderContext2DProtocol>)context;
-(void) addModifierContext:(id<SCIRenderContext2DProtocol>)context;
-(void) addBackgroundContext:(id<SCIRenderContext2DProtocol>)context;

-(BOOL) needRedraw;

@end
