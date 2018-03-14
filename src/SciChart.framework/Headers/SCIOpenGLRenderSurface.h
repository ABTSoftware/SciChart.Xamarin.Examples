//
//  SCIOpenGLRenderSurface.h
//  SciChart
//
//  Created by Admin on 18.06.15.
//

#import "SCIRenderSurfaceBase.h"


@interface SCIOpenGLRenderSurface : SCIRenderSurfaceBase 

@property (nonatomic) CGRect projectionFrame;
@property (nonatomic) UIColor *backgroundColor;
@property (nonatomic) int drawingBufferSize;

- (void)free;

@end
