//
//  SCIBrushColoredTexture.h
//  SciChart
//
//  Created by Admin on 28.03.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIBrush2D.h"
#import "SCITexturedBrush.h"

@interface SCIBrushColoredTexture : NSObject <SCIBrush2DProtocol, SCITexturedBrushProtocol>

-(instancetype)initWithTexture:(SCITextureOpenGL*)texture ColorCode:(unsigned int)color;
-(instancetype)initWithTexture:(SCITextureOpenGL*)texture Color:(UIColor *)color;

@end
