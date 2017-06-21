using System.Collections;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public partial class SCIAxisCollection : IList<ISCIAxis2DProtocol>
    {
        public IEnumerator<ISCIAxis2DProtocol> GetEnumerator()
        {
            return new Enumerator<ISCIAxis2DProtocol>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(ISCIAxis2DProtocol[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Count; i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool IsReadOnly => false;

        public int Count => Count();

        public void Insert(int index, ISCIAxis2DProtocol item)
        {
            this.Insert(item, index);
        }

        public ISCIAxis2DProtocol this[int index]
        {
            get { return this.ItemAt(index); }
            set { SetAxis(value, index); }
        }
    }
}