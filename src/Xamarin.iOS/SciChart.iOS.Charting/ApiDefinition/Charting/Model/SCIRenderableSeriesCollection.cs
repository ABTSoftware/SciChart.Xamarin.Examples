using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    [BaseType(typeof (SCIObservableCollection))]
    interface SCIRenderableSeriesCollection
    {
		//// - (id)initWithParent;
		//[Export("init")]
		//IntPtr Constructor();

        // - (id)initWithParent:(SCIChartSurface *)parent;
        [Export("initWithParent:")]
        IntPtr Constructor(SCIChartSurface parent);

        // - (id)initWithParent:(SCIChartSurface *)parent SeriesCollection:(NSArray<id<SCIRenderableSeriesProtocol>>*)series;
        [Export("initWithParent:SeriesCollection:")]
        IntPtr Constructor(SCIChartSurface parent, [Params]ISCIRenderableSeriesProtocol[] series);

        // @property(nonatomic, weak) SCIChartSurface* parent;
        [Export("parent", ArgumentSemantic.Weak)]
        SCIChartSurface Parent { get; set; }

        // - (void)add:(id<SCIRenderableSeriesProtocol>)item;
        [Export("add:")]
        void Add(ISCIRenderableSeriesProtocol item);

        // - (BOOL)remove:(id<SCIRenderableSeriesProtocol>)item;
        [Export("remove:")]
        bool Remove(ISCIRenderableSeriesProtocol item);        

        // - (id<SCIRenderableSeriesProtocol>)itemAt:(unsigned int)index;
        [Export("itemAt:")]
        ISCIRenderableSeriesProtocol ItemAt(int index);

        // - (void)insert:(id<SCIRenderableSeriesProtocol>)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIRenderableSeriesProtocol item, int index);

        // - (id<SCIRenderableSeriesProtocol>)firstObject;
        [Export("firstObject")]
        ISCIRenderableSeriesProtocol FirstObject { get; }

        // - (BOOL)contains:(id<SCIRenderableSeriesProtocol>)item;
        [Export("contains:")]
        bool Contains(ISCIRenderableSeriesProtocol item);

        // - (int)indexOf:(id <SCIRenderableSeriesProtocol>)item;
        [Export("indexOf:")]
        int IndexOf(ISCIRenderableSeriesProtocol item);

        // - (void)setSeries:(id <SCIRenderableSeriesProtocol>)series atIndex:(unsigned int)index;
        [Export("setSeries:atIndex:")]
        void SetSeries(ISCIRenderableSeriesProtocol series, int index);
    }
}