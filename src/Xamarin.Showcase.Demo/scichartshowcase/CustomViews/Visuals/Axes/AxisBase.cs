using System;
using scichartshowcase.CustomViews.Data.Ranges;

namespace scichartshowcase.CustomViews.Visuals.Axes
{
    public enum AxisType
    {
        NumericAxis,
        DateTimeAxis
    }

    public enum AxisAlignment
    {
        Auto,
        Bottom,
        Left,
        Right,
        Top
    }

    public class AxisBase
    {
        public AxisType AxisType { get; set; }
        public AutoRange AutoRange { get; set; }
        public DoubleRange VisibleRange { get; set; }
        public AxisAlignment AxisAlignment { get; set; }

        public bool DrawMajorBands { get; set; }
        public bool DrawMinorTicks { get; set; }
        public bool DrawMajorGridLines { get; set; }
        public bool DrawMinorGridLines { get; set; }
        public bool DrawLabels { get; set; }
        public bool DrawMajorTicks { get; set; }
        public bool FlipCoordinates { get; set; }

        public AxisBase(AxisType axisType)
        {
            this.AxisType = axisType;
            DrawMajorBands = true;
            DrawMinorTicks = true;
            DrawMajorGridLines = true;
            DrawMinorGridLines = true;
            DrawLabels = true;
            DrawMajorTicks = true;

            FlipCoordinates = false;
        }
    }
}
