using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieRenderableSeriesCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIPieRenderableSeriesCollection
    {
        // -(instancetype)initWithParent:(id<SCIPieRenderableSeriesProtocol>)parent;
        [Export("initWithParent:")]
        IntPtr Constructor(ISCIPieRenderableSeriesProtocol parent);

        // -(instancetype)initWithParent:(id<SCIPieRenderableSeriesProtocol>)parent SeriesCollection:(NSArray<id<SCIPieRenderableSeriesProtocol>> *)series;
        [Export("initWithParent:SeriesCollection:")]
        IntPtr Constructor(ISCIPieRenderableSeriesProtocol parent, [Params]ISCIPieRenderableSeriesProtocol[] series);

        // @property (nonatomic, weak) SCIChartSurface * parent;
        [Export("parent", ArgumentSemantic.Weak)]
        ISCIPieRenderableSeriesProtocol Parent { get; set; }

        // -(void)add:(id<SCIPieRenderableSeriesProtocol>)item;
        [Export("add:")]
        void Add(ISCIPieRenderableSeriesProtocol item);

        // -(BOOL)remove:(id<SCIPieRenderableSeriesProtocol>)item;
        [Export("remove:")]
        bool Remove(ISCIPieRenderableSeriesProtocol item);

        // -(id<SCIPieRenderableSeriesProtocol>)itemAt:(unsigned int)index;
        [Export("itemAt:")]
        ISCIPieRenderableSeriesProtocol ItemAt(uint index);

        // -(void)insert:(id<SCIPieRenderableSeriesProtocol>)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIPieRenderableSeriesProtocol item, int index);

        // -(id<SCIPieRenderableSeriesProtocol>)firstObject;
        [Export("firstObject")]
        ISCIPieRenderableSeriesProtocol FirstObject { get; }

        // -(BOOL)contains:(id<SCIPieRenderableSeriesProtocol>)item;
        [Export("contains:")]
        bool Contains(ISCIPieRenderableSeriesProtocol item);

        // -(int)indexOf:(id<SCIPieRenderableSeriesProtocol>)item;
        [Export("indexOf:")]
        int IndexOf(ISCIPieRenderableSeriesProtocol item);

        // -(void)setSeries:(id<SCIPieRenderableSeriesProtocol>)series atIndex:(unsigned int)index;
        [Export("setSeries:atIndex:")]
        void SetSeries(ISCIPieRenderableSeriesProtocol series, uint index);
    }

    // @interface Indexing (SCIPieRenderableSeriesCollection)
    [Category]
    [BaseType(typeof(SCIPieRenderableSeriesCollection))]
    interface SCIPieRenderableSeriesCollection_Indexing
    {
        // -(id<SCIPieRenderableSeriesProtocol>)objectAtIndexedSubscript:(unsigned int)idx;
        [Export("objectAtIndexedSubscript:")]
        ISCIPieRenderableSeriesProtocol ObjectAtIndexedSubscript(uint idx);

        // -(void)setObject:(id<SCIPieRenderableSeriesProtocol>)obj atIndexedSubscript:(unsigned int)idx;
        [Export("setObject:atIndexedSubscript:")]
        void SetObject(ISCIPieRenderableSeriesProtocol obj, uint idx);
    }
}
