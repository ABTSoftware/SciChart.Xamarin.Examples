using System;
using System.Linq;
using SciChart.Core.Utility;

namespace SciChart.Core.Model
{
    public interface IValues<T> : IValues
    {
        void Add(T value);
        void Add(int index, T value);
        void Add(T[] values);
        void Add(T[] values, int startIndex, int count);

        void Set(int location, T value);
        T Get(int index);

        void Remove(int location);
    }

    public partial class DoubleValues : IValues<Double>
    {
        
    }

    public partial class FloatValues : IValues<Single>
    {
        
    }

    public partial class IntegerValues : IValues<Int32>
    {
        
    }

    public partial class ShortValues : IValues<Int16>
    {
        
    }

    public partial class LongValues : IValues<Int64>
    {
        
    }

    public partial class ByteValues : IValues<SByte>
    {
        public ByteValues(sbyte[] values) : this((byte[]) (Array) values)
        {
            
        }

        public void Add(sbyte[] values)
        {
            Add((byte[]) (Array) values);
        }

        public void Add(sbyte[] values, int startIndex, int count)
        {
            Add((byte[]) (Array) values, startIndex, count);
        }
    }

    public partial class DateValues : IValues<DateTime>
    {
       
        public void Add(DateTime value)
        {
            AddTime(value.ToUnixTime());
        }

        public void Add(int index, DateTime value)
        {
            AddTime(index, value.ToUnixTime());
        }

        public void Add(DateTime[] values)
        {
            var longValues = values.Select(x => x.ToUnixTime()).ToArray();

            AddTime(longValues);
        }

        public void Add(DateTime[] values, int startIndex, int count)
        {
            var longValues = values.Select(x => x.ToUnixTime()).Skip(startIndex).Take(count).ToArray();

            AddTime(longValues, 0, longValues.Length);
        }

        public void Set(int location, DateTime value)
        {
            SetTime(location, value.ToUnixTime());
        }

        DateTime IValues<DateTime>.Get(int index)
        {
            return GetTime(index).FromUnixTime();
        }
    }
}