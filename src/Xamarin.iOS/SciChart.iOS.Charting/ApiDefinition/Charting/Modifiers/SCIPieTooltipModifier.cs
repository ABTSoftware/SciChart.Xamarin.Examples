using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieTooltipModifier : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIPieTooltipModifier
    {
        //-(SCITooltipView*) createTooltipView;
        [Export("createTooltipView")]
        SCITooltipView createTooltipView();

        //@property(nonatomic, copy) SCITooltipModifierStyle* style;
        [Export("style")]
        SCITooltipModifierStyle Style { get; set; }
    }
}
