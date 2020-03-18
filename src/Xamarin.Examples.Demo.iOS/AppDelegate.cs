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
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            Xamarin.Calabash.Start();

            // Set your trial or purchased license key here!
            // 
            // If you don't have a trial key you can get one from www.scichart.com/licensing-scichart-ios
            // 
            // Use code similar to the following: 
            // 
            // var licensingContract = @"Get your license from www.scichart.com/licensing-scichart-ios";
            // SciChart.iOS.Charting.SCIChartSurface.SetRuntimeLicenseKey(licensingContract);

//@BEGINDELETE
            // DEVELOPER KEY WILL BE DELETED IN DEPLOYMENT 
            var licensingContract = @"<LicenseContract>
                  <Customer>SciChart Dev Team</Customer>
                  <OrderId>Trial Ext</OrderId>
                  <LicenseCount>1</LicenseCount>
                  <IsTrialLicense>true</IsTrialLicense>
                  <SupportExpires>12/16/2017 00:00:00</SupportExpires>
                  <ProductCode>SC-IOS-2D-PRO</ProductCode>
                  <KeyCode>33d18b1a2d8dc5f93af2a6c657792f565d97425da20af5e18f19365a206c664a38636ea00dd89d2a424b9a272019c43cf9cbfddc8ddaaa93236c94a03e82ab9de83086d8eceaafa4073df101f20a4b84ce6366eae92706044d0694ea06582d292790107b3707988ba7f994fcaf37ef0b19024d0a82df1302cd246e21c9cd03a3d7d925af76d399e7979104f9c7d91795f61493fb297c711ac47ba9ad7e35ea7e</KeyCode>
                </LicenseContract>";
            SciChart.iOS.Charting.SCIChartSurface.SetRuntimeLicenseKey(licensingContract);
//@ENDDELETE

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}