namespace SciChart.iOS.Charting
{
    public partial class SCIIntegerRange : ISCIRangeProtocol<int>
    {
        public SCIIntegerRange(int min, int max) : this(new SCIGenericType(min), new SCIGenericType(max))
        {
        }

        public int Min
        {
            get { return Min_native.intData; }
            set { Min_native = new SCIGenericType(value); }
        }

        public int Max
        {
            get { return Max_native.intData; }
            set { Max_native = new SCIGenericType(value); }
        }

        public int Diff => Diff_native.intData;

        public void SetMinMax(int min, int max)
        {
            SetMinMax(new SCIGenericType(min), new SCIGenericType(max));
        }
    }
}