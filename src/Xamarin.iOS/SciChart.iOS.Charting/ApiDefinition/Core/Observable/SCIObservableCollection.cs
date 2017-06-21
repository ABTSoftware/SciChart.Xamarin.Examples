using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;
using System.Collections;

namespace SciChart.iOS.Charting
{
    // @interface SCIObservableCollection<__covariant ObjectType> : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIObservableCollection
    {
        // -(int) count;
        [Export("count")]
        int Count();

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

        // -(ObjectType) firstObject;
        [Export("firstObject")]
        NSObject FirstObject { get; }

        // -(BOOL)contains:(ObjectType)item;
        [Export("contains:")]
        bool Contains(NSObject item);

        // - (int)indexOf:(ObjectType)item;
        [Export("indexOf:")]
        int IndexOf(NSObject item);

        //TODO should be event
        // -(void) addObserver:(SCICollectionChangedCallback)observer;
        [Export("addObserver:")]
        void AddObserver(SCICollectionChangedCallback observer);

        // -(void) removeObserver:(SCICollectionChangedCallback)observer;
        [Export("removeObserver:")]
        void RemoveObserver(SCICollectionChangedCallback observer);
    }
}