using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
	// @interface SCIBaseMountainRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
	[BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIBaseMountainRenderableSeries : SCIThemeableProtocol
	{
		// @property (copy, nonatomic) SCIColumnSeriesStyle * style;
		[Export("style", ArgumentSemantic.Copy)]
		SCIMountainSeriesStyle Style { get; set; }

		// @property (nonatomic, copy) SCIColumnSeriesStyle * selectedStyle;
		[Export("selectedStyle", ArgumentSemantic.Copy)]
		SCIMountainSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) BOOL isDigitalLine;
        [Export("isDigitalLine")]
        bool IsDigitalLine { get; set; }

        // @property (nonatomic, strong) id<SCIBrushStyleProtocol> areaStyle;
        [Export("areaStyle")]
        ISCIBrushStyleProtocol AreaStyle { get; set; }
    }
}