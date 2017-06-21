//
//  SCITextureBrushStyle.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 2/19/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIBrushStyle.h"

@class SCITextureOpenGL;

@interface SCITextureBrushStyle : SCIBrushStyle

-(nonnull instancetype)initWithTexture:(nonnull SCITextureOpenGL*)texture;

-(nonnull instancetype)initWithTexture:(nonnull SCITextureOpenGL*)texture colorCode:(unsigned int)color;

-(nonnull instancetype)initWithTexture:(nonnull SCITextureOpenGL*)texture color:(nonnull UIColor *)color;

@property (nonatomic, strong, nonnull) SCITextureOpenGL* texture;

@end
