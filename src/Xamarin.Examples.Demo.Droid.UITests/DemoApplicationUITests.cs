using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace SciChart.Android.UITests
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
                .ApkFile(@"..\..\..\" + projectName + @"\bin\Release\" + projectName + ".apk")
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
            "Stacked Column Side by Side Chart",
            "Stacked Mountain Chart",
            "Using CursorModifier Tooltips",
            "Using RolloverModifier Tooltips",
            "Using ThemeManager",
            "Using TooltipModifier Tooltips"
        };

        [Test, TestCaseSource(nameof(Examples))]
        public void TakeAScreenshotOfExample(string exampleName)
        {
            app.WaitForElement(c => c.Marked("list"));

            app.ScrollDownTo( c=>c.Text(exampleName));

            app.Tap(c=>c.Text(exampleName));

            app.WaitForElement(c => c.Marked("fragment_container"));

            var screenshot = app.Screenshot(exampleName);
            var screenshotCopy = screenshot.CopyTo(Path.Combine(screenshot.Directory?.ToString() ?? @"C:\Screenshots", exampleName + ".png"), true);

            Console.WriteLine("Saved screenshot to: {0}\\{1}", screenshotCopy.Directory, screenshotCopy.Name);
        }
    }
}

