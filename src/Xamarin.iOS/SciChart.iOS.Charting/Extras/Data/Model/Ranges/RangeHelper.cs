using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public static class RangeHelper
    {
        public static readonly NSString GetMinMethod = new NSString("min");
        public static readonly NSString SetMinMethod = new NSString("setMin:");

        public static readonly NSString GetMaxMethod = new NSString("max");
        public static readonly NSString SetMaxMethod = new NSString("setMax:");

        public static readonly NSString DiffMethod = new NSString("diff");

        public static readonly NSString SetMinToMaxToMethod = new NSString("setMinTo:MaxTo:");
        public static readonly NSString GrowMinMaxMethod = new NSString("growMinBy:MaxBy:");
    }
}