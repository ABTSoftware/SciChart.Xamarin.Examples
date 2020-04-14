using System.Linq;
using UIKit;
using ObjCRuntime;
using Foundation;

namespace Xamarin.Examples.Demo.iOS
{
    public class DoubleTouchDownGestureRecognizer : UITapGestureRecognizer
    {
        public DoubleTouchDownGestureRecognizer(NSObject target, Selector action) : base(target, action)
        {
            NumberOfTapsRequired = 2;
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            var firstTouch = (UITouch)touches.First();
            if (firstTouch.TapCount != 2) return;

            if (State == UIGestureRecognizerState.Possible)
            {
                State = UIGestureRecognizerState.Recognized;
            }
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            State = UIGestureRecognizerState.Failed;
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            State = UIGestureRecognizerState.Failed;
        }
    }
}
