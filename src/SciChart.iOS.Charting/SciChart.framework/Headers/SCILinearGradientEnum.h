//
//  SCILinearGradientEnum.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 2/19/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#ifndef SCILinearGradientEnum_h
#define SCILinearGradientEnum_h

/**
 @typedef SCILinearGradientDirection
 @brief Enum provides linear gradient directions
 
 @field SCILinearGradientDirection_Vertical color changes from top to bottom
 
 @field SCILinearGradientDirection_Horizontal color changes from left to right
 */
typedef NS_ENUM(int, SCILinearGradientDirection) {
    /** color changes from top to bottom */
    SCILinearGradientDirection_Vertical,
    /** color changes from left to right */
    SCILinearGradientDirection_Horizontal
};

#endif /* SCILinearGradientEnum_h */
