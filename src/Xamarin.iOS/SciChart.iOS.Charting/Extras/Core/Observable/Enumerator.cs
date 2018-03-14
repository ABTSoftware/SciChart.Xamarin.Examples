using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    internal class NSFastEnumerator
    {
        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public extern static nuint objc_msgSend(IntPtr receiver, IntPtr selector, ref NSFastEnumerationState arg1, IntPtr[] arg2, nuint arg3);
    }

    // Sources is from xamarin-macios sources
    // class name changed to omit naming conflicts
    // https://github.com/xamarin/xamarin-macios/blob/fc55e4306f79491fd269ca2495c6a859799cb1c6/src/Foundation/NSFastEnumerator.cs
    internal class Enumerator<T> : IEnumerator<T> where T : class, INativeObject
    {
        private NSFastEnumerationState state;
        private SCIObservableCollection collection;
        private IntPtr[] array;
        private nuint count;
        private IntPtr mutationValue;
        private nuint current;
        private bool started;

        public Enumerator(SCIObservableCollection observableCollection)
        {
            collection = observableCollection;
        }

        void Fetch()
        {
            if (array == null)
            {
                array = new IntPtr[16];
            }

            count = NSFastEnumerator.objc_msgSend(collection.Handle, Selector.GetHandle("countByEnumeratingWithState:objects:count:"), ref state, array, (nuint)array.Length);

            if (!started)
            {
                started = true;
                mutationValue = Marshal.ReadIntPtr(state.mutationsPtr);
            }
            current = 0;
        }

        void VerifyNonMutated()
        {
            if (mutationValue != Marshal.ReadIntPtr(state.mutationsPtr))
                throw new InvalidOperationException("Collection was modified");
        }

        #region IEnumerator implementation
        bool IEnumerator.MoveNext()
        {
            if (array == null || current == count - 1)
            {
                Fetch();
                if (count == 0)
                    return false;
            }
            else
            {
                current++;
            }
            VerifyNonMutated();
            return true;
        }

        void IEnumerator.Reset()
        {
            state = new NSFastEnumerationState();
            started = false;
        }

        object IEnumerator.Current
        {
            get
            {
                VerifyNonMutated();
                return Current;
            }
        }
        #endregion

        #region IDisposable implementation
        void IDisposable.Dispose()
        {
            // Nothing to do
        }
        #endregion

        #region IEnumerator<T> implementation
        public T Current
        {
            get
            {
                return Runtime.GetINativeObject<T>(Marshal.ReadIntPtr(state.itemsPtr, IntPtr.Size * (int)current), false);
            }
        }
        #endregion
    }
}