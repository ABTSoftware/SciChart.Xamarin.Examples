using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIAxisCollection
    {
        // -(id)initWithAxisCollection:(NSArray<id<SCIAxis2DProtocol>> *)axes Parent:(SCIChartSurface *)parent IsXAxisCollection:(BOOL)isXAxisCollection;
        [Export("initWithAxisCollection:Parent:IsXAxisCollection:")]
        IntPtr Constructor(ISCIAxis2DProtocol[] axes, SCIChartSurface parent, bool isXAxisCollection);

        // -(id)initWithParent:(SCIChartSurface *)parent IsXAxisCollection:(BOOL)isXAxisCollection;
        [Export("initWithParent:IsXAxisCollection:")]
        IntPtr Constructor(SCIChartSurface parent, bool isXAxisCollection);

        // @property (nonatomic, weak) SCIChartSurface * parent;
        [Export("parent", ArgumentSemantic.Weak)]
        SCIChartSurface Parent { get; set; }

        // -(id<SCIAxis2DProtocol>)getAxisById:(NSString *)axisId;
        [Export("getAxisById:")]
        ISCIAxis2DProtocol GetAxisById(string axisId);

        // -(id<SCIAxis2DProtocol>)getAxisById:(NSString *)axisId AssertAxisExist:(BOOL)assert;
        [Export("getAxisById:AssertAxisExist:")]
        ISCIAxis2DProtocol GetAxisById(string axisId, bool assert);

        // -(BOOL)hasPrimaryAxis;
        [Export("hasPrimaryAxis")]
        bool HasPrimaryAxis { get; }

        // -(id<SCIAxis2DProtocol>)primaryAxis;
        [Export("primaryAxis")]
        ISCIAxis2DProtocol PrimaryAxis { get; }

        // -(id<SCIAxis2DProtocol>)defaultAxis;
        [Export("defaultAxis")]
        ISCIAxis2DProtocol DefaultAxis { get; }

        // -(void)add:(id<SCIAxis2DProtocol>)item;
        [Export("add:")]
        void Add(ISCIAxis2DProtocol item);

        // -(BOOL)remove:(id<SCIAxis2DProtocol>)item;
        [Export("remove:")]
        bool Remove(ISCIAxis2DProtocol item);

        // -(id<SCIAxis2DProtocol>)itemAt:(int)index;
        [Export("itemAt:")]
        ISCIAxis2DProtocol ItemAt(int index);

        // -(void)insert:(id<SCIAxis2DProtocol>)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIAxis2DProtocol item, int index);

        // -(BOOL)contains:(id<SCIAxis2DProtocol>)item;
        [Export("contains:")]
        bool Contains(ISCIAxis2DProtocol item);

        // -(int)indexOf:(id<SCIAxis2DProtocol>)item;
        [Export("indexOf:")]
        int IndexOf(ISCIAxis2DProtocol item);

        // -(void)setAxis:(id<SCIAxis2DProtocol>)axis atIndex:(unsigned int)index;
        [Export("setAxis:atIndex:")]
        void SetAxis(ISCIAxis2DProtocol axis, uint index);
    }

    // @interface Indexing (SCIAxisCollection)
    [Category]
    [BaseType(typeof(SCIAxisCollection))]
    interface SCIAxisCollection_Indexing
    {
        // -(id<SCIAxis2DProtocol>)objectAtIndexedSubscript:(unsigned int)idx;
        [Export("objectAtIndexedSubscript:")]
        ISCIAxis2DProtocol ObjectAtIndexedSubscript(uint idx);

        // -(void)setObject:(id<SCIAxis2DProtocol>)obj atIndexedSubscript:(unsigned int)idx;
        [Export("setObject:atIndexedSubscript:")]
        void SetObject(ISCIAxis2DProtocol obj, uint idx);
    }
}