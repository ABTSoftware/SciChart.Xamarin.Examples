using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIPen2DProtocol : INSObjectProtocol, ISCIOpenGLBrushProtocol { }

    // @protocol SCIPen2DProtocol <NSObject, SCIOpenGLBrushProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIPen2DProtocol : SCIOpenGLBrushProtocol
    {
        // @required -(float)strokeThickness;
        [Abstract]
        [Export("strokeThickness")]
        float StrokeThickness { get; }
    }
}