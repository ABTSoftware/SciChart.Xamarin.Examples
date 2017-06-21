using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIDoubleRange : ISCIRangeProtocol<double>
    {
        public SCIDoubleRange(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public double Min
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMinMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMinMethod, value); }
        }

        public double Max
        {
            get { return SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMaxMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMaxMethod, value); }
        }

        public double Diff()
        {
            return SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.DiffMethod);
        }

        public void SetMinMax(double min, double max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.SetMinToMaxToMethod, min, max);
        }

        public void GrowMinMax(double min, double max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.GrowMinMaxMethod, min, max);
        }
    }
}