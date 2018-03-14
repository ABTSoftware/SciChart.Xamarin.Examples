using System;
using System.Collections.Generic;
using SciChart.Core.Model;
using SciChart.Core.Utility;

namespace SciChart.Charting.Model.DataSeries
{
    public partial interface IXyzDataSeries<TX, TY, TZ> where TX : IComparable where TY : IComparable where TZ : IComparable
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

    public partial class XyzDataSeries<TX, TY, TZ> : XyzDataSeries, IXyzDataSeries<TX, TY, TZ> where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;
        private readonly IValuesFactory<TZ> _zValuesFactory;

        public XyzDataSeries() : base(typeof(TX).ToClass(), typeof(TY).ToClass(), typeof(TZ).ToClass()) 
        {
            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
            _zValuesFactory = ValuesFactory.Get<TZ>();
        }

        public void Append(TX x, TY y, TZ z)
        {
            Append(_xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _zValuesFactory.CreateFrom(z));
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            Append(_xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _zValuesFactory.CreateFrom(zValues));
        }

        public void UpdateXyzAt(int index, TX x, TY y, TZ z)
        {
            UpdateRangeXyzAt(index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _zValuesFactory.CreateFrom(z));
        }

        public void UpdateXAt(int index, TX x)
        {
            UpdateRangeXAt(index, _xValuesFactory.CreateFrom(x));
        }

        public void UpdateYAt(int index, TY y)
        {
            UpdateRangeYAt(index, _yValuesFactory.CreateFrom(y));
        }

        public void UpdateZAt(int index, TZ z)
        {
            UpdateRangeZAt(index, _zValuesFactory.CreateFrom(z));
        }

        public void UpdateRangeXyzAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            UpdateRangeXyzAt(index, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _zValuesFactory.CreateFrom(zValues));
        }

        public void UpdateRangeXAt(int index, IEnumerable<TX> xValues)
        {
            UpdateRangeXAt(index, _xValuesFactory.CreateFrom(xValues));
        }

        public void UpdateRangeYAt(int index, IEnumerable<TY> yValues)
        {
            UpdateRangeYAt(index, _yValuesFactory.CreateFrom(yValues));
        }

        public void UpdateRangeZAt(int index, IEnumerable<TZ> zValues)
        {
            UpdateRangeZAt(index, _zValuesFactory.CreateFrom(zValues));
        }

        public void Insert(int index, TX x, TY y, TZ z)
        {
            InsertRange(index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _zValuesFactory.CreateFrom(z));
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues)
        {
            InsertRange(startIndex, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _zValuesFactory.CreateFrom(zValues));
        }
    }
}