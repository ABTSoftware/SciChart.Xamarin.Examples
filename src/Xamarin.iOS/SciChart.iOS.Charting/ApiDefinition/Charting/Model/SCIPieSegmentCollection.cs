using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieSegmentCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIPieSegmentCollection
    {
        // -(instancetype)initWithParent:(SCIPieChartSurface *)parent;
        [Export("initWithParent:")]
        IntPtr Constructor(SCIPieChartSurface parent);

        // -(instancetype)initWithParent:(SCIPieChartSurface *)parent segmentCollection:(NSArray<SCIPieSegment*> *)series;
        [Export("initWithParent:segmentCollection:")]
        IntPtr Constructor(SCIPieChartSurface parent, [Params]SCIPieSegment[] series);

        // @property (nonatomic, weak) SCIChartSurface * parent;
        [Export("parent", ArgumentSemantic.Weak)]
        SCIPieChartSurface Parent { get; set; }

        // -(void)add:(SCIPieSegment)item;
        [Export("add:")]
        void Add(SCIPieSegment item);

        // -(BOOL)remove:(SCIPieSegment)item;
        [Export("remove:")]
        bool Remove(SCIPieSegment item);

        // -(SCIPieSegment)itemAt:(unsigned int)index;
        [Export("itemAt:")]
        SCIPieSegment ItemAt(uint index);

        // -(void)insert:(SCIPieSegment)item At:(int)index;
        [Export("insert:At:")]
        void Insert(SCIPieSegment item, int index);

        // -(SCIPieSegment)firstObject;
        [Export("firstObject")]
        SCIPieSegment FirstObject { get; }

        // -(BOOL)contains:(SCIPieSegment)item;
        [Export("contains:")]
        bool Contains(SCIPieSegment item);

        // -(int)indexOf:(SCIPieSegment)item;
        [Export("indexOf:")]
        int IndexOf(SCIPieSegment item);

        // -(void)setSegment:(SCIPieSegment)segment atIndex:(unsigned int)index;
        [Export("setSegment:atIndex:")]
        void SetSegment(SCIPieSegment segment, uint index);
    }

    // @interface Indexing (SCIPieSegmentCollection)
    [Category]
    [BaseType(typeof(SCIPieSegmentCollection))]
    interface SCIPieSegmentCollection_Indexing
    {
        // -(SCIPieSegment)objectAtIndexedSubscript:(unsigned int)idx;
        [Export("objectAtIndexedSubscript:")]
        SCIPieSegment ObjectAtIndexedSubscript(uint idx);

        // -(void)setObject:(SCIPieSegment)obj atIndexedSubscript:(unsigned int)idx;
        [Export("setObject:atIndexedSubscript:")]
        void SetObject(SCIPieSegment obj, uint idx);
    }
}
