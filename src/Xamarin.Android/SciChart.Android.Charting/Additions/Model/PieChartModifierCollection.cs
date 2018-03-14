using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using SciChart.Charting.Modifiers;
using SciChart.Core.Observable;

namespace SciChart.Charting.Model
{
    public partial class PieChartModifierCollection : IList<IPieChartModifier>
    {
        public IEnumerator<IPieChartModifier> GetEnumerator()
        {
            return new Enumerator<IPieChartModifier>(this, o => (IPieChartModifier)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IPieChartModifier item)
        {
            base.Add(item as Object);
        }

        public bool Contains(IPieChartModifier item)
        {
            return base.Contains(item as Object);
        }

        public void CopyTo(IPieChartModifier[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(IPieChartModifier item)
        {
            return base.Remove(item as Object);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(IPieChartModifier item)
        {
            return base.IndexOf(item as Object);
        }

        public void Insert(int index, IPieChartModifier item)
        {
            base.Add(index, item as Object);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public IPieChartModifier this[int index]
        {
            get { return Get(index) as IPieChartModifier; }
            set { Set(index, value as Object); }
        }
    }
}