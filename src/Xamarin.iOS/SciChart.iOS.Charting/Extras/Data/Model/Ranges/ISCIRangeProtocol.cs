using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial interface ISCIRangeProtocol<T> : ISCIRangeProtocol where T : IComparable
    {
        T Min { get; set; }

        T Max { get; set; }

        T Diff();

        void SetMinMax(T min, T max);

        void GrowMinMax(T min, T max);
    }
}