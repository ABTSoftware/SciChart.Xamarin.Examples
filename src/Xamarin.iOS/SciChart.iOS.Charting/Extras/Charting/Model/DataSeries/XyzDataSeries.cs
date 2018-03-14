using System;
using System.Linq;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public interface IXyzDataSeries<TX, TY, TZ> : ISCIXyzDataSeriesProtocol, IDataSeries where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        void Append(TX x, TY y, TZ z);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues);

        void UpdateXyzAt(int index, TX x, TY y, TZ z);

        void UpdateXAt(int index, TX x);

        void UpdateYAt(int index, TY y);

        void UpdateZAt(int index, TZ z);

        void UpdateRangeXyzAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues);

        void UpdateRangeXAt(int index, IEnumerable<TX> xValues);

        void UpdateRangeYAt(int index, IEnumerable<TY> yValues);

        void UpdateRangeZAt(int index, IEnumerable<TZ> zValues);

        void Insert(int index, TX x, TY y, TZ z);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues);
    }

    public class XyzDataSeries<TX, TY, TZ> : SCIXyzDataSeries, IXyzDataSeries<TX, TY, TZ> where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;
        private readonly IValuesFactory<TZ> _zValuesFactory;

        public XyzDataSeries() : base(ValuesFactory.Get<TX>().BaseType, ValuesFactory.Get<TY>().BaseType, ValuesFactory.Get<TZ>().BaseType)
        {
            IsDirectBinding = false;

            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
            _zValuesFactory = ValuesFactory.Get<TZ>();
        }

        public void Append(TX x, TY y, TZ z)
        {
            Append_native(x.FromComparable(), y.FromComparable(), z.FromComparable());
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            AppendRange(new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), new SCIGenericType(zPtr, _zValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedZ.Free();
        }

        public void UpdateXyzAt(int index, TX x, TY y, TZ z)
        {
            UpdateXyzAt_native(index, x.FromComparable(), y.FromComparable(), z.FromComparable());
        }

        public void UpdateXAt(int index, TX x)
        {
            UpdateXAt_native(index, x.FromComparable());
        }

        public void UpdateYAt(int index, TY y)
        {
            UpdateYAt_native(index, y.FromComparable());
        }

        public void UpdateZAt(int index, TZ z)
        {
            UpdateZAt_native(index, z.FromComparable());
        }

        public void UpdateRangeXyzAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            UpdateRangeXyzAt(index, new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), new SCIGenericType(zPtr, _zValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedZ.Free();
        }

        public void UpdateRangeXAt(int index, IEnumerable<TX> xValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            UpdateRangeXAt(index, new SCIGenericType(xPtr, _xValuesFactory.PointerType), count);

            pinnedX.Free();
        }

        public void UpdateRangeYAt(int index, IEnumerable<TY> yValues)
        {
            var count = yValues.Count();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            UpdateRangeYAt(index, new SCIGenericType(yPtr, _yValuesFactory.PointerType), count);

            pinnedY.Free();
        }

        public void UpdateRangeZAt(int index, IEnumerable<TZ> zValues)
        {
            var count = zValues.Count();

            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            UpdateRangeZAt(index, new SCIGenericType(zPtr, _zValuesFactory.PointerType), count);

            pinnedZ.Free();
        }

        public void Insert(int index, TX x, TY y, TZ z)
        {
            Insert_native(index, x.FromComparable(), y.FromComparable(), z.FromComparable());
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            InsertRange(startIndex, new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), new SCIGenericType(zPtr, _zValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedZ.Free();
        }
    }
}