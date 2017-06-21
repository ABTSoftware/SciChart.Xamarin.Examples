using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

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

        protected static readonly NSString AppendXyMethod = new NSString("appendX:Y:");
        public void Append(TX x, TY y)
        {
            SCIXamarinMessageResolver.sendMessageVGG(this, AppendXyMethod, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y));
        }

        protected static readonly NSString AppendRangeXyMethod = new NSString("appendRangeX:Y:Count:");
        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVPPI(this, AppendRangeXyMethod, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
        }

        protected static readonly NSString UpdateAtXyMethod = new NSString("updateAt:X:Y:");
        public void UpdateXyAt(int index, TX x, TY y)
        {
            SCIXamarinMessageResolver.sendMessageVIGG(this, UpdateAtXyMethod, index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y));
        }

        protected static readonly NSString UpdateXAtMethod = new NSString("updateAt:X:");
        public void UpdateXAt(int index, TX x)
        { 
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateXAtMethod, index, _xValuesFactory.CreateFrom(x));
        }

        protected static readonly NSString UpdateYAtMethod = new NSString("updateAt:Y:");
        public void UpdateYAt(int index, TY y)
        { 
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateYAtMethod, index, _yValuesFactory.CreateFrom(y));
        }

        protected static readonly NSString UpdateRangeXValuesYValuesCount = new NSString("updateRange:xValues:yValues:count:");
        public void UpdateRangeXyAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPPI(this, UpdateRangeXValuesYValuesCount, index, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
        }

        protected static readonly NSString UpdateRangeXValuesCount = new NSString("updateRange:xValues:count:");
        public void UpdateRangeXAt(int index, IEnumerable<TX> xValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPI(this, UpdateRangeXValuesCount, index, xPtr, _xValuesFactory.PointerType, count);

            pinnedX.Free();
        }

        protected static readonly NSString UpdateRangeYValuesCount = new NSString("updateRange:yValues:count:");
        public void UpdateRangeYAt(int index, IEnumerable<TY> yValues)
        {
            var count = yValues.Count();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPI(this, UpdateRangeXValuesYValuesCount, index, yPtr, _yValuesFactory.PointerType, count);

            pinnedY.Free();
        }

        protected static readonly NSString InsertAtXyMethod = new NSString("insertAt:X:Y:");
        public void Insert(int index, TX x, TY y)
        {
            SCIXamarinMessageResolver.sendMessageVIGG(this, InsertAtXyMethod, index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y));
        }

        protected static readonly NSString InsertRangeAtXyCountMethod = new NSString("insertRangeAt:X:Y:Count:");
        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPPI(this, InsertRangeAtXyCountMethod, startIndex, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
        }
    }
}