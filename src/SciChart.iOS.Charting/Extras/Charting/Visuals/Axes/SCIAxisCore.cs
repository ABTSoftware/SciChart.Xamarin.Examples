using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
public partial class SCIAxisCore
    {
        // @property(nonatomic) SCIGenericType minimalZoomConstrain;
        private static readonly NSString MinimalZoomConstrainMethod = new NSString("minimalZoomConstrain");
        private static readonly NSString SetMinimalZoomConstrainMethod = new NSString("setMinimalZoomConstrain:");
        public IComparable MinimalZoomConstrain
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, MinimalZoomConstrainMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetMinimalZoomConstrainMethod, ComparableUtil.ToDouble(value)); }
        }

        // @property(nonatomic) SCIGenericType maximalZoomConstrain;
        private static readonly NSString MaximalZoomConstrainMethod = new NSString("maximalZoomConstrain");
        private static readonly NSString SetMaximalZoomConstrainMethod = new NSString("setMaximalZoomConstrain:");
        public IComparable MaximalZoomConstrain
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, MaximalZoomConstrainMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetMaximalZoomConstrainMethod, ComparableUtil.ToDouble(value)); }
        }

        // - (double)getCoordinate:(SCIGenericType)value;
        private static readonly NSString GetCoordinateMethod = new NSString("getCoordinate:");
        public virtual double GetCoordinate(IComparable dataValue)
        {
            return SCIXamarinMessageResolver.sendMessageGD(this, GetCoordinateMethod, ComparableUtil.ToDouble(dataValue));
        }

        // - (SCIGenericType)getDataValue:(double)pixelCoordinate;
        private static readonly NSString GetDataValueMethod = new NSString("getDataValue:");
        public virtual IComparable GetDataValue(double pixelCoordinate)
        {
            return SCIXamarinMessageResolver.sendMessageGD(this, GetDataValueMethod, pixelCoordinate);
        }
    }
}