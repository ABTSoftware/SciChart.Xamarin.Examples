using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public interface IRange : ISCIRangeProtocol
    {
        SCIDoubleRange AsDoubleRange();

        IRange ClipToRange(IRange maximumRange);

        bool Equals(IRange otherRange);

        IRange UnionWith(IRange range);

        IRange Clone();
    }

    public interface IRange<T> : IRange where T : IComparable
    {
        T Min { get; set; }

        T Max { get; set; }

        T Diff();

        void SetMinMax(T min, T max);

        void GrowMinMax(T min, T max);
    }
}