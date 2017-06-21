using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIAxisMarkerAnnotation
    {
        private static readonly NSString PositionMethod = new NSString("position");
        private static readonly NSString SetPositionMethod = new NSString("setPosition:");
        public IComparable Position
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, PositionMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetPositionMethod, ComparableUtil.ToDouble(value)); }
        }

        // -(NSString *) formatValue:(SCIGenericType)value; 
        private static readonly NSString FormatValueMethod = new NSString("formatValue:");
        public string FormatValue(IComparable value)
        {
            return SCIXamarinMessageResolver.sendMessageSG(this, FormatValueMethod, ComparableUtil.ToDouble(value));
        }
    }
}