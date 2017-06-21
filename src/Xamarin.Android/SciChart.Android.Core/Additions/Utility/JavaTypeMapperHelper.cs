using System;
using System.Collections.Generic;
using Java.Interop;
using Class = Java.Lang.Class;

namespace SciChart.Core.Utility
{
    public static class JavaTypeMapperHelper
    {
        private static readonly Dictionary<Type, Class> _mappings = new Dictionary<Type, Class>()
        {
            {typeof (Double), Class.FromType(typeof (Java.Lang.Double))},
            {typeof (Single), Class.FromType(typeof (Java.Lang.Float))},
            {typeof (Int64), Class.FromType(typeof (Java.Lang.Long))},
            {typeof (Int32), Class.FromType(typeof (Java.Lang.Integer))},
            {typeof (Int16), Class.FromType(typeof (Java.Lang.Short))},
            {typeof (SByte), Class.FromType(typeof (Java.Lang.Byte))},
            {typeof (DateTime), Class.FromType(typeof (Java.Util.Date))}

        };

        private static readonly DoubleMapper DoubleMapper = new DoubleMapper();
        private static readonly FloatMapper FloatMapper = new FloatMapper();
        private static readonly LongMapper LongMapper = new LongMapper();
        private static readonly IntegerMapper IntegerMapper = new IntegerMapper();
        private static readonly ShortMapper ShortMapper = new ShortMapper();
        private static readonly ByteMapper ByteMapper = new ByteMapper();
        private static readonly DateMapper DateMapper = new DateMapper();

        private static readonly Dictionary<Type, IComparableMapper> _sharpComparableMappers = new Dictionary<Type, IComparableMapper>()
        {
            {typeof (Double), DoubleMapper},
            {typeof(Single), FloatMapper },
            {typeof(Int64), LongMapper },
            {typeof(Int32), IntegerMapper },
            {typeof(Int16), ShortMapper },
            {typeof(SByte), ByteMapper },
            {typeof(DateTime), DateMapper }
        };

        private static readonly Dictionary<Type, IComparableMapper> _javaComparableMappers = new Dictionary<Type, IComparableMapper>()
        {
            {typeof(Java.Lang.Double), DoubleMapper },
            {typeof(Java.Lang.Float), FloatMapper },
            {typeof(Java.Lang.Long), LongMapper },
            {typeof(Java.Lang.Integer), IntegerMapper },
            {typeof(Java.Lang.Short), ShortMapper },
            {typeof(Java.Lang.Byte), ByteMapper },
            {typeof(Java.Util.Date), DateMapper }
        };

        public static Class ToClass(this Type type)
        {
            Class c;
            return _mappings.TryGetValue(type, out c) ? c : Class.FromType(type);
        }

        public static T ToComparable<T>(this Java.Lang.IComparable comparable) where T : IComparable
        {
            return (T) comparable.ToComparable();
        }

        public static IComparable ToComparable(this Java.Lang.IComparable comparable)
        {
            var type = comparable.GetType();
            try
            {
                return _javaComparableMappers[type].Map(comparable);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"No mapping exists for {type} type");
            }
        }

        public static Java.Lang.IComparable FromComparable(this IComparable value)
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

    internal interface IComparableMapper
    {
        IComparable Map(Java.Lang.IComparable javaComparable);

        Java.Lang.IComparable Map(IComparable comparable);
    }

    internal class DoubleMapper : IComparableMapper
    {
        public IComparable Map(Java.Lang.IComparable javaComparable)
        {
            return ((Java.Lang.Double) javaComparable).DoubleValue();
        }

        public Java.Lang.IComparable Map(IComparable comparable)
        {
            return Java.Lang.Double.ValueOf((double) comparable);
        }
    }

    internal class FloatMapper : IComparableMapper
    {
        public IComparable Map(Java.Lang.IComparable javaComparable)
        {
            return ((Java.Lang.Float) javaComparable).FloatValue();
        }

        public Java.Lang.IComparable Map(IComparable comparable)
        {
            return Java.Lang.Float.ValueOf((float) comparable);
        }
    }

    internal class LongMapper : IComparableMapper
    {
        public IComparable Map(Java.Lang.IComparable javaComparable)
        {
            return ((Java.Lang.Long) javaComparable).LongValue();
        }

        public Java.Lang.IComparable Map(IComparable comparable)
        {
            return Java.Lang.Long.ValueOf((long) comparable);
        }
    }

    internal class IntegerMapper : IComparableMapper
    {
        public IComparable Map(Java.Lang.IComparable javaComparable)
        {
            return ((Java.Lang.Integer) javaComparable).IntValue();
        }

        public Java.Lang.IComparable Map(IComparable comparable)
        {
            return Java.Lang.Integer.ValueOf((int) comparable);
        }
    }

    internal class ShortMapper : IComparableMapper
    {
        public IComparable Map(Java.Lang.IComparable javaComparable)
        {
            return ((Java.Lang.Short) javaComparable).ShortValue();
        }

        public Java.Lang.IComparable Map(IComparable comparable)
        {
            return Java.Lang.Short.ValueOf((short) comparable);
        }
    }

    internal class ByteMapper : IComparableMapper
    {
        public IComparable Map(Java.Lang.IComparable javaComparable)
        {
            return ((Java.Lang.Byte) javaComparable).ByteValue();
        }

        public Java.Lang.IComparable Map(IComparable comparable)
        {
            return Java.Lang.Byte.ValueOf((sbyte) comparable);
        }
    }

    internal class DateMapper : IComparableMapper
    {
        public IComparable Map(Java.Lang.IComparable javaComparable)
        {
            return ((Java.Util.Date) javaComparable).FromDate();
        }

        public Java.Lang.IComparable Map(IComparable comparable)
        {
            return ((DateTime) comparable).ToDate();
        }
    }
}
