using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    //@interface SCIPieSeriesDataView : SCITooltipDataView
    [BaseType(typeof(SCITooltipDataView))]
    interface SCIPieSeriesDataView
    {
        //-(void) setData:(SCIPieSeriesInfo*) data;
        [Export("setData:")]
        void SetData(SCIPieSeriesInfo data);

        //+(SCITooltipDataView*) createInstance;
        [Export("createInstance")]
        SCITooltipDataView CreateInstance();
    }
}
