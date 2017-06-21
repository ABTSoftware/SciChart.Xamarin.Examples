using Android.Graphics;

namespace SciChart.Charting.Visuals.Annotations
{
    public abstract partial class LineAnnotationBase
    {
        // Added method here, because we can't map int to Android.Graphics.Color via Metadata.xml, 
        // so we just removed it there and add this override here as well as on android side
        public override void SetBackgroundColor(Color color)
        {
        }
    }
}