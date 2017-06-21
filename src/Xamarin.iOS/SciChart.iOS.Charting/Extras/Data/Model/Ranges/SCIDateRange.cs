using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIDateRange : ISCIRangeProtocol<DateTime>
    {
        public SCIDateRange(DateTime min, DateTime max)
        {
            Min = min;
            Max = max;
        }

        public DateTime Min
        {
            get { return new DateTime((long)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMinMethod)); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMinMethod, value.Ticks); }
        }

        public DateTime Max
        {
            get { return new DateTime((long)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMaxMethod)); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMaxMethod, value.Ticks); }
        }

        public DateTime Diff()
        {
            return new DateTime((long)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.DiffMethod));
        }

        public void SetMinMax(DateTime min, DateTime max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.SetMinToMaxToMethod, min.Ticks, max.Ticks);
        }

        public void GrowMinMax(DateTime min, DateTime max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.GrowMinMaxMethod, min.Ticks, max.Ticks);
        }
    }
}