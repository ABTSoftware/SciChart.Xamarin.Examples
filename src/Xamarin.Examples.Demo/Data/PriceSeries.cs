using System;
using System.Collections.Generic;
using System.Linq;

namespace SciChart.Examples.Demo.Data
{
    public class PriceSeries : List<PriceBar>
    {
        public string Symbol { get; set; }

        public PriceSeries()
        {
        }

        public PriceSeries(int capacity) : base(capacity)
        {
        }

        /// <summary>
        /// Extracts the DateTime column of the PriceSeries as an array
        /// </summary>
        public DateTime[] TimeData { get { return this.Select(x => x.DateTime).ToArray(); } }

        /// <summary>
        /// Extracts the Open column of the PriceSeries as an array
        /// </summary>
        public double[] OpenData { get { return this.Select(x => x.Open).ToArray(); } }

        /// <summary>
        /// Extracts the High column of the PriceSeries as an array
        /// </summary>
        public double[] HighData { get { return this.Select(x => x.High).ToArray(); } }

        /// <summary>
        /// Extracts the Low column of the PriceSeries as an array
        /// </summary>
        public double[] LowData { get { return this.Select(x => x.Low).ToArray(); } }

        /// <summary>
        /// Extracts the Close column of the PriceSeries as an array
        /// </summary>
        public double[] CloseData { get { return this.Select(x => x.Close).ToArray(); } }

        /// <summary>
        /// Extracts the Volume column of the PriceSeries as an array
        /// </summary>
        public long[] VolumeData { get { return this.Select(x => x.Volume).ToArray(); } }

        public PriceSeries Clip(int startIndex, int endIndex)
        {
            var result = new PriceSeries(endIndex - startIndex);
            for (var i = startIndex; i < endIndex; i++)
            {
                result.Add(this[i]);
            }
            return result;
        }
    }
}