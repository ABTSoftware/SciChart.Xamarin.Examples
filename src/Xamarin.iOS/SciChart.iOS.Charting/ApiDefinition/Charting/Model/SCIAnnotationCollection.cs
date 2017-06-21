using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAnnotationCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIAnnotationCollection
    {
        // - (id)initWithChildAnnotations:(NSArray<id <SCIAnnotationProtocol>> *)childAnnotations;
        [Export("initWithChildAnnotations:")]
        IntPtr Constructor([Params]ISCIAnnotationProtocol[] childAnnotations);

        // - (id <SCIAnnotationProtocol>)itemByName:(NSString *)name;
        [Export("itemByName:")]
        ISCIAnnotationProtocol ItemByName(string name);

        // - (void)add:(id <SCIAnnotationProtocol>)item;
        [Export("add:")]
        void Add(ISCIAnnotationProtocol item);

        // - (BOOL)remove:(id <SCIAnnotationProtocol>)item;
        [Export("remove:")]
        bool Remove(ISCIAnnotationProtocol item);

        // - (id <SCIAnnotationProtocol>)itemAt:(int)index;
        [Export("itemAt:")]
        ISCIAnnotationProtocol ItemAt(int index);

        // - (void)insert:(id <SCIAnnotationProtocol>)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIAnnotationProtocol item, int index);

        // - (id <SCIAnnotationProtocol>)firstObject;
        [Export("firstObject")]
        ISCIAnnotationProtocol FirstObject { get; }

        // - (BOOL)contains:(id <SCIAnnotationProtocol>)item;
        [Export("contains:")]
        bool Contains(ISCIAnnotationProtocol item);

        // - (int)indexOf:(id <SCIAnnoationProtocol>)item;
        [Export("indexOf:")]
        int IndexOf(ISCIAnnotationProtocol item);

        // - (void)setAnnotation:(id <SCIAnnotationProtocol>)annotation atIndex(unsigned int)index;
        [Export("setAnnotation:atIndex:")]
        void SetAnnotation(ISCIAnnotationProtocol annotation, int index);

        // @property (nonatomic) BOOL handleGestureFirstOnly;
        [Export("handleGestureFirstOnly")]
        bool HandleGestureFirstOnly { get; set; }
    }
}