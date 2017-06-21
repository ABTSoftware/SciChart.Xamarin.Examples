using System.Collections;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public partial class SCIChartModifierCollection : IList<ISCIChartModifierProtocol>
    {
        public IEnumerator<ISCIChartModifierProtocol> GetEnumerator()
        {
            return new Enumerator<ISCIChartModifierProtocol>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(ISCIChartModifierProtocol[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Count; i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool IsReadOnly => false;

        public int Count => Count();

        public void Insert(int index, ISCIChartModifierProtocol item)
        {
            this.Insert(item, index);
        }

        public ISCIChartModifierProtocol this[int index]
        {
            get { return this.ItemAt(index); }
            set { SetModifier(value, index); }
        }
    }
}