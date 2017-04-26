using System;

namespace SciChart.Examples.Demo.Fragments.Base
{
    public enum ExampleIcon
    { 
        Annotations,
        Axis,
        BandChart,
        BubbleChart,
        CandlestickChart,
        ColumnChart,
        CubeChart,
        DigitalLine,
        ErrorBars,
        Fan,
        FeatureChart,
        HeatmapChart,
        Impulse,
        LineChart,
        MountainChart,
        Ohlc,
        RealTime,
        ScatterChart, 
        StackedBar,
        StackedColumn,
        StackedColumns100,
        StackedMountainChart,
        Themes, 
        ZoomPan
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExampleDefinition : Attribute
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ExampleIcon? Icon { get; set; }

        public ExampleDefinition(string title, string description)
        {
	        Title = title;
            Description = description;
        }

        public ExampleDefinition(string title, string description, ExampleIcon icon)
        {
	        Title = title;
	        Description = description;
	        Icon = icon;
        }
    }
}