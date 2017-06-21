//
//  SCIArrayController.h
//  SciChart
//
//  Created by Admin on 20.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIArrayControllerProtocol.h"

/**
 * The Class implements only SCIArrayControllerProtocol. More details you can see in SCIArrayControllerProtocol. The class is used by all dataSeries which is not category. The main idea of the class is providing simple interface to work with array of pointers on simple types (e.g. double, integer etc.)
 * @see SCIArrayControllerProtocol
 */
@interface SCIArrayController : NSObject <SCIArrayControllerProtocol> {
    /**
     * Instance variables for private using in classes which inheriting SCIArrayController.
     */
@protected
    /**
     * Array of values.
     */
    void * _data;
    
    /**
     * Max count of current array.
     */
    int _maxSize;
    
    /**
     * Count of values in array.
     */
    int _count;
    
    /**
     * Type of values in array.
     * @see SCIDataType
     */
    SCIDataType _type;
}

@end

/** @}*/
