using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Core.Observable;

namespace SciChart.Charting.Model
{
    public partial class PieRenderableSeriesCollection : IList<IPieRenderableSeries>
    {
        public IEnumerator<IPieRenderableSeries> GetEnumerator()
        {
            return new Enumerator<IPieRenderableSeries>(this, o => (IPieRenderableSeries)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IPieRenderableSeries item)
        {
            base.Add(item as Object);
        }

        public bool Contains(IPieRenderableSeries item)
        {
            return base.Contains(item as Object);
        }

        public void CopyTo(IPieRenderableSeries[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(IPieRenderableSeries item)
        {
            return base.Remove(item as Object);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(IPieRenderableSeries item)
        {
            return base.IndexOf(item as Object);
        }

        public void Insert(int index, IPieRenderableSeries item)
        {
            base.Add(index, item as Object);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public IPieRenderableSeries this[int index]
        {
            get { return Get(index) as IPieRenderableSeries; }
            set { Set(index, value as Object); }
        }
    }
}