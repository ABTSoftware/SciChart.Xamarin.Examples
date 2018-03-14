using System;
using System.Collections.Generic;
using SciChart.Core.Model;
using SciChart.Core.Utility;

namespace SciChart.Charting.Model.DataSeries
{
    public partial interface IHlDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        void Append(TX x, TY y, TY high, TY low);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);

        void Update(int index, TY y, TY high, TY low);

        void Update(int index, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);

        void Insert(int index, TX x, TY y, TY high, TY low);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);
    }

    public partial class HlDataSeries<TX, TY> : HlDataSeries, IHlDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public HlDataSeries() : base(typeof (TX).ToClass(), typeof (TY).ToClass())
        {
            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX x, TY y, TY high, TY low)
        {
            Append(_xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _yValuesFactory.CreateFrom(high), _yValuesFactory.CreateFrom(low));
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            Append(_xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _yValuesFactory.CreateFrom(highValues), _yValuesFactory.CreateFrom(lowValues));
        }

        public void Update(int index, TY y, TY high, TY low)
        {
            Update(index, _yValuesFactory.CreateFrom(y), _yValuesFactory.CreateFrom(high), _yValuesFactory.CreateFrom(low));
        }

        public void Update(int index, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            Update(index, _yValuesFactory.CreateFrom(yValues), _yValuesFactory.CreateFrom(highValues), _yValuesFactory.CreateFrom(lowValues));
        }

        public void Insert(int index, TX x, TY y, TY high, TY low)
        {
            InsertRange(index, _xValuesFactory.CreateFrom(x), _yValuesFactory.CreateFrom(y), _yValuesFactory.CreateFrom(high), _yValuesFactory.CreateFrom(low));
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues)
        {
            InsertRange(startIndex, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _yValuesFactory.CreateFrom(highValues), _yValuesFactory.CreateFrom(lowValues));
        }
    }
}