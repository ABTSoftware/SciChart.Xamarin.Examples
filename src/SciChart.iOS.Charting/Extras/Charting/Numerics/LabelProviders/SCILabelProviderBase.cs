using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public partial class SCILabelProviderBase
    {
        // -(id<SCITickLabelProtocol>)updateDataContextWithContext:(SCIDefaultTickLabel *)label Data:(SCIGenericType)dataValue Style:(SCITextFormattingStyle *)style;
        private static readonly NSString UpdateDataContextWithContextDataStyleMethod = new NSString("updateDataContextWithContext:Data:Style:");
        public virtual SCITickLabelProtocol UpdateDataContext(SCIDefaultTickLabel label, IComparable dataValue, SCITextFormattingStyle style)
        {
            return (SCITickLabelProtocol)SCIXamarinMessageResolver.sendMessageOOGO(this, UpdateDataContextWithContextDataStyleMethod, label, ComparableUtil.ToDouble(dataValue), style);
        }

        // -(NSString *)formatLabel:(id)dataValue;
        private static readonly NSString FormatLabelMethod = new NSString("formatLabel:");
        public virtual string FormatLabel(IComparable dataValue)
        {
            return SCIXamarinMessageResolver.sendMessageSG(this, FormatLabelMethod, ComparableUtil.ToDouble(dataValue));
        }

        // -(NSString *)formatCursorLabel:(id)dataValue;
        private static readonly NSString FormatCursorLabelMethod = new NSString("formatCursorLabel:");
        public virtual string FormatCursorLabel(IComparable dataValue)
        {
            return SCIXamarinMessageResolver.sendMessageSG(this, FormatCursorLabelMethod, ComparableUtil.ToDouble(dataValue));
        }
    }
}