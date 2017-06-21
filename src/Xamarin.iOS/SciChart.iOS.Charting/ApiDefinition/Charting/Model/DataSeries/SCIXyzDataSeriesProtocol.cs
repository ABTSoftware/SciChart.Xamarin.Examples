using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIXyzDataSeriesProtocol : SCIDataSeriesProtocol, INSObjectProtocol { }

    // @protocol SCIXyzDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIXyzDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(SCIDataType)zType;
        [Abstract]
        [Export("zType")]
        SCIDataType ZType { get; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)zValues;
        [Abstract]
        [Export("zValues")]
        SCIArrayControllerProtocol ZValues { get; }

        // @required -(void)appendX:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z;
        // @required -(void)appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z Count:(int)count;

        // @required -(void)updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z;
        // @required -(void)updateAt:(int)index X:(SCIGenericType)x;
        // @required -(void)updateAt:(int)index Y:(SCIGenericType)y;
        // @required -(void)updateAt:(int)index Z:(SCIGenericType)z;

        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues yValues:(SCIGenericType)yValues zValues:(SCIGenericType)zValues count:(int)count;
        // @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;
        // @required -(void)updateRange:(int)index yValues:(SCIGenericType)yValues count:(int)count;
        // @required -(void)updateRange:(int)index zValues:(SCIGenericType)zValues count:(int)count;

        // @required -(void)insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z;
        // @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z Count:(int)count;
    }
}