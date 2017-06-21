using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIBrushStyleProtocol { }

    // @protocol SCIBrushStyleProtocol<SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIBrushStyleProtocol
    {
        // @property(nonatomic, nonnull) UIColor* color;
        [Abstract]
        [Export("color")]
        UIColor Color { get; set; }

        // @property(nonatomic) unsigned int colorCode;
        [Abstract]
        [Export("colorCode")]
        uint ColorCode { get; set; }
    }

    // @interface SCIBrushStyle : NSObject<SCIBrushStyleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIBrushStyle : SCIBrushStyleProtocol
    {
    }
}