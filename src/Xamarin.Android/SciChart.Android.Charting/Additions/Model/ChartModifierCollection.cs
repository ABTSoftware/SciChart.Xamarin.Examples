using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using SciChart.Charting.Modifiers;
using SciChart.Core.Observable;

namespace SciChart.Charting.Model
{
    public partial class ChartModifierCollection : IList<IChartModifier>
    {
        public IEnumerator<IChartModifier> GetEnumerator()
        {
            return new Enumerator<IChartModifier>(this, o => (IChartModifier)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IChartModifier item)
        {
            base.Add(item as Object);
        }

        public bool Contains(IChartModifier item)
        {
            return base.Contains(item as Object);
        }

        public void CopyTo(IChartModifier[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(IChartModifier item)
        {
            return base.Remove(item as Object);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(IChartModifier item)
        {
            return base.IndexOf(item as Object);
        }

        public void Insert(int index, IChartModifier item)
        {
            base.Add(index, item as Object);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public IChartModifier this[int index]
        {
            get { return Get(index) as IChartModifier; }
            set { Set(index, value as Object); }
        }
    }
}