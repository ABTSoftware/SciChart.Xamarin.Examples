using System;
using System.Linq;
using System.Collections.Generic;
using Foundation;

namespace SciChart.iOS.Charting
{
    public interface IXyDataSeries<TX, TY> : ISCIXyDataSeriesProtocol, IDataSeries where TX : IComparable where TY : IComparable
    {
        void Append(TX x, TY y);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues);

        void UpdateXyAt(int index, TX x, TY y);

        void UpdateXAt(int index, TX x);

        void UpdateYAt(int index, TY y);

        void UpdateRangeXyAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues);

        void UpdateRangeXAt(int index, IEnumerable<TX> xValues);

        void UpdateRangeYAt(int index, IEnumerable<TY> yValues);

        void Insert(int index, TX x, TY y);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues);
    }

    public class XyDataSeries<TX, TY> : SCIXyDataSeries, IXyDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public XyDataSeries() : base(ValuesFactory.Get<TX>().BaseType, ValuesFactory.Get<TY>().BaseType)
        {
            IsDirectBinding = false;

            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX x, TY y)
        {
            Append_native(x.FromComparable(), y.FromComparable());
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            AppendRange(new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
        }

        public void UpdateXyAt(int index, TX x, TY y)
        {
            UpdateXyAt_native(index, x.FromComparable(), y.FromComparable());
        }

        public void UpdateXAt(int index, TX x)
        {
            UpdateXAt_native(index, x.FromComparable());
        }

        public void UpdateYAt(int index, TY y)
        {
            UpdateYAt_native(index, y.FromComparable());
        }

        public void UpdateRangeXyAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            UpdateRangeXyAt(index, new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
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

        public void Insert(int index, TX x, TY y)
        {
            Insert_native(index, x.FromComparable(), y.FromComparable());
        }

        protected static readonly NSString InsertRangeAtXyCountMethod = new NSString("insertRangeAt:X:Y:Count:");
        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            InsertRange(startIndex, new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
        }
    }
}