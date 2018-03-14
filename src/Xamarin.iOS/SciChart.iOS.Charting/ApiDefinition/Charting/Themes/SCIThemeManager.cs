using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIThemeManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIThemeManager
    {
        // +(id<SCIThemeProviderProtocol> _Nullable)themeProviderWith:(NSString * _Nonnull)themeKey;
        [Static]
        [Export("themeProviderWith:")]
        [return: NullAllowed]
        ISCIThemeProviderProtocol GetThemeProvider(string themeKey);

        // +(void)removeThemeByThemeKey:(NSString * _Nonnull)themeKey;
        [Static]
        [Export("removeThemeByThemeKey:")]
        void RemoveTheme(string themeKey);

        // +(void)addThemeByThemeKey:(NSString * _Nonnull)themeKey;
        [Static]
        [Export("addThemeByThemeKey:")]
        void AddTheme(string themeKey);

        // +(void)applyThemeToThemeable:(id<SCIThemeableProtocol> _Nonnull)themeable withThemeKey:(NSString * _Nonnull)themeKey;
        [Static]
        [Export("applyThemeToThemeable:withThemeKey:")]
        void ApplyTheme(ISCIThemeableProtocol themeable, string themeKey);

        // +(void)applyDefaultThemeToThemeable:(id<SCIThemeableProtocol> _Nonnull)themeable;
        [Static]
        [Export("applyDefaultThemeToThemeable:")]
        void ApplyDefaultTheme(ISCIThemeableProtocol themeable);
    }
}