using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisBase : SCIAxisCore <SCIAxis2DProtocol, SCIThemeableProtocol>
    [BaseType(typeof(SCIAxisCore))]
    interface SCIAxisBase : SCIAxis2DProtocol, SCIThemeableProtocol
    {
        // +(NSString *)defaultAxisId;
        [Static]
        [Export("defaultAxisId")]
        string DefaultAxisId { get; }

        // -(int)minDistanceToBounds;
        [Export("minDistanceToBounds")]
        int MinDistanceToBounds { get; }

        // -(double)zeroRangeGrowBy;
        [Export("zeroRangeGrowBy")]
        double ZeroRangeGrowBy { get; }

        // -(id<SCIRenderSurfaceProtocol>)renderSurface;
        [Export("renderSurface")]
        ISCIRenderSurfaceProtocol RenderSurface { get; }

        // -(id<SCIRangeProtocol>)coerceZeroRange:(id<SCIRangeProtocol>)maximumRange;
        [Export("coerceZeroRange:")]
        ISCIRangeProtocol CoerceZeroRange(ISCIRangeProtocol maximumRange);

        // -(SCIArrayController *)getSupportedTypes;
        [Export("getSupportedTypes")]
        SCIArrayController GetSupportedTypes();

        // -(SCIAxisParams *)getAxisParams;
        [Export("getAxisParams")]
        SCIAxisParams GetAxisParams();

        // @property (nonatomic) BOOL isLicenseValid;
        [Export("isLicenseValid")]
        bool IsLicenseValid { get; set; }

        // -(void)drawGridLinesWithContext:(id<SCIRenderContext2DProtocol>)renderContext WithCoordinates:(SCITickCoordinates *)tickCoords;
        [Export("drawGridLinesWithContext:WithCoordinates:")]
        void DrawGridLinesWithContext(ISCIRenderContext2DProtocol renderContext, SCITickCoordinates tickCoords);

        // -(void)onDrawAxis:(SCITickCoordinates *)tickCoords;
        [Export("onDrawAxis:")]
        void OnDrawAxis(SCITickCoordinates tickCoords);

        // -(double)getOffsetForLabels;
        [Export("getOffsetForLabels")]
        double OffsetForLabels { get; }

        // -(SCIGenericType)convertTickToDataValue:(SCIGenericType)value;
        [Export("convertTickToDataValue:")]
        SCIGenericType ConvertTickToDataValue(SCIGenericType value);

        // -(void)drawAxisAreaWithContext:(id<SCIRenderContext2DProtocol>)renderContext;
        [Export("drawAxisAreaWithContext:")]
        void DrawAxisArea(ISCIRenderContext2DProtocol renderContext);

        // -(void)drawBandsWithContext:(id<SCIRenderContext2DProtocol>)renderContext;
        [Export("drawBandsWithContext:")]
        void DrawBands(ISCIRenderContext2DProtocol renderContext);

        // -(void)drawMinorGridLinesWithContext:(id<SCIRenderContext2DProtocol>)renderContext;
        [Export("drawMinorGridLinesWithContext:")]
        void DrawMinorGridLines(ISCIRenderContext2DProtocol renderContext);

        // -(void)drawMajorGridLinesWithContext:(id<SCIRenderContext2DProtocol>)renderContext;
        [Export("drawMajorGridLinesWithContext:")]
        void DrawMajorGridLines(ISCIRenderContext2DProtocol renderContext);
    }

    [Category, BaseType(typeof(SCIAxisBase))]
    interface SCIAxisBase_Category
    {
        // - (SCIArrayController*)currentController;
        [Export("currentController")]
        SCIArrayController CurrentController();

        //- (id<SCIRangeProtocol>)categoryVisibleRange;
        [Export("categoryVisibleRange")]
        SCIRangeProtocol CategoryVisibleRange();
    }
}