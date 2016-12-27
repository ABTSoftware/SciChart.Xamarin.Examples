using System;
using UIKit;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.iOS.Views.Examples;

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
            var lineChartView = (LineChartView) example;

            lineChartView.ExampleView.Frame = View.Frame;
            lineChartView.ExampleView.TranslatesAutoresizingMaskIntoConstraints = true;

            View.Add(lineChartView.ExampleView);

            lineChartView.InitExample();
        }
    }
}