using System;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public class RealtimeExamplePanel : UIView
    {
        public UIButton StartButton { get; } = new UIButton(UIButtonType.System) { TranslatesAutoresizingMaskIntoConstraints = false };
        public UIButton PauseButton { get; } = new UIButton(UIButtonType.System) { TranslatesAutoresizingMaskIntoConstraints = false };
        public UIButton ResetButton { get; } = new UIButton(UIButtonType.System) { TranslatesAutoresizingMaskIntoConstraints = false };

        public RealtimeExamplePanel()
        {
            StartButton.SetTitle("Start", UIControlState.Normal);
            PauseButton.SetTitle("Pause", UIControlState.Normal);
            ResetButton.SetTitle("Reset", UIControlState.Normal);

            AddSubviews(StartButton, PauseButton, ResetButton);

            StartButton.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 8).Active = true;
            StartButton.TopAnchor.ConstraintEqualTo(TopAnchor, 8).Active = true;
            StartButton.BottomAnchor.ConstraintEqualTo(BottomAnchor, -8).Active = true;

            StartButton.TrailingAnchor.ConstraintEqualTo(PauseButton.LeadingAnchor, -8).Active = true;

            PauseButton.TopAnchor.ConstraintEqualTo(TopAnchor, 8).Active = true;
            PauseButton.BottomAnchor.ConstraintEqualTo(BottomAnchor, -8).Active = true;

            PauseButton.TrailingAnchor.ConstraintEqualTo(ResetButton.LeadingAnchor, -8).Active = true;

            ResetButton.TopAnchor.ConstraintEqualTo(TopAnchor, 8).Active = true;
            ResetButton.BottomAnchor.ConstraintEqualTo(BottomAnchor, -8).Active = true;
            ResetButton.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 8).Active = true;

            StartButton.WidthAnchor.ConstraintEqualTo(PauseButton.WidthAnchor).Active = true;
            PauseButton.WidthAnchor.ConstraintEqualTo(ResetButton.WidthAnchor).Active = true;
        }
    }
}
