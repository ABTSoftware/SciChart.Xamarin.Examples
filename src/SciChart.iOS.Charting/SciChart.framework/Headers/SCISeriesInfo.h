//
//  SeriesInfo.h
//  SciChart
//
//  Created by Admin on 08.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup SeriesInfo
 *  @{
 */

#import <Foundation/Foundation.h>
#import <QuartzCore/QuartzCore.h>
#import "SCIGenericType.h"
#import "SCIDataSeries.h"
#import "SCIHitTestProviderBase.h"

@protocol SCIRenderableSeriesProtocol;
@protocol SCIPathColorProtocol;
@class UIView;
@class SCITooltipDataView;

@interface SCISeriesInfo : NSObject {
@protected
    id<SCIRenderableSeriesProtocol> _rSeries;
    NSString * _seriesName;
    SCIGenericType _xValue;
    SCIGenericType _yValue;
    SCIDataSeriesType _dataSeriesType;
    BOOL _isHit;
    int _dataSeriesIndex;
    
    id<SCIPathColorProtocol> _seriesColor;
}

@property (nonatomic, strong) NSNumberFormatter *numberFormatter;
@property (nonatomic, strong) NSDateFormatter *dateTimeFormatter;

-(instancetype)initWithSeries:(id<SCIRenderableSeriesProtocol>)series HitTest:(SCIHitTestInfo)hitTest;

-(id<SCIRenderableSeriesProtocol>) renderableSeries;
-(NSString *) seriesName;
-(SCIGenericType) xValue;
-(SCIGenericType) yValue;
-(SCIDataSeriesType) dataSeriesType;
-(BOOL) isHit;
-(int) dataSeriesIndex;

-(unsigned int) seriesColor;
-(unsigned int) seriesColorAtX:(double)x Y:(double)y;

-(SCITooltipDataView *) createDataSeriesView;

- (NSString*)fortmatterdValueFromSeriesInfo:(SCIGenericType)data forDataType:(SCIDataType)dataType;

@end

/** @}*/
