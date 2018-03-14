//
//  SCICreationAnnotationFactory.h
//  SciChart
//
//  Created by Gkol on 8/10/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIAnnotationProtocol.h"

typedef NSString * SCIAnnotationCreationType NS_EXTENSIBLE_STRING_ENUM;
FOUNDATION_EXPORT SCIAnnotationCreationType _Nonnull const SCILineAnnotationType;
FOUNDATION_EXPORT SCIAnnotationCreationType _Nonnull const SCITextAnnotationType;
FOUNDATION_EXPORT SCIAnnotationCreationType _Nonnull const SCIBoxAnnotationType;

@protocol SCICreationAnnotationFactoryProtocol <NSObject>

- (nullable id<SCIAnnotationProtocol>)createAnnotationForType:(nonnull SCIAnnotationCreationType)annotationType;

@end

@interface SCICreationAnnotationFactory : NSObject <SCICreationAnnotationFactoryProtocol>

@end
