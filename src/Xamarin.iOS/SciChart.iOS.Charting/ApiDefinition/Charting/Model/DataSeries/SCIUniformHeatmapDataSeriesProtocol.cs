using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIUniformHeatmapDataSeriesProtocol { }

    // @protocol SCIUniformHeatmapDataSeriesProtocol <SCIDataSeriesProtocol>
    [Protocol, Model]
    interface SCIUniformHeatmapDataSeriesProtocol : SCIDataSeriesProtocol
    {
        // @required @property (nonatomic, strong) id<SCIRangeProtocol> _Nullable xRange;
        //[Abstract] TODO CHeck Abstract on XRange in heatmap
        [NullAllowed, Export("xRange", ArgumentSemantic.Strong)]
        new ISCIRangeProtocol XRange { get; set; }

        // @required @property (nonatomic, strong) id<SCIRangeProtocol> _Nullable yRange;
        //[Abstract] TODO CHeck Abstract on YRange in heatmap
        [NullAllowed, Export("yRange", ArgumentSemantic.Strong)]
        new ISCIRangeProtocol YRange { get; set; }

        // @required @property (nonatomic) SCIGenericType stepX;
        [Abstract]
        [Export("stepX", ArgumentSemantic.Assign)]
        SCIGenericType StepX_native { get; set; }

        // @required @property (nonatomic) SCIGenericType stepY;
        [Abstract]
        [Export("stepY", ArgumentSemantic.Assign)]
        SCIGenericType StepY_native { get; set; }

        // @required @property (nonatomic) SCIGenericType startX;
        [Abstract]
        [Export("startX", ArgumentSemantic.Assign)]
        SCIGenericType StartX_native { get; set; }

        // @required @property (nonatomic) SCIGenericType startY;
        [Abstract]
        [Export("startY", ArgumentSemantic.Assign)]
        SCIGenericType StartY_native { get; set; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)xIndices;
        [Abstract]
        [Export("xIndices")]
        ISCIArrayControllerProtocol XIndices { get; }

        // @required -(id<SCIArrayControllerProtocol> _Nonnull)yIndices;
        [Abstract]
        [Export("yIndices")]
        ISCIArrayControllerProtocol YIndices { get; }

        // @required -(SCIArrayController2D * _Nonnull)zValues;
        [Abstract]
        [Export("zValues")]
        SCIArrayController2D ZValues { get; }

        // @required -(int)sizeX;
        [Abstract]
        [Export("sizeX")]
        int SizeX { get; }

        // @required -(int)sizeY;
        [Abstract]
        [Export("sizeY")]
        int SizeY { get; }

        // @required -(void)updateZAtXIndex:(int)xIndex yIndex:(int)yIndex withValue:(SCIGenericType)value;
        [Abstract]
        [Export("updateZAtXIndex:yIndex:withValue:")]
        void UpdateZAtXIndex(int xIndex, int yIndex, SCIGenericType value);

        // @required -(void)updateZValues:(SCIArrayController2D * _Nonnull)values;
        [Abstract]
        [Export("updateZValues:")]
        void UpdateZValues(SCIArrayController2D values);

        // @required -(void)updateZValues:(SCIGenericType)values Size:(int)size;
        [Abstract]
        [Export("updateZValues:Size:")]
        void UpdateZValues(SCIGenericType values, int size);

        // @required -(void)updateRangeZAtXIndex:(int)xIndex yIndex:(int)yIndex withValues:(SCIArrayController2D * _Nonnull)values;
        [Abstract]
        [Export("updateRangeZAtXIndex:yIndex:withValues:")]
        void UpdateRangeZAtXIndex(int xIndex, int yIndex, SCIArrayController2D values);

        // @required -(void)updateRangeZAtXIndex:(int)xIndex yIndex:(int)yIndex withValues:(SCIGenericType)values count:(int)count;
        [Abstract]
        [Export("updateRangeZAtXIndex:yIndex:withValues:count:")]
        void UpdateRangeZAtXIndex(int xIndex, int yIndex, SCIGenericType values, int count);
    }
}