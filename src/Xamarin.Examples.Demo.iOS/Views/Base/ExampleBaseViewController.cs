using System;
using SciChart.Examples.Demo.Application;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Views.Base
{
    public abstract class ExampleBaseViewController : UIViewController
    {
        protected ExampleBaseViewController()
        {
            EdgesForExtendedLayout = UIRectEdge.Bottom;

            var example = ExampleManager.Instance.GetExampleByType(this.GetType());
            NavigationItem.Title = example?.Title;
        }

        public abstract Type ExampleViewType { get; }

        public override void LoadView()
        {
            View = (UIView)ExampleViewType.GetMethod("Create").Invoke(null, null);
            View.AccessibilityIdentifier = "ExampleView";           
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitExample();
        }

        protected abstract void InitExample();
    }
}