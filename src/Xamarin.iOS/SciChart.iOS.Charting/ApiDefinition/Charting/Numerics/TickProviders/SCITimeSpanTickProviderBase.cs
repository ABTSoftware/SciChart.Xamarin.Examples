using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCITimeSpanTickProviderBase : NSObject <SCITickProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCITimeSpanTickProviderBase : SCITickProviderProtocol
    {
        // -(double)roundUp:(double)current Delta:(double)delta;
        [Export("roundUp:Delta:")]
        double RoundUp(double current, double delta);

        // -(BOOL)isAdditionValid:(double)current Delta:(double)delta;
        [Export("isAdditionValid:Delta:")]
        bool IsAdditionValid(double current, double delta);

        // -(double)addDelta:(double)current Delta:(double)delta;
        [Export("addDelta:Delta:")]
        double AddDelta(double current, double delta);

        // -(BOOL)isDateDivisible:(double)current ByDelta:(double)delta;
        [Export("isDateDivisible:ByDelta:")]
        bool IsDateDivisible(double current, double delta);
    }
}