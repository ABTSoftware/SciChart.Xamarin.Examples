using System;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public abstract class SingleChartViewController<TSurface> : ExampleBaseViewController where TSurface: UIView, IISCIInvalidatableElement
    {
        public TSurface Surface => (TSurface)View;

        public override void LoadView()
        {
            View = Activator.CreateInstance<TSurface>();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            View.Dispose();
        }
    }
}