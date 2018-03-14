using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Core.Observable;

namespace SciChart.Charting.Model
{
    public partial class PieSegmentCollection : IList<IPieSegment>
    {
        public IEnumerator<IPieSegment> GetEnumerator()
        {
            return new Enumerator<IPieSegment>(this, o => (IPieSegment)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IPieSegment item)
        {
            base.Add(item as Object);
        }

        public bool Contains(IPieSegment item)
        {
            return base.Contains(item as Object);
        }

        public void CopyTo(IPieSegment[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(IPieSegment item)
        {
            return base.Remove(item as Object);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(IPieSegment item)
        {
            return base.IndexOf(item as Object);
        }

        public void Insert(int index, IPieSegment item)
        {
            base.Add(index, item as Object);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public IPieSegment this[int index]
        {
            get { return Get(index) as IPieSegment; }
            set { Set(index, value as Object); }
        }
    }
}