﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial interface IUniformHeatmapDataSeries<TX, TY, TZ> : ISCIUniformHeatmapDataSeriesProtocol where TX : IComparable where TY : IComparable where TZ : IComparable
    {
        TX StartX { get; set; }
        TY StartY { get; set; }
        TX StepX { get; set; }
        TY StepY { get; set; }

        void UpdateZValues(IEnumerable<TZ> values);
        // @required -(void)updateZAtXIndex:(int)xIndex yIndex:(int)yIndex withValue:(SCIGenericType)value;
        // void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values);
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

            //StartX = xStart;
            //StepX = xStep;
            //StartY = yStart;
            //StepY = yStep;

            UpdateZValues(array2D.CopyToOneDimArray());
        }

        protected static readonly NSString StartXMethod = new NSString("startX");
        protected static readonly NSString SetStartXMethod = new NSString("setStartX:");
		protected static readonly NSString StartYMethod = new NSString("startY");
		protected static readonly NSString SetStartYMethod = new NSString("setStartY:");
		protected static readonly NSString StepXMethod = new NSString("stepX");
		protected static readonly NSString SetStepXMethod = new NSString("setStepX:");
		protected static readonly NSString StepYMethod = new NSString("stepY");
		protected static readonly NSString SetStepYMethod = new NSString("setStepY:");

        public TX StepX
        {
            get { return _xValuesFactory.ConvertTo(ComparableUtil.ToDouble(SCIXamarinMessageResolver.sendMessageGV(this, StepXMethod))); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetStepXMethod, _xValuesFactory.CreateFrom(value)); }
        }

        public TY StepY
        {
            get { return _yValuesFactory.ConvertTo(ComparableUtil.ToDouble(SCIXamarinMessageResolver.sendMessageGV(this, StepYMethod))); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetStepYMethod, _yValuesFactory.CreateFrom(value)); }
        }

        public TX StartX
        {
            get { return _xValuesFactory.ConvertTo(ComparableUtil.ToDouble(SCIXamarinMessageResolver.sendMessageGV(this, StartXMethod))); }
            set { SCIXamarinMessageResolver.sendMessageVG(this, SetStartXMethod, _xValuesFactory.CreateFrom(value)); }
        }
		public TY StartY
		{
			get { return _yValuesFactory.ConvertTo(ComparableUtil.ToDouble(SCIXamarinMessageResolver.sendMessageGV(this, StartYMethod))); }
			set { SCIXamarinMessageResolver.sendMessageVG(this, SetStartYMethod, _yValuesFactory.CreateFrom(value)); }
        }

        private static readonly NSString UpdateZValuesMethod = new NSString("updateZValues:Size:");
        public void UpdateZValues(IEnumerable<TZ> values)
        {
            var count = values.Count();
            var pinnedArray = _zValuesFactory.CreateFrom(values);
            var ptr = pinnedArray.AddrOfPinnedObject();

            SCIXamarinMessageResolver.sendMessageVPI(this, UpdateZValuesMethod, ptr, _zValuesFactory.PointerType, count);

            pinnedArray.Free();
        }

        //public void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values)
        //{
        //    //SCIXamarinMessageResolver.sendMessageVIIP(this, UpdateRangeZAtXIndexYIndexWithValues, xPtr, _xValuesFactory.PointerType, yPtr, _yValuesFactory.PointerType, y1Ptr, _yValuesFactory.PointerType, xValuesArray.Length);
        //}
    }
}