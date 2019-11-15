using UIKit;
using System;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public abstract class SingleChartWithModifierTipViewController<TSurface> : ExampleBaseViewController where TSurface : SCIChartSurfaceBase
    {
        public TSurface Surface { get; private set; }

        public abstract string ModifierTip { get; }

        public override void ViewDidLoad()
        {
            Surface = Activator.CreateInstance<TSurface>();
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(Surface);
            
            Surface.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            Surface.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            Surface.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            Surface.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            var label = new UILabel { Text = ModifierTip, TextColor = 0x77FFFFFF.ToUIColor() };
            View.AddSubview(label);
            label.TranslatesAutoresizingMaskIntoConstraints = false;
            label.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            label.TopAnchor.ConstraintEqualTo(View.TopAnchor, 10).Active = true;

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