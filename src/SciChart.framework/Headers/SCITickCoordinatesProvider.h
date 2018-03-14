//
//  ITickCoordinateProvider.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

@protocol SCIAxisCoreProtocol;
@class SCITickCoordinates;

@protocol SCITickCoordinatesProviderProtocol <NSObject>


@property (nonatomic, weak) id<SCIAxisCoreProtocol> parentAxis;
-(void) setAxis:(id<SCIAxisCoreProtocol>)parentAxis;
-(SCITickCoordinates*) getTickCoordinatesWithMinorTicks:(double*)minorTicks Count:(int)minorCount
                                          MajorTicks:(double*)majorTicks Count:(int)majorCount;

@end
