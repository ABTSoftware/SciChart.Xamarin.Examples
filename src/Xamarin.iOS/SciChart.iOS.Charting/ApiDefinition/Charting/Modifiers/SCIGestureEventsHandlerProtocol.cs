using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIGestureEventsHandlerProtocol { }

    // @protocol SCIGestureEventsHandlerProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIGestureEventsHandlerProtocol
    {
        // @required -(BOOL)pointWithinBounds:(CGPoint)point;
        [Abstract]
        [Export("pointWithinBounds:")]
        // TODO check bool IsPointWithinBounds(CGPoint point);
        bool PointWithinBounds(CGPoint point);

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

        // @required -(BOOL)onTapGestureToCancelAnimation:(UITapGestureRecognizer *)gesture At:(UIView *)view;
        [Abstract]
        [Export("onTapGestureToCancelAnimation:At:")]
        bool OnTapGestureToCancelAnimation(UITapGestureRecognizer gesture, UIView view);
    }
}