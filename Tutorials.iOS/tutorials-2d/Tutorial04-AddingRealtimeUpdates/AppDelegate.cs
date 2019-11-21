using Foundation;
using UIKit;
using SciChart.iOS.Charting;

namespace Tutorial04_AddingRealtimeUpdates
{
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {
        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Provide your License Key:
            SCIChartSurface.SetRuntimeLicenseKey("");

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new ViewController();
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}