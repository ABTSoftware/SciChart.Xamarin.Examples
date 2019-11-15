using System.Linq;
using System.Collections.Generic;

namespace Xamarin.Examples.Demo.Data
{
    public class DoubleSeries : List<XyPoint>
    {
        public DoubleSeries()
        {
        }

        public DoubleSeries(int capacity) : base(capacity)
        {
        }

        public double[] XData { get { return this.Select(x => x.X).ToArray(); } }
        public double[] YData { get { return this.Select(x => x.Y).ToArray(); } }
    }
} 