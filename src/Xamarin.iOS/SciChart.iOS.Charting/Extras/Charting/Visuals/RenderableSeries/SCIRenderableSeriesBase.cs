using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIRenderableSeriesBase
    {
        // @property(nonatomic) SCIGenericType dataAggregation;
        private static readonly NSString DataAggregationMethod = new NSString("dataAggregation");
        private static readonly NSString SetDataAggregationMethod = new NSString("setDataAggregation:");
        public IComparable DataAggregation
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, DataAggregationMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetDataAggregationMethod, ComparableUtil.ToDouble(value)); }
        }
    }
}