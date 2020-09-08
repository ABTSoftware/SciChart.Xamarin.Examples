using System;
using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public class CustomGestureModifier : SCIGestureModifierBase
    {
        private DoubleTouchDownGestureRecognizer doubleTapGesture;
        private CGPoint InitialLocation = CGPoint.Empty;
        private readonly nfloat ScaleFactor = -50;
        private bool CanPan;

        public CustomGestureModifier() { }

        public override void AttachTo(IISCIServiceContainer services)
        {
            base.AttachTo(services);

            doubleTapGesture = new DoubleTouchDownGestureRecognizer(this, new Selector("handleDoubleTapGesture:"));

            if (ParentSurface is UIView)
            {
                UIView surfaceView = (UIView)ParentSurface;
                surfaceView.AddGestureRecognizer(doubleTapGesture); 
            }
        }

        protected override UIGestureRecognizer CreateGestureRecognizer()
        {
            return new UIPanGestureRecognizer();
        }

        protected override void OnGestureBegan(SCIGestureModifierEventArgs args)
        {
            if (!CanPan) return;

            UIPanGestureRecognizer gesture = (UIPanGestureRecognizer)args.GestureRecognizer;
            UIView parentView = ParentSurface.ModifierSurface.View;

            InitialLocation = gesture.LocationInView(parentView);
        }

        protected override void OnGestureChanged(SCIGestureModifierEventArgs args)
        {
            if (!CanPan) return;

            UIPanGestureRecognizer gesture = (UIPanGestureRecognizer)args.GestureRecognizer;
            UIView parentView = ParentSurface.ModifierSurface.View;

            performZoom(InitialLocation, gesture.TranslationInView(parentView).Y);
            gesture.SetTranslation(CGPoint.Empty, parentView);
        }

        protected override void OnGestureEnded(SCIGestureModifierEventArgs args)
        {
            CanPan = false;
        }

        protected override void OnGestureCancelled(SCIGestureModifierEventArgs args)
        {
            CanPan = false;
        }

        void performZoom(CGPoint point, nfloat yScaleFactor)
        {
            nfloat fraction = yScaleFactor / ScaleFactor;
            for (int i = 0; i < XAxes.Count; i++)
            {
                growAxis(XAxes[i], point, fraction);
            }
        }

        void growAxis(IISCIAxis axis, CGPoint point, nfloat fraction)
        {
            nfloat width = axis.LayoutSize.Width;
            nfloat coord = width - point.X;

            double minFraction = (coord / width) * fraction;
            double maxFraction = (1 - coord / width) * fraction;

            axis.ZoomByFractionMin(minFraction, maxFraction);
        }

        [Export("handleDoubleTapGesture:")]
        void handleDoubleTap(UILongPressGestureRecognizer gesture)
        {
            if (gesture.State == UIGestureRecognizerState.Ended)
            {
                CanPan = true;
            }
        }
    }
}
