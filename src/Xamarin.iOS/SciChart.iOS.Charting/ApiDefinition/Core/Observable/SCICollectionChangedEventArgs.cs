using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    //typedef void (^SCICollectionChangedCallback) (SCICollectionChangedEventArgs *);
    delegate void SCICollectionChangedCallback(SCICollectionChangedEventArgs args); 

    // @interface SCICollectionChangedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface SCICollectionChangedEventArgs
    {
        //@property(nonatomic, strong) NSArray* addedItems;
        [Export("addedItems")]
        NSObject[] AddedItems { get; set; }

        //@property(nonatomic, strong) NSArray* removedItems;
        [Export("removedItems")]
        NSObject[] RemovedItems { get; set; }

        //@property(nonatomic) SCICollectionChangedAction action;
        [Export("action")]
        SCICollectionChangedAction Action { get; set; }

        //@property(nonatomic) int addedIndex;
        [Export("addedIndex")]
        int AddedIndex { get; set; }

        //@property(nonatomic) int removedIndex;
        [Export("removedIndex")]
        int RemovedIndex { get; set; }

        //-(id) initWithAction:(SCICollectionChangedAction)action RemovedItems:(NSArray*)removedItems RemovedIndex:(int)removedIndex AddedItems:(NSArray*)addedItems AddedIndex:(int)addedIndex;
        [Export("initWithAction:RemovedItems:RemovedIndex:AddedItems:AddedIndex:")]
        IntPtr Constructor(SCICollectionChangedAction action, NSObject[] removedItems, int removedIndex, NSObject[] addedItems, int addedIndex);
    }
}