using Foundation;
using UIKit;
using SciChart.iOS.Charting;

namespace Tutorial01_CreateSimple2DChart
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
            SCIChartSurface.SetRuntimeLicenseKey("{\r\n  \"ActivatedBy\": null,\r\n  \"Customer\": \"TestCompany\",\r\n  \"DeveloperCount\": 1,\r\n  \"ExpiryDate\": \"2019-12-31\",\r\n  \"Features\": [\r\n    \"iOS-3D\",\r\n    \"iOS-2D\"\r\n  ],\r\n  \"IsTrialLicense\": false,\r\n  \"KeyCode\": \"274827e18d015f0b8f98cc37600b744966112de315a64dc2a87225a72f038a4465c431064405f3133c31afebf7858a9967b36990a14e2cacf86d62fe19d201fe91bd32305a6345fca4d387f32310c4650297b71b9638dce34892bfd3abaa94b0303d0fa51110a0863d0b928d4ce8cf4016855d9d29962d58d2d7c82b5ff50c87556462102e102654a1e24c9e107c244d51cd9bf63cddb2381141617dc276792599457d793876415c\",\r\n  \"MachineId\": null,\r\n  \"OrderId\": \"TestCompanyOrder123\",\r\n  \"ProductCode\": \"SC-IOS-SDK-PRO\",\r\n  \"SerialKey\": null,\r\n  \"TicketQuantity\": null\r\n}");

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new ViewController();
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}