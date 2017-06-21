using System;
using System.Collections.Generic;
using SciChart.Core.Model;
using SciChart.Core.Utility;

namespace SciChart.Charting.Model.DataSeries
{

    public partial interface IXyyDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        void Append(TX xValue, TY yValue, TY y1Value);

        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);

        void UpdateXyy1At(int index, TX xValue, TY yValue, TY y1Value);

        void UpdateXAt(int index, TX xValue);

        void UpdateYAt(int index, TY yValue);

        void UpdateY1At(int index, TY y1Value);

        void UpdateRangeXyy1At(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);

        void UpdateRangeXAt(int index, IEnumerable<TX> xValues);

        void UpdateRangeYAt(int index, IEnumerable<TY> yValues);

        void UpdateRangeY1At(int index, IEnumerable<TY> y1Values);

        void Insert(int index, TX xValue, TY yValue, TY y1Value);

        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);
    }

    public partial class XyyDataSeries<TX, TY> : XyyDataSeries, IXyyDataSeries<TX, TY> where TX : IComparable where TY : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;

        public XyyDataSeries() : base(typeof (TX).ToClass(), typeof (TY).ToClass())
        {
            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
        }

        public void Append(TX xValue, TY yValue, TY y1Value)
        {
            Append(_xValuesFactory.CreateFrom(xValue), _yValuesFactory.CreateFrom(yValue), _yValuesFactory.CreateFrom(y1Value));
        }

        public void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            Append(_xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _yValuesFactory.CreateFrom(y1Values));
        }

        public void UpdateXyy1At(int index, TX xValue, TY yValue, TY y1Value)
        {
            UpdateRangeXyy1At(index, _xValuesFactory.CreateFrom(xValue), _yValuesFactory.CreateFrom(yValue), _yValuesFactory.CreateFrom(y1Value));
        }

        public void UpdateXAt(int index, TX xValue)
        {
            UpdateRangeXAt(index, _xValuesFactory.CreateFrom(xValue));
        }

        public void UpdateYAt(int index, TY yValue)
        {
            UpdateRangeYAt(index, _yValuesFactory.CreateFrom(yValue));
        }

        public void UpdateY1At(int index, TY y1Value)
        {
            UpdateRangeY1At(index, _yValuesFactory.CreateFrom(y1Value));
        }

        public void UpdateRangeXyy1At(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            UpdateRangeXyy1At(index, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _yValuesFactory.CreateFrom(y1Values));
        }

        public void UpdateRangeXAt(int index, IEnumerable<TX> xValues)
        {
            UpdateRangeXAt(index, _xValuesFactory.CreateFrom(xValues));
        }

        public void UpdateRangeYAt(int index, IEnumerable<TY> yValues)
        {
            UpdateRangeYAt(index, _yValuesFactory.CreateFrom(yValues));
        }

        public void UpdateRangeY1At(int index, IEnumerable<TY> y1Values)
        {
            UpdateRangeY1At(index, _yValuesFactory.CreateFrom(y1Values));
        }

        public void Insert(int index, TX xValue, TY yValue, TY y1Value)
        {
            InsertRange(index, _xValuesFactory.CreateFrom(xValue), _yValuesFactory.CreateFrom(yValue), _yValuesFactory.CreateFrom(y1Value));
        }

        public void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values)
        {
            InsertRange(startIndex, _xValuesFactory.CreateFrom(xValues), _yValuesFactory.CreateFrom(yValues), _yValuesFactory.CreateFrom(y1Values));
        }
    }
}