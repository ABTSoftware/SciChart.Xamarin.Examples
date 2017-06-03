using System;
using UIKit;
using SciChart.Examples.Demo.Application;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class ExampleViewController : UIViewController
    {
        Type exampleType;
        NSLayoutConstraint constraintTopMainView;

        public ExampleViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var exampleView = (UIView)Activator.CreateInstance(exampleType);
            this.NavigationItem.Title = ExampleManager.Instance.Examples.Find(x => x.ExampleType.Equals(exampleType)).Title;
            //this.NavigationController.NavigationBar.BackgroundColor = new UIColor(red: 0.35f, green: 0.78f, blue: 0.36f, alpha: 1.0f);

            var exampleViewLayout = ((IExampleBaseView<UIView>)exampleView).ExampleViewLayout;

			exampleView.AddSubview(exampleViewLayout);
			exampleViewLayout.TranslatesAutoresizingMaskIntoConstraints = false;

			NSLayoutConstraint constraintRight = NSLayoutConstraint.Create(exampleViewLayout, NSLayoutAttribute.Right, NSLayoutRelation.Equal, exampleView, NSLayoutAttribute.Right, 1, 0);
			NSLayoutConstraint constraintLeft = NSLayoutConstraint.Create(exampleViewLayout, NSLayoutAttribute.Left, NSLayoutRelation.Equal, exampleView, NSLayoutAttribute.Left, 1, 0);
			NSLayoutConstraint constraintTop = NSLayoutConstraint.Create(exampleViewLayout, NSLayoutAttribute.Top, NSLayoutRelation.Equal, exampleView, NSLayoutAttribute.Top, 1, 0);
			NSLayoutConstraint constraintBottom = NSLayoutConstraint.Create(exampleViewLayout, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, exampleView, NSLayoutAttribute.Bottom, 1, 0);
			exampleView.AddConstraint(constraintRight);
			exampleView.AddConstraint(constraintLeft);
			exampleView.AddConstraint(constraintTop);
			exampleView.AddConstraint(constraintBottom);


			View.AddSubview(exampleView);
			exampleView.TranslatesAutoresizingMaskIntoConstraints = false;

			NSLayoutConstraint constraintRight1 = NSLayoutConstraint.Create(exampleView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, 0);
			NSLayoutConstraint constraintLeft1 = NSLayoutConstraint.Create(exampleView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 0);
			constraintTopMainView = NSLayoutConstraint.Create(exampleView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 0);
			NSLayoutConstraint constraintBottom1 = NSLayoutConstraint.Create(exampleView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.Bottom, 1, 0);
			View.AddConstraint(constraintRight1);
			View.AddConstraint(constraintLeft1);
			View.AddConstraint(constraintTopMainView);
			View.AddConstraint(constraintBottom1);
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            constraintTopMainView.Constant = this.NavigationController.NavigationBar.Frame.Height + 10;
        }

        public void InitChartView(Type exampleType)
        {
            this.exampleType = exampleType;
        }
    }
}