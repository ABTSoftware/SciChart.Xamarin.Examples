using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCICallbackHelperProtocol { }

    // @protocol SCICallbackHelperProtocol
    [Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SCICallbackHelperProtocol
    {
        // @required -(void)setParentHandler:(SCICallbackHandler *)parent;
        [Abstract]
        [Export("setParentHandler:")]
        void SetParentHandler(SCICallbackHandler parent);

        // @required -(void)remove;
        [Abstract]
        [Export("remove")]
        void Remove();
    }
}