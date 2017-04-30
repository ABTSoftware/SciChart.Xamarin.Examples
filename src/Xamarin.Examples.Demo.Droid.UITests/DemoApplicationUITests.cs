using System;
using System.Drawing;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace Xamarin.Examples.Demo.Droid.UITests
{
    [TestFixture]
    public class DemoApplicationUiTests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            const string projectName = "Xamarin.Examples.Demo.Droid";

            app = ConfigureApp
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
            "Performance Demo",
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
        public void TakeAScreenshotOfExample(string exampleName)
        {
            app.WaitForElement(c => c.Marked("examplesList"));

            app.ScrollDownTo(c => c.Text(exampleName));

            app.Tap(c => c.Text(exampleName));

            app.WaitForElement(c => c.Marked("fragment_container"));

            var rect = app.Query(c => c.Marked("fragment_container")).FirstOrDefault()?.Rect;
            if(rect == null) throw new InvalidOperationException("fragment_container has null rect");

            var actualScreenshotFileInfo = app.Screenshot(exampleName);
            var actualBitmap = VisualTestHelpers.LoadFromPng(actualScreenshotFileInfo.FullName);

            var fragmentRect = new Rectangle((int)rect.X, (int) rect.Y, (int)rect.Width, (int)rect.Height);
            var fragmentBitmap = new Bitmap(fragmentRect.Width, fragmentRect.Height);

            using (var graphics = Graphics.FromImage(fragmentBitmap))
            {
                graphics.DrawImage(actualBitmap, 0, 0, fragmentRect, GraphicsUnit.Pixel);
            }

            const string expectationsPath = @"..\..\Expectations";
            var expectedBitmap = VisualTestHelpers.LoadFromPng(Path.Combine(expectationsPath, $"{exampleName}.png"));

            VisualTestHelpers.CompareBitmaps(exampleName, fragmentBitmap, expectedBitmap);
        }
    }
}

