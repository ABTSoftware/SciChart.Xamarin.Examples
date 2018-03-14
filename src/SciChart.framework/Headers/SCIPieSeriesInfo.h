//
//  SCIPieSeriesInfo.h
//  SciChart
//
//  Created by Admin on 30/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>

@class SCIPieSegment;
@protocol SCIPieRenderableSeriesProtocol;
@class SCIPieHitTestInfo;
@class SCIPieSeriesDataView;

@interface SCIPieSeriesInfo : NSObject {
    @protected
    int _segmentIndex;
    id<SCIPieRenderableSeriesProtocol> _rSeries;
    SCIPieSegment * _segment;
    double _totalValue;
    double _segmentValue;
    BOOL _isHit;
    NSString * _seriesName;
    NSString * _segmentTitle;
}

@property (nonatomic, strong) NSNumberFormatter *numberFormatter;

-(id<SCIPieRenderableSeriesProtocol>) series;
-(SCIPieSegment*)segment;
-(int)segmentIndex;
-(double) totalValue;
-(double) segmentValue;
-(BOOL) isHit;
-(NSString*) seriesName;
-(NSString*) segmentTitle;

-(instancetype)initWithHitTest:(SCIPieHitTestInfo*)hitTest;

-(SCIPieSeriesDataView *) createDataSeriesView;

- (NSString*)fortmattedValueFromSeriesInfo;

@end
