using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIVerticallyStackedColumnsCollection : SCIStackedSeriesCollectionBase
    // @interface SCIVerticallyStackedColumnsCollection(HorizontalShifts) <SCIStackedRenderableSeriesProtocol>
    [BaseType(typeof(SCIStackedSeriesCollectionBase))]
    interface SCIVerticallyStackedColumnsCollection : SCIStackedRenderableSeriesProtocol
    {
    }
}