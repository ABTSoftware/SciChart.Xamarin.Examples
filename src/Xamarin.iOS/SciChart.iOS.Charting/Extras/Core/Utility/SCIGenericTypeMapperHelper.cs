using System;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public static class SCIGenericTypeMapperHelper
    {
        private static readonly SCIGenericDoubleMapper DoubleMapper = new SCIGenericDoubleMapper();
        private static readonly SCIGenericFloatMapper FloatMapper = new SCIGenericFloatMapper();
        private static readonly SCIGenericLongMapper LongMapper = new SCIGenericLongMapper();
        private static readonly SCIGenericIntegerMapper IntegerMapper = new SCIGenericIntegerMapper();
        private static readonly SCIGenericShortMapper ShortMapper = new SCIGenericShortMapper();
        private static readonly SCIGenericByteMapper ByteMapper = new SCIGenericByteMapper();
        private static readonly SCIGenericDateTimeMapper DateMapper = new SCIGenericDateTimeMapper();

        private static readonly Dictionary<Type, ISCIGenericTypeMapper> _sharpComparableMappers = new Dictionary<Type, ISCIGenericTypeMapper>
        {
            {typeof(Double), DoubleMapper},
            {typeof(Single), FloatMapper },
            {typeof(Int64), LongMapper },
            {typeof(Int32), IntegerMapper },
            {typeof(Int16), ShortMapper },
            {typeof(SByte), ByteMapper },
            {typeof(DateTime), DateMapper }
        };

        private static readonly Dictionary<SCIDataType, ISCIGenericTypeMapper> _sciGenericTypeComparableMappers = new Dictionary<SCIDataType, ISCIGenericTypeMapper>
        {
            {SCIDataType.Double, DoubleMapper },
            {SCIDataType.Float, FloatMapper },
            {SCIDataType.Int64, LongMapper },
            {SCIDataType.Int32, IntegerMapper },
            {SCIDataType.Int16, ShortMapper },
            {SCIDataType.Byte, ByteMapper },
            {SCIDataType.DateTime, DateMapper }
        };

        public static T ToComparable<T>(this SCIGenericType comparable) where T : IComparable
        {
            return (T)comparable.ToComparable();
        }

        public static IComparable ToComparable(this SCIGenericType genericValue)
        {
            var type = genericValue.type;
            try
            {
                return _sciGenericTypeComparableMappers[type].Map(genericValue);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"No mapping exists for {type} type");
            }
        }

        public static SCIGenericType FromComparable(this IComparable value)
        {
            var type = value.GetType();
            try
            {
                return _sharpComparableMappers[type].Map(value);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"No mapping exist for {type} type");
            }
        }
    }

    internal interface ISCIGenericTypeMapper
    {
        IComparable Map(SCIGenericType genericValue);

        SCIGenericType Map(IComparable comparable);
    }

    internal class SCIGenericDoubleMapper : ISCIGenericTypeMapper
    {
        public IComparable Map(SCIGenericType genericValue)
        {
            return genericValue.doubleData;
        }

        public SCIGenericType Map(IComparable comparable)
        {
            return new SCIGenericType((double)comparable);
        }
    }

    internal class SCIGenericFloatMapper : ISCIGenericTypeMapper
    {
        public IComparable Map(SCIGenericType genericValue)
        {
            return genericValue.floatData;
        }

        public SCIGenericType Map(IComparable comparable)
        {
            return new SCIGenericType((float)comparable);
        }
    }

    internal class SCIGenericLongMapper : ISCIGenericTypeMapper
    {
        public IComparable Map(SCIGenericType genericValue)
        {
            return genericValue.longData;
        }

        public SCIGenericType Map(IComparable comparable)
        {
            return new SCIGenericType((long)comparable);
        }
    }

    internal class SCIGenericIntegerMapper : ISCIGenericTypeMapper
    {
        public IComparable Map(SCIGenericType genericValue)
        {
            return genericValue.intData;
        }

        public SCIGenericType Map(IComparable comparable)
        {
            return new SCIGenericType((int)comparable);
        }
    }

    internal class SCIGenericShortMapper : ISCIGenericTypeMapper
    {
        public IComparable Map(SCIGenericType genericValue)
        {
            return genericValue.shortData;
        }

        public SCIGenericType Map(IComparable comparable)
        {
            return new SCIGenericType((short)comparable);
        }
    }

    internal class SCIGenericByteMapper : ISCIGenericTypeMapper
    {
        public IComparable Map(SCIGenericType genericValue)
        {
            return genericValue.charData;
        }

        public SCIGenericType Map(IComparable comparable)
        {
            return new SCIGenericType((sbyte)comparable);
        }
    }

    internal class SCIGenericDateTimeMapper : ISCIGenericTypeMapper
    {
        public IComparable Map(SCIGenericType genericValue)
        {
            return genericValue.dateTimeData;
        }

        public SCIGenericType Map(IComparable comparable)
        {
            return new SCIGenericType((DateTime)comparable);
        }
    }
}