using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCICoordinateCalculatorProtocol : INSObjectProtocol { }

    // @protocol SCICoordinateCalculatorProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCICoordinateCalculatorProtocol
    {
        // @required -(BOOL)isCategoryAxisCalculator;
        [Abstract]
        [Export("isCategoryAxisCalculator")]
        bool IsCategoryAxisCalculator { get; }

        // @required -(BOOL)isLogarithmicAxisCalculator;
        [Abstract]
        [Export("isLogarithmicAxisCalculator")]
        bool IsLogarithmicAxisCalculator { get; }

        // @required -(BOOL)isHorizontalAxisCalculator;
        [Abstract]
        [Export("isHorizontalAxisCalculator")]
        bool IsHorizontalAxisCalculator { get; }

        // @required -(BOOL)isXAxisCalculator;
        [Abstract]
        [Export("isXAxisCalculator")]
        bool IsXAxisCalculator { get; }

        // @required -(BOOL)hasFlippedCoordinates;
        [Abstract]
        [Export("hasFlippedCoordinates")]
        bool HasFlippedCoordinates { get; }

        // @required -(BOOL)isPolarAxisCalculator;
        [Abstract]
        [Export("isPolarAxisCalculator")]
        bool IsPolarAxisCalculator { get; }

        // @required -(double)coordinatesOffset;
        [Abstract]
        [Export("coordinatesOffset")]
        double CoordinatesOffset { get; }

        // @required -(double)getCoordinateFromDate:(NSDate *)dataValue;
        [Abstract]
        [Export("getCoordinateFromDate:")]
        double GetCoordinateFromDate(NSDate dataValue);

        // @required -(double)getCoordinateFrom:(double)dataValue;
        [Abstract]
        [Export("getCoordinateFrom:")]
        double GetCoordinateFrom(double dataValue);

        // @required -(double)getDataValueFrom:(double)pixelCoordinate;
        [Abstract]
        [Export("getDataValueFrom:")]
        double GetDataValueFrom(double pixelCoordinate);

        // @required -(double)getVelocityValueFrom:(double)pixelVelocity;
        [Abstract]
        [Export("getVelocityValueFrom:")]
        double GetVelocityValueFrom(double pixelVelocity);

        // @required -(id<SCIRangeProtocol>)translateByPixels:(double)pixels InputRange:(id<SCIRangeProtocol>)inputRange;
        [Abstract]
        [Export("translateByPixels:InputRange:")]
        ISCIRangeProtocol TranslateByPixels(double pixels, ISCIRangeProtocol inputRange);

        // @required -(id<SCIRangeProtocol>)translateByMinFraction:(double)minFraction MaxFraction:(double)maxFraction InputRange:(id<SCIRangeProtocol>)inputRange;
        [Abstract]
        [Export("translateByMinFraction:MaxFraction:InputRange:")]
        ISCIRangeProtocol TranslateByMinFraction(double minFraction, double maxFraction, ISCIRangeProtocol inputRange);

        //// @required -(SCICoordinateCalculatorHelper)getCalculatorHelper;
        //[Abstract]
        //[Export("getCalculatorHelper")]
        //// TODO discuss with Andrii
        //SCICoordinateCalculatorHelper GetCalculatorHelper();
    }
}