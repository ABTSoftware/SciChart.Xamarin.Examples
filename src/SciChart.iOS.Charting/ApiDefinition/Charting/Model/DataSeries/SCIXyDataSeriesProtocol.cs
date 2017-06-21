using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIXyDataSeriesProtocol : SCIDataSeriesProtocol, INSObjectProtocol { }

    // @protocol SCIXyDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIXyDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required -(void)appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y Count:(int)count;
    	// @required -(void)appendX:(SCIGenericType)x Y:(SCIGenericType)y;

    	// @required -(void)updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y;
    	// @required -(void)updateAt:(int)index X:(SCIGenericType)x;
    	// @required -(void)updateAt:(int)index Y:(SCIGenericType)y;

    	// @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues yValues:(SCIGenericType)yValues count:(int)count;
    	// @required -(void)updateRange:(int)index yValues:(SCIGenericType)yValues count:(int)count;
    	// @required -(void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;

    	// @required -(void)insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y;
    	// @required -(void)insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Count:(int)count;
    }
}
