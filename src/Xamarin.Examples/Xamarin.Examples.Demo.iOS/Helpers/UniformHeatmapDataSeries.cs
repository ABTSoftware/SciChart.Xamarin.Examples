//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SciChart.iOS.Charting
//{
//    public partial interface IUniformHeatmapDataSeries<TX, TY, TZ> : ISCIUniformHeatmapDataSeriesProtocol, IDataSeries where TX : IComparable where TY : IComparable where TZ : IComparable
//    {
//        TX StartX { get; set; }

//        TY StartY { get; set; }

//        TX StepX { get; set; }

//        TY StepY { get; set; }

//        void UpdateZValues(IEnumerable<TZ> values);

//        void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values);
//    }

//    public class UniformHeatmapDataSeries<TX, TY, TZ> : SCIUniformHeatmapDataSeries, IUniformHeatmapDataSeries<TX, TY, TZ> where TX : IComparable where TY : IComparable where TZ : IComparable
//    {
//        private readonly IValuesFactory<TX> _xValuesFactory;
//        private readonly IValuesFactory<TY> _yValuesFactory;
//        private readonly IValuesFactory<TZ> _zValuesFactory;

//        public UniformHeatmapDataSeries(int sizeX, int sizeY, ISCIRange rangeX, ISCIRange rangeY)
//            : base(ValuesFactory.Get<TX>().BaseType, ValuesFactory.Get<TY>().BaseType, ValuesFactory.Get<TZ>().BaseType, sizeX, sizeY, rangeX, rangeY)
//        {
//            _xValuesFactory = ValuesFactory.Get<TX>();
//            _yValuesFactory = ValuesFactory.Get<TY>();
//            _zValuesFactory = ValuesFactory.Get<TZ>();
//        }



//        public TX StartX { get; set; }
//        public TY StartY { get; set; }
//        public TX StepX { get; set; }
//        public TY StepY { get; set; }

//        public void UpdateZValues(IEnumerable<TZ> values)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}