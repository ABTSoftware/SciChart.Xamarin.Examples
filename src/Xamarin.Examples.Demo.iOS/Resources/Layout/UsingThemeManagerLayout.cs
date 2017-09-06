using Foundation;
using System;
using ObjCRuntime;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    public partial class UsingThemeManagerLayout : UIView
    {
        public UIButton SelectThemeButton => ThemeButton;

        public SCIChartSurface SciChartSurface => Surface;

        public UsingThemeManagerLayout (IntPtr handle) : base (handle)
        {
        }

        public static UsingThemeManagerLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("UsingThemeManagerLayout", null, null);
            var view = Runtime.GetNSObject<UsingThemeManagerLayout>(pointersArray.ValueAt(0));

            return view;
        }
    }
}