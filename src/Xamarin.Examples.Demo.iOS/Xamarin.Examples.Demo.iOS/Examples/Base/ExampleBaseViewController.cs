using UIKit;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public abstract class ExampleBaseViewController : UIViewController
    {
        protected ExampleBaseViewController()
        {
            ViewRespectsSystemMinimumLayoutMargins = false;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CommonInit();
            InitExample();
        }

        protected virtual void CommonInit() { }
        protected abstract void InitExample();

        public static SCIModifierGroup CreateDefaultModifiers()
        {
            var modifierGroup = new SCIModifierGroup();
            modifierGroup.ChildModifiers.Add(new SCIPinchZoomModifier());
            modifierGroup.ChildModifiers.Add(new SCIZoomPanModifier { ReceiveHandledEvents = true });
            modifierGroup.ChildModifiers.Add(new SCIZoomExtentsModifier());

            return modifierGroup;
        }

        public static SCIModifierGroup3D CreateDefault3DModifiers()
        {
            var modifierGroup3D = new SCIModifierGroup3D();
            modifierGroup3D.ChildModifiers.Add(new SCIPinchZoomModifier3D());
            modifierGroup3D.ChildModifiers.Add(new SCIFreeLookModifier3D(defaultNumberOfTouches: 2));
            modifierGroup3D.ChildModifiers.Add(new SCIOrbitModifier3D());
            modifierGroup3D.ChildModifiers.Add(new SCIZoomExtentsModifier3D());

            return modifierGroup3D;
        }
    }
}