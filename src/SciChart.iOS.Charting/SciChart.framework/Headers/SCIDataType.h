//
//  SCIDataType.h
//  SciChart
//
//  Created by Admin on 09.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#ifndef SciChart_DataTypeEnum_h
#define SciChart_DataTypeEnum_h

#import <Foundation/Foundation.h>

/**
 @file
 */

/**
 @typedef SCIDataType

 @brief Enumeration of SciChart supported types. Defines types of data in SCIGenericType and in SCIArrayController
 @see SCIGenericType
 @see SCIArrayController
 
 @field SCIDataType_None - undefined type
 
 @field SCIDataType_Int16 - short data
 
 @field SCIDataType_Int32 - int data
 
 @field SCIDataType_Int64 - long long data
 
 @field SCIDataType_Byte - char (single byte) data
 
 @field SCIDataType_Float - float data
 
 @field SCIDataType_Double - double data
 
 @field SCIDataType_DateTime - NSDate
 
 @field SCIDataType_VoidPtr - void pointer (not used)
 
 @field SCIDataType_CharPtr - char * array
 
 @field SCIDataType_Int16Ptr - short * array
 
 @field SCIDataType_Int32Ptr - int * array
 
 @field SCIDataType_Int64Ptr - long long * array
 
 @field SCIDataType_FloatPtr - float * array
 
 @field SCIDataType_DoublePtr - double * array
 
 @field SCIDataType_Array - NSArray
 
 @field SCIDataType_Object - NSObject (not NSArray or NSDate)
 */
typedef NS_ENUM(int, SCIDataType) {
    SCIDataType_None,
    
    SCIDataType_Int16,
    SCIDataType_Int32,
    SCIDataType_Int64,
    SCIDataType_Byte,
    SCIDataType_Float,
    SCIDataType_Double,
    SCIDataType_DateTime,
    SCIDataType_SwiftDateTime,
    
    SCIDataType_VoidPtr,
    SCIDataType_CharPtr,
    SCIDataType_Int16Ptr,
    SCIDataType_Int32Ptr,
    SCIDataType_Int64Ptr,
    SCIDataType_FloatPtr,
    SCIDataType_DoublePtr,
    
    SCIDataType_Array,
    SCIDataType_Object
};

#endif
