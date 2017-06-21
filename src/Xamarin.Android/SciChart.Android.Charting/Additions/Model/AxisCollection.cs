using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using SciChart.Charting.Visuals.Axes;
using SciChart.Core.Observable;

namespace SciChart.Charting.Model
{
    public partial class AxisCollection : IList<IAxis>
    {
        public IEnumerator<IAxis> GetEnumerator()
        {
            return new Enumerator<IAxis>(this, o => (IAxis)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IAxis item)
        {
            base.Add(item as Object);
        }

        public bool Contains(IAxis item)
        {
            return base.Contains(item as Object);
        }

        public void CopyTo(IAxis[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(IAxis item)
        {
            return base.Remove(item as Object);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(IAxis item)
        {
            return base.IndexOf(item as Object);
        }

        public void Insert(int index, IAxis item)
        {
            base.Add(index, item as Object);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public IAxis this[int index]
        {
            get { return Get(index) as IAxis; }
            set { Set(index, value as Object); }
        }
    }
}