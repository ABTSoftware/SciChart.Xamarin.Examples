namespace Xamarin.Examples.Demo.Showcase.AudioAnalyzer
{
    public class AudioData
    {
        public int Count { get; }
        public long[] XData { get; }
        public short[] YData { get; }

        public AudioData(int count)
        {
            Count = count;
            XData = new long[count];
            YData = new short[count];
        }
    }
}