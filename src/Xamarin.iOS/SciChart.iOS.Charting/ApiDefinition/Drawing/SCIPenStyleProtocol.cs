using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIPenStyleProtocol { }

    // @protocol SCIPenStyleProtocol <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIPenStyleProtocol
    {
        // @property(nonatomic) float thickness;
        [Abstract]
        [Export("thickness")]
        SCIAnnotationCoordinateMode Thickness { get; set; }

        //TODO Bind StrokeDashArray in SCIPenStyleProtocol 
        // @property(nonatomic, nullable) NSArray<NSNumber*>* strokeDashArray;
        //[Abstract]
        //[Export("strokeDashArray")]
        //NSArray<NSNumber*> StrokeDashArray { get; set; }

        // @property(nonatomic, nonnull) UIColor* color;
        [Abstract]
        [Export("color")]
        UIColor Color { get; set; }

        // @property(nonatomic) unsigned int colorCode;
        [Abstract]
        [Export("colorCode")]
        uint ColorCode { get; set; }
    }

    // @interface SCIPenStyle : NSObject<SCIPenStyleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPenStyle : SCIPenStyleProtocol
    {
    }
}