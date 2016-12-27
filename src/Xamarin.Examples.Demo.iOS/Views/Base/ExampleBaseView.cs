using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Views.Base
{
    public abstract class ExampleBaseView : SCIChartSurfaceView
    {
        protected ExampleBaseView()
        {
            //InitExample();
        }

        public abstract void InitExample();
    }
}