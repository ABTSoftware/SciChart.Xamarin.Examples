//
//  CoordinateCalculatorBase.h
//  SciChart
//
//  Created by Admin on 16.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup CoordinateCalculators
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICoordinateCalculatorProtocol.h"

typedef NS_OPTIONS(int, CoordinateCalculatorOptions) {
    CoordinateCalculator_XAxis = 1,
    CoordinateCalculator_YAxis = 2,
    CoordinateCalculator_CategoryAxis = 4,
    CoordinateCalculator_LogarithmicAxis = 8,
    CoordinateCalculator_HorizontalAxis = 16,
    CoordinateCalculator_Flipped = 32
};

@protocol SCIRangeProtocol;

@interface SCICoordinateCalculatorBase : NSObject <SCICoordinateCalculatorProtocol>

@property (nonatomic) BOOL isCategoryAxisCalculator;
@property (nonatomic) BOOL isLogarithmicAxisCalculator;
@property (nonatomic) BOOL isHorizontalAxisCalculator;
@property (nonatomic) BOOL isXAxisCalculator;
@property (nonatomic) BOOL hasFlippedCoordinates;
@property (nonatomic) BOOL isPolarAxisCalculator;

-(double) getCoordinateFromDate:(NSDate *)dataValue;
-(id<SCIRangeProtocol>) translateByPixels:(double)pixels InputRange:(id<SCIRangeProtocol>)inputRange;
-(double) getDataValueFrom:(double)pixelCoordinate;
-(id<SCIRangeProtocol>) translateByMinFraction:(double)minFraction MaxFraction:(double)maxFraction InputRange:(id<SCIRangeProtocol>)inputRange;
+(double) flip:(BOOL)flipCoords Coords:(double)coord WithViewPortDimension:(double)viewportDimension;

-(void)setCoordinatesOffset:(double)value;

@end

/** @}*/