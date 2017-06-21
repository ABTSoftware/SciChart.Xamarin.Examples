using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    [BaseType(typeof(NSObject))]
    interface SCIXamarinMessageResolver
    {
        [Static, Export("sendMessagePointGG:Method:P1:P2:")]
        CGPoint sendMessagePointGG(NSObject target, NSString method, Double p1, Double p2);

        [Static, Export("sendMessageSG:Method:P1:")]
        NSString sendMessageSG(NSObject target, NSString method, Double p1);

        [Static, Export("sendMessageGI:Method:P1:")]
        double sendMessageGI(NSObject target, NSString method, int p1);

        [Static, Export("sendMessageGII:Method:P1:P2:")]
        double sendMessageGII(NSObject target, NSString method, int p1, int p2);

        [Static, Export("sendMessageGD:Method:P1:")]
        double sendMessageGD(NSObject target, NSString method, Double p1);

        [Static, Export("sendMessagePGG:Method:P1:P2:")]
        NSObject sendMessagePGG(NSObject target, NSString method, Double p1, Double p2);

        [Static, Export("sendMessageVG:Method:P1:")]
        void sendMessageVG(NSObject target, NSString method, Double p1);

        [Static, Export("sendMessageVIIP:Method:P1:P2:P3:Type3:")]
        void sendMessageVIIP(NSObject target, NSString method, int p1, int p2, IntPtr p3, SCIDataType t3);

        [Static, Export("sendMessageVGI:Method:P1:P2:")]
        void sendMessageVGI(NSObject target, NSString method, Double p1, int p2);

        [Static, Export("sendMessageVGII:Method:P1:P2:P3:")]
        void sendMessageVGII(NSObject target, NSString method, Double p1, int p2, int p3);

        [Static, Export("sendMessageVGG:Method:P1:P2:")]
        void sendMessageVGG(NSObject target, NSString method, Double p1, Double p2);

        [Static, Export("sendMessageVGGGGG:Method:P1:P2:P3:P4:P5:")]
        void sendMessageVGGGGG(NSObject target, NSString method, Double p1, Double p2, Double p3, Double p4, Double p5);

        [Static, Export("sendMessageVGGGG:Method:P1:P2:P3:P4:")]
        void sendMessageVGGGG(NSObject target, NSString method, Double p1, Double p2, Double p3, Double p4);

        [Static, Export("sendMessageVGGG:Method:P1:P2:P3:")]
        void sendMessageVGGG(NSObject target, NSString method, Double p1, Double p2, Double p3);

        [Static, Export("sendMessageGV:Method:")]
        Double sendMessageGV(NSObject target, NSString method);

        [Static, Export("sendMessageIGI:Method:P1:P2:")]
        int sendMessageIGI(NSObject target, NSString method, Double p1, int p2);

        [Static, Export("sendMessageIGBI:Method:P1:P2:P3:")]
        int sendMessageIGBI(NSObject target, NSString method, double p1, bool p2, int p3);

        [Static, Export("sendMessageVPPI:Method:P1:Type1:P2:Type2:P3:")]
        void sendMessageVPPI(NSObject target, NSString method, IntPtr p1, SCIDataType t1, IntPtr p2, SCIDataType t2, int p3);

        [Static, Export("sendMessageVP:Method:P1:Type1:")]
        void sendMessageVP(NSObject target, NSString method, IntPtr p1, SCIDataType t1);

        [Static, Export("sendMessageVPI:Method:P1:Type1:P2:")]
        void sendMessageVPI(NSObject target, NSString method, IntPtr p1, SCIDataType t1, int p2);

        [Static, Export("sendMessageVPII:Method:P1:Type1:P1:P2:")]
        void sendMessageVPII(NSObject target, NSString method, IntPtr p1, SCIDataType t1, int p2, int p3);

        [Static, Export("sendMessageVPPPI:Method:P1:Type1:P2:Type2:P3:Type3:P4:")]
        void sendMessageVPPPI(NSObject target, NSString method, IntPtr p1, SCIDataType t1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, int p4);

        [Static, Export("sendMessageVPPPPPI:Method:P1:Type1:P2:Type2:P3:Type3:P4:Type4:P5:Type5:P6:")]
        void sendMessageVPPPPPI(NSObject target, NSString method, IntPtr p1, SCIDataType t1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, IntPtr p4, SCIDataType t4, IntPtr p5, SCIDataType t5, int p6);

        [Static, Export("sendMessageVPPPP:Method:P1:Type1:P2:Type2:P3:Type3:P4:Type4:")]
        void sendMessageVPPPP(NSObject target, NSString method, IntPtr p1, SCIDataType t1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, IntPtr p4, SCIDataType t4);

        [Static, Export("sendMessageVIG:Method:P1:P2:")]
        void sendMessageVIG(NSObject target, NSString method, int p1, Double p2);

        [Static, Export("sendMessageVIGG:Method:P1:P2:P3:")]
        void sendMessageVIGG(NSObject target, NSString method, int p1, Double p2, Double p3);

        [Static, Export("sendMessageVIGGG:Method:P1:P2:P3:P4:")]
        void sendMessageVIGGG(NSObject target, NSString method, int p1, Double p2, Double p3, Double p4);

        [Static, Export("sendMessageVIGGGG:Method:P1:P2:P3:P4:P5:")]
        void sendMessageVIGGGG(NSObject target, NSString method, int p1, Double p2, Double p3, Double p4, Double p5);

        [Static, Export("sendMessageVIGGGGG:Method:P1:P2:P3:P4:P5:P6:")]
        void sendMessageVIGGGGG(NSObject target, NSString method, int p1, Double p2, Double p3, Double p4, Double p5, Double p6);

        [Static, Export("sendMessageVIPI:Method:P1:P2:Type2:P3:")]
        void sendMessageVIPI(NSObject target, NSString method, int p1, IntPtr p2, SCIDataType t2, int p3);

        [Static, Export("sendMessageVIPPI:Method:P1:P2:Type2:P3:Type3:P4:")]
        void sendMessageVIPPI(NSObject target, NSString method, int p1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, int p4);

        [Static, Export("sendMessageVIPPP:Method:P1:P2:Type2:P3:Type3:P4:Type4:")]
        void sendMessageVIPPP(NSObject target, NSString method, int p1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, IntPtr p4, SCIDataType type4);

        [Static, Export("sendMessageVIPPPI:Method:P1:P2:Type2:P3:Type3:P4:Type4:P5:")]
        void sendMessageVIPPPI(NSObject target, NSString method, int p1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, IntPtr p4, SCIDataType type4, int p5);

        [Static, Export("sendMessageVIPPPP:Method:P1:P2:Type2:P3:Type3:P4:Type4:P5:Type5:")]
        void sendMessageVIPPPP(NSObject target, NSString method, int p1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, IntPtr p4, SCIDataType t4, IntPtr p5, SCIDataType t5);

        [Static, Export("sendMessageVIPPPPPI:Method:P1:P2:Type2:P3:Type3:P4:Type4:P5:Type5:P6:Type6:P7:")]
        void sendMessageVIPPPPPI(NSObject target, NSString method, int p1, IntPtr p2, SCIDataType t2, IntPtr p3, SCIDataType t3, IntPtr p4, SCIDataType t4, IntPtr p5, SCIDataType t5, IntPtr p6, SCIDataType t6, int p7);

        // +(id) sendMessageOOGO:(id)object Method:(NSString*)method P1:(id)p1 P2:(double)p2 P3:(id)p3;
        [Static, Export("sendMessageOOGO:Method:P1:P2:P3:")]
        NSObject sendMessageOOGO(NSObject target, NSString method, NSObject p1, Double p2, NSObject p3);

        //+(int) sendMessage:(id) object Method:(NSString*) method enumerationState:(void*) state objects:(void*) objects count:(int) len;
        [Static, Export("sendMessage:Method:enumerationState:objects:count:")]
        int sendMessageEnumeration(NSObject target, NSString method, IntPtr state, IntPtr objects, int len);
    }
}