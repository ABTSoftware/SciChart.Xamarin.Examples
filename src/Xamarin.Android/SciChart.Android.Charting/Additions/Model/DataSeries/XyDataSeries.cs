using System;
using System.Collections.Generic;
using SciChart.Core.Model;
using SciChart.Core.Utility;

namespace SciChart.Charting.Model.DataSeries
{
    public interface IXyDataSeries<TX, TY> where TX : IComparable where TY : IComparable
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

    public class XyDataSeries<TX, TY> : XyDataSeries, IXyDataSeries<TX, TY> where TX : IComparable
        where TY : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public XyDataSeries() : base(typeof (TX).ToClass(), typeof (TY).ToClass())
        {
            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX x, TY y)
        {
            Append(_xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y));
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            Append(_xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues));
        }

        public void UpdateXyAt(int index, TX x, TY y)
        {
            UpdateRangeXyAt(index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y));
        }

        public void UpdateXAt(int index, TX x)
        {
            UpdateRangeXAt(index, _xValuesFactory.CreateFrom(x));
        }

        public void UpdateYAt(int index, TY y)
        {
            UpdateRangeYAt(index, _yValuesFactory.CreateFrom(y));
        }

        public void UpdateRangeXyAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            UpdateRangeXyAt(index, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues));
        }

        public void UpdateRangeXAt(int index, IEnumerable<TX> xValues)
        {
            UpdateRangeXAt(index, _xValuesFactory.CreateFrom(xValues));
        }

        public void UpdateRangeYAt(int index, IEnumerable<TY> yValues)
        {
            UpdateRangeYAt(index, _yValuesFactory.CreateFrom(yValues));
        }

        public void Insert(int index, TX x, TY y)
        {
            InsertRange(index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y));
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues)
        {
            InsertRange(startIndex, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues));
        }
    }
}