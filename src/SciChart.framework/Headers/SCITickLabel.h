//
//  SCITickLabel.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

@protocol SCITickLabelProtocol <NSObject>

@property (nonatomic) BOOL hasExponent;
@property (nonatomic, copy) NSString * separator;
@property (nonatomic, copy) NSString * exponent;
@property (nonatomic, copy) NSString * text;

@end
