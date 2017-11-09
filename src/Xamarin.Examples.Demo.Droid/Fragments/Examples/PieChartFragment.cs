using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SciChart.Charting.Model;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Pie Chart", description: "Demonstrates a simple Pie Chart", icon: ExampleIcon.PieChart)]
    public class PieChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId { get { return Resource.Layout.Example_Single_Pie_Chart_Fragment; } }

        private SciPieChartSurface Surface => View.FindViewById<SciPieChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            PieSegment pieSegment1 = new PieSegment()
            {
                Value = 40,
                Title = "Green",
                FillStyle = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, new Color[] {Color.Red, Color.Yellow},
                    new float[] {0f, 1f}),
            };

            PieSegment pieSegment2 = new PieSegment()
            {
                Value = 10,
                Title = "Red",
                FillStyle = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, new Color[] { new Color(unchecked((int) 0xffe04a2f)), new Color(unchecked((int) 0xffB7161B)) },
                    new float[] { 0.6f, 0.95f }),
            };

            PieSegment pieSegment3 = new PieSegment()
            {
                Value = 20,
                Title = "Blue",
                FillStyle = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, new Color[] { new Color(unchecked((int)0xff4AB6C1)), new Color(unchecked((int)0xff2182AD)) },
                    new float[] { 0.6f, 0.95f }),
            };

            var pieSeries = new PieRenderableSeries()
            {
                SelectedSegmentOffset = 0f,
                SegmentsCollection = new PieSegmentCollection(new[] {pieSegment1, pieSegment2, pieSegment3}),
            };

            Surface.RenderableSeries.Add(pieSeries);
        }
    }
}