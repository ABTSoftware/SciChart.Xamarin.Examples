using System;
using System.Collections.Generic;
using System.Linq;
using SciChart.Core.Utility;

namespace SciChart.Core.Model
{
    public interface IValuesFactory<T>
    {
        IValues<T> CreateFrom(IEnumerable<T> values);
        IValues<T> CreateFrom(T value);
    }

    public static class ValuesFactory
    {
        private static readonly Dictionary<Type, object> FactoryMap = new Dictionary<Type, object>
        {
            {typeof (double), new DoubleValuesFactory()},
            {typeof (float), new FloatValuesFactory()},
            {typeof (long), new LongValuesFactory()},
            {typeof (int), new IntegerValuesFactory()},
            {typeof (short), new ShortValuesFactory()},
            {typeof (sbyte), new ByteValuesFactory()},
            {typeof (DateTime), new DateValuesFactory()}
        };

        public static IValuesFactory<T> Get<T>()
        {
            var type = typeof (T);

            object factory;
            FactoryMap.TryGetValue(type, out factory);

            if (factory == null)
            {
                throw new InvalidOperationException($"There is no factory for {type}");
            }

            return (IValuesFactory<T>) factory;
        }

        private abstract class ValuesFactoryBase<T> : IValuesFactory<T>
        {
            public abstract IValues<T> CreateFrom(IEnumerable<T> values);

            public IValues<T> CreateFrom(T value)
            {
                return CreateFrom(new[] {value});
            }
        }

        private class DoubleValuesFactory : ValuesFactoryBase<Double>
        {
            public override IValues<double> CreateFrom(IEnumerable<double> values)
            {
                return new DoubleValues(values.ToArray());
            }
        }

        private class FloatValuesFactory : ValuesFactoryBase<Single>
        {
            public override IValues<float> CreateFrom(IEnumerable<float> values)
            {
                return new FloatValues(values.ToArray());
            }
        }

        private class LongValuesFactory : ValuesFactoryBase<Int64>
        {
            public override IValues<long> CreateFrom(IEnumerable<long> values)
            {
                return new LongValues(values.ToArray());
            }
        }

        private class IntegerValuesFactory : ValuesFactoryBase<Int32>
        {
            public override IValues<int> CreateFrom(IEnumerable<int> values)
            {
                return new IntegerValues(values.ToArray());
            }
        }

        private class ShortValuesFactory : ValuesFactoryBase<Int16>
        {
            public override IValues<short> CreateFrom(IEnumerable<short> values)
            {
                return new ShortValues(values.ToArray());
            }
        }

        private class ByteValuesFactory : ValuesFactoryBase<SByte>
        {
            public override IValues<sbyte> CreateFrom(IEnumerable<sbyte> values)
            {
                return new ByteValues(values.ToArray());
            }
        }

        private class DateValuesFactory : ValuesFactoryBase<DateTime>
        {
            public override IValues<DateTime> CreateFrom(IEnumerable<DateTime> values)
            {
                return new DateValues(values.Select(x => x.ToUnixTime()).ToArray());
            }
        }
    }
}