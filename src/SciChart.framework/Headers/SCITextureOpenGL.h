//
//  SCITextureOpenGL.h
//  SciChart
//
//  Created by Admin on 05.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <OpenGLES/ES2/gl.h>
#import <CoreGraphics/CoreGraphics.h>

@class UIImage, UIColor;
@protocol SCIRenderContext2DProtocol;
@interface SCITextureOpenGL : NSObject

@property (nonatomic) NSArray <UIColor *> *colors;
@property (nonatomic) NSArray <NSNumber *> *stops;
@property (nonatomic) CGSize textureSize;

-(instancetype)initWithId:(GLuint)textureId;
-(instancetype)initWithByteData:(GLubyte*)data Width:(int)width Height:(int)height;
-(instancetype)initWithByteData:(GLubyte*)data Width:(int)width Height:(int)height WrapParameter:(GLint)wrapParameter;
-(instancetype)initWithImage:(UIImage*)image;
-(instancetype)initWithFloatData:(GLfloat*)data Width:(int)width Height:(int)height;
-(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count;
-(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count Detalization:(int)detalization;

-(instancetype)initWithByteData:(GLubyte*)data Width:(int)width Height:(int)height Context:(id<SCIRenderContext2DProtocol>)context;
-(instancetype)initWithImage:(UIImage*)image Context:(id<SCIRenderContext2DProtocol>)context;
-(instancetype)initWithFloatData:(GLfloat*)data Width:(int)width Height:(int)height Context:(id<SCIRenderContext2DProtocol>)context;
-(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count Context:(id<SCIRenderContext2DProtocol>)context;
-(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count Detalization:(int)detalization Context:(id<SCIRenderContext2DProtocol>)context;

-(void)updateWithByteData:(GLubyte*)data Width:(int)width Height:(int)height;
-(void)updateWithFloatData:(GLfloat*)data Width:(int)width Height:(int)height;

-(GLuint)textureId;
-(BOOL) isValid;

@end
