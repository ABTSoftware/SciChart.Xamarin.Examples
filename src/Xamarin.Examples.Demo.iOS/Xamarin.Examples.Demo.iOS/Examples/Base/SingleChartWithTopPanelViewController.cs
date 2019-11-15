using UIKit;
using System;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public abstract class SingleChartWithTopPanelViewController<TSurface> : ExampleBaseViewController where TSurface : SCIChartSurfaceBase
    {
        public TSurface Surface { get; private set; }

        public abstract UIView ProvidePanel();

        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.FromRGB(0x1C, 0x1C, 0x1C);

            var panel = ProvidePanel();
            panel.TranslatesAutoresizingMaskIntoConstraints = false;
            Surface = Activator.CreateInstance<TSurface>();
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubviews(panel, Surface);

            panel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            panel.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            panel.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            
            Surface.TopAnchor.ConstraintEqualTo(panel.BottomAnchor).Active = true;

            Surface.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            Surface.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            Surface.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            base.ViewDidLoad();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Surface.RemoveFromSuperview();
            Surface.Dispose();
        }
    }
}
