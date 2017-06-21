using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIIntegerRange : ISCIRangeProtocol<int>
    {
        public SCIIntegerRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min
        {
            get { return (int)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMinMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMinMethod, value); }
        }

        public int Max
        {
            get { return (int)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMaxMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMaxMethod, value); }
        }

        public int Diff()
        {
            return (int)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.DiffMethod);
        }

        public void SetMinMax(int min, int max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.SetMinToMaxToMethod, min, max);
        }

        public void GrowMinMax(int min, int max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.GrowMinMaxMethod, min, max);
        }
    }
}