using UIKit;

namespace Xamarin.Examples.Demo.iOS.Views.Base
{
    public abstract class ExampleBaseView : UIView
    {
        public abstract UIView ExampleView { get; }

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