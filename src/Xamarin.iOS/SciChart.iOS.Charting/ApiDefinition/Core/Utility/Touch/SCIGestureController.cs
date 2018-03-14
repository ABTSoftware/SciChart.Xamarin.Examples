using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIGestureController : NSObject <UIGestureRecognizerDelegate>
    [BaseType(typeof(NSObject))]
    interface SCIGestureController : IUIGestureRecognizerDelegate
    {
        // -(id)initWithParent:(id<SCIChartSurfaceProtocol>)parent View:(UIView *)view;
        [Export("initWithParent:View:")]
        IntPtr Constructor(SCIChartSurfaceProtocol parent, UIView view);

        // -(void)enablePinchGesture;
        [Export("enablePinchGesture")]
        void EnablePinchGesture();

        // -(void)enablePanGesture;
        [Export("enablePanGesture")]
        void EnablePanGesture();

        // -(void)enableTapGesture;
        [Export("enableTapGesture")]
        void EnableTapGesture();

        // -(void)enableDoubleTapGesture;
        [Export("enableDoubleTapGesture")]
        void EnableDoubleTapGesture();

        // -(void)disablePinchGesture;
        [Export("disablePinchGesture")]
        void DisablePinchGesture();

        // -(void)disablePanGesture;
        [Export("disablePanGesture")]
        void DisablePanGesture();

        // -(void)disableTapGesture;
        [Export("disableTapGesture")]
        void DisableTapGesture();

        // -(void)disableDoubleTapGesture;
        [Export("disableDoubleTapGesture")]
        void DisableDoubleTapGesture();

        // -(void)handlePinchGestureWith:(UIPinchGestureRecognizer *)gesture;
        [Export("handlePinchGestureWith:")]
        void HandlePinchGestureWith(UIPinchGestureRecognizer gesture);

        // -(void)handlePanGestureWith:(UIPanGestureRecognizer *)gesture;
        [Export("handlePanGestureWith:")]
        void HandlePanGestureWith(UIPanGestureRecognizer gesture);

        // -(void)handleTapGestureWith:(UITapGestureRecognizer *)gesture;
        [Export("handleTapGestureWith:")]
        void HandleTapGestureWith(UITapGestureRecognizer gesture);

        // -(void)handleTapGestureToCancelAnimationWith:(UITapGestureRecognizer *)gesture;
        [Export("handleTapGestureToCancelAnimationWith:")]
        void HandleTapGestureToCancelAnimationWith(UITapGestureRecognizer gesture);

        // -(void)handleDoubleTapGestureWith:(UITapGestureRecognizer *)gesture;
        [Export("handleDoubleTapGestureWith:")]
        void HandleDoubleTapGestureWith(UITapGestureRecognizer gesture);

        // -(BOOL)gestureRecognizer:(UIGestureRecognizer *)gestureRecognizer shouldRecognizeSimultaneouslyWithGestureRecognizer:(UIGestureRecognizer *)otherGestureRecognizer;
        [Export("gestureRecognizer:shouldRecognizeSimultaneouslyWithGestureRecognizer:")]
        bool GestureRecognizer(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer);
    }
}