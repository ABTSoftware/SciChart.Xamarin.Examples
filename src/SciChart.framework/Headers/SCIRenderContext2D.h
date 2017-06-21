//
//  SCIRenderContext2D.h
//  SciChart
//
//  Created by Admin on 14.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <QuartzCore/QuartzCore.h>
#import "SCICallbackBlock.h"

@protocol SCIBrushStyleProtocol;
@protocol SCIBrush2DProtocol;
@protocol SCIPenStyleProtocol;
@protocol SCIPen2DProtocol;
@protocol SCIOpenGLBrushProtocol;
@class CC3GLMatrix;
@protocol SCIRenderSurfaceProtocol;
@class SCIArrayController;

@protocol SCIRenderContext2DProtocol <NSObject>

-(void) invalidate;
@property (nonatomic, copy) SCIActionBlock invalidated;

@property (nonatomic, weak) id<SCIRenderSurfaceProtocol> parentRenderSurface;

@property (nonatomic) BOOL wasChanged;

-(CGSize) viewportSize;

-(void) clear;

-(void)performDrawingCommands;

#pragma mark - separated primitives

-(void)drawLineWithBrush:(__unsafe_unretained id<SCIPen2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY;

-(void)drawRectWithBrush:(__unsafe_unretained id<SCIBrush2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY;

-(void)drawTriangleWithBrush:(__unsafe_unretained id<SCIBrush2DProtocol>)brush X1:(float)x1 Y1:(float)y1 X2:(float)x2 Y2:(float)y2 X3:(float)x3 Y3:(float)y3;

// ArrayControllers have to be Float and with size = details
-(void)renderEllipseToBufferX:(__unsafe_unretained SCIArrayController*)xBuffer Y:(__unsafe_unretained SCIArrayController*)yBuffer
               RadiusVertical:(float)radiusV RadiusHorizontal:(float)radiusH Detalization:(int)details;
-(void)drawEllipseWithBrush:(__unsafe_unretained id<SCIBrush2DProtocol>)brush WithCenterX:(float)cx Y:(float)cy
                      XData:(__unsafe_unretained SCIArrayController*)xData YData:(__unsafe_unretained SCIArrayController*)yData;

-(void)drawSpriteWithBrush:(__unsafe_unretained id<SCIBrush2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY;
-(void)drawSpriteWithBrush:(__unsafe_unretained id<SCIBrush2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY swapVertically:(BOOL)swapVertically swapHorizontally:(BOOL)swapHorizontally andSwapedAxesPlaces:(BOOL)axesSwaped;

#pragma mark - continuous primitives

-(void)beginPolylineWithBrush:(__unsafe_unretained id<SCIPen2DProtocol>)brush withPointX:(float)X Y:(float)Y;
-(void)extendPolylineWithBrush:(__unsafe_unretained id<SCIPen2DProtocol>)brush withPointX:(float)X Y:(float)Y;
-(void) drawPolylineWithBrush:(__unsafe_unretained id <SCIPen2DProtocol>)brush
                   WithXData:(__unsafe_unretained SCIArrayController *)xArray
                       YData:(__unsafe_unretained SCIArrayController *)yArray
               StartingIndex:(int)startingIndex;

-(void)beginZeroToLineAreaWithBrush:(__unsafe_unretained id<SCIBrush2DProtocol>)brush withPointX:(float)X Y:(float)Y Zero:(float)zero IsVertical:(BOOL)isVertical;
-(void)extendZeroToLineAreaWithBrush:(__unsafe_unretained id<SCIBrush2DProtocol>)brush withPointX:(float)X Y:(float)Y Zero:(float)zero IsVertical:(BOOL)isVertical;

-(void)beginBandAreaWithBrush1:(__unsafe_unretained id<SCIBrush2DProtocol>)brush1 Brush2:(__unsafe_unretained id<SCIBrush2DProtocol>)brush2
                    withPointX:(float)X Y1:(float)Y1 Y2:(float)Y2 IsVertical:(BOOL)isVertical;
-(void)extendBandAreaWithBrush1:(__unsafe_unretained id<SCIBrush2DProtocol>)brush1 Brush2:(__unsafe_unretained id<SCIBrush2DProtocol>)brush2
                     withPointX:(float)X Y1:(float)Y1 Y2:(float)Y2 IsVertical:(BOOL)isVertical;


#pragma mark - service commands

-(void)beginNewPrimitive;

-(void)setDrawingArea:(CGRect)frame;

-(id<SCIPen2DProtocol>)createPenFromStyle:(id<SCIPenStyleProtocol>)style;
-(id<SCIBrush2DProtocol>)createBrushFromStyle:(id<SCIBrushStyleProtocol>)style;

@end
