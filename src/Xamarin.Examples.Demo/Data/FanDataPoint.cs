using System;

namespace Xamarin.Examples.Demo.Data
{
    public class FanDataPoint
    {
        public double MaxValue { get; set; }

        public double MinValue { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public double Value3 { get; set; }

        public double Value4 { get; set; }

        public double ActualValue { get; set; }

        public DateTime Date { get; set; }

        public FanDataPoint()
        {
            MaxValue = double.NaN;
            MinValue = double.NaN;
            Value1 = double.NaN;
            Value2 = double.NaN;
            Value3 = double.NaN;
            Value4 = double.NaN;
        }

    }
}
