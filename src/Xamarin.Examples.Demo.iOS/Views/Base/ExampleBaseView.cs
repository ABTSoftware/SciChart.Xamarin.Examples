using UIKit;

namespace Xamarin.Examples.Demo.iOS.Views.Base
{
    public abstract class ExampleBaseView
    {
        public abstract UIView ExampleView { get; }

        protected ExampleBaseView()
        {
            Init();
        }

        private void Init()
        {
            InitExample();
        }

        protected abstract void InitExample();
    }
}