using System.Collections;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public partial class SCIAnnotationCollection : IList<ISCIAnnotationProtocol>
    {
        public IEnumerator<ISCIAnnotationProtocol> GetEnumerator()
        {
            return new Enumerator<ISCIAnnotationProtocol>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(ISCIAnnotationProtocol[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Count; i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool IsReadOnly => false;

        public int Count => Count();

        public void Insert(int index, ISCIAnnotationProtocol item)
        {
            this.Insert(item, index);
        }

        public ISCIAnnotationProtocol this[int index]
        {
            get { return this.ItemAt(index); }
            set { SetAnnotation(value, index); }
        }
    }
}