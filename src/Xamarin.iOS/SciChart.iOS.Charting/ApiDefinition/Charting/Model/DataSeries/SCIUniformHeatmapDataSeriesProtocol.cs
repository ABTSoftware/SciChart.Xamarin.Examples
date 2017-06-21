using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIUniformHeatmapDataSeriesProtocol : SCIDataSeriesProtocol, INSObjectProtocol { }

    // @protocol SCIUniformHeatmapDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIUniformHeatmapDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(id<SCIArrayControllerProtocol>)xIndices;
        [Abstract]
        [Export("xIndices")]
        ISCIArrayControllerProtocol XIndices { get; }

        // @required -(id<SCIArrayControllerProtocol>)yIndices;
        [Abstract]
        [Export("yIndices")]
        ISCIArrayControllerProtocol YIndices { get; }

        // @required -(SCIArrayController2D *)zValues;
        [Abstract]
        [Export("zValues")]
        SCIArrayController2D ZValues { get; }

        // @required -(int)sizeX;
        [Abstract]
        [Export("sizeX")]
        int SizeX { get; }

        // @required -(int)sizeY;
        [Abstract]
        [Export("sizeY")]
        int SizeY { get; }

        // @required -(void)updateZValues:(SCIArrayController2D *)values;
        [Abstract]
        [Export("updateZValues:")]
        void UpdateZValues(SCIArrayController2D values);

        // @required -(void)updateRangeZAtXIndex:(int)xIndex yIndex:(int)yIndex withValues:(SCIArrayController2D *)values;
        [Abstract]
        [Export("updateRangeZAtXIndex:yIndex:withValues:")]
        void UpdateRangeZAtXIndex(int xIndex, int yIndex, SCIArrayController2D values);

        // @required @property SCIGenericType stepX;
        // @required @property SCIGenericType stepY;
        // @required -(void)updateZAtXIndex:(int)xIndex yIndex:(int)yIndex withValue:(SCIGenericType)value;
        // @required -(void)updateZValues:(SCIGenericType)values Size:(int)size;
    }
}