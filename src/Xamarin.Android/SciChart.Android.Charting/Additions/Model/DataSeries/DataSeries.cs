namespace SciChart.Charting.Model.DataSeries
{
    public partial class DataSeries
    {
        public int? FifoCapacityValue
        {
            get { return FifoCapacity?.IntValue(); }
            set { FifoCapacity = value.HasValue ? Java.Lang.Integer.ValueOf(value.Value) : null; }
        }
    }
}