using System;

namespace SciChart.iOS.Charting
{
    public partial interface ISCIRangeProtocol<T> : ISCIRangeProtocol where T : IComparable
    {
        T Min { get; set; }

        T Max { get; set; }

        T Diff { get; }

        void SetMinMax(T min, T max);
    }
}