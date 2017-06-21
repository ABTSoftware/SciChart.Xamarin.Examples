using System;
using System.Collections.Generic;
using System.Linq;
using Java.Interop;
using SciChart.Core.Model;
using SciChart.Core.Utility;

namespace SciChart.Charting.Model.DataSeries
{
    public partial interface IUniformHeatmapDataSeries<TX, TY, TZ> where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        TX StartX { get; set; }

        TY StartY { get; set; }

        TX StepX { get; set; }

        TY StepY { get; set; }

        void UpdateZValues(IEnumerable<TZ> values);

        void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values);
    }

    public partial class UniformHeatmapDataSeries<TX, TY, TZ> : UniformHeatmapDataSeries, IUniformHeatmapDataSeries<TX, TY, TZ> where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        private readonly IValuesFactory<TZ> _zValuesFactory;

        public UniformHeatmapDataSeries(int xSize, int ySize) : base(typeof (TX).ToClass(), typeof (TY).ToClass(), typeof (TZ).ToClass(), xSize, ySize)
        {
            _zValuesFactory = ValuesFactory.Get<TZ>();
        }

        public UniformHeatmapDataSeries(TZ[,] array2D, TX xStart, TX xStep, TY yStart, TY yStep) : this(array2D.GetLength(1), array2D.GetLength(0))
        {
            StartX = xStart;
            StepX = xStep;
            StartY = yStart;
            StepY = yStep;

            UpdateZValues(array2D.CopyToOneDimArray());
        }

        public new TX StartX
        {
            get { return ((UniformHeatmapDataSeries) this).StartX.JavaCast<Java.Lang.IComparable>().ToComparable<TX>(); }
            set { SetStartX(value.FromComparable()); }
        }

        public new TY StartY
        {
            get { return ((UniformHeatmapDataSeries) this).StartY.JavaCast<Java.Lang.IComparable>().ToComparable<TY>(); }
            set { SetStartY(value.FromComparable()); }
        }

        public new TX StepX
        {
            get { return ((UniformHeatmapDataSeries) this).StepX.JavaCast<Java.Lang.IComparable>().ToComparable<TX>(); }
            set { SetStepX(value.FromComparable()); }
        }

        public new TY StepY
        {
            get { return ((UniformHeatmapDataSeries) this).StepY.JavaCast<Java.Lang.IComparable>().ToComparable<TY>(); }
            set { SetStepY(value.FromComparable()); }
        }

        public void UpdateZValues(IEnumerable<TZ> values)
        {
            UpdateZValues(_zValuesFactory.CreateFrom(values));
        }

        public void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values)
        {
            UpdateRangeZAt(xIndex, yIndex, _zValuesFactory.CreateFrom(values));
        }
    }
}