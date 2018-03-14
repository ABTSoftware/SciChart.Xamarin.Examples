using System;
using System.Linq;
using System.Collections.Generic;
using Foundation;

namespace SciChart.iOS.Charting
{
    public interface IXyyDataSeries<TX, TY> : ISCIXyyDataSeriesProtocol, IDataSeries where TX : IComparable where TY : IComparable
    {
        void Append(TX x, TY y, TY y1);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);

        void UpdateXyy1At(int index, TX xValue, TY yValue, TY y1Value);

        void UpdateXAt(int index, TX xValue);

        void UpdateYAt(int index, TY yValue);

        void UpdateY1At(int index, TY y1Value);

        void UpdateRangeXyy1At(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);

        void UpdateRangeXAt(int index, IEnumerable<TX> xValues);

        void UpdateRangeYAt(int index, IEnumerable<TY> yValues);

        void UpdateRangeY1At(int index, IEnumerable<TY> y1Values);

        void Insert(int index, TX x, TY y, TY y1);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);
    }

    public class XyyDataSeries<TX, TY> : SCIXyyDataSeries, IXyyDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public XyyDataSeries() : base(ValuesFactory.Get<TX>().BaseType, ValuesFactory.Get<TY>().BaseType)
        {
            IsDirectBinding = false;

            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX x, TY y, TY y1)
        {
            Append_native(x.FromComparable(), y.FromComparable(), y1.FromComparable());
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            AppendRange(new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), new SCIGenericType(y1Ptr, _yValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedY1.Free();
        }

        public void UpdateXyy1At(int index, TX xValue, TY yValue, TY y1Value)
        {
            UpdateXyy1At_native(index, xValue.FromComparable(), yValue.FromComparable(), y1Value.FromComparable());
        }

        public void UpdateXAt(int index, TX xValue)
        {
            UpdateXAt_native(index, xValue.FromComparable());
        }

        public void UpdateYAt(int index, TY yValue)
        {
            UpdateYAt_native(index, yValue.FromComparable());
        }

        public void UpdateY1At(int index, TY y1Value)
        {
            UpdateY1At_native(index, y1Value.FromComparable());
        }

        public void UpdateRangeXyy1At(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            UpdateRangeXyy1At(index, new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), new SCIGenericType(y1Ptr, _yValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedY1.Free();
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

        public void UpdateRangeY1At(int index, IEnumerable<TY> y1Values)
        {
            var count = y1Values.Count();

            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            UpdateRangeY1At(index, new SCIGenericType(y1Ptr, _yValuesFactory.PointerType), count);

            pinnedY1.Free();
        }

        public void Insert(int index, TX x, TY y, TY y1)
        {
            Insert_native(index, x.FromComparable(), y.FromComparable(), y1.FromComparable());
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            InsertRange(startIndex, new SCIGenericType(xPtr, _xValuesFactory.PointerType), new SCIGenericType(yPtr, _yValuesFactory.PointerType), new SCIGenericType(y1Ptr, _yValuesFactory.PointerType), count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedY1.Free();
        }
    }
}