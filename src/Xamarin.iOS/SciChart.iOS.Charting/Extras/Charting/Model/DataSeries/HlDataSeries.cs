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

        protected static NSString AppendXYHighLowMethod = new NSString("appendX:Y:High:Low:");

        public void Append(TX x, TY y, TY high, TY low)
        {
            SCIXamarinMessageResolver.sendMessageVGGGG(this, AppendXYHighLowMethod,
                _xValuesFactory.CreateFrom(x),
                _yValuesFactory.CreateFrom(y),
                _yValuesFactory.CreateFrom(high),
                _yValuesFactory.CreateFrom(low));
        }

        protected static NSString AppendRangeXYHighLowMethod = new NSString("appendRangeX:Y:High:Low:");
        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVPPPP(this, AppendRangeXYHighLowMethod,
                                                       xPtr, _xValuesFactory.PointerType,
                                                       yPtr, _yValuesFactory.PointerType,
                                                       hPtr, _yValuesFactory.PointerType,
                                                       lPtr, _yValuesFactory.PointerType);

            pinnedX.Free();
            pinnedY.Free();
            pinnedH.Free();
            pinnedL.Free();
        }

        protected static NSString UpdateAtYHighLowMethod = new NSString("updateAt:Y:High:Low:");
        public void Update(int index, TY y, TY high, TY low)
        {
            SCIXamarinMessageResolver.sendMessageVIGGG(this, UpdateAtYHighLowMethod, index, _yValuesFactory.CreateFrom(y), _yValuesFactory.CreateFrom(high), _yValuesFactory.CreateFrom(low));
        }

        protected static NSString UpdateRangeAtYHighLowCountMethod = new NSString("updateRangeAt:Y:High:Low:Count:");
        public void Update(int index, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            var count = yValues.Count();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPPPI(this, UpdateRangeAtYHighLowCountMethod,
                                                        index,
                                                        yPtr, _yValuesFactory.PointerType,
                                                        hPtr, _yValuesFactory.PointerType,
                                                        lPtr, _yValuesFactory.PointerType,
                                                        count);

            pinnedY.Free();
            pinnedH.Free();
            pinnedL.Free();
        }

        protected static NSString InsertAtXYHighLowMethod = new NSString("insertAt:X:Y:High:Low:");
        public void Insert(int index, TX x, TY y, TY high, TY low)
        {
            SCIXamarinMessageResolver.sendMessageVIGGGG(this, InsertAtXYHighLowMethod,
                                                        index,
                                                        _xValuesFactory.CreateFrom(x),
                                                        _yValuesFactory.CreateFrom(y),
                                                        _yValuesFactory.CreateFrom(high),
                                                        _yValuesFactory.CreateFrom(low));
        }

        protected static NSString InsertRangeAtXYHighLowMethod = new NSString("insertRangeAt:X:Y:High:Low:");
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

            SCIXamarinMessageResolver.sendMessageVIPPPP(this, InsertRangeAtXYHighLowMethod,
                                                       startIndex,
                                                       xPtr, _xValuesFactory.PointerType,
                                                       yPtr, _yValuesFactory.PointerType,
                                                       hPtr, _yValuesFactory.PointerType,
                                                       lPtr, _yValuesFactory.PointerType);

            pinnedX.Free();
            pinnedY.Free();
            pinnedH.Free();
            pinnedL.Free();
        }
    }
}