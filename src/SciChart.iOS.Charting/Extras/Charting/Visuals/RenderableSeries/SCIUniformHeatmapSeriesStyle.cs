using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIUniformHeatmapSeriesStyle
    {
        protected static NSString _minimum = new NSString("minimum");
        protected static NSString _setMinimum = new NSString("setMinimum:");

        public IComparable Minimum
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, _minimum); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, _setMinimum, ComparableUtil.ToDouble(value)); }
        }

        protected static NSString _maximum = new NSString("maximum");
        protected static NSString _setMaximum = new NSString("setMaximum:");

        public IComparable Maximum
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, _maximum); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, _setMaximum, ComparableUtil.ToDouble(value)); }
        }
    }
}