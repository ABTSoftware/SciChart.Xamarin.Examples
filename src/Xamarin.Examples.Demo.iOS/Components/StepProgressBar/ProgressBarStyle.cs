using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public class ProgressBarStyle
    {
        public bool IsVertical;
        public int Max;
        public int Spacing;
        public int BarSize;
        public UIColor ProgressBackgroundColor;
        public UIColor ProgressColor;

        public ProgressBarStyle(bool isVertical, int max, int spacing, int barSize, UIColor progressBackgroundColor, UIColor progressColor)
        {
            IsVertical = isVertical;
            Max = max;
            Spacing = spacing;
            BarSize = barSize;
            ProgressBackgroundColor = progressBackgroundColor;
            ProgressColor = progressColor;
        }
    }
}
