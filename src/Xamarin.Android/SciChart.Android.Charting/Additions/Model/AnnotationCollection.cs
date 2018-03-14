using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using Java.Lang.Annotation;
using SciChart.Core.Observable;

namespace SciChart.Charting.Model
{
    public partial class AnnotationCollection : IList<IAnnotation>
    {
        public IEnumerator<IAnnotation> GetEnumerator()
        {
            return new Enumerator<IAnnotation>(this, o => (IAnnotation)o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IAnnotation item)
        {
            base.Add(item as Object);
        }

        public bool Contains(IAnnotation item)
        {
            return base.Contains(item as Object);
        }

        public void CopyTo(IAnnotation[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, size = Size(); i < size; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public bool Remove(IAnnotation item)
        {
            return base.Remove(item as Object);
        }

        public int Count => Size();

        public bool IsReadOnly => false;

        public int IndexOf(IAnnotation item)
        {
            return base.IndexOf(item as Object);
        }

        public void Insert(int index, IAnnotation item)
        {
            base.Add(index, item as Object);
        }

        public void RemoveAt(int index)
        {
            base.Remove(index);
        }

        public IAnnotation this[int index]
        {
            get { return Get(index) as IAnnotation; }
            set { Set(index, value as Object); }
        }
    }
}