using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCINiceScaleProtocol : INSObjectProtocol { }

    // @protocol SCINiceScaleProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCINiceScaleProtocol
    {
        // @required -(SCIDoubleAxisDelta *)tickSpacing;
        [Abstract]
        [Export("tickSpacing")]
        SCIDoubleAxisDelta TickSpacing { get; }

        // @required -(void)calculateDelta;
        [Abstract]
        [Export("calculateDelta")]
        void CalculateDelta();
    }
}