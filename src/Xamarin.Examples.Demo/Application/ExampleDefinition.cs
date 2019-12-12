using System;

namespace Xamarin.Examples.Demo
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
        PieChart,
        RealTime,
        ScatterChart, 
        StackedBar,
        StackedColumn,
        StackedColumns100,
        StackedMountainChart,
        Themes, 
        ZoomPan,

        Axis3D,
        Scatter3D,
        Surface3D,
    }

    public abstract class ExampleDefinitionBase : Attribute
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ExampleIcon? Icon { get; set; }
        public bool IsExample3D { get; }

        public ExampleDefinitionBase(bool isExample3D, string title, string description, ExampleIcon icon)
        {
            IsExample3D = isExample3D;
	        Title = title;
	        Description = description;
	        Icon = icon;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExampleDefinition : ExampleDefinitionBase
    {
        public ExampleDefinition(string title, string description, ExampleIcon icon = default) : base(false, title, description, icon)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class Example3DDefinition : ExampleDefinitionBase
    {
        public Example3DDefinition(string title, string description, ExampleIcon icon = default) : base(true, title, description, icon)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FeaturedExampleDefinition : ExampleDefinitionBase
    {
        public FeaturedExampleDefinition(string title, string description, ExampleIcon icon = default) : base(true, title, description, icon)
        {
        }
    }
}