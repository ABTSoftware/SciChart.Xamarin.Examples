using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIBoxAnnotation
    {
        private static readonly NSString X1Method = new NSString("x1");
        private static readonly NSString SetX1Method = new NSString("setX1:");
        public IComparable X1Value
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, X1Method); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetX1Method, ComparableUtil.ToDouble(value)); }
        }

        private static readonly NSString Y1Method = new NSString("y1");
        private static readonly NSString SetY1Method = new NSString("setY1:");
        public IComparable Y1Value
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, Y1Method); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetY1Method, ComparableUtil.ToDouble(value)); }
        }

        private static readonly NSString X2Method = new NSString("x2");
        private static readonly NSString SetX2Method = new NSString("setX2:");
        public IComparable X2Value
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, X2Method); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetX2Method, ComparableUtil.ToDouble(value)); }
        }

        private static readonly NSString Y2Method = new NSString("y2");
        private static readonly NSString SetY2Method = new NSString("setY2:");
        public IComparable Y2Value
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, Y2Method); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetY2Method, ComparableUtil.ToDouble(value)); }
        }
    }
}