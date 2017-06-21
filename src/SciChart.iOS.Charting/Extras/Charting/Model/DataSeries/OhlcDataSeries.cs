using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

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

        protected static NSString AppendXOpenHighLowCloseMethod = new NSString("appendX:Open:High:Low:Close:");
        public void Append(TX x, TY open, TY high, TY low, TY close)
        {
            SCIXamarinMessageResolver.sendMessageVGGGGG(this, AppendXOpenHighLowCloseMethod,
                _xValuesFactory.CreateFrom(x),
                _yValuesFactory.CreateFrom(open),
                _yValuesFactory.CreateFrom(high),
                _yValuesFactory.CreateFrom(low),
                _yValuesFactory.CreateFrom(close));
        }

        protected static NSString AppendRangeXOpenHighLowCloseCountMethod = new NSString("appendRangeX:Open:High:Low:Close:Count:");
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

            SCIXamarinMessageResolver.sendMessageVPPPPPI(this, AppendRangeXOpenHighLowCloseCountMethod,
                xPtr, _xValuesFactory.PointerType,
                oPtr, _yValuesFactory.PointerType,
                hPtr, _yValuesFactory.PointerType,
                lPtr, _yValuesFactory.PointerType,
                cPtr, _yValuesFactory.PointerType,
                count);

            pinnedX.Free();
            pinnedO.Free();
            pinnedH.Free();
            pinnedL.Free();
            pinnedC.Free();
        }

        protected static NSString UpdateAtOpenHighLowCloseMethod = new NSString("updateAt:Open:High:Low:Close:");
        public void Update(int index, TY open, TY high, TY low, TY close)
        {
            SCIXamarinMessageResolver.sendMessageVIGGGG(this, UpdateAtOpenHighLowCloseMethod,
                index,
                _yValuesFactory.CreateFrom(open),
                _yValuesFactory.CreateFrom(high),
                _yValuesFactory.CreateFrom(low),
                _yValuesFactory.CreateFrom(close));
        }

        protected static NSString UpdateRangeAtOpenHighLowCloseCountMethod = new NSString("updateAt:Open:High:Low:Close:Count:");
        public void Update(int index, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues)
        {
            var pinnedO = _yValuesFactory.CreateFrom(openValues);
            var oPtr = pinnedO.AddrOfPinnedObject();
            var pinnedH = _yValuesFactory.CreateFrom(highValues);
            var hPtr = pinnedH.AddrOfPinnedObject();
            var pinnedL = _yValuesFactory.CreateFrom(lowValues);
            var lPtr = pinnedL.AddrOfPinnedObject();
            var pinnedC = _yValuesFactory.CreateFrom(closeValues);
            var cPtr = pinnedC.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPPPP(this, UpdateRangeAtOpenHighLowCloseCountMethod,
                                                         index,
                                                         oPtr, _yValuesFactory.PointerType,
                                                         hPtr, _yValuesFactory.PointerType,
                                                         lPtr, _yValuesFactory.PointerType,
                                                         cPtr, _yValuesFactory.PointerType);

            pinnedO.Free();
            pinnedH.Free();
            pinnedL.Free();
            pinnedC.Free();
        }

        protected static NSString InsertAtXOpenHighLowCloseMethod = new NSString("insertAt:X:Open:High:Low:Close:");
        public void Insert(int index, TX x, TY open, TY high, TY low, TY close)
        {
            SCIXamarinMessageResolver.sendMessageVGGGGG(this, InsertAtXOpenHighLowCloseMethod,
                _xValuesFactory.CreateFrom(x),
                _yValuesFactory.CreateFrom(open),
                _yValuesFactory.CreateFrom(high),
                _yValuesFactory.CreateFrom(low),
                _yValuesFactory.CreateFrom(close));
        }

        protected static NSString InsertRangeAtXOpenHighLowCloseCountMethod = new NSString("insertRangeAt:X:Open:High:Low:Close:Count:");
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

            SCIXamarinMessageResolver.sendMessageVPPPPPI(this, InsertRangeAtXOpenHighLowCloseCountMethod,
                xPtr, _xValuesFactory.PointerType,
                oPtr, _yValuesFactory.PointerType,
                hPtr, _yValuesFactory.PointerType,
                lPtr, _yValuesFactory.PointerType,
                cPtr, _yValuesFactory.PointerType,
                count);

            pinnedX.Free();
            pinnedO.Free();
            pinnedH.Free();
            pinnedL.Free();
            pinnedC.Free();
        }
    }
}