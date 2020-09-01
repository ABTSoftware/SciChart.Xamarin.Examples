using Foundation;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Set your trial or purchased license key here!
            // SciChart.iOS.Charting.SCIChartSurface.SetRuntimeLicenseKey("");
            
            return true;
        }
    }
}