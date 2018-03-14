//
//  SCILabelProvider.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import "SCIGenericType.h"
@protocol SCIAxisCoreProtocol;
@protocol SCITickLabelProtocol;
@class SCITextFormattingStyle;
@class SCIDefaultTickLabel;

@protocol SCILabelProviderProtocol <NSObject>

-(void) setAxis:(id<SCIAxisCoreProtocol>)parentAxis;
-(void) onBeginAxisDraw;
-(id<SCITickLabelProtocol>) updateDataContextWithContext:(SCIDefaultTickLabel*)label Data:(SCIGenericType)dataValue Style:(SCITextFormattingStyle*)style;
-(NSString *) formatLabel:(SCIGenericType)dataValue;
-(NSString *) formatCursorLabel:(SCIGenericType)dataValue;

@end
