//
//  SCICallbackBlock.h
//  SciChart
//
//  Created by Admin on 16.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#ifndef SciChart_DelegateBlock_h
#define SciChart_DelegateBlock_h

typedef void (^SCIActionBlock) (void);
typedef void (^SCIActionBlock_Pint) (int);

typedef id (^SCIFuncBlock_Rid) (void);
typedef double (^SCIFuncBlock_RdoublePint) (int);
typedef double (^SCIFuncBlock_RdoublePdouble) (double);
typedef bool (^SCIFuncBlock_Rbool) (void);
typedef id (^SCIFunc_RidPidPdoublePdouble) (id, double, double);
typedef id (^SCIFunc_RidPdoublePdouble) (double, double);

typedef id (^SCIFunc_RidP1) (id);
typedef id (^SCIFunc_RidP2) (id, id);
typedef id (^SCIFunc_RidP3) (id, id, id);

#endif
