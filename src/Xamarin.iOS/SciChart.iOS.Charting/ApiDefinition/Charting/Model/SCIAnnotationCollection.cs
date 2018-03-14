using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIAnnotationCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIAnnotationCollection
    {
        // -(id)initWithChildAnnotations:(NSArray<id<SCIAnnotationProtocol>> *)childAnnotations;
        [Export("initWithChildAnnotations:")]
        IntPtr Constructor([Params]ISCIAnnotationProtocol[] childAnnotations);

        // -(id<SCIAnnotationProtocol>)itemByName:(NSString *)name;
        [Export("itemByName:")]
        ISCIAnnotationProtocol ItemByName(string name);

        // -(void)add:(id<SCIAnnotationProtocol>)item;
        [Export("add:")]
        void Add(ISCIAnnotationProtocol item);

        // -(BOOL)remove:(id<SCIAnnotationProtocol>)item;
        [Export("remove:")]
        bool Remove(ISCIAnnotationProtocol item);

        // -(id<SCIAnnotationProtocol>)itemAt:(int)index;
        [Export("itemAt:")]
        ISCIAnnotationProtocol ItemAt(int index);

        // -(void)insert:(id<SCIAnnotationProtocol>)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIAnnotationProtocol item, int index);

        // -(id<SCIAnnotationProtocol>)firstObject;
        [Export("firstObject")]
        ISCIAnnotationProtocol FirstObject { get; }

        // -(BOOL)contains:(id<SCIAnnotationProtocol>)item;
        [Export("contains:")]
        bool Contains(ISCIAnnotationProtocol item);

        // -(int)indexOf:(id<SCIAnnotationProtocol>)item;
        [Export("indexOf:")]
        int IndexOf(ISCIAnnotationProtocol item);

        // -(void)setAnnotation:(id<SCIAnnotationProtocol>)annotation atIndex:(unsigned int)index;
        [Export("setAnnotation:atIndex:")]
        void SetAnnotation(ISCIAnnotationProtocol annotation, uint index);

        // @property (nonatomic) BOOL handleGestureFirstOnly;
        [Export("handleGestureFirstOnly")]
        bool HandleGestureFirstOnly { get; set; }
    }

    // @interface Indexing (SCIAnnotationCollection)
    [Category]
    [BaseType(typeof(SCIAnnotationCollection))]
    interface SCIAnnotationCollection_Indexing
    {
        // -(id<SCIAnnotationProtocol>)objectAtIndexedSubscript:(unsigned int)idx;
        [Export("objectAtIndexedSubscript:")]
        ISCIAnnotationProtocol ObjectAtIndexedSubscript(uint idx);

        // -(void)setObject:(id<SCIAnnotationProtocol>)obj atIndexedSubscript:(unsigned int)idx;
        [Export("setObject:atIndexedSubscript:")]
        void SetObject(ISCIAnnotationProtocol obj, uint idx);
    }
}