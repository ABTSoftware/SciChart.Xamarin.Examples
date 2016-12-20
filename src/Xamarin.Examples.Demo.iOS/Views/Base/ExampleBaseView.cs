using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Views.Base
{
    public abstract class ExampleBaseView : SCIChartSurfaceView
    {
        protected ExampleBaseView()
        {
            InitExample();
        }

        protected abstract void InitExample();
    }
}