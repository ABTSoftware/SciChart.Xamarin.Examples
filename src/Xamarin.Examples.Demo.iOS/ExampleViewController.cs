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
			this.EdgesForExtendedLayout = UIRectEdge.None;
        }

        public void InitChartView(Type exampleType)
        {
			var example = Activator.CreateInstance(exampleType) as ExampleBaseView;
            example.Frame = View.Frame;
            example.TranslatesAutoresizingMaskIntoConstraints = true;
			example.InitExample();

            View.Add(example);
        }
    }
}