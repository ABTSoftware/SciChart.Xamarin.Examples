using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
	// @interface SCIBaseColumnRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
	[BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIBaseColumnRenderableSeries : SCIThemeableProtocol
	{
		// @property (copy, nonatomic) SCIColumnSeriesStyle * style;
		[Export("style", ArgumentSemantic.Copy)]
		SCIColumnSeriesStyle Style { get; set; }

		// @property (nonatomic, copy) SCIColumnSeriesStyle * selectedStyle;
		[Export("selectedStyle", ArgumentSemantic.Copy)]
		SCIColumnSeriesStyle SelectedSeriesStyle { get; set; }

        // @property(nonatomic) SCIBrushStyle* fillBrushStyle;
        [Export("fillBrushStyle")]
        SCIBrushStyle FillBrushStyle { get; set; }

        // @property(nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }
    }
}