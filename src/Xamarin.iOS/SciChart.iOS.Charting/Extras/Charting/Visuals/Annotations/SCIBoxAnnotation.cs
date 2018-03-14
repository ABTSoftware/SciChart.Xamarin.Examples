using System;

namespace SciChart.iOS.Charting
{
    public partial class SCIBoxAnnotation
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

        public IComparable X2Value
        {
            get { return X2.ToComparable(); }
            set { X2 = value.FromComparable(); }
        }

        public IComparable Y2Value
        {
            get { return Y2.ToComparable(); }
            set { Y2 = value.FromComparable(); }
        }
    }
}