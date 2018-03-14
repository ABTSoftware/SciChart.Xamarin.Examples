using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITickCoordinates : NSObject
    // TODO Discuss with Andrii
    [BaseType(typeof(NSObject))]
    interface SCITickCoordinates
    {
        //// -(id)initWithMinorTicks:(double *)minorTicks Count:(int)minorTicksCount MajorTicks:(double *)majorTicks Count:(int)majorTicksCount MinorTicksCoordinates:(float *)minorTickCoord Count:(int)minorTickCoordCount MajorTicksCoordinates:(float *)majorTickCoord Count:(int)majorTickCoordCount;
        //[Export("initWithMinorTicks:Count:MajorTicks:Count:MinorTicksCoordinates:Count:MajorTicksCoordinates:Count:")]
        //unsafe IntPtr Constructor(double* minorTicks, int minorTicksCount, double* majorTicks, int majorTicksCount, float* minorTickCoord, int minorTickCoordCount, float* majorTickCoord, int majorTickCoordCount);

        // -(BOOL)isEmpty;
        [Export("isEmpty")]
        bool IsEmpty { get; }

        //// -(void)getMinorTicks:(double **)ticks Count:(int *)count;
        //[Export("getMinorTicks:Count:")]
        //unsafe void GetMinorTicks(double** ticks, int* count);

        //// -(void)getMajorTicks:(double **)ticks Count:(int *)count;
        //[Export("getMajorTicks:Count:")]
        //unsafe void GetMajorTicks(double** ticks, int* count);

        //// -(void)getMinorTickCoordinates:(float **)ticks Count:(int *)count;
        //[Export("getMinorTickCoordinates:Count:")]
        //unsafe void GetMinorTickCoordinates(float** ticks, int* count);

        //// -(void)getMajorTickCoordinates:(float **)ticks Count:(int *)count;
        //[Export("getMajorTickCoordinates:Count:")]
        //unsafe void GetMajorTickCoordinates(float** ticks, int* count);
    }
}