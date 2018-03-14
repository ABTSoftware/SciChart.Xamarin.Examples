using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisParams : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIAxisParams
    {
        // -(BOOL)equals:(id)obj;
        [Export("equals:")]
        bool Equals(NSObject obj);
    }
}