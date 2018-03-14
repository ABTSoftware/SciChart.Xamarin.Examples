using System;
using CoreGraphics;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieSegment : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIPieSegment
    {
        //@property(nonatomic, nullable) SCIBrushStyle* fillStyle;
        [Export("fillStyle")]
        SCIBrushStyle FillStyle { get; set; }
        //@property(nonatomic, nullable) SCIBrushStyle* selectedFillStyle;
        [Export("selectedFillStyle")]
        SCIBrushStyle SelectedFillStyle { get; set; }

        //@property(nonatomic, nullable) SCIPenStyle* strokeStyle;
        [Export("strokeStyle")]
        SCIPenStyle StrokeStyle { get; set; }
        //@property(nonatomic, nullable) SCIPenStyle* selectedStrokeStyle;
        [Export("selectedStrokeStyle")]
        SCIPenStyle SelectedStrokeStyle { get; set; }

        //@property(nonatomic, nullable) SCIPenStyle* outlineStyle;
        [Export("outlineStyle")]
        SCIPenStyle OutlineStyle { get; set; }
        //@property(nonatomic, nullable) SCIPenStyle* selectedOutlineStyle;
        [Export("selectedOutlineStyle")]
        SCIPenStyle SelectedOutlineStyle { get; set; }

        //@property(nonatomic, nullable) SCITextFormattingStyle* titleStyle;
        [Export("titleStyle")]
        SCITextFormattingStyle TitleStyle { get; set; }
        //@property(nonatomic, nullable) SCITextFormattingStyle* selectedTitleStyle;
        [Export("selectedTitleStyle")]
        SCITextFormattingStyle SelectedTitleStyle { get; set; }

        //@property(nonatomic) double centerOffset;
        [Export("centerOffset")]
        double CenterOffset { get; set; }

        //@property(nonatomic) BOOL isSelected;
        [Export("isSelected")]
        bool IsSelected { get; set; }

        //@property(nonatomic) double value;
        [Export("value")]
        double Value { get; set; }
        //@property(nonatomic, strong, nullable) NSString* title;
        [Export("title")]
        string Title { get; set; }

        //-(SCIBrushStyle* _Nullable) getFillStyle;
        [Export("getFillStyle")]
        SCIBrushStyle GetFillStyle();
        //-(SCIPenStyle* _Nullable) getStrokeStyle;
        [Export("getStrokeStyle")]
        SCIPenStyle GetStrokeStyle();
        //-(SCIPenStyle* _Nullable) getOutlineStyle;
        [Export("getOutlineStyle")]
        SCIPenStyle GetOutlineStyle();
        //-(SCITextFormattingStyle* _Nullable) getTextStyle;
        [Export("getTextStyle")]
        SCITextFormattingStyle GetTextStyle();

        //-(UIColor* _Nullable) segmentColor;
        [Export("segmentColor")]
        UIColor SegmentColor();
    }
}
