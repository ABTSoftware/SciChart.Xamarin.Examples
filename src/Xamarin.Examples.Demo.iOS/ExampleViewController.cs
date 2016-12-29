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

            example.Frame = View.Frame;
            example.TranslatesAutoresizingMaskIntoConstraints = true;

            exampleView.Frame = example.Frame;
            exampleView.TranslatesAutoresizingMaskIntoConstraints = true;

            example.Add(exampleView);

            View.Add(example);
        }
    }
}