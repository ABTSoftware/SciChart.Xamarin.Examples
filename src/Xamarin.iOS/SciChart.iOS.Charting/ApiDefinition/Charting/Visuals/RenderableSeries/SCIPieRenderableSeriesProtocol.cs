using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIPieRenderableSeriesProtocol {}

    // @protocol SCIPieRenderableSeriesProtocol <<NSObject, SCIInvalidatableElementProtocol>>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIPieRenderableSeriesProtocol : SCIInvalidatableElementProtocol
    {
        //@property(nonatomic, weak, nullable) SCIPieChartSurface* parentSurface;
        [Abstract]
        [Export("parentSurface", ArgumentSemantic.Weak)]
        SCIPieChartSurface ParentSurface { get; set; }

        //@property(nonatomic, strong, nonnull) SCIPieSegmentCollection* segments;
        [Abstract]
        [Export("segments")]
        SCIPieSegmentCollection Segments { get; set; }

        //@property(nonatomic, strong, nonnull) NSString* seriesName;
        [Abstract]
        [Export("seriesName")]
        string SeriesName { get; set; }

        //@property(nonatomic) BOOL isVisible;
        [Abstract]
        [Export("isVisible")]
        bool IsVisible { get; set; }

        //-(BOOL) isSelected;
        [Abstract]
        [Export("isSelected")]
        bool IsSelected { get; }

        //-(double) totalSegmentValue;
        [Abstract]
        [Export("totalSegmentValue")]
        double TotalSegmentValue { get; }

        //@property(nonatomic, nonnull) SCIPieRenderPassData* renderData;
        [Abstract]
        [Export("renderData")]
        SCIPieRenderPassData RenderData { get; set; }

        //@property(nonatomic) double height;
        [Abstract]
        [Export("height")]
        double Height { get; set; }

        //@property(nonatomic) SCIPieSeriesSizingMode heightSizingMode;
        [Abstract]
        [Export("heightSizingMode")]
        SCIPieSeriesSizingMode HeightSizingMode { get; set; }

        //@property(nonatomic) double startAngle;
        [Abstract]
        [Export("startAngle")]
        double StartAngle { get; set; }

        //-(void) setLayout:(SCIPieLayoutPassData* _Nonnull) data;
        [Abstract]
        [Export("setLayout:")]
        void SetLayout(SCIPieLayoutPassData data);

        //-(void) draw;
        [Abstract]
        [Export("draw")]
        void Draw();

        //-(void) deselectSegments;
        [Abstract]
        [Export("deselectSegments")]
        void DeselectSegments();

        //-(void) selectSegmentAtIndex:(int) index;
        [Abstract]
        [Export("selectSegmentAtIndex:")]
        void SelectSegment(int index);

        //-(void) setSegmentSelected:(BOOL) selected atIndex:(int) index;
        [Abstract]
        [Export("setSegmentSelected:atIndex:")]
        void SetSegmentSelected(bool selected, int index);

        //-(int) getSegmentIndexAtPoint:(CGPoint) point;
        [Abstract]
        [Export("getSegmentIndexAtPoint:")]
        int GetSegmentIndexAtPoint(CGPoint point);

        //-(NSString* _Nonnull) getSegmentTextAtIndex:(int) index;
        [Abstract]
        [Export("getSegmentTextAtIndex:")]
        string GetSegmentTextAtIndex(int index);

        //-(SCIPieHitTestProvider* _Nullable) hitTestProvider;
        [Abstract]
        [Export("hitTestProvider")]
        SCIPieHitTestProvider HitTestProvider { get; }

        //@property(nonatomic) double selectedSegmentOffset;
        [Abstract]
        [Export("selectedSegmentOffset")]
        double SelectedSegmentOffset { get; set; }

        //@property(nonatomic, nullable) SCIBrushStyle* segmentFillStyle;
        [Abstract]
        [Export("segmentFillStyle")]
        SCIBrushStyle SegmentFillStyle { get; set; }
        //@property(nonatomic, nullable) SCIBrushStyle* selectedSegmentFillStyle;
        [Abstract]
        [Export("selectedSegmentFillStyle")]
        SCIBrushStyle SelectedSegmentFillStyle { get; set; }

        //@property(nonatomic, nullable) SCIPenStyle* segmentStrokeStyle;
        [Abstract]
        [Export("segmentStrokeStyle")]
        SCIPenStyle SegmentStrokeStyle { get; set; }
        //@property(nonatomic, nullable) SCIPenStyle* selectedSegmentStrokeStyle;
        [Abstract]
        [Export("selectedSegmentStrokeStyle")]
        SCIPenStyle SelectedSegmentStrokeStyle { get; set; }

        //@property(nonatomic, nullable) SCIPenStyle* segmentOutlineStyle;
        [Abstract]
        [Export("segmentOutlineStyle")]
        SCIPenStyle SegmentOutlineStyle { get; set; }
        //@property(nonatomic, nullable) SCIPenStyle* selectedSegmentOutlineStyle;
        [Abstract]
        [Export("selectedSegmentOutlineStyle")]
        SCIPenStyle SelectedSegmentOutlineStyle { get; set; }

        //@property(nonatomic, nullable) SCITextFormattingStyle* segmentTitleStyle;
        [Abstract]
        [Export("segmentTitleStyle")]
        SCITextFormattingStyle SegmentTitleStyle { get; set; }
        //@property(nonatomic, nullable) SCITextFormattingStyle* selectedSegmentTitleStyle;
        [Abstract]
        [Export("selectedSegmentTitleStyle")]
        SCITextFormattingStyle SelectedSegmentTitleStyle { get; set; }

        //-(SCIBrushStyle* _Nullable) getFillStyleForSegment:(SCIPieSegment* _Nonnull) segment;
        [Abstract]
        [Export("getFillStyleForSegment:")]
        SCIBrushStyle GetFillStyleForSegment(SCIPieSegment segment);
        //-(SCIPenStyle* _Nullable) getStrokeStyleForSegment:(SCIPieSegment* _Nonnull) segment;
        [Abstract]
        [Export("getStrokeStyleForSegment:")]
        SCIPenStyle GetStrokeStyleForSegment(SCIPieSegment segment);
        //-(SCIPenStyle* _Nullable) getOutlineStyleForSegment:(SCIPieSegment* _Nonnull) segment;
        [Abstract]
        [Export("getOutlineStyleForSegment:")]
        SCIPenStyle GetOutlineStyleForSegment(SCIPieSegment segment);
        //-(SCITextFormattingStyle* _Nullable) getTextStyleForSegment:(SCIPieSegment* _Nonnull) segment;
        [Abstract]
        [Export("getTextStyleForSegment:")]
        SCITextFormattingStyle GetTextStyleForSegment(SCIPieSegment segment);
    }
}
