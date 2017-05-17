using Android.Views;
using SciChart.Charting.Modifiers;
using SciChart.Core.Framework;
namespace Xamarin.Examples.Demo.Droid.Extensions
{
    public static class ModifiersExtensions
    {
        public static ChartModifierBase WithReceiveHandledEvents(this ChartModifierBase chartModifierBase, bool receiveHandledEvents)
        {
            chartModifierBase.SetReceiveHandledEvents(receiveHandledEvents);
            return chartModifierBase;
        }

        public static LegendModifier WithShowCheckBoxes(this LegendModifier legendModifier, bool showCheckBoxes)
        {
            legendModifier.SetShowCheckboxes(showCheckBoxes);
            return legendModifier;
        }

        public static LegendModifier WithOrientation(this LegendModifier legendModifier, Orientation orientation)
        {
            legendModifier.SetOrientation(orientation);
            return legendModifier;
        }

        public static LegendModifier WithPosition(this LegendModifier legendModifier, GravityFlags gravity, int margin)
        { 
            legendModifier.SetLegendPosition(gravity, margin);
            return legendModifier;
        }
    }
}