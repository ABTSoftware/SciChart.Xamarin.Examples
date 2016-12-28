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
            var example = (ExampleBaseView) Activator.CreateInstance(exampleType);
            var exampleView = example.ExampleView;

            exampleView.Frame = View.Frame;
            exampleView.TranslatesAutoresizingMaskIntoConstraints = true;

            View.Add(exampleView);
        }
    }
}