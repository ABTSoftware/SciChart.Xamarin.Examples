//
//  BrushProtocol.h
//  SciChart
//
//  Created by Admin on 11.06.15.
//
//

#import "SCIPathColor.h"

@protocol SCIRenderPassDataProtocol;
@class SCIShaderAttributes;

/**
 @brief Protocol defines brushes for OpenGL drawing
 @see SCIPathColorProtocol
@extends SCIPathColorProtocol
 */
@protocol SCIOpenGLBrushProtocol ///
 <NSObject, SCIPathColorProtocol>
/** @{ @} */

@required
/**
 @brief Returns true if brush has transparency
 */
-(BOOL) hasAlpha;

/**
 @brief Applies brush before drawing.
 @remark For internal use
 */
-(void) apply:(SCIShaderAttributes*)attributes;
/**
 @brief Returns brush shader type code
 @remark For internal use
 */
-(NSUInteger) shaderType;
/**
 @brief Returns true if brushes shader types are eequal. Frequent switching of "not equal" brushes can lead to drawing performance loss.
 */
-(bool) equalsToBrush:(__unsafe_unretained id <SCIOpenGLBrushProtocol>)otherBrush;
/**
 @brief Method for getting color code and brush texture coordinates at specific screen coordinates
 @param color color code. Out parameter
 @param tx texture coordinate X. Out parameter
 @param ty texture coorinate Y. Out parameter
 @param x screen X coordinate
 @param y screen Y coordinate
 */
-(void) getColorCode:(uint*)color TextureX:(float *)tx Y:(float *)ty AtX:(double)x Y:(double)y;
/**
 @brief Returns true if brush color or texture coorinates changes depending on screen coordinates
 */
-(BOOL) variativeColor;

/**
 @brief If that property set to true, brush will get render pass data from renderable series during drawing.
 @discussion It is YES by default for gradient brushes. If you set that property to NO you should provide render pass dara or drawing area by yourself
 */
@property (nonatomic) BOOL requireRenderPassData;
/**
 @brief If brush require render pass data for drawing (gradient brushes) render pass data transfered to brush with that method
 @discussion If you want to call that method manually you should set requireRenderPassData to NO
 */
-(void) setRenderPassData:(id<SCIRenderPassDataProtocol>)data;
/**
 @brief Set drawing area for brush, if brush color changes with coordinates (gradient brush)
 @discussion If you want to call that method you should set requireRenderPassData to NO, otherwise area setting will be replaced with render pass data
 */
-(void) setDrawingAreaX:(double)x Y:(double)y Width:(double)width Height:(double)height;

@end
