using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIFloatRange : ISCIRangeProtocol<float>
    {
        public SCIFloatRange(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public float Min
        {
            get { return (float)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMinMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMinMethod, value); }
        }

        public float Max
        {
            get { return (float)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.GetMaxMethod); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, RangeHelper.SetMaxMethod, value); }
        }

        public float Diff()
        {
            return (float)SCIXamarinMessageResolver.sendMessageGV(this, RangeHelper.DiffMethod);
        }

        public void SetMinMax(float min, float max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.SetMinToMaxToMethod, min, max);
        }

        public void GrowMinMax(float min, float max)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, RangeHelper.GrowMinMaxMethod, min, max);
        }
    }
}