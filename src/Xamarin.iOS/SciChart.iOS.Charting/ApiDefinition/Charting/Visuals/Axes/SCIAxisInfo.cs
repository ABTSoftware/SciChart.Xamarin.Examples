using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIAxisInfo
    {
        // @property (copy, nonatomic) NSString * axisId;
        [Export("axisId")]
        string AxisId { get; set; }

        // @property (copy, nonatomic) NSString * axisTitle;
        [Export("axisTitle")]
        string AxisTitle { get; set; }

        // @property (nonatomic) SCIAxisAlignmentMode axisAlignment;
        [Export("axisAlignment", ArgumentSemantic.Assign)]
        SCIAxisAlignment AxisAlignment { get; set; }

        // @property (nonatomic) SCIGenericType dataValue;
        //[Export("dataValue", ArgumentSemantic.Assign)]
        //SCIGenericType DataValue { get; set; }

        // @property (copy, nonatomic) NSString * axisFormattedDataValue;
        [Export("axisFormattedDataValue")]
        string AxisFormattedDataValue { get; set; }

        // @property (nonatomic) BOOL isHorizontal;
        [Export("isHorizontal")]
        bool IsHorizontal { get; set; }

        // @property (nonatomic) BOOL isXAxis;
        [Export("isXAxis")]
        bool IsXAxis { get; set; }

        // @property (copy, nonatomic) NSString * cursorFormattedDataValue;
        [Export("cursorFormattedDataValue")]
        string CursorFormattedDataValue { get; set; }

        // @property (nonatomic) BOOL isMasterChartAxis;
        [Export("isMasterChartAxis")]
        bool IsMasterChartAxis { get; set; }

        // @property (nonatomic) CGRect frame;
        [Export("frame", ArgumentSemantic.Assign)]
        CGRect Frame { get; set; }

        // @property (nonatomic) NSNumberFormatter * numberFormatter;
        [Export("numberFormatter", ArgumentSemantic.Assign)]
        NSNumberFormatter NumberFormatter { get; set; }

        // @property (nonatomic) NSDateFormatter * dateTimeFormatter;
        [Export("dateTimeFormatter", ArgumentSemantic.Assign)]
        NSDateFormatter DateTimeFormatter { get; set; }

        // -(SCITooltipDataView *)createAxisDataView;
        [Export("createAxisDataView")]
        SCITooltipDataView CreateAxisDataView { get; }
    }
}