//
//  SCITickProvider.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

@protocol SCIAxisCoreProtocol;
@class SCIArrayController;

@protocol SCITickProviderProtocol <NSObject>

@required
@property (nonatomic, weak) id<SCIAxisCoreProtocol> axis;
-(SCIArrayController*) getMajorTicksFromAxis:(id<SCIAxisCoreProtocol>)axis;
-(SCIArrayController*) getMinorTicksFromAxis:(id<SCIAxisCoreProtocol>)axis;

@end
