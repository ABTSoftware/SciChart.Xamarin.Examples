using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisArea : UIView
    [BaseType(typeof(UIView))]
    interface SCIAxisArea
    {
        // @property (nonatomic) SCIStackPanelOrientation orientation;
        [Export("orientation", ArgumentSemantic.Assign)]
        SCIStackPanelOrientation Orientation { get; set; }

        // -(int)count;
        [Export("count")]
        int Count { get; }

        // -(id<SCIAxis2DProtocol>)itemAt:(int)index;
        [Export("itemAt:")]
        ISCIAxis2DProtocol ItemAt(int index);

        // -(void)addItem:(id<SCIAxis2DProtocol>)item;
        [Export("addItem:")]
        void AddItem(ISCIAxis2DProtocol item);

        // -(void)insertItem:(id<SCIAxis2DProtocol>)item At:(int)index;
        [Export("insertItem:At:")]
        void InsertItem(ISCIAxis2DProtocol item, int index);

        // -(BOOL)contains:(id<SCIAxis2DProtocol>)item;
        [Export("contains:")]
        bool Contains(ISCIAxis2DProtocol item);

        // -(void)removeItem:(id<SCIAxis2DProtocol>)item;
        [Export("removeItem:")]
        void RemoveItem(ISCIAxis2DProtocol item);

        // -(void)removeItemAt:(int)index;
        [Export("removeItemAt:")]
        void RemoveItemAt(int index);

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();

        // -(void)clear;
        [Export("clear")]
        void Clear();

        // -(void)layout;
        [Export("layout")]
        void Layout();

        // -(float)recommendedSize;
        [Export("recommendedSize")]
        float RecommendedSize { get; }

        // @property (copy, nonatomic) SCIActionBlock resizeRequest;
        [Export("resizeRequest", ArgumentSemantic.Copy)]
        SCIActionBlock ResizeRequest { get; set; }

        // -(BOOL)hasEnoughSpace;
        [Export("hasEnoughSpace")]
        bool HasEnoughSpace { get; }

        // -(BOOL)needResizing;
        [Export("needResizing")]
        bool NeedResizing { get; }

        // @property (nonatomic) float forcedSize;
        [Export("forcedSize")]
        float ForcedSize { get; set; }
    }
}