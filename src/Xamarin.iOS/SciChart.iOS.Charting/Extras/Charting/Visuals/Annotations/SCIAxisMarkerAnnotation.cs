using System;

namespace SciChart.iOS.Charting
{
    public partial class SCIAxisMarkerAnnotation
    {
        public IComparable Position
        {
            get { return Position_native.ToComparable(); }
            set { Position_native = value.FromComparable(); }
        }
    }
}