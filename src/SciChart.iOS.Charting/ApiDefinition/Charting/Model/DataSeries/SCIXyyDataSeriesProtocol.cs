using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIXyyDataSeriesProtocol : SCIDataSeriesProtocol, INSObjectProtocol { }

    // @protocol SCIXyyDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIXyyDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(id<SCIArrayControllerProtocol>)y1Values;
        [Abstract]
        [Export("y1Values")]
        SCIArrayControllerProtocol Y1Values { get; }

        // @required -(id<SCIArrayControllerProtocol>)y2Values;
        [Abstract]
        [Export("y2Values")]
        SCIArrayControllerProtocol Y2Values { get; }

        // @required -(SCIDataType)y1Type;
        [Abstract]
        [Export("y1Type")]
        SCIDataType Y1Type { get; }

        // @required -(SCIDataType)y2Type;
        [Abstract]
        [Export("y2Type")]
        SCIDataType Y2Type { get; }

        // @required -(void)appendX:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;
        // @required -(void)appendRangeX:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2 Count:(int)count;

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;
        // @required -(void)updateAt:(int)index X:(SCIGenericType)x;
        // @required -(void)updateAt:(int)index Y1:(SCIGenericType)y1;
        // @required -(void)updateAt:(int)index Y2:(SCIGenericType)y2;

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues y1Values:(SCIGenericType)y1Values y2Values:(SCIGenericType)y2Values count:(int)count;
        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;
        // @required -(void)updateRange:(int)index y1Values:(SCIGenericType)y1Values count:(int)count;
        // @required -(void)updateRange:(int)index y2Values:(SCIGenericType)y2Values count:(int)count;

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;
        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2 Count:(int)count;
    }
}