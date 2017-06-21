using System;
using SciChart.Core.Utility;

namespace SciChart.Data.Model
{
    public interface IRange<T>: IRange where T : IComparable
    {
        new T Min { get; set; }
        new T Max { get; set; }

        new T Diff { get; }

        void SetMinMax(T min, T max);

    }

    public partial class DoubleRange : IRange<Double>
    {
        public DoubleRange(double min, double max) : this(Java.Lang.Double.ValueOf(min), Java.Lang.Double.ValueOf(max))
        {
            
        }

        public new double Min
        {
            get { return ((Java.Lang.Double) (((IRange) this).Min)).DoubleValue(); }
            set { ((IRange) this).Min = Java.Lang.Double.ValueOf(value); }
        }

        public new double Max
        {
            get { return ((Java.Lang.Double) (((IRange) this).Max)).DoubleValue(); }
            set { ((IRange) this).Max = Java.Lang.Double.ValueOf(value); }
        }

        public new double Diff => ((Java.Lang.Double) (((IRange) this).Diff)).DoubleValue();

        public void SetMinMax(double min, double max)
        {
            SetMinMax(Java.Lang.Double.ValueOf(min), Java.Lang.Double.ValueOf(max));
        }
    }

    public partial class FloatRange : IRange<Single>
    {
        public FloatRange(float min, float max) : this(Java.Lang.Float.ValueOf(min), Java.Lang.Float.ValueOf(max))
        {
            
        }

        public new float Min
        {
            get { return ((Java.Lang.Float) (((IRange) this).Min)).FloatValue(); }
            set { ((IRange) this).Min = Java.Lang.Float.ValueOf(value); }
        }

        public new float Max
        {
            get { return ((Java.Lang.Float) (((IRange) this).Max)).FloatValue(); }
            set { ((IRange) this).Max = Java.Lang.Float.ValueOf(value); }
        }

        public new float Diff => ((Java.Lang.Float) (((IRange) this).Diff)).FloatValue();

        public void SetMinMax(float min, float max)
        {
            SetMinMax(Java.Lang.Float.ValueOf(min), Java.Lang.Float.ValueOf(max));
        }
    }

    public partial class LongRange : IRange<Int64>
    {
        public LongRange(long min, long max) : this(Java.Lang.Long.ValueOf(min), Java.Lang.Long.ValueOf(max))
        {
            
        }

        public new long Min
        {
            get { return ((Java.Lang.Long) (((IRange) this).Min)).LongValue(); }
            set { ((IRange) this).Min = Java.Lang.Float.ValueOf(value); }
        }

        public new long Max
        {
            get { return ((Java.Lang.Long) (((IRange) this).Max)).LongValue(); }
            set { ((IRange) this).Max = Java.Lang.Float.ValueOf(value); }
        }

        public new long Diff => ((Java.Lang.Long) (((IRange) this).Diff)).LongValue();

        public void SetMinMax(long min, long max)
        {
            SetMinMax(Java.Lang.Long.ValueOf(min), Java.Lang.Long.ValueOf(max));
        }
    }

    public partial class IntegerRange : IRange<Int32>
    {
        public IntegerRange(int min, int max) : this(Java.Lang.Integer.ValueOf(min), Java.Lang.Integer.ValueOf(max))
        {
            
        }

        public new int Min
        {
            get { return ((Java.Lang.Integer) (((IRange) this).Min)).IntValue(); }
            set { ((IRange) this).Min = Java.Lang.Integer.ValueOf(value); }
        }

        public new int Max
        {
            get { return ((Java.Lang.Integer) (((IRange) this).Max)).IntValue(); }
            set { ((IRange) this).Max = Java.Lang.Integer.ValueOf(value); }
        }

        public new int Diff => ((Java.Lang.Integer) (((IRange) this).Diff)).IntValue();

        public void SetMinMax(int min, int max)
        {
            SetMinMax(Java.Lang.Integer.ValueOf(min), Java.Lang.Integer.ValueOf(max));
        }
    }

    public partial class ShortRange : IRange<Int16>
    {
        public ShortRange(short min, short max) : this(Java.Lang.Short.ValueOf(min), Java.Lang.Short.ValueOf(max))
        {
            
        }

        public new short Min
        {
            get { return ((Java.Lang.Short) (((IRange) this).Min)).ShortValue(); }
            set { ((IRange) this).Min = Java.Lang.Short.ValueOf(value); }
        }

        public new short Max
        {
            get { return ((Java.Lang.Short) (((IRange) this).Max)).ShortValue(); }
            set { ((IRange) this).Max = Java.Lang.Short.ValueOf(value); }
        }

        public new short Diff => ((Java.Lang.Short) (((IRange) this).Diff)).ShortValue();

        public void SetMinMax(short min, short max)
        {
            SetMinMax(Java.Lang.Short.ValueOf(min), Java.Lang.Short.ValueOf(max));
        }
    }

    public partial class ByteRange : IRange<SByte>
    {
        public ByteRange(sbyte min, sbyte max) : this(Java.Lang.Byte.ValueOf(min), Java.Lang.Byte.ValueOf(max))
        {
            
        }

        public new sbyte Min
        {
            get { return ((Java.Lang.Byte) (((IRange) this).Min)).ByteValue(); }
            set { ((IRange) this).Min = Java.Lang.Byte.ValueOf(value); }
        }

        public new sbyte Max
        {
            get { return ((Java.Lang.Byte) (((IRange) this).Max)).ByteValue(); }
            set { ((IRange) this).Max = Java.Lang.Byte.ValueOf(value); }
        }

        public new sbyte Diff => ((Java.Lang.Byte) (((IRange) this).Diff)).ByteValue();

        public void SetMinMax(sbyte min, sbyte max)
        {
            SetMinMax(Java.Lang.Byte.ValueOf(min), Java.Lang.Byte.ValueOf(max));
        }
    }

    public partial class IndexRange : IRange<Int32>
    {
        public IndexRange(int min, int max) : this(Java.Lang.Integer.ValueOf(min), Java.Lang.Integer.ValueOf(max))
        {
            
        }

        public new int Min
        {
            get { return ((Java.Lang.Integer) (((IRange) this).Min)).IntValue(); }
            set { ((IRange) this).Min = Java.Lang.Integer.ValueOf(value); }
        }

        public new int Max
        {
            get { return ((Java.Lang.Integer) (((IRange) this).Max)).IntValue(); }
            set { ((IRange) this).Max = Java.Lang.Integer.ValueOf(value); }
        }

        public new int Diff => ((Java.Lang.Integer) (((IRange) this).Diff)).IntValue();

        public void SetMinMax(int min, int max)
        {
            SetMinMax(Java.Lang.Integer.ValueOf(min), Java.Lang.Integer.ValueOf(max));
        }
    }

    public partial class DateRange : IRange<DateTime>
    {
        public DateRange(DateTime min, DateTime max) : this(min.ToDate(), max.ToDate())
        {
            
        }

        public new DateTime Min
        {
            get { return ((Java.Util.Date) (((IRange) this).Min)).FromDate(); }
            set { ((IRange) this).Min = value.ToDate(); }
        }

        public new DateTime Max
        {
            get { return ((Java.Util.Date) (((IRange) this).Max)).FromDate(); }
            set { ((IRange) this).Max = value.ToDate(); }
        }

        public new DateTime Diff => ((Java.Util.Date) (((IRange) this).Diff)).FromDate();

        public void SetMinMax(DateTime min, DateTime max)
        {
            SetMinMax(min.ToDate(), max.ToDate());
        }
    }
}