using System;
namespace scichartshowcase.CustomViews.Data.DataSeries
{
    public enum DataSeriesType
    {
        Xy,
        Xyz
    }

    public class DataSeries
    {
        public int Count { get; set; }
        public int FifoCapacity { get; set; }
        public string SeriesName { get; set; }
        public DataSeriesType SeriesType { get; set; }
    }
}
