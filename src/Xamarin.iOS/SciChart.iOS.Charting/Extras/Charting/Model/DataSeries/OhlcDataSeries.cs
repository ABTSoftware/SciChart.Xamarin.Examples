using System;
using System.Linq;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public interface IOhlcDataSeries<TX, TY> : ISCIOhlcDataSeriesProtocol, IDataSeries where TX : IComparable where TY : IComparable
    {
        void Append(TX x, TY open, TY high, TY low, TY close);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);

        void Update(int index, TY open, TY high, TY low, TY close);

        void Update(int index, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);

        void Insert(int index, TX x, TY open, TY high, TY low, TY close);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);
    }

    public class OhlcDataSeries<TX, TY> : SCIOhlcDataSeries, IOhlcDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {

        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public OhlcDataSeries() : base(ValuesFactory.Get<TX>().BaseType, ValuesFactory.Get<TY>().BaseType)
        {
            IsDirectBinding = false;

            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX x, TY open, TY high, TY low, TY close)
        {
            Append_native(x.FromComparable(),
                          open.FromComparable(),
                          high.FromComparable(),
                          low.FromComparable(),
                          close.FromComparable());
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            var pinnedO = _yValuesFactory.CreateFrom(openValues);
            var oPtr = pinnedO.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();
            var pinnedC = _yValuesFactory.CreateFrom(closeValues);
            var cPtr = pinnedC.AddrOfPinnedObject();

            AppendRange(new SCIGenericType(xPtr, _xValuesFactory.PointerType),
                        new SCIGenericType(oPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(hPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(lPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(cPtr, _yValuesFactory.PointerType),
                        count);

            pinnedX.Free();
            pinnedO.Free();
            pinnedH.Free();
            pinnedL.Free();
            pinnedC.Free();
        }

        public void Update(int index, TY open, TY high, TY low, TY close)
        {
            Update_native(index,
                          open.FromComparable(),
                          high.FromComparable(),
                          low.FromComparable(),
                          close.FromComparable());
        }

        public void Update(int index, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues)
        {
            var count = openValues.Count();

            var pinnedO = _yValuesFactory.CreateFrom(openValues);
            var oPtr = pinnedO.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();
            var pinnedC = _yValuesFactory.CreateFrom(closeValues);
            var cPtr = pinnedC.AddrOfPinnedObject();

            UpdateRange(index,
                        new SCIGenericType(oPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(hPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(lPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(cPtr, _yValuesFactory.PointerType),
                        count);

            pinnedO.Free();
            pinnedH.Free();
            pinnedL.Free();
            pinnedC.Free();
        }

        public void Insert(int index, TX x, TY open, TY high, TY low, TY close)
        {
            Insert_native(index,
                          x.FromComparable(),
                          open.FromComparable(),
                          high.FromComparable(),
                          low.FromComparable(),
                          close.FromComparable());
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            var pinnedO = _yValuesFactory.CreateFrom(openValues);
            var oPtr = pinnedO.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();
            var pinnedC = _yValuesFactory.CreateFrom(closeValues);
            var cPtr = pinnedC.AddrOfPinnedObject();

            InsertRange(startIndex,
                        new SCIGenericType(xPtr, _xValuesFactory.PointerType),
                        new SCIGenericType(oPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(hPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(lPtr, _yValuesFactory.PointerType),
                        new SCIGenericType(cPtr, _yValuesFactory.PointerType),
                        count);

            pinnedX.Free();
            pinnedO.Free();
            pinnedH.Free();
            pinnedL.Free();
            pinnedC.Free();
        }
    }
}