using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderableSeriesCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIRenderableSeriesCollection
    {
        // -(instancetype)initWithParent:(SCIChartSurface *)parent;
        [Export("initWithParent:")]
        IntPtr Constructor(SCIChartSurface parent);

        // -(instancetype)initWithParent:(SCIChartSurface *)parent SeriesCollection:(NSArray<id<SCIRenderableSeriesProtocol>> *)series;
        [Export("initWithParent:SeriesCollection:")]
        IntPtr Constructor(SCIChartSurface parent, [Params]ISCIRenderableSeriesProtocol[] series);

        // @property (nonatomic, weak) SCIChartSurface * parent;
        [Export("parent", ArgumentSemantic.Weak)]
        SCIChartSurface Parent { get; set; }

        // -(void)add:(id<SCIRenderableSeriesProtocol>)item;
        [Export("add:")]
        void Add(ISCIRenderableSeriesProtocol item);

        // -(BOOL)remove:(id<SCIRenderableSeriesProtocol>)item;
        [Export("remove:")]
        bool Remove(ISCIRenderableSeriesProtocol item);

        // -(id<SCIRenderableSeriesProtocol>)itemAt:(unsigned int)index;
        [Export("itemAt:")]
        ISCIRenderableSeriesProtocol ItemAt(uint index);

        // -(void)insert:(id<SCIRenderableSeriesProtocol>)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIRenderableSeriesProtocol item, int index);

        // -(id<SCIRenderableSeriesProtocol>)firstObject;
        [Export("firstObject")]
        ISCIRenderableSeriesProtocol FirstObject { get; }

        // -(BOOL)contains:(id<SCIRenderableSeriesProtocol>)item;
        [Export("contains:")]
        bool Contains(ISCIRenderableSeriesProtocol item);

        // -(int)indexOf:(id<SCIRenderableSeriesProtocol>)item;
        [Export("indexOf:")]
        int IndexOf(ISCIRenderableSeriesProtocol item);

        // -(void)setSeries:(id<SCIRenderableSeriesProtocol>)series atIndex:(unsigned int)index;
        [Export("setSeries:atIndex:")]
        void SetSeries(ISCIRenderableSeriesProtocol series, uint index);
    }

    // @interface Indexing (SCIRenderableSeriesCollection)
    [Category]
    [BaseType(typeof(SCIRenderableSeriesCollection))]
    interface SCIRenderableSeriesCollection_Indexing
    {
        // -(id<SCIRenderableSeriesProtocol>)objectAtIndexedSubscript:(unsigned int)idx;
        [Export("objectAtIndexedSubscript:")]
        ISCIRenderableSeriesProtocol ObjectAtIndexedSubscript(uint idx);

        // -(void)setObject:(id<SCIRenderableSeriesProtocol>)obj atIndexedSubscript:(unsigned int)idx;
        [Export("setObject:atIndexedSubscript:")]
        void SetObject(ISCIRenderableSeriesProtocol obj, uint idx);
    }
}