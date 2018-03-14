namespace SciChart.iOS.Charting
{
    public partial class SCIDoubleRange : ISCIRangeProtocol<double>
    {
        public SCIDoubleRange(double min, double max) : this(new SCIGenericType(min), new SCIGenericType(max))
        {
        }

        public double Min
        {
            get { return Min_native.doubleData; }
            set { Min_native = new SCIGenericType(value); }
        }

        public double Max
        {
            get { return Max_native.doubleData; }
            set { Max_native = new SCIGenericType(value); }
        }

        public double Diff => Diff_native.doubleData;

        public void SetMinMax(double min, double max)
        {
            SetMinMax(new SCIGenericType(min), new SCIGenericType(max));
        }
    }
}