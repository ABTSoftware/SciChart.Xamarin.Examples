using System.Collections;
using System.Collections.Generic;
using SciChart.Core.Observable;

namespace SciChart.Charting.Visuals.Annotations
{
    public partial class AnnotationLabelCollection : IList<AnnotationLabel> {

        public IEnumerator<AnnotationLabel> GetEnumerator()
        {
            return new Enumerator<AnnotationLabel>(this, o => (AnnotationLabel)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(AnnotationLabel item)
        {
            base.Add(item);
        }

        public bool Contains(AnnotationLabel item)
        {
            return base.Contains(item);
        }

        public void CopyTo(AnnotationLabel[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(AnnotationLabel item)
        {
            return base.Remove(item);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(AnnotationLabel item)
        {
            return base.IndexOf(item);
        }

        public void Insert(int index, AnnotationLabel item)
        {
            base.Add(index, item);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public AnnotationLabel this[int index]
        {
            get { return Get(index) as AnnotationLabel; }
            set { Set(index, value); }
        }
    }
}