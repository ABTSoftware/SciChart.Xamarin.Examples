//
//  SCICollectionObserver.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 6/15/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCICollectionChangedEventArgs.h"

@interface SCICollectionObserver : NSObject

- (instancetype _Nonnull )initWithCollectionChangedBlock:(SCICollectionChangedCallback _Nonnull )block;

@property (nonatomic, copy, nonnull) SCICollectionChangedCallback onCollectionChanged;

@end
