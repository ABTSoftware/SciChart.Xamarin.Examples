using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIVerticallyStackedColumnsCollection : SCIStackedSeriesCollectionBase
    [BaseType(typeof(SCIStackedSeriesCollectionBase))]
    interface SCIVerticallyStackedColumnsCollection : SCIStackedRenderableSeriesProtocol
    {
    }

    // @interface HorizontalShifts (SCIVerticallyStackedColumnsCollection) <SCIStackedRenderableSeriesProtocol>
    [Category]
    [BaseType(typeof(SCIVerticallyStackedColumnsCollection))]
    interface SCIVerticallyStackedColumnsCollection_HorizontalShifts 
    {
    }
}