using System;
using Foundation;
namespace SciChart.iOS.Charting
{
    public partial class SCIArrayController2D
    {
        public static readonly NSString ValueAtXYMethod = new NSString("valueAtX:Y:");

        public IComparable ValueAt(int x, int y) {
            return SCIXamarinMessageResolver.sendMessageGII(this, ValueAtXYMethod, x, y);
        }

        public static readonly NSString SetValueAtXYMethod = new NSString("setValue:AtX:Y:");

		public void SetValueAt(IComparable value, int x, int y)
		{
			 SCIXamarinMessageResolver.sendMessageVGII(this, SetValueAtXYMethod, ComparableUtil.ToDouble(value), x, y);
		}
    }
}
