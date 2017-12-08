using System;
namespace scichartshowcase.CustomViews.Data.Ranges
{
    public enum AutoRange
    {
        Once,
        Always,
        Never
    }

    public class DoubleRange
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
