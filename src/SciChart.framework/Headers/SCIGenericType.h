//
//  SCIGenericType.h
//  SciChart
//
//  Created by Admin on 15.09.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#ifndef SciChart_GenericType_h
#define SciChart_GenericType_h

/** \addtogroup SCIGenericType
 *  @{
 */

/**
 @file
 @brief Description of SCIGenerciType structure and functions for work with it
 */

#import "SCIDataType.h"

/**
 @brief Objective-C macro that constructs SCIGenericType from variable, literal or pointer to head of array
 @code
 SCIGenericType one = SCIGeneric(1);
 double varTwo = 2;
 SCIGenericType two = SCIGeneric(varTwo);
 SCIGenericType date = SCIGeneric([NSDate date]);
 double array[] = {1.0, 2.0, 3.0};
 SCIGenericType cArray = SCIGeneric( (double *) array );
 @endcode
 */
// TODO: resolve trouble. In current version arrays have to be casted to pointers. If remove typeof(x) _tm_x = x; will not be able to use numeric literals
#define SCIGeneric(x) ({ typeof(x) _tm_x = (x); SCI_constructGenericType( &_tm_x, @encode( typeof (_tm_x) ) ); })

#if __NATIVESCRIPT_METADATA_GENERATOR
typedef struct {
    SCIDataType type;
    long long dummy;   // This is not really used by ANYTHING in NativeScript, just to allocate space.
} SCIGenericType;
#else
/**
 @typedef SCIGenericType
 
 @brief Structure contains data and information about type
 
 @discussion Structure contains various fields of different types, but they are overlapping in memory, so only one of them is valid at same time
 @discussion You can access fields in that structure manually, but it is recommended to be created with method SCIGeneric() and accessed with methods SCIGenerciInt(), SCIGenericDouble() and the others
 
 @code
 let generic1 = SCIGeneric(0)
 let variable = 1
 let generic2 = SCIGeneric( variable )
 let generic3 = SCIGeneric( NSDate() )
 
 let doubleVariable = SCIGenericDouble(generic1)
 let intVariable = SCIGenericInt(generic2)
 let floatVariable = SCIGenericFloat(generic2)
 let date = SCIGenericDate(generic3)
 let timeIntervalSince1970 = SCIGenericDouble(generic3)
 @endcode
 
 @see SCIDataType
 @see SCIGeneric
 @see SCIGenericInt
 @see SCIGenericShort
 @see SCIGenericLong
 @see SCIGenericChar
 @see SCIGenericFloat
 @see SCIGenericDouble
 @see SCIGenericDate
 @see SCIGenericArray
 @see SCIGenericIntPtr
 @see SCIGenericCharPtr
 @see SCIGenericShortPtr
 @see SCIGenericLongPtr
 @see SCIGenericFloatPtr
 @see SCIGenericDoublePtr
 
 @field type SCIDataType information about type
 
 @field charData char data
 
 @field int16Data short data
 
 @field int32Data int data
 
 @field int64Data long long data
 
 @field floatData float data

 @field doubleData double data or NSTimeInterval in seconds since 1970

 @field voidPtr void * pointer to undefined type. Value that can not be processed
 
 @field charPtr char * pointer to char array. Do not use for storring pointers for long time for memory safety reasons
 
 @field int16Ptr short * pointer to short array. Do not use for storring pointers for long time for memory safety reasons
 
 @field int32Ptr int * pointer to int array. Do not use for storring pointers for long time for memory safety reasons
 
 @field int64Ptr long long * pointer to long long array. Do not use for storring pointers for long time for memory safety reasons
 
 @field floatPtr float * pointer to float array. Do not use for storring pointers for long time for memory safety reasons
 
 @field doublePtr double * pointer to double array. Do not use for storring pointers for long time for memory safety reasons
 */
typedef struct {
    /** SCIDataType information about type */
    SCIDataType type;
    union {
        /** char data. Is valid if type = SCIDataType_Byte */
        char charData;
        /** short data. Is valid if type = SCIDataType_Int16 */
        short int16Data;
        /** int data. Is valid if type = SCIDataType_Int32 */
        int int32Data;
        /** long long data. Is valid if type = SCIDataType_Int64 */
        long long int64Data;
        /** float data. Is valid if type = SCIDataType_Float */
        float floatData;
        /** double data or NSTimeInterval in seconds since 1970. Is valid if type = SCIDataType_Double or type = SCIDataType_DateTime */
        double doubleData;
        
        /** contains pointer to NSArray if type = SCIDataType_Array, or other NSObject if type = SCIDataType_Object */
        void * voidPtr;
        /** pointer to char array. Is valid if type = SCIDataType_CharPtr */
        char * charPtr;
        /** pointer to short array. Is valid if type = SCIDataType_Int16Ptr */
        short * int16Ptr;
        /** pointer to int array. Is valid if type = SCIDataType_Int32Ptr */
        int * int32Ptr;
        /** pointer to long long array. Is valid if type = SCIDataType_Int64Ptr */
        long long * int64Ptr;
        /** pointer to float array. Is valid if type = SCIDataType_FloatPtr */
        float * floatPtr;
        /** pointer to double array. Is valid if type = SCIDataType_DoublePtr */
        double * doublePtr;
    };
    
} SCIGenericType;
#endif
/**
 @typedef SCIGenericEquationResult
 @brief Possible results of SCIGenericType equation
 
 @field SCIGeneric_NotEqual values are not equal and cannot be compared, for example pointers to different locations in memory or with different types
 
 @field SCIGeneric_Equal values are equal
 
 @field SCIGeneric_Lesser first value is lesser than second
 
 @field SCIGeneric_Greater first value is greater than second
 
 @see SCIGenericCompare
 @see SCIGenericType
 */
typedef NS_ENUM(int, SCIGenericEquationResult) {
    /** Values are not equal and cannot be compared, for example pointers to different locations in memory or with different types */
    SCIGeneric_NotEqual,
    /** Values are equal */
    SCIGeneric_Equal,
    /** First value is lesser than second */
    SCIGeneric_Lesser,
    /** First value is greater than second */
    SCIGeneric_Greater
};

/**
 @brief Function compares two SCIGenericType structures.
 @remark That function is for internal use.
 
 @discussion If one of two params is reference and second param is not a reference to the same memory with the same type information, values considered not equal, otherwise they are equal.
 @discussion If first param has type info SCIDataType_DateTime and second param is not date or double, then result of equation is not equal. Otherwise first param can be equal, lesser or greater than second param based on NSTimeInterval comparison
 @discussion If one of params is float or double both params will be converted to double and compared. Possible results is equal, greater or lesser
 @discussion If params are integer types they will be converted to long long and compared. Possible results is equal, greater or lesser
 
 @param x SCIGenericType first value to compare
 @param y SCIGenericType second value to compare
 @return SCIGenericEquationResult
 
 @see SCIGenericType
 @see SCIGenericEquationResult
 */
SCIGenericEquationResult SCIGenericCompare(SCIGenericType x, SCIGenericType y);

/**
 @brief Function constructs SCIGenericType
 @remark For internal use only. It is used in Objective-C in SCIGeneric() macro
 @param data Void pointer to value received in macro.
 @param type Information about value type received from \@encode()
 @return SCIGenericType structure with data and type information
 @see SCIGenericType
 */
SCIGenericType SCI_constructGenericType(void * data, char * type);

/**
 @brief Function constructs SCIGenericType
 @remark For internal use only. It is used in Swift in SCIGeneric() function
 @param data Void pointer to value
 @param type SCIDataType information about value type
 @return SCIGenericType structure with data and type information
 @see SCIGenericType
 @see SCIDataType
 */
SCIGenericType SCI_constructGenericTypeWithInfo(void * data, SCIDataType type);

/**
 @brief Function detects is data in SCIGenericType is copied. It returns true for value types and false for reference types
 @remark For internal use.
 @discussion SCIGenerciType not designed for storing data but for transition of data through API. If SCIIsSafeGeneric returns true, it is safe to keep value, otherwise you should not keep SCIGenericType value outside of scope of current function
 @see SCIGenericType
 */
BOOL SCIIsSafeGeneric(SCIGenericType x);

/**
 @brief Function extracts int value from SCIGenericType. Float types will be cast to integer type
 @discussion Function does not throw exceptions. If data in SCIGenericType is not numeric it returns 0.
 @see SCIGenericType
 */
int SCIGenericInt(SCIGenericType x);
/**
 @brief Function extracts char (single byte) value from SCIGenericType. Float types will be cast to integer type
 @discussion Function does not throw exceptions. If data in SCIGenericType is not numeric it returns 0.
 @see SCIGenericType
 */
char SCIGenericChar(SCIGenericType x);
/**
 @brief Function extracts short value from SCIGenericType. Float types will be cast to integer type
 @discussion Function does not throw exceptions. If data in SCIGenericType is not numeric it returns 0.
 @see SCIGenericType
 */
short SCIGenericShort(SCIGenericType x);
/**
 @brief Function extracts long long value from SCIGenericType. Float types will be cast to integer type
 @discussion Function does not throw exceptions. If data in SCIGenericType is not numeric it returns 0.
 @see SCIGenericType
 */
long long SCIGenericLong(SCIGenericType x);
/**
 @brief Function extracts float value from SCIGenericType.
 @discussion Function does not throw exceptions. If data in SCIGenericType is not numeric it returns NAN.
 @see SCIGenericType
 */
float SCIGenericFloat(SCIGenericType x);
/**
 @brief Function extracts double value from SCIGenericType. If data is date, it returns time interval since 1970.
 @discussion Function does not throw exceptions. If data in SCIGenericType is not numeric it returns NAN.
 @see SCIGenericType
 */
double SCIGenericDouble(SCIGenericType x);

/**
 @brief If data in SCIGenericType is int * it returns pointer, otherwise it returns nil
 @see SCIGenericType
 */
int * SCIGenericIntPtr(SCIGenericType x);
/**
 @brief If data in SCIGenericType is char * it returns pointer, otherwise it returns nil
 @see SCIGenericType
 */
char * SCIGenericCharPtr(SCIGenericType x);
/**
 @brief If data in SCIGenericType is short * it returns pointer, otherwise it returns nil
 @see SCIGenericType
 */
short * SCIGenericShortPtr(SCIGenericType x);
/**
 @brief If data in SCIGenericType is long long * it returns pointer, otherwise it returns nil
 @see SCIGenericType
 */
long long * SCIGenericLongPtr(SCIGenericType x);
/**
 @brief If data in SCIGenericType is float * it returns pointer, otherwise it returns nil
 @see SCIGenericType
 */
float * SCIGenericFloatPtr(SCIGenericType x);
/**
 @brief If data in SCIGenericType is double * it returns pointer, otherwise it returns nil
 @see SCIGenericType
 */
double * SCIGenericDoublePtr(SCIGenericType x);

/**
 @brief Function converts SCIGenericType to NSDate. Returns nil if conversion is not possible.
 @discussion If SCIGenericType contains float, double, int or short data it is considered as time interval since 1970.
 @see SCIGenericType
 */
NSDate * SCIGenericDate(SCIGenericType x);
/**
 @brief Function returns pointer to NSArray if SCIGenericType contains it, otherwise it returns nil
 @see SCIGenericType
 */
NSArray * SCIGenericArray(SCIGenericType x);

/**
 @brief Function returns size of type contained in SCIGenericType
 @discussion It does not return size of array but size of type that pointer points to.
 @see SCIGenericType
 */
int SCIGenericSize(SCIGenericType value);

#endif

/** @} */
