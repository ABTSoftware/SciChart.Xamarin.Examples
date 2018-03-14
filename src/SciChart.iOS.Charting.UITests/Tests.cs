using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace SciChart.iOS.Charting.UITests
{
    [TestFixture]
    public class Tests
    {
        private iOSApp _app;

        [SetUp]
        public void BeforeEachTest()
        {
            _app = ConfigureApp.iOS.EnableLocalScreenshots().StartApp();
        }

        private static readonly string[] Examples = {
            "Annotations are Easy",
            "Band Chart",
            "Impulse Chart",
            "Heatmap Chart",
            "FIFO Chart",
            "ErrorBars Chart",
            "ECG Monitor Demo",
            "Dashboard Style Charts",
            "Chart Legends API",
            "Candlestick Chart",
            "Bubble Chart",
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
        public void ShouldTakeScreenshot(string example)
        {
            // need to ensure that we take screenshot with same orientation
            _app.SetOrientationPortrait();

            // wait for main screen to load
            _app.WaitForElement(c => c.Id("SciChart Xamarin.iOS Examples"));

            _app.ScrollDownTo(c => c.Text(example));

            _app.Screenshot(example);

            _app.Tap(c => c.Text(example));

            _app.WaitForElement(c => c.Marked("ExampleView"));

            _app.Screenshot(example);
        }
    }
}