using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieHitTestProvider : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIPieHitTestProvider
    {
        //-(instancetype) initWithParent:(id<SCIPieRenderableSeriesProtocol>) parent;
        [Export("initWithParent:")]
        IntPtr Constructor(ISCIPieRenderableSeriesProtocol parent);

        //-(SCIPieHitTestInfo*) hitTestAtPoint:(CGPoint) point;
        [Export("hitTestAtPoint:")]
        SCIPieHitTestInfo HitTestAtPoint(CGPoint point);
    }
}
