//
//  RenderPassData.h
//  SciChart
//
//  Created by Admin on 28.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>

@class SCIIndexRange;
@protocol SCIPointSeriesProtocol;
@protocol SCICoordinateCalculatorProtocol;
@protocol SCIDataSeriesProtocol;
@protocol SCIRenderableSeriesProtocol;

#pragma mark - SCIRenderPassData protocol

@protocol SCIRenderPassDataProtocol <NSObject>

@required
-(SCIIndexRange *) pointRange;
-(id<SCIPointSeriesProtocol>) pointSeries;
-(id<SCIDataSeriesProtocol>) dataSeries;
-(id<SCIRenderableSeriesProtocol>) renderableSeries;
-(BOOL) isVerticalChart;
-(id<SCICoordinateCalculatorProtocol>) yCoordinateCalculator;
-(id<SCICoordinateCalculatorProtocol>) xCoordinateCalculator;

@end

#pragma mark - SCIRenderPassData default implementation

@interface SCIRenderPassData : NSObject <SCIRenderPassDataProtocol>

-(id) initWithPointRange:(SCIIndexRange*)pointRange
             PointSeries:(id<SCIPointSeriesProtocol>)pointSeries
              DataSeries:(id<SCIDataSeriesProtocol>)dataSeries
        RenderableSeries:(id<SCIRenderableSeriesProtocol>)renderableSeries
             YCalculator:(id<SCICoordinateCalculatorProtocol>)yCalculator
             XCalculator:(id<SCICoordinateCalculatorProtocol>)xCalculator;

@end
