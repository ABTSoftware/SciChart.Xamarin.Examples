using System.Linq;
using System.Collections.Generic;


namespace SciChart.Examples.Demo.Data
{
    public class DoubleSeries : List<XyPoint>
    {
        public DoubleSeries()
        {
        }

        public DoubleSeries(int capacity) : base(capacity)
        {
        }

        public IList<double> XData { get { return this.Select(x => x.X).ToArray(); } }
        public IList<double> YData { get { return this.Select(x => x.Y).ToArray(); } }
    }
} 