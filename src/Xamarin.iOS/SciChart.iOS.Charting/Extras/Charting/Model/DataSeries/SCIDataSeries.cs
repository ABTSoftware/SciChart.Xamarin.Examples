using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public interface IDataSeries : ISCIDataSeriesProtocol
    {
        // TODO sync X\Y Max\Min with native binding
        //IComparable XMin { get; }
        //IComparable XMax { get; }
        //IComparable YMin { get; }
        //IComparable YMax { get; }
    }

    public partial class SCIDataSeries : IDataSeries
    {
        protected static readonly NSString XMinMethod = new NSString("XMin");
        protected static readonly NSString XMaxMethod = new NSString("XMax");
        protected static readonly NSString YMinMethod = new NSString("YMin");
        protected static readonly NSString YMaxMethod = new NSString("YMax");
        protected static readonly NSString RemoveValueMethod = new NSString("removeValue:");
        protected static readonly NSString FindIndexForValueMode = new NSString("findIndexForValue:Mode:");

        // TODO sync X\Y Max\Min with native binding
        //public IComparable XMin => SCIXamarinMessageResolver.sendMessageGV(this, XMinMethod);
        //public IComparable XMax => SCIXamarinMessageResolver.sendMessageGV(this, XMaxMethod);
        //public IComparable YMin => SCIXamarinMessageResolver.sendMessageGV(this, YMinMethod);
        //public IComparable YMax => SCIXamarinMessageResolver.sendMessageGV(this, YMaxMethod);
    }
}