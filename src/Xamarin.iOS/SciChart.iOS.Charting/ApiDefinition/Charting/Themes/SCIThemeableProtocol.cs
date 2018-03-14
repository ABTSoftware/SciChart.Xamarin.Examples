using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIThemeableProtocol { }

    // @protocol SCIThemeableProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIThemeableProtocol
    {
        // @required -(void)applyThemeProvider:(id<SCIThemeProviderProtocol>)themeProvider;
        [Abstract]
        [Export("applyThemeProvider:")]
        void ApplyThemeProvider(ISCIThemeProviderProtocol themeProvider);
    }
}