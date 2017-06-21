//
//  SCIPaletteProvider.h
//  SciChart
//
//  Created by Admin on 10/08/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>

@protocol SCIStyleProtocol;
@protocol SCIRenderPassDataProtocol;

/**
 * SCIPaletteProvider - tool that allows switching renderable series style dependant on data point coordinates or index
 */
@protocol SCIPaletteProviderProtocol ///
<NSObject>
/** @{ @} */

/**
 * Method is called before renderable series drawing. Use it to get required render pass data
 * @param data SCIRenderPassData that will be used in current render frame
 * @see SCIRenderPassDataProtocol
 */
-(void)updateData:(id<SCIRenderPassDataProtocol>)data;
/**
 * Method is called for every data point on screen
 * @discussion if you need to get data X and Y from screen coordinates you can use SCICoordinateCalculator from SCIRenderPassData or get values from SCIDataSeries by index
 * @param x horizontal position on screen
 * @param y vertical position on screnn
 * @param index index of data point in data series
 * @return SCIStyleProtocol should be a valid style for renderable series you are using, or nil if you need default renderable series style for current data point
 */
-(id<SCIStyleProtocol>)styleForX:(double)x Y:(double)y Index:(int)index;

@end

/**
 * SCIPaletteProvider - tool that allows switching renderable series style dependant on data point coordinates or index
 */
@interface SCIPaletteProvider : NSObject <SCIPaletteProviderProtocol> {
    @protected
    /**
     * variable contains data for current render frame if default "updateData:" implementation was not overriden
     * @see SCIRenderPassDataProtocol
     */
    id<SCIRenderPassDataProtocol> _data;
}

@end

/** @} */