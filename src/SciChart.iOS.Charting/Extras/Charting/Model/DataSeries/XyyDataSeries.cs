using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

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

        private static readonly NSString AppendXy1Y2Method = new NSString("appendX:Y1:Y2:");
        public void Append(TX x, TY y, TY y1)
        {
            SCIXamarinMessageResolver.sendMessageVGGG(this, AppendXy1Y2Method, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _yValuesFactory.CreateFrom(y1));
        }

        private static readonly NSString AppendRangeXy1Y2CountMethod = new NSString("appendRangeX:Y1:Y2:Count:");
        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVPPPI(this, AppendRangeXy1Y2CountMethod, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, y1Ptr, _yValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedY1.Free();
        }

        private static readonly NSString UpdateAtXy1Y2Method = new NSString("updateAt:X:Y1:Y2:");
        public void UpdateXyy1At(int index, TX xValue, TY yValue, TY y1Value)
        {
            SCIXamarinMessageResolver.sendMessageVIGGG(this, UpdateAtXy1Y2Method, index, _xValuesFactory.CreateFrom(xValue), _yValuesFactory.CreateFrom(yValue), _yValuesFactory.CreateFrom(y1Value));
        }

        private static readonly NSString UpdateAtXMethod = new NSString("updateAt:X:");
        public void UpdateXAt(int index, TX xValue)
        {
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateAtXy1Y2Method, index, _xValuesFactory.CreateFrom(xValue));
        }

        private static readonly NSString UpdateAtY1Method = new NSString("updateAt:Y1:");
        public void UpdateYAt(int index, TY yValue)
        {
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateAtY1Method, index, _yValuesFactory.CreateFrom(yValue));
        }

        private static readonly NSString UpdateAtY2Method = new NSString("updateAt:Y2:");
        public void UpdateY1At(int index, TY y1Value)
        {
            SCIXamarinMessageResolver.sendMessageVIG(this, UpdateAtY2Method, index, _yValuesFactory.CreateFrom(y1Value));
        }

        private static readonly NSString UpdateRangeXValuesY1ValuesY2ValuesCountMethod = new NSString("updateRange:xValues:y1Values:y2Values:count:");
        public void UpdateRangeXyy1At(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPPPI(this, UpdateRangeXValuesY1ValuesY2ValuesCountMethod, index, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, y1Ptr, _yValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedY1.Free();
        }

        private static readonly NSString UpdateRangeXValuesCountMethod = new NSString("updateRange:xValues:count:");
        public void UpdateRangeXAt(int index, IEnumerable<TX> xValues)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPI(this, UpdateRangeXValuesCountMethod, index, xPtr, _xValuesFactory.PointerType, count);

            pinnedX.Free();
        }

        private static readonly NSString UpdateRangeY1ValuesCountMethod = new NSString("updateRange:y1Values:count:");
        public void UpdateRangeYAt(int index, IEnumerable<TY> yValues)
        {
            var count = yValues.Count();

            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPI(this, UpdateRangeY1ValuesCountMethod, index, yPtr, _yValuesFactory.PointerType, count);

            pinnedY.Free();
        }

        private static readonly NSString UpdateRangeY2ValuesCountMethod = new NSString("updateRange:y2Values:count:");
        public void UpdateRangeY1At(int index, IEnumerable<TY> y1Values)
        {
            var count = y1Values.Count();

            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVIPI(this, UpdateRangeY2ValuesCountMethod, index, y1Ptr, _yValuesFactory.PointerType, count);

            pinnedY1.Free();
        }

        static readonly NSString InsertAtXy1Y2Method = new NSString("insertAt:X:Y1:Y2:");
        public void Insert(int index, TX x, TY y, TY y1)
        {
            SCIXamarinMessageResolver.sendMessageVIGGG(this, InsertAtXy1Y2Method, index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _yValuesFactory.CreateFrom(y1));
        }

        private static readonly NSString InsertRangeAtXy1Y2CountMethod = new NSString("insertRangeAt:X:Y1:Y2:Count");
        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            var count = xValues.Count();

            var pinnedX = _xValuesFactory.CreateFrom(xValues);
            var xPtr = pinnedX.AddrOfPinnedObject();
            var pinnedY = _yValuesFactory.CreateFrom(yValues);
            var yPtr = pinnedY.AddrOfPinnedObject();
            var pinnedY1 = _yValuesFactory.CreateFrom(y1Values);
            var y1Ptr = pinnedY1.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVPPPI(this, InsertRangeAtXy1Y2CountMethod, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, y1Ptr, _yValuesFactory.PointerType, count);

            pinnedX.Free();
            pinnedY.Free();
            pinnedY1.Free();
        }
    }
}