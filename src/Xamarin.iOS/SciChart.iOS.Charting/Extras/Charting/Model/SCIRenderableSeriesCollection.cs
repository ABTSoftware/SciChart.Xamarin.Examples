using System.Collections;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public partial class SCIRenderableSeriesCollection : IList<ISCIRenderableSeriesProtocol>
    {
        public IEnumerator<ISCIRenderableSeriesProtocol> GetEnumerator()
        {
            return new Enumerator<ISCIRenderableSeriesProtocol>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(ISCIRenderableSeriesProtocol[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Count; i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool IsReadOnly => false;

        public int Count => Count();

        public void Insert(int index, ISCIRenderableSeriesProtocol item)
        {
            this.Insert(item, index);
        }

        public ISCIRenderableSeriesProtocol this[int index]
        {
            get { return this.ItemAt(index); }
            set { SetSeries(value, index); }
        }
    }
}