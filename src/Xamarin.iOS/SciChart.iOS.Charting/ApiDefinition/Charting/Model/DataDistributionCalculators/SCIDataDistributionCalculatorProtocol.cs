using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIDataDistributionCalculatorProtocol { }

    // @protocol SCIDataDistributionCalculatorProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIDataDistributionCalculatorProtocol
    {
        // @required -(BOOL)dataIsSortedAscending;
        [Abstract]
        [Export("dataIsSortedAscending")]
        bool DataIsSortedAscending { get; set; }

        // @required -(BOOL)dataIsEvenlySpaced;
        [Abstract]
        [Export("dataIsEvenlySpaced")]
        bool DataIsEvenlySpaced { get; set; }

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // @required -(void)onAppendValueInArrayController:(id<SCIArrayControllerProtocol>)array andCount:(int)count acceptsUnsortedData:(BOOL)acceptsUnsortedData;
        [Abstract]
        [Export("onAppendValueInArrayController:andCount:acceptsUnsortedData:")]
        void OnAppendValueInArrayController(SCIArrayControllerProtocol array, int count, bool acceptsUnsortedData);

        // @required -(void)onUpdateValueInArrayController:(id<SCIArrayControllerProtocol>)array atIndex:(int)atIndex acceptsUnsortedData:(BOOL)acceptsUnsortedData;
        [Abstract]
        [Export("onUpdateValueInArrayController:atIndex:acceptsUnsortedData:")]
        void OnUpdateValueInArrayController(SCIArrayControllerProtocol array, int atIndex, bool acceptsUnsortedData);

        // @required -(void)onInsertValueInArrayController:(id<SCIArrayControllerProtocol>)array atIndex:(int)atIndex andCount:(int)count acceptsUnsortedData:(BOOL)acceptsUnsortedData;
        [Abstract]
        [Export("onInsertValueInArrayController:atIndex:andCount:acceptsUnsortedData:")]
        void OnInsertValueInArrayController(SCIArrayControllerProtocol array, int atIndex, int count, bool acceptsUnsortedData);
    }
}