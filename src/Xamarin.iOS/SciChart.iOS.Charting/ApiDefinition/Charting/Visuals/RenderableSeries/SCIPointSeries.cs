using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIPointSeries : NSObject <ISCIPointSeriesProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPointSeries : SCIPointSeriesProtocol
    {
        // -(id)initWithCapacity:(NSInteger)size;
        [Export("initWithCapacity:")]
        IntPtr Constructor(int size);

        // -(id)initWithXData:(SCIArrayController *)xData YData:(SCIArrayController *)yData Indices:(SCIArrayController *)indices;
        [Export("initWithXData:YData:Indices:")]
        IntPtr Constructor(SCIArrayController xData, SCIArrayController yData, SCIArrayController indices);

        // -(void)addX:(double)x Y:(double)y Index:(int)index;
        [Export("addX:Y:Index:")]
        void AddX(double x, double y, int index);
    }
}