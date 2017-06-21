using System;
using System.Collections;
using System.Collections.Generic;
using Java.Util;

namespace SciChart.Core.Observable
{
    public class Enumerator<T> : IEnumerator<T>
    {
        private readonly ObservableCollection _observableCollection;
        private readonly Func<Java.Lang.Object, T> _mapFunc;

        private IIterator _iterator;

        public Enumerator(ObservableCollection observableCollection, Func<Java.Lang.Object, T> mapFunc)
        {
            _observableCollection = observableCollection;
            _mapFunc = mapFunc;

            _iterator = observableCollection.Iterator();
            Current = default(T);
        }

        public bool MoveNext()
        {
            var hasNext = _iterator.HasNext;
            if (hasNext)
                Current = _mapFunc(_iterator.Next());

            return hasNext;
        }

        public void Reset()
        {
            _iterator = _observableCollection.Iterator();
            Current = default(T);
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _iterator = null;
        }
    }
}