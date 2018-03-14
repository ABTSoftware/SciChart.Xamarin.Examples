using Foundation;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIActionBlock)();
    delegate void SCIActionBlock();

    // typedef void (^SCIActionBlock_Pint)(int);
    delegate void SCIActionBlock_Pint(int arg0);

    // typedef id (^SCIFuncBlock_Rid)();
    delegate NSObject SCIFuncBlock_Rid();

    // typedef double (^SCIFuncBlock_RdoublePint)(int);
    delegate double SCIFuncBlock_RdoublePint(int arg0);

    // typedef double (^SCIFuncBlock_RdoublePdouble)(double);
    delegate double SCIFuncBlock_RdoublePdouble(double arg0);

    // typedef _Bool (^SCIFuncBlock_Rbool)();
    delegate bool SCIFuncBlock_Rbool();

    // typedef id (^SCIFunc_RidPidPdoublePdouble)(id, double, double);
    delegate NSObject SCIFunc_RidPidPdoublePdouble(NSObject arg0, double arg1, double arg2);

    // typedef id (^SCIFunc_RidPdoublePdouble)(double, double);
    delegate NSObject SCIFunc_RidPdoublePdouble(double arg0, double arg1);

    // typedef id (^SCIFunc_RidP1)(id);
    delegate NSObject SCIFunc_RidP1(NSObject arg0);

    // typedef id (^SCIFunc_RidP2)(id, id);
    delegate NSObject SCIFunc_RidP2(NSObject arg0, NSObject arg1);

    // typedef id (^SCIFunc_RidP3)(id, id, id);
    delegate NSObject SCIFunc_RidP3(NSObject arg0, NSObject arg1, NSObject arg2);
}