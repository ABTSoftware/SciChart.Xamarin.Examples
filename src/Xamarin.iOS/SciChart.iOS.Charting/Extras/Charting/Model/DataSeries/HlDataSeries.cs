using System;
using System.Linq;
using System.Collections.Generic;
using Foundation;

namespace SciChart.iOS.Charting
{
    public interface IHlDataSeries<TX, TY> : ISCIHlDataSeriesProtocol, IDataSeries where TX : IComparable where TY : IComparable
    {
        void Append(TX x, TY y, TY high, TY low);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);

        void Update(int index, TY y, TY high, TY low);

        void Update(int index, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);

        void Insert(int index, TX x, TY y, TY high, TY low);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);
    }

    public class HlDataSeries<TX, TY> : SCIHlDataSeries, IHlDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public HlDataSeries() : base(ValuesFactory.Get<TX>().BaseType, ValuesFactory.Get<TY>().BaseType)
        {
            IsDirectBinding = false;

            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX x, TY y, TY high, TY low)
        {
            Append_native(x.FromComparable(), y.FromComparable(), high.FromComparable(), low.FromComparable());
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();

            AppendRange(new SCIGenericType(xPtr, _xValuesFactory.PointerType),
                        new SCIGenericType(yPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(hPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(lPtr, _yValuesFactory.PointerType),
                        count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedH.Free();
            pinnedL.Free();
        }

        public void Update(int index, TY y, TY high, TY low)
        {
            Update_native(index, y.FromComparable(), high.FromComparable(), low.FromComparable());
        }

        public void Update(int index, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            var count = yValues.Count();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();

            UpdateRange(index,
                        new SCIGenericType(yPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(hPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(lPtr, _yValuesFactory.PointerType),
                        count);

            pinnedY.Free();
            pinnedH.Free();
            pinnedL.Free();
        }

        public void Insert(int index, TX x, TY y, TY high, TY low)
        {
            Insert_native(index, x.FromComparable(), y.FromComparable(), high.FromComparable(), low.FromComparable());
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();

            InsertRange(startIndex,
                        new SCIGenericType(xPtr, _xValuesFactory.PointerType),
                        new SCIGenericType(yPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(hPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(lPtr, _yValuesFactory.PointerType),
                        count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedH.Free();
            pinnedL.Free();
        }
    }
}