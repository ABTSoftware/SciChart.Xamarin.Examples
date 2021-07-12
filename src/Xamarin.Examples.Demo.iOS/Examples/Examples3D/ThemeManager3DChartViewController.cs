using System.Collections.Generic;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Theme Manager 3D Chart", description: "Styling Chart3D via the ThemeManager", icon: ExampleIcon.Themes)]
    class ThemeManager3DChartViewController : SingleChartWithTopPanelViewController<SCIChartSurface3D>
    {
        private static readonly Dictionary<string, string> _themesDictionary = new Dictionary<string, string>
        {
            { "Black Steel", SCIThemeManager.BlackSteel },
            { "Bright Spark", SCIThemeManager.Bright_Spark },
            { "Chrome", SCIThemeManager.Chrome },
            { "Chart V4 Dark", SCIThemeManager.SciChartv4Dark },
            { "Electric", SCIThemeManager.Electric },
            { "Expression Dark", SCIThemeManager.ExpressionDark },
            { "Expression Light", SCIThemeManager.ExpressionLight },
            { "Oscilloscope", SCIThemeManager.Oscilloscope },
        };
        private readonly UIButton SelectThemeButton = new UIButton(UIButtonType.RoundedRect);

        public override UIView ProvidePanel()
        {
            SelectThemeButton.SetTitle("Select Theme", UIControlState.Normal);
            SelectThemeButton.TouchUpInside += (sender, args) =>
            {
                var actionSheetAlert = UIAlertController.Create("Select Theme", null, UIAlertControllerStyle.ActionSheet);

                foreach (var themeName in _themesDictionary.Keys)
                {
                    var themeAction = UIAlertAction.Create(themeName, UIAlertActionStyle.Default, action => SetTheme(themeName));
                    actionSheetAlert.AddAction(themeAction);
                }
                actionSheetAlert.AddAction(UIAlertAction.Create("Cansel", UIAlertActionStyle.Cancel, null));

                if (actionSheetAlert.PopoverPresentationController != null)
                {
                    actionSheetAlert.PopoverPresentationController.SourceView = View;
                    actionSheetAlert.PopoverPresentationController.SourceRect = ((UIButton)sender).Frame;
                }

                View.Window.RootViewController.PresentViewController(actionSheetAlert, true, null);
            };

            return SelectThemeButton;
        }
        
        protected override void InitExample()
        {
            var dataManager = DataManager.Instance;
            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new SCIPointMetadataProvider3D();

            for (int i = 0; i < 1250; i++)
            {
                var x = dataManager.GetGaussianRandomNumber(5, 1.5);
                var y = dataManager.GetGaussianRandomNumber(5, 1.5);
                var z = dataManager.GetGaussianRandomNumber(5, 1.5);
                dataSeries3D.Append(x, y, z);

                var metadata = new SCIPointMetadata3D((uint)dataManager.GetRandomColor().ToArgb(), dataManager.GetRandomScale());
                metadataProvider.Metadata.Add(metadata);
            }

            var renderableSeries3D = new SCIScatterRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider,
                PointMarker = new SCISpherePointMarker3D { FillColor = ColorUtil.Lime, Size = 2f },
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(renderableSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
            }
        }

        private void SetTheme(string themeName)
        {
            SCIThemeManager.ApplyTheme(_themesDictionary[themeName], Surface);
            SelectThemeButton.SetTitle(themeName, UIControlState.Normal);
        }
    }
}