using System;

namespace SciChart.iOS.Charting
{
    public partial class SCITextAnnotation
    {
        public IComparable X1Value
        {
            get { return X1.ToComparable(); }
            set { X1 = value.FromComparable(); }
        }

        public IComparable Y1Value
        {
            get { return Y1.ToComparable(); }
            set { Y1 = value.FromComparable(); }
        }
    }
}