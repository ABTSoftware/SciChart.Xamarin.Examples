//
//  SCIAnnotationCreationModifier.h
//  SciChart
//
//  Created by Gkol on 8/4/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIGestureModifier.h"
#import "SCICreationAnnotationFactory.h"
#import "SCIAnnotationProtocol.h"

@protocol SCIStyleProtocol;

typedef void(^SCIAnnotationCreationHandler)(_Nonnull id<SCIAnnotationProtocol>, _Nonnull SCIAnnotationCreationType);

@interface SCIAnnotationCreationModifier : SCIGestureModifier

@property (nonatomic, nonnull) SCICreationAnnotationFactory *annotationsFactory;

@property (nonatomic, nonnull) SCIAnnotationCreationType annotationType;

@property (nonatomic, nullable) id<SCIStyleProtocol> style;

/**
 * Gets or sets the ID of the X-Axis which this Annotation is measured against
 */
@property (nonatomic, copy, nullable) NSString * xAxisId;

/**
 * Gets or sets the ID of the Y-Axis which this Annotation is measured against
 */
@property (nonatomic, copy, nullable) NSString * yAxisId;

@property (nonatomic, copy, nullable) SCIAnnotationCreationHandler creationHanlder;

- (nonnull instancetype)initWithAnnotationType:(nonnull SCIAnnotationCreationType)annotationType;

@end
