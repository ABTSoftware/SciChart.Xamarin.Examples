using System;
using System.Linq;
using System.Collections.Generic;

namespace SciChart.iOS.Charting
{
    public partial interface IUniformHeatmapDataSeries<TX, TY, TZ> : ISCIUniformHeatmapDataSeriesProtocol where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        TX StartX { get; set; }

        TY StartY { get; set; }

        TX StepX { get; set; }

        TY StepY { get; set; }

        void UpdateZValues(IEnumerable<TZ> values);

        void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values);
    }

    public class UniformHeatmapDataSeries<TX, TY, TZ> : SCIUniformHeatmapDataSeries, IUniformHeatmapDataSeries<TX, TY, TZ> where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        private readonly IValuesFactory<TX> _xValuesFactory;
        private readonly IValuesFactory<TY> _yValuesFactory;
        private readonly IValuesFactory<TZ> _zValuesFactory;

        public UniformHeatmapDataSeries(TZ[,] array2D, TX xStart, TX xStep, TY yStart, TY yStep)
            : base(ValuesFactory.Get<TX>().BaseType, ValuesFactory.Get<TY>().BaseType, ValuesFactory.Get<TZ>().BaseType,
                  array2D.GetLength(0), array2D.GetLength(1),
                  new SCIDoubleRange(ComparableUtil.ToDouble(xStart), ComparableUtil.ToDouble(xStart) + ComparableUtil.ToDouble(xStep) * array2D.GetLength(0)),
                  new SCIDoubleRange(ComparableUtil.ToDouble(yStart), ComparableUtil.ToDouble(yStart) + ComparableUtil.ToDouble(yStep) * array2D.GetLength(1)))
        {
            IsDirectBinding = false;

            _xValuesFactory = ValuesFactory.Get<TX>();
            _yValuesFactory = ValuesFactory.Get<TY>();
            _zValuesFactory = ValuesFactory.Get<TZ>();

            StartX = xStart;
            StepX = xStep;
            StartY = yStart;
            StepY = yStep;

            UpdateZValues(array2D.CopyToOneDimArray());
        }

        public TX StepX
        {
            get { return _xValuesFactory.ConvertTo(StepX_native.ToComparable()); }
            set { StepX_native = value.FromComparable(); }
        }

        public TY StepY
        {
            get { return _yValuesFactory.ConvertTo(StepY_native.ToComparable()); }
            set { StepY_native = value.FromComparable(); }
        }

        public TX StartX
        {
            get { return _xValuesFactory.ConvertTo(StartX_native.ToComparable()); }
            set { StartX_native = value.FromComparable(); }
        }
        public TY StartY
        {
            get { return _yValuesFactory.ConvertTo(StartY_native.ToComparable()); }
            set { StartY_native = value.FromComparable(); }
        }

        public void UpdateZValues(IEnumerable<TZ> values)
        {
            var count = values.Count();

            var pinnedArray = _zValuesFactory.CreateFrom(values);
            var ptr = pinnedArray.AddrOfPinnedObject();

            UpdateZValues(new SCIGenericType(ptr, _zValuesFactory.PointerType), count);

            pinnedArray.Free();
        }

        public void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values)
        {
            var count = values.Count();

            var pinnedArray = _zValuesFactory.CreateFrom(values);
            var ptr = pinnedArray.AddrOfPinnedObject();

            UpdateRangeZAtXIndex(xIndex, yIndex, new SCIGenericType(ptr, _zValuesFactory.PointerType), count);

            pinnedArray.Free();
        }
    }
}