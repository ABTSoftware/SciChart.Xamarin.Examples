using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILegendModifier : SCIChartModifierBase
    [BaseType(typeof(SCIChartModifierBase))]
    interface SCILegendModifierBase

    {
        // @property (nonatomic) SCILegendPosition position;
        [Export("position", ArgumentSemantic.Assign)]
        SCILegendPosition Position { get; set; }

        // @property (nonatomic) SCIOrientation orientation;
        [Export("orientation", ArgumentSemantic.Assign)]
        SCIOrientation Orientation { get; set; }

        [Export("sourceMode")]
        SCISourceMode SourceMode { get; set; }

        // @property (nonatomic) BOOL showCheckBoxes;
        [Export("showCheckBoxes")]
        bool ShowCheckBoxes { get; set; }

        // @property (nonatomic) BOOL showSeriesMarkers;
        [Export("showSeriesMarkers")]
        bool ShowSeriesMarkers { get; set; }

        // @property (nonatomic) NSArray<SCILegendItem *> * dataSource;
        [Export("dataSource", ArgumentSemantic.Assign)]
        SCILegendItem[] DataSource { get; set; }

        // @property (readonly, nonatomic) UIView * holderLegendView;
        [Export("holderLegendView")]
        UIView HolderLegendView { get; }

        // @property (nonatomic) CGSize preferredMaxSize;
        [Export("preferredMaxSize", ArgumentSemantic.Assign)]
        CGSize PreferredMaxSize { get; set; }

        //[Export("init")]
        //IntPtr Constructor();

        // -(instancetype)initWithPosition:(SCILegendPosition)postition andOrientation:(SCIOrientation)orientation;
        [Export("initWithPosition:andOrientation:")]
        IntPtr Constructor(SCILegendPosition postition, SCIOrientation orientation);

        // -(void)layoutPositionOfHolderView;
        [Export("layoutPositionOfHolderView")]
        void LayoutPositionOfHolderView();

        // -(void)generateDataSourceAndSetDataSource;
        [Export("generateDataSourceAndSetDataSource")]
        void GenerateDataSourceAndSetDataSource();
    }
}