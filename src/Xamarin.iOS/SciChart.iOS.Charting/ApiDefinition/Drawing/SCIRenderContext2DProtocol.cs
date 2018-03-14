using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderContext2DProtocol { }

    // @protocol SCIRenderContext2DProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIRenderContext2DProtocol
    {
        // @required -(void)invalidate;
        [Abstract]
        [Export("invalidate")]
        void Invalidate();

        // @required @property (copy, nonatomic) SCIActionBlock invalidated;
        [Abstract]
        [Export("invalidated", ArgumentSemantic.Copy)]
        SCIActionBlock Invalidated { get; set; }

        // @required @property (nonatomic, weak) id<SCIRenderSurfaceProtocol> parentRenderSurface;
        [Abstract]
        [Export("parentRenderSurface", ArgumentSemantic.Weak)]
        ISCIRenderSurfaceProtocol ParentRenderSurface { get; set; }

        // @required @property (nonatomic) BOOL wasChanged;
        [Abstract]
        [Export("wasChanged")]
        bool WasChanged { get; set; }

        // @required -(CGSize)viewportSize;
        [Abstract]
        [Export("viewportSize")]
        CGSize ViewportSize { get; }

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // @required -(void)performDrawingCommands;
        [Abstract]
        [Export("performDrawingCommands")]
        void PerformDrawingCommands();

        // @required -(void)drawLineWithBrush:(id<SCIPen2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY;
        [Abstract]
        [Export("drawLineWithBrush:fromX:Y:toX:Y:")]
        void DrawLine(ISCIPen2DProtocol brush, float startX, float startY, float endX, float endY);

        // @required -(void)drawRectWithBrush:(id<SCIBrush2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY;
        [Abstract]
        [Export("drawRectWithBrush:fromX:Y:toX:Y:")]
        void DrawRect(ISCIBrush2DProtocol brush, float startX, float startY, float endX, float endY);

        // @required -(void)drawTriangleWithBrush:(id<SCIBrush2DProtocol>)brush X1:(float)x1 Y1:(float)y1 X2:(float)x2 Y2:(float)y2 X3:(float)x3 Y3:(float)y3;
        [Abstract]
        [Export("drawTriangleWithBrush:X1:Y1:X2:Y2:X3:Y3:")]
        void DrawTriangle(ISCIBrush2DProtocol brush, float x1, float y1, float x2, float y2, float x3, float y3);

        // @required -(void)renderEllipseToBufferX:(SCIArrayController *)xBuffer Y:(SCIArrayController *)yBuffer RadiusVertical:(float)radiusV RadiusHorizontal:(float)radiusH Detalization:(int)details;
        [Abstract]
        [Export("renderEllipseToBufferX:Y:RadiusVertical:RadiusHorizontal:Detalization:")]
        void RenderEllipse(SCIArrayController xBuffer, SCIArrayController yBuffer, float radiusV, float radiusH, int details);

        // @required -(void)drawEllipseWithBrush:(id<SCIBrush2DProtocol>)brush WithCenterX:(float)cx Y:(float)cy XData:(SCIArrayController *)xData YData:(SCIArrayController *)yData;
        [Abstract]
        [Export("drawEllipseWithBrush:WithCenterX:Y:XData:YData:")]
        void DrawEllipse(ISCIBrush2DProtocol brush, float cx, float cy, SCIArrayController xData, SCIArrayController yData);

        // @required -(void)drawSpriteWithBrush:(id<SCIBrush2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY;
        [Abstract]
        [Export("drawSpriteWithBrush:fromX:Y:toX:Y:")]
        void DrawSprite(ISCIBrush2DProtocol brush, float startX, float startY, float endX, float endY);

        // @required -(void)drawSpriteWithBrush:(id<SCIBrush2DProtocol>)brush fromX:(float)startX Y:(float)startY toX:(float)endX Y:(float)endY swapVertically:(BOOL)swapVertically swapHorizontally:(BOOL)swapHorizontally andSwapedAxesPlaces:(BOOL)axesSwaped;
        [Abstract]
        [Export("drawSpriteWithBrush:fromX:Y:toX:Y:swapVertically:swapHorizontally:andSwapedAxesPlaces:")]
        void DrawSprite(ISCIBrush2DProtocol brush, float startX, float startY, float endX, float endY, bool swapVertically, bool swapHorizontally, bool axesSwaped);

        // @required -(void)beginPolylineWithBrush:(id<SCIPen2DProtocol>)brush withPointX:(float)X Y:(float)Y;
        [Abstract]
        [Export("beginPolylineWithBrush:withPointX:Y:")]
        void BeginPolyline(ISCIPen2DProtocol brush, float X, float Y);

        // @required -(void)extendPolylineWithBrush:(id<SCIPen2DProtocol>)brush withPointX:(float)X Y:(float)Y;
        [Abstract]
        [Export("extendPolylineWithBrush:withPointX:Y:")]
        void ExtendPolyline(ISCIPen2DProtocol brush, float X, float Y);

        // @required -(void)drawPolylineWithBrush:(id<SCIPen2DProtocol>)brush WithXData:(SCIArrayController *)xArray YData:(SCIArrayController *)yArray StartingIndex:(int)startingIndex;
        [Abstract]
        [Export("drawPolylineWithBrush:WithXData:YData:StartingIndex:")]
        void DrawPolyline(ISCIPen2DProtocol brush, SCIArrayController xArray, SCIArrayController yArray, int startingIndex);

        // @required -(void)beginZeroToLineAreaWithBrush:(id<SCIBrush2DProtocol>)brush withPointX:(float)X Y:(float)Y Zero:(float)zero IsVertical:(BOOL)isVertical;
        [Abstract]
        [Export("beginZeroToLineAreaWithBrush:withPointX:Y:Zero:IsVertical:")]
        void BeginZeroToLineArea(ISCIBrush2DProtocol brush, float X, float Y, float zero, bool isVertical);

        // @required -(void)extendZeroToLineAreaWithBrush:(id<SCIBrush2DProtocol>)brush withPointX:(float)X Y:(float)Y Zero:(float)zero IsVertical:(BOOL)isVertical;
        [Abstract]
        [Export("extendZeroToLineAreaWithBrush:withPointX:Y:Zero:IsVertical:")]
        void ExtendZeroToLineArea(ISCIBrush2DProtocol brush, float X, float Y, float zero, bool isVertical);

        // @required -(void)beginBandAreaWithBrush1:(id<SCIBrush2DProtocol>)brush1 Brush2:(id<SCIBrush2DProtocol>)brush2 withPointX:(float)X Y1:(float)Y1 Y2:(float)Y2 IsVertical:(BOOL)isVertical;
        [Abstract]
        [Export("beginBandAreaWithBrush1:Brush2:withPointX:Y1:Y2:IsVertical:")]
        void BeginBandArea(ISCIBrush2DProtocol brush1, ISCIBrush2DProtocol brush2, float X, float Y1, float Y2, bool isVertical);

        // @required -(void)extendBandAreaWithBrush1:(id<SCIBrush2DProtocol>)brush1 Brush2:(id<SCIBrush2DProtocol>)brush2 withPointX:(float)X Y1:(float)Y1 Y2:(float)Y2 IsVertical:(BOOL)isVertical;
        [Abstract]
        [Export("extendBandAreaWithBrush1:Brush2:withPointX:Y1:Y2:IsVertical:")]
        void ExtendBandArea(ISCIBrush2DProtocol brush1, ISCIBrush2DProtocol brush2, float X, float Y1, float Y2, bool isVertical);

        // @required -(void)beginNewPrimitive;
        [Abstract]
        [Export("beginNewPrimitive")]
        void BeginNewPrimitive();

        // @required -(void)setDrawingArea:(CGRect)frame;
        [Abstract]
        [Export("setDrawingArea:")]
        void SetDrawingArea(CGRect frame);

        // @required -(id<SCIPen2DProtocol>)createPenFromStyle:(id<SCIPenStyleProtocol>)style;
        [Abstract]
        [Export("createPenFromStyle:")]
        ISCIPen2DProtocol CreatePen(ISCIPenStyleProtocol penStyle);

        // @required -(id<SCIBrush2DProtocol>)createBrushFromStyle:(id<SCIBrushStyleProtocol>)style;
        [Abstract]
        [Export("createBrushFromStyle:")]
        ISCIBrush2DProtocol CreateBrush(ISCIBrushStyleProtocol brushStyle);
    }
}