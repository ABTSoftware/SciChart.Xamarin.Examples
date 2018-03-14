//
//  SCIBrushPalettedTexture.h
//  SciChart
//
//  Created by Admin on 08.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIBrush2D.h"
#import "SCITexturedBrush.h"

@interface SCIBrushPalettedTexture : NSObject <SCIBrush2DProtocol, SCITexturedBrushProtocol>

-(instancetype)initWithTexture:(SCITextureOpenGL*)map Palette:(SCITextureOpenGL*)palette;

@property (nonatomic, strong, readonly) SCITextureOpenGL* palette;

@end
