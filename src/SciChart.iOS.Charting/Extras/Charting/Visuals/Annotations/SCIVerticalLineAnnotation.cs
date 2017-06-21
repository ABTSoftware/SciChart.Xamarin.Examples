using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIVerticalLineAnnotation
    {
        // @property(nonatomic) SCIGenericType x1;
        private static readonly NSString XMethod = new NSString("x");
        private static readonly NSString SetXMethod = new NSString("setX:");
        public IComparable XValue
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, XMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetXMethod, ComparableUtil.ToDouble(value)); }
        }

        // @property(nonatomic) SCIGenericType y1;
        private static readonly NSString Y1Method = new NSString("y1");
        private static readonly NSString SetY1Method = new NSString("setY1:");
        public IComparable Y1Value
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, Y1Method); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetY1Method, ComparableUtil.ToDouble(value)); }
        }

		// @property(nonatomic) SCIGenericType y2;
		private static readonly NSString Y2Method = new NSString("y2");
		private static readonly NSString SetY2Method = new NSString("setY2:");
		public IComparable Y2Value
		{
			get { return SCIXamarinMessageResolver.sendMessageGV(this, Y2Method); }
			set { SCIXamarinMessageResolver.sendMessageVG(this, SetY2Method, ComparableUtil.ToDouble(value)); }
		}

        // -(NSString *) formatValue:(SCIGenericType)value;
        private static readonly NSString FormatValueMethod = new NSString("formatValue:");
        public string FormatValue(IComparable value)
        {
            return SCIXamarinMessageResolver.sendMessageSG(this, FormatValueMethod, ComparableUtil.ToDouble(value));
        }
    }
}