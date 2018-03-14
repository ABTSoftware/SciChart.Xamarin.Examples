using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCICollectionChangedCallback)(SCICollectionChangedEventArgs *);
    delegate void SCICollectionChangedCallback(SCICollectionChangedEventArgs arg0);

    // @interface SCICollectionChangedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface SCICollectionChangedEventArgs
    {
        // @property (nonatomic, strong) NSArray * addedItems;
        [Export("addedItems", ArgumentSemantic.Strong)]
        NSObject[] AddedItems { get; set; }

        // @property (nonatomic, strong) NSArray * removedItems;
        [Export("removedItems", ArgumentSemantic.Strong)]
        NSObject[] RemovedItems { get; set; }

        // @property (nonatomic) int addedIndex;
        [Export("addedIndex")]
        int AddedIndex { get; set; }

        // @property (nonatomic) int removedIndex;
        [Export("removedIndex")]
        int RemovedIndex { get; set; }

        // @property (nonatomic) SCICollectionChangedAction action;
        [Export("action", ArgumentSemantic.Assign)]
        SCICollectionChangedAction Action { get; set; }

        // -(id)initWithAction:(SCICollectionChangedAction)action RemovedItems:(NSArray *)removedItems RemovedIndex:(int)removedIndex AddedItems:(NSArray *)addedItems AddedIndex:(int)addedIndex;
        [Export("initWithAction:RemovedItems:RemovedIndex:AddedItems:AddedIndex:")]
        IntPtr Constructor(SCICollectionChangedAction action, NSObject[] removedItems, int removedIndex, NSObject[] addedItems, int addedIndex);
    }
}