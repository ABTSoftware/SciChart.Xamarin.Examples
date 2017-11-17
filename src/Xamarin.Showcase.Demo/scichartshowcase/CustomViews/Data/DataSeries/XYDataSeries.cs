using System;
using System.Collections;
using System.Collections.Generic;

namespace scichartshowcase.CustomViews.Data.DataSeries
{
    public class XYDataSeries<TX, TY> : DataSeries where TX : IComparable where TY : IComparable
    {
        public TX[] XValues { get; set; }
        public TY[] YValues { get; set; }

        public new int Count { get => YValues.Length; }

        public XYDataSeries() => SeriesType = DataSeriesType.Xy;
    }
}