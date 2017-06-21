using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIGestureEventsHandler : ISCIGestureEventsHandlerProtocol { }

    interface ISCIGestureEventsHandlerProtocol { }

    // @protocol SCIGestureEventsHandlerProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIGestureEventsHandlerProtocol
    {
        // @required -(BOOL)pointWithinBounds:(CGPoint)point;
        [Abstract]
        [Export("pointWithinBounds:")]
        bool IsPointWithinBounds(CGPoint point);

        // @required -(BOOL)onTapGesture:(UITapGestureRecognizer *)gesture At:(UIView *)view;
        [Abstract]
        [Export("onTapGesture:At:")]
        bool OnTapGesture(UITapGestureRecognizer gesture, UIView view);

        // @required -(BOOL)onPanGesture:(UIPanGestureRecognizer *)gesture At:(UIView *)view;
        [Abstract]
        [Export("onPanGesture:At:")]
        bool OnPanGesture(UIPanGestureRecognizer gesture, UIView view);

        // @required -(BOOL)onPinchGesture:(UIPinchGestureRecognizer *)gesture At:(UIView *)view;
        [Abstract]
        [Export("onPinchGesture:At:")]
        bool OnPinchGesture(UIPinchGestureRecognizer gesture, UIView view);

        // @required -(BOOL)onDoubleTapGesture:(UITapGestureRecognizer *)gesture At:(UIView *)view;
        [Abstract]
        [Export("onDoubleTapGesture:At:")]
        bool OnDoubleTapGesture(UITapGestureRecognizer gesture, UIView view);
    }
}
