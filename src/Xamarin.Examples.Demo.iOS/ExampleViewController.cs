using System;
using UIKit;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class ExampleViewController : UIViewController
    {
        public ExampleViewController(IntPtr handle) : base(handle)
        {
        }

        public void InitChartView(Type exampleType)
        {
            var example = (UIView)Activator.CreateInstance(exampleType);
            var exampleView = ((IExampleBaseView<UIView>)example).ExampleViewLayout;

            example.Frame = new CoreGraphics.CGRect(0, 60, View.Frame.Width, View.Frame.Height - 60);
            example.TranslatesAutoresizingMaskIntoConstraints = true;

            exampleView.Frame = new CoreGraphics.CGRect(0, 0, example.Frame.Width, example.Frame.Height);
            exampleView.TranslatesAutoresizingMaskIntoConstraints = true;

            example.AddSubview(exampleView);

            View.AddSubview(example);
        }
    }
}