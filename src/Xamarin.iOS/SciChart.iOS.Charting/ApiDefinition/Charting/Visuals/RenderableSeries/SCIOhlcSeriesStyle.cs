using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIOhlcSeriesStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIOhlcSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeUpStyle;
        [Export("strokeUpStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeUpStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeDownStyle;
        [Export("strokeDownStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeDownStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }
    }
}