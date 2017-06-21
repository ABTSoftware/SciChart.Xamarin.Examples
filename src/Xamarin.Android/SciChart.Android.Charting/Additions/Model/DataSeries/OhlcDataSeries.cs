using System;
using System.Collections.Generic;
using SciChart.Core.Model;
using SciChart.Core.Utility;

namespace SciChart.Charting.Model.DataSeries
{
    public partial interface IOhlcDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        void Append(TX x, TY open, TY high, TY low, TY close);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);

        void Update(int index, TY open, TY high, TY low, TY close);

        void Update(int index, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);

        void Insert(int index, TX x, TY open, TY high, TY low, TY close);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);
    }

    public partial class OhlcDataSeries<TX, TY> : OhlcDataSeries, IOhlcDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public OhlcDataSeries() : base(typeof(TX).ToClass(), typeof(TY).ToClass())
        {
            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX x, TY open, TY high, TY low, TY close)
        {
            Append(_xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(open), _yValuesFactory.CreateFrom(high), _yValuesFactory.CreateFrom(low), _yValuesFactory.CreateFrom(close));
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues,
            IEnumerable<TY> closeValues)
        {
            Append(_xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(openValues), _yValuesFactory.CreateFrom(highValues), _yValuesFactory.CreateFrom(lowValues), _yValuesFactory.CreateFrom(closeValues));
        }

        public void Update(int index, TY open, TY high, TY low, TY close)
        {
            Update(index, _yValuesFactory.CreateFrom(open), _yValuesFactory.CreateFrom(high), _yValuesFactory.CreateFrom(low), _yValuesFactory.CreateFrom(close));
        }

        public void Update(int index, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues)
        {
            Update(index, _yValuesFactory.CreateFrom(openValues), _yValuesFactory.CreateFrom(highValues), _yValuesFactory.CreateFrom(lowValues), _yValuesFactory.CreateFrom(closeValues));
        }

        public void Insert(int index, TX x, TY open, TY high, TY low, TY close)
        {
            InsertRange(index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(open), _yValuesFactory.CreateFrom(high), _yValuesFactory.CreateFrom(low), _yValuesFactory.CreateFrom(close));
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues,
            IEnumerable<TY> lowValues, IEnumerable<TY> closeValues)
        {
            InsertRange(startIndex, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(openValues), _yValuesFactory.CreateFrom(highValues), _yValuesFactory.CreateFrom(lowValues), _yValuesFactory.CreateFrom(closeValues));
        }
    }
}