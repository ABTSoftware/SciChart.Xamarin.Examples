using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // audit-objc-generics: @interface SCIObservableCollection<__covariant ObjectType> : NSObject <NSFastEnumeration>
    [BaseType(typeof(NSObject))]
    interface SCIObservableCollection
    {
        // -(int)count;
        [Export("count")]
        int Count { get; }

        // -(void)clear;
        [Export("clear")]
        void Clear();

        // -(void)add:(ObjectType)item;
        [Export("add:")]
        void Add(NSObject item);

        // -(BOOL)remove:(ObjectType)item;
        [Export("remove:")]
        bool Remove(NSObject item);

        // -(void)removeAt:(int)index;
        [Export("removeAt:")]
        void RemoveAt(int index);

        // -(ObjectType)itemAt:(int)index;
        [Export("itemAt:")]
        NSObject ItemAt(int index);

        // -(void)insert:(ObjectType)item At:(int)index;
        [Export("insert:At:")]
        void Insert(NSObject item, int index);

        // -(ObjectType)firstObject;
        [Export("firstObject")]
        NSObject FirstObject { get; }

        // -(void)setObject:(id)object atIndex:(unsigned int)index;
        [Export("setObject:atIndex:")]
        void SetObject(NSObject @object, uint index);

        // -(BOOL)contains:(ObjectType)item;
        [Export("contains:")]
        bool Contains(NSObject item);

        // -(int)indexOf:(ObjectType)item;
        [Export("indexOf:")]
        int IndexOf(NSObject item);

        //TODO should be event
        // -(void)addObserver:(SCICollectionObserver *)observer;
        [Export("addObserver:")]
        void AddObserver(SCICollectionObserver observer);

        // -(void)removeObserver:(SCICollectionObserver *)observer;
        [Export("removeObserver:")]
        void RemoveObserver(SCICollectionObserver observer);
    }

    // @interface Indexing (SCIObservableCollection)
    [Category]
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIObservableCollection_Indexing
    {
        // -(ObjectType)objectAtIndexedSubscript:(unsigned int)idx;
        [Export("objectAtIndexedSubscript:")]
        NSObject ObjectAtIndexedSubscript(uint idx);

        // -(void)setObject:(ObjectType)obj atIndexedSubscript:(unsigned int)idx;
        [Export("setObject:atIndexedSubscript:")]
        void SetObject(NSObject obj, uint idx);
    }
}