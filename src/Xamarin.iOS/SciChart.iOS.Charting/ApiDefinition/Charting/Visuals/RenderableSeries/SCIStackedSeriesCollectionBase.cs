using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIStackedSeriesCollectionBase : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIStackedSeriesCollectionBase : SCIThemeableProtocol
    {
        // -(void)add:(id<SCIStackedRenderableSeriesProtocol>)series;
        [Export("add:")]
        void Add(ISCIStackedRenderableSeriesProtocol series);

        // -(void)remove:(id<SCIStackedRenderableSeriesProtocol>)series;
        [Export("remove:")]
        void Remove(ISCIStackedRenderableSeriesProtocol series);

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();

        // -(SCIRenderPassData *)renderDataForSeries:(id<SCIRenderableSeriesProtocol>)series;
        [Export("renderDataForSeries:")]
        SCIRenderPassData RenderDataForSeries(ISCIRenderableSeriesProtocol series);

        // @property BOOL isOneHundredPercentSeries;
        [Export("isOneHundredPercentSeries")]
        bool IsOneHundredPercentSeries { get; set; }

        // @required - (void)addAnimation:(id<SCIStackedSeriesCollectionAnimnationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIStackedSeriesCollectionAnimnationProtocol animation);
    }
}