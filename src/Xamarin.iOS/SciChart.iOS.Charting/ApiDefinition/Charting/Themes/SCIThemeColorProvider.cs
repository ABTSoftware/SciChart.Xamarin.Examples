using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIThemeColorProvider : NSObject <SCIThemeProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIThemeColorProvider : SCIThemeProviderProtocol
    {
        // -(instancetype _Nullable)initWithThemeKey:(NSString * _Nonnull)themeKey;
        [Export("initWithThemeKey:")]
        IntPtr Constructor(string themeKey);
    }
}