using System;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public abstract class CustomLayoutViewController<TLayoutType> : ExampleBaseViewController where TLayoutType : UIView
    {
        public TLayoutType Layout => (TLayoutType)View;

        public override void LoadView()
        {
            View = (UIView)typeof(TLayoutType).GetMethod("Create").Invoke(null, null);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            View.Dispose();
        }
    }
}