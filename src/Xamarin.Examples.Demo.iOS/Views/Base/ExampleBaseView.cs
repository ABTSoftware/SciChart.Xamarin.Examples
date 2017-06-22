using UIKit;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Views.Base
{
    public interface IExampleBaseView<out T> where T : UIView
    {
        T ExampleViewLayout { get; }
    }

    public abstract class ExampleBaseView<T> : UIView, IExampleBaseView<T> where T : UIView
    {
        public abstract T ExampleViewLayout { get; }

        protected ExampleBaseView()
        {
            InitExample();
        }

        private void InitExample()
        {
            UpdateFrame();
            InitExampleInternal();
        }

        protected abstract void UpdateFrame();
        protected abstract void InitExampleInternal();
    }
}