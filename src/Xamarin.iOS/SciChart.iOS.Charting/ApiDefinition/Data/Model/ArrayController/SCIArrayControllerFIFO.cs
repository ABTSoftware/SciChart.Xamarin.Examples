using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIArrayControllerFIFO : SCIArrayController
    [BaseType(typeof(SCIArrayController))]
    interface SCIArrayControllerFIFO
    {
        // -(int)headIndex;
        [Export("headIndex")]
        int HeadIndex { get; }

        // -(void)normalizeIndices;
        [Export("normalizeIndices")]
        void NormalizeIndices();
    }
}