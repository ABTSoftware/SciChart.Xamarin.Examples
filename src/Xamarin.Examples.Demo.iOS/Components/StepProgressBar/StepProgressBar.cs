using Foundation;
using System;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class StepProgressBar : UIView
    {
        private  ProgressBarStyle _style;
        private int _progress;

        public StepProgressBar(IntPtr handle) : base(handle)
        {
        }

        readonly UIStackView stackView = new UIStackView();

        public void SetStyle(ProgressBarStyle style)
        {
            _style = style;
            SetupStackView();
        }

        public void SetProgress(int progress)
        {
            _progress = progress - 1;

            UIView[] views = stackView.ArrangedSubviews;

            foreach (var view in views)
            {
                view.BackgroundColor = _style.ProgressBackgroundColor;
            }

            if (_style.IsVertical)
            {
                Array.Reverse(views);
            }

            for (int i = 0; i < _progress; i++)
            {
                views[i].BackgroundColor = _style.ProgressColor;
            }
        }

        void SetupStackView()
        {
            stackView.Distribution = UIStackViewDistribution.FillEqually;
            stackView.Spacing = _style.Spacing;
            stackView.Axis = _style.IsVertical ? UILayoutConstraintAxis.Vertical : UILayoutConstraintAxis.Horizontal;

            AddSubview(stackView);
            stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            stackView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            stackView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            stackView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            stackView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;

            for (int i = 0; i < _style.Max; i++)
            {
                UIView step = new UIView()
                {
                    BackgroundColor = _style.ProgressBackgroundColor,
                    TranslatesAutoresizingMaskIntoConstraints = false
                };

                stackView.AddArrangedSubview(step);
                if (stackView.Axis == UILayoutConstraintAxis.Vertical)
                {
                    step.HeightAnchor.ConstraintEqualTo(_style.BarSize).Active = true;
                }
                else
                {
                    step.WidthAnchor.ConstraintEqualTo(_style.BarSize).Active = true;
                }
            }
        }
    }
}
