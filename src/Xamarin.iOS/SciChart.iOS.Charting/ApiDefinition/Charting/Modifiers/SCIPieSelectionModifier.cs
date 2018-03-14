using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieSelectionModifier : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIPieSelectionModifier
    {
        //@property(nonatomic) SCIPieSelectionModifierSelectionMode selectionMode;
        [Export("selectionMode")]
        SCIPieSelectionModifierSelectionMode SelectionMode { get; set; }
    }
}
