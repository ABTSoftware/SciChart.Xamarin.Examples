using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCIAxisBase
    {
        // - (NSString*)formatText:(SCIGenericType)value;
        private static readonly NSString FormatTextMethod = new NSString("formatText:");
        public virtual string FormatText(IComparable dataValue)
        {
        return SCIXamarinMessageResolver.sendMessageSG(this, FormatTextMethod, ComparableUtil.ToDouble(dataValue));
        }

        // - (NSString*)formatCursorText:(SCIGenericType)value;
        private static readonly NSString FormatCursorTextMethod = new NSString("formatCursorText:");
        public virtual string FormatCursorLabel(IComparable dataValue)
        {
        	return SCIXamarinMessageResolver.sendMessageSG(this, FormatCursorTextMethod, ComparableUtil.ToDouble(dataValue));
        }
    }
}