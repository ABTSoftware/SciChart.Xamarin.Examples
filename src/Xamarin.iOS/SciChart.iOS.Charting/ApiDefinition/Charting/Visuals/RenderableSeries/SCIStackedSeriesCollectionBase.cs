using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIStackedSeriesCollectionBase : SCIRenderableSeriesBase<SCIThemeableProtocol> {
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIStackedSeriesCollectionBase : SCIThemeableProtocol
    {
        // -(void)add:(id<ISCIStackedRenderableSeriesProtocol>)series;
        [Export("add:")]
        void Add(ISCIStackedRenderableSeriesProtocol series);

        // -(void)remove:(id<ISCIStackedRenderableSeriesProtocol>)series;
        [Export("remove:")]
        void Remove(ISCIStackedRenderableSeriesProtocol series);

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();

        // @property BOOL isOneHundredPercentSeries;
        [Export("isOneHundredPercentSeries")]
        bool IsOneHundredPercentSeries { get; set; }
    }
}