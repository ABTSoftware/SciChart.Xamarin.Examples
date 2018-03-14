using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Core.Observable;

namespace SciChart.Charting.Model
{
    public partial class RenderableSeriesCollection : IList<IRenderableSeries>
    {
        public IEnumerator<IRenderableSeries> GetEnumerator()
        {
            return new Enumerator<IRenderableSeries>(this, o => (IRenderableSeries)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IRenderableSeries item)
        {
            base.Add(item as Object);
        }

        public bool Contains(IRenderableSeries item)
        {
            return base.Contains(item as Object);
        }

        public void CopyTo(IRenderableSeries[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(IRenderableSeries item)
        {
            return base.Remove(item as Object);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(IRenderableSeries item)
        {
            return base.IndexOf(item as Object);
        }

        public void Insert(int index, IRenderableSeries item)
        {
            base.Add(index, item as Object);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public IRenderableSeries this[int index]
        {
            get { return Get(index) as IRenderableSeries; }
            set { Set(index, value as Object); }
        }
    }
}