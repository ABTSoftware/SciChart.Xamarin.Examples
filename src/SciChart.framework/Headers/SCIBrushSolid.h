//
//  SCIBrushSolid.h
//  SciChart
//
//  Created by Admin on 09.06.15.
//
//

#import <Foundation/Foundation.h>
#import "SCIBrush2D.h"

/**
 @brief Brush with solid color fill
 @see SCIBrush2DProtocol
 */
@interface SCIBrushSolid : NSObject <SCIBrush2DProtocol>

/**
 @brief Constructor creates brush with given color
 */
-(id) initWithColor:(UIColor*)color;
/**
 @brief Constructor creates brush with given color code. Color code byte order is 0xAABBGGRR
 */
-(id) initWithColorCode:(unsigned int)color;

@end
