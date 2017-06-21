using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

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

        protected static readonly NSString AppendXyzMethod = new NSString("appendX:Y:Z:");
        public void Append(TX x, TY y, TZ z)
        {
            SCIXamarinMessageResolver.sendMessageVGGG(this, AppendXyzMethod, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _zValuesFactory.CreateFrom(z));
        }

        protected static readonly NSString AppendRangeXyzCountMethod = new NSString("appendRangeX:Y:Z:Count:");
        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVPPPI(this, AppendRangeXyzCountMethod, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, zPtr, _zValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedZ.Free();
        }

        protected static readonly NSString UpdateAtXyzMethod = new NSString("updateAt:X:Y:Z:");
        public void UpdateXyzAt(int index, TX x, TY y, TZ z)
        {
            SCIXamarinMessageResolver.sendMessageVIGGG(this, UpdateAtXyzMethod, index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _zValuesFactory.CreateFrom(z));
        }

        protected static readonly NSString UpdateAtXMethod = new NSString("updateAt:X:");
        public void UpdateXAt(int index, TX x)
        {
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateAtXMethod, index, _xValuesFactory.CreateFrom(x));
        }

        protected static readonly NSString UpdateAtYMethod = new NSString("updateAt:Y:");
        public void UpdateYAt(int index, TY y)
        {
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateAtYMethod, index, _yValuesFactory.CreateFrom(y));
        }

        protected static readonly NSString UpdateAtZMethod = new NSString("updateAt:Z:");
        public void UpdateZAt(int index, TZ z)
        {
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateAtZMethod, index, _zValuesFactory.CreateFrom(z));
        }

        protected static readonly NSString UpdateRangeXValuesYValuesZValuesCount = new NSString("updateRange:xValues:yValues:zValues:count:");
        public void UpdateRangeXyzAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPPPI(this, UpdateRangeXValuesYValuesZValuesCount, index, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, zPtr, _zValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedZ.Free();
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

            SCIXamarinMessageResolver.sendMessageVIPI(this, UpdateRangeYValuesCount, index, yPtr, _yValuesFactory.PointerType, count);

            pinnedY.Free();
        }


        protected static readonly NSString UpdateRangeZValuesCount = new NSString("updateRange:zValues:count:");
        public void UpdateRangeZAt(int index, IEnumerable<TZ> zValues)
        {
            var count = zValues.Count();

            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPI(this, UpdateRangeZValuesCount, index, zPtr, _zValuesFactory.PointerType, count);

            pinnedZ.Free();
        }

        protected static readonly NSString InsertAtXyzMethod = new NSString("insertAt:X:Y:Z:");
        public void Insert(int index, TX x, TY y, TZ z)
        {
            SCIXamarinMessageResolver.sendMessageVIGGG(this, InsertAtXyzMethod, index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _zValuesFactory.CreateFrom(z));
        }

        protected static readonly NSString InsertRangeAtXyzCountMethod = new NSString("insertRangeAt:X:Y:Z:Count");
        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedZ = _zValuesFactory.CreateFrom(zValues);
            var zPtr = pinnedZ.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVPPPI(this, InsertRangeAtXyzCountMethod, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, zPtr, _zValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedZ.Free();
        }
    }
}