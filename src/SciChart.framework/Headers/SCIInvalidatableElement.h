//
//  SCIInvalidatableElement.h
//  SciChart
//
//  Created by Admin on 14.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol SCIInvalidatableElementProtocol <NSObject>

@required
-(void) invalidateElement;

@end
