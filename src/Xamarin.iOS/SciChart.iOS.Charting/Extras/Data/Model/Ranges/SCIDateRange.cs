using System;

namespace SciChart.iOS.Charting
{
    public partial class SCIDateRange : ISCIRangeProtocol<DateTime>
    {
        public SCIDateRange(DateTime min, DateTime max) : this(new SCIGenericType(min), new SCIGenericType(max))
        {
        }

        public DateTime Min
        {
            get { return Min_native.dateTimeData; }
            set { Min_native = new SCIGenericType(value); }
        }

        public DateTime Max
        {
            get { return Max_native.dateTimeData; }
            set { Max_native = new SCIGenericType(value); }
        }

        public DateTime Diff => Diff_native.dateTimeData;

        public void SetMinMax(DateTime min, DateTime max)
        {
            SetMinMax(new SCIGenericType(min), new SCIGenericType(max));
        }
    }
}