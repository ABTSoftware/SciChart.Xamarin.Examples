using System;
using System.Runtime.InteropServices;

namespace SciChart.Core.Utility
{
    public static class ArrayExtensions
    {
        public static T[] CopyToOneDimArray<T>(this T[,] array2D)
        {
            var tmp = new T[array2D.GetLength(0) * array2D.GetLength(1)];
            Buffer.BlockCopy(array2D, 0, tmp, 0, tmp.Length * Marshal.SizeOf(typeof(T)));
            return tmp;
        }
    }
}