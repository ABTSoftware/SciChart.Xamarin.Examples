using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

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
            "Bubble Chart",
            "Candlestick Chart",
            "Chart Legends API",
            "Dashboard Style Charts",
            "ECG Monitor Demo",
            "ErrorBars Chart",
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
			// need to ensure that we take screenshot with same orientation
			_app.SetOrientationPortrait();

            // wait for main screen to load
			_app.WaitForElement(c => c.Id("SciChart Xamarin.iOS Examples"));

			_app.ScrollDownTo(c => c.Text(exampleName));

			_app.Tap(c => c.Text(exampleName));

            // wait for example to load
            _app.WaitForElement(c => c.Id(exampleName));

			_app.Screenshot(exampleName);
		}
    }
}