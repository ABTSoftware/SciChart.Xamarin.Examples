using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    public interface IValuesFactory<T> where T : IComparable
    {
        SCIDataType BaseType { get; }

        SCIDataType PointerType { get; }

        double CreateFrom(T value);

        T ConvertTo(double value);

        T ConvertTo(IComparable value);

        GCHandle CreateFrom(IEnumerable<T> values);
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

        public static IValuesFactory<T> Get<T>() where T : IComparable
        {
            var type = typeof(T);

            object factory;
            FactoryMap.TryGetValue(type, out factory);

            if (factory == null)
            {
                throw new InvalidOperationException($"Type {type} is not supported. There is no factory for {type}");
            }

            return (IValuesFactory<T>)factory;
        }

        private abstract class ValuesFactoryBase<T> : IValuesFactory<T> where T : IComparable
        {
            public abstract SCIDataType BaseType { get; }

            public abstract SCIDataType PointerType { get; }

            public abstract double CreateFrom(T value);

            public abstract T ConvertTo(double value);

            public abstract T ConvertTo(IComparable value);

            public virtual GCHandle CreateFrom(IEnumerable<T> values)
            {
                return GCHandle.Alloc(values.ToArray(), GCHandleType.Pinned);
            }
        }

        private class DoubleValuesFactory : ValuesFactoryBase<double>
        {
            public override SCIDataType BaseType => SCIDataType.Double;

            public override SCIDataType PointerType => SCIDataType.DoublePtr;

            public override double CreateFrom(double value)
            {
                return value;
            }

            public override double ConvertTo(double value)
            {
                return Convert.ToDouble(value);
            }

            public override double ConvertTo(IComparable value)
            {
                return Convert.ToDouble(value);
            }
        }

        private class FloatValuesFactory : ValuesFactoryBase<float>
        {
            public override SCIDataType BaseType => SCIDataType.Float;

            public override SCIDataType PointerType => SCIDataType.FloatPtr;

            public override double CreateFrom(float value)
            {
                return value;
            }

            public override float ConvertTo(double value)
            {
                float floatValue = (float)Convert.ToDouble(value);

                if (float.IsPositiveInfinity(floatValue))
                {
                    floatValue = float.MaxValue;
                }
                else if (float.IsNegativeInfinity(floatValue))
                {
                    floatValue = float.MinValue;
                }

                return floatValue;
            }

            public override float ConvertTo(IComparable value)
            {
                float floatValue = (float)Convert.ToDouble(value);

                if (float.IsPositiveInfinity(floatValue))
                {
                    floatValue = float.MaxValue;
                }
                else if (float.IsNegativeInfinity(floatValue))
                {
                    floatValue = float.MinValue;
                }

                return floatValue;
            }
        }

        private class LongValuesFactory : ValuesFactoryBase<long>
        {
            public override SCIDataType BaseType => SCIDataType.Int64;

            public override SCIDataType PointerType => SCIDataType.Int64Ptr;

            public override double CreateFrom(long value)
            {
                return value;
            }

            public override long ConvertTo(double value)
            {
                return Convert.ToInt64(value);
            }

            public override long ConvertTo(IComparable value)
            {
                return Convert.ToInt64(value);
            }
        }

        private class IntegerValuesFactory : ValuesFactoryBase<int>
        {
            public override SCIDataType BaseType => SCIDataType.Int32;

            public override SCIDataType PointerType => SCIDataType.Int32Ptr;

            public override double CreateFrom(int value)
            {
                return value;
            }

            public override int ConvertTo(double value)
            {
                return Convert.ToInt32(value);
            }

            public override int ConvertTo(IComparable value)
            {
                return Convert.ToInt32(value);
            }
        }

        private class ShortValuesFactory : ValuesFactoryBase<short>
        {
            public override SCIDataType BaseType => SCIDataType.Int16;

            public override SCIDataType PointerType => SCIDataType.Int16Ptr;

            public override double CreateFrom(short value)
            {
                return value;
            }

            public override short ConvertTo(double value)
            {
                return Convert.ToInt16(value);
            }

            public override short ConvertTo(IComparable value)
            {
                return Convert.ToInt16(value);
            }
        }

        private class ByteValuesFactory : ValuesFactoryBase<sbyte>
        {
            public override SCIDataType BaseType => SCIDataType.Byte;

            public override SCIDataType PointerType => SCIDataType.CharPtr;

            public override double CreateFrom(sbyte value)
            {
                return value;
            }

            public override sbyte ConvertTo(double value)
            {
                return Convert.ToSByte(value);
            }

            public override sbyte ConvertTo(IComparable value)
            {
                return Convert.ToSByte(value);
            }
        }

        private class DateValuesFactory : ValuesFactoryBase<DateTime>
        {
            public override SCIDataType BaseType => SCIDataType.DateTime;

            public override SCIDataType PointerType => SCIDataType.DoublePtr;

            public override double CreateFrom(DateTime value)
            {
                // SciChart iOS framework is using TimeIntervalSince1970 method when converting date from double

                var reference = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return (value.ToUniversalTime() - reference).TotalSeconds;
            }

            public override GCHandle CreateFrom(IEnumerable<DateTime> values)
            {
				// SciChart iOS framework is using TimeIntervalSince1970 method when converting date from double
				
				var reference = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var array = values.Select(x => (x.ToUniversalTime() - reference).TotalSeconds).ToArray(); 

                return GCHandle.Alloc(array, GCHandleType.Pinned);
            }

            public override DateTime ConvertTo(double value)
            {
                return (DateTime)ComparableUtil.FromDouble(value, typeof(DateTime));
            }

            public override DateTime ConvertTo(IComparable value)
            {
                return (DateTime)ComparableUtil.FromDouble(Convert.ToDouble(value), typeof(DateTime));
            }
        }
    }
}