namespace Xamarin.Examples.Demo.Showcase.AudioAnalyzer
{
    public interface IAudioAnalyzerDataProvider : IDataProvider<AudioData>
    {
        int BufferSize { get; }
        int SampleRate { get; }
    }
}