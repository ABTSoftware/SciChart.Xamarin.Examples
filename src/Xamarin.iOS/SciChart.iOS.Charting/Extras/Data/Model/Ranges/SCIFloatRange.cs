namespace SciChart.iOS.Charting
{
    public partial class SCIFloatRange : ISCIRangeProtocol<float>
    {
        public SCIFloatRange(float min, float max) : this(new SCIGenericType(min), new SCIGenericType(max))
        {
        }

        public float Min
        {
            get { return Min_native.floatData; }
            set { Min_native = new SCIGenericType(value); }
        }

        public float Max
        {
            get { return Max_native.floatData; }
            set { Max_native = new SCIGenericType(value); }
        }

        public float Diff => Diff_native.floatData;

        public void SetMinMax(float min, float max)
        {
            SetMinMax(new SCIGenericType(min), new SCIGenericType(max));
        }
    }
}