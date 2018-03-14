using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCITooltipDataView : UIView
    [BaseType(typeof(UIView))]
    interface SCITooltipDataView
    {
        // -(void)applyHeadLineStyle:(SCITextFormattingStyle *)style;
        [Export("applyHeadLineStyle:")]
        void ApplyHeadLineStyle(SCITextFormattingStyle style);

        // -(void)applyDataLineStyle:(SCITextFormattingStyle *)style;
        [Export("applyDataLineStyle:")]
        void ApplyDataLineStyle(SCITextFormattingStyle style);

        // -(void)setColor:(UIColor *)color;
        [Export("setColor:")]
        void SetColor(UIColor color);

        // -(CGSize)getTransformedViewSize:(UIView *)view;
        [Export("getTransformedViewSize:")]
        CGSize GetTransformedViewSize(UIView view);
    }
}