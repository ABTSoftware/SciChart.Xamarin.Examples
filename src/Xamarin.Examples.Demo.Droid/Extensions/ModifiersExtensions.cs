using SciChart.Charting.Modifiers;

namespace Xamarin.Examples.Demo.Droid.Extensions
{
    public static class ModifiersExtensions
    {
        public static ChartModifierBase WithReceiveHandledEvents(this ChartModifierBase chartModifierBase, bool receiveHandledEvents)
        {
            chartModifierBase.SetReceiveHandledEvents(receiveHandledEvents);
            return chartModifierBase;
        }
    }
}