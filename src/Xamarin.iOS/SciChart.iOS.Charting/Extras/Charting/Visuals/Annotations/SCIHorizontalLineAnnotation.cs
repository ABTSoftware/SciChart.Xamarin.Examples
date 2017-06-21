using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIHorizontalLineAnnotation
    {
        // @property(nonatomic) SCIGenericType x1;
        private static readonly NSString X1Method = new NSString("x1");
        private static readonly NSString SetX1Method = new NSString("setX1:");
        public IComparable X1Value
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, X1Method); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetX1Method, ComparableUtil.ToDouble(value)); }
        }

        // @property(nonatomic) SCIGenericType x2;
        private static readonly NSString X2Method = new NSString("x2");
        private static readonly NSString SetX2Method = new NSString("setX2:");
        public IComparable X2Value
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, X2Method); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetX2Method, ComparableUtil.ToDouble(value)); }
        }

		// @property(nonatomic) SCIGenericType y;
		private static readonly NSString YMethod = new NSString("y");
		private static readonly NSString SetYMethod = new NSString("setY:");
		public IComparable YValue
		{
			get { return SCIXamarinMessageResolver.sendMessageGV(this, YMethod); }
			set { SCIXamarinMessageResolver.sendMessageVG(this, SetYMethod, ComparableUtil.ToDouble(value)); }
		}

        // -(NSString *) formatValue:(SCIGenericType)value;
        private static readonly NSString FormatValueMethod = new NSString("formatValue:");
        public string FormatValue(IComparable value)
        {
            return SCIXamarinMessageResolver.sendMessageSG(this, FormatValueMethod, ComparableUtil.ToDouble(value));
        }
    }
}