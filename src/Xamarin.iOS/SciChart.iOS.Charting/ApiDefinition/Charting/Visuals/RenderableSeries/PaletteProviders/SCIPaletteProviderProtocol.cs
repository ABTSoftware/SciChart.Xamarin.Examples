using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIPaletteProviderProtocol : INSObjectProtocol { }

    // @protocol SCIPaletteProviderProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIPaletteProviderProtocol
    {
        // @required -(void)updateData:(id<ISCIRenderPassDataProtocol>)data;
        [Abstract]
        [Export("updateData:")]
        void UpdateData(ISCIRenderPassDataProtocol data);

        // @required -(id<ISCIStyleProtocol>)styleForX:(double)x Y:(double)y Index:(int)index;
        [Abstract]
        [Export("styleForX:Y:Index:")]
        ISCIStyleProtocol StyleForPoint(double x, double y, int index);
    }
}
