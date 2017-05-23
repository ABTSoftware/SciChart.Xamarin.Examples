using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace Xamarin.Examples.Demo.Droid.UITests
{
    [TestFixture]
    public class DemoApplicationUiTests
    {
#if !DEBUG
        private const string ExpectationsPath = @"..\..\Expectations";

        private AndroidApp _app;

        [SetUp]
        public void BeforeEachTest()
        {
            const string projectName = "Xamarin.Examples.Demo.Droid";

            _app = ConfigureApp
                .Android
                .ApkFile($@"..\..\..\{projectName}\bin\Release\{projectName}.apk")
                .EnableLocalScreenshots()
                .StartApp();
        }

        private static readonly string[] Examples = {
            "Animating Line Chart",
            "Band Chart",
            "Bubble Chart",
            "Candlestick Chart",
            "Chart Legends API",
            "Dashboard Style Charts",
            "FIFO Chart",
            "Heatmap Chart",
            "Impulse Chart",
            "Interaction with Annotations",
            "Line Chart",
            "Mountain Chart",
            "Multi-Pane Stock Charts",
            "Performance Demo",
            "Realtime Ticking Stock Charts",
            "Scatter Chart",
            "Series Selection",
            "Stacked Bar Chart",
            "Stacked Column Chart",
            "Stacked Column Side By Side Chart",
            "Stacked Mountain Chart",
            "Using CursorModifier Tooltips",
            "Using RolloverModifier Tooltips",
            "Using ThemeManager",
            "Using TooltipModifier Tooltips"
        };

        [Test, TestCaseSource(nameof(Examples))]
        public void ShouldTakeScreenshot(string exampleName)
        {
            TakeScreenshotOfExample(exampleName);
        }

        private FileInfo TakeScreenshotOfExample(string exampleName)
        {
            // need to ensure that we take screenshot with same orientation
            _app.SetOrientationPortrait();

            _app.WaitForElement(c => c.Marked("examplesList"));

            _app.ScrollDownTo(c => c.Text(exampleName));

            _app.Tap(c => c.Text(exampleName));

            _app.WaitForElement(c => c.Marked("fragment_container"));

            _app.Invoke("InitExampleForUiTest");

            return _app.Screenshot(exampleName);
        }

        [Ignore, Test, TestCaseSource(nameof(Examples))]
        public void ShouldTakeAndCompareScreenshot(string exampleName)
        {
            var fragmentBitmap = GetFragmentScreenshot(exampleName);

            var expectedBitmap = VisualTestHelpers.LoadFromPng(Path.Combine(ExpectationsPath, GetDeviceId(_app), $"{exampleName}.png"));

            VisualTestHelpers.CompareBitmaps(exampleName, fragmentBitmap, expectedBitmap);
        }      

        private Bitmap GetFragmentScreenshot(string exampleName)
        {
            var actualScreenshotFileInfo = TakeScreenshotOfExample(exampleName);

            var rect = _app.Query(c => c.Marked("fragment_container")).FirstOrDefault()?.Rect;
            if (rect == null) throw new InvalidOperationException("fragment_container has null rect");
                        
            var actualBitmap = VisualTestHelpers.LoadFromPng(actualScreenshotFileInfo.FullName);

            var fragmentRect = new Rectangle((int) rect.X, (int) rect.Y, (int) rect.Width, (int) rect.Height);
            var fragmentBitmap = new Bitmap(fragmentRect.Width, fragmentRect.Height);

            using (var graphics = Graphics.FromImage(fragmentBitmap))
            {
                graphics.DrawImage(actualBitmap, 0, 0, fragmentRect, GraphicsUnit.Pixel);
            }

            return fragmentBitmap;
        }

        /**
         * Should be run once to create/update screenshots which then will be used for automatical comparison
         */
        [Ignore]
        [Test, TestCaseSource(nameof(Examples))]
        public void UpdateScreenshotsWithExpectations(string exampleName)
        {
            var fragmentBitmap = GetFragmentScreenshot(exampleName);

            VisualTestHelpers.SaveToPng(Path.Combine(ExpectationsPath, GetDeviceId(_app), $"{exampleName}.png"), fragmentBitmap);
        }

        private static string GetDeviceId(AndroidApp app)
        {
            var id = app.Device.DeviceIdentifier;

            // get DisplayMetrics
            var json = app.Query(x => x.Marked("content").Invoke("getContext").Invoke("getResources").Invoke("getDisplayMetrics")).First().ToString();
            var displayMetrics = JsonConvert.DeserializeObject<Dictionary<string, double>>(json);

            // get screen parameters
            var width = displayMetrics["widthPixels"];
            var height = displayMetrics["heightPixels"];
            var xdpi = displayMetrics["xdpi"];
            var ydpi = displayMetrics["ydpi"];

            return $"{id}-{width}x{height}-{xdpi}x{ydpi}";
        }
#endif
    }
}

