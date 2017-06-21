using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @protocol ISCIDataDistributionCalculatorProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIDataDistributionCalculatorProtocol
    {
        // @required -(BOOL)dataIsSortedAscending;
        [Abstract]
        [Export("dataIsSortedAscending")]
        bool DataIsSortedAscending { get; set; }

        // @required -(BOOL)dataIsEvenlySpaced;
        [Abstract]
        [Export("dataIsEvenlySpaced")]
        bool DataIsEvenlySpaced { get; set; }

        // @required -(void)updateDataDistributionFlagsWhenRemovedXValues;
        [Abstract]
        [Export("updateDataDistributionFlagsWhenRemovedXValues")]
        void UpdateDataDistributionFlagsWhenRemovedXValues();

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();
    }
}