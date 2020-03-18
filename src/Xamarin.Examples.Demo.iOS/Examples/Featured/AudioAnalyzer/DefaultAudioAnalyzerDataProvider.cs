using System;
using System.Reactive.Linq;
using Xamarin.Examples.Demo.Showcase.AudioAnalyzer;

namespace Xamarin.Examples.Demo.iOS
{
    public class DefaultAudioAnalyzerDataProvider : IAudioAnalyzerDataProvider
    {
        private AudioData _audioData;
        private readonly AudioRecorder recorder;

        private long _time = 0;

        public int BufferSize { get; }

        public int SampleRate { get; }

        public DefaultAudioAnalyzerDataProvider(int sampleRate = 44100, int bufferSize = 2048)
        {
            SampleRate = sampleRate;
            BufferSize = bufferSize;

            _audioData = new AudioData(BufferSize);
            recorder = new AudioRecorder(SampleRate);
        }

        public IObservable<AudioData> Data
        {
            get
            {
                recorder.Start();
                return Observable.Interval(TimeSpan
                    .FromMilliseconds((double)SampleRate / BufferSize))
                    .Select(interval => OnNext())
                    .Finally(() => recorder.Stop());
            }
        }

        private AudioData OnNext()
        {
            var timeValues = _audioData.XData;
            for (int i = 0; i < BufferSize; i++)
            {
                timeValues[i] = _time++;
                if (i < recorder.samples.Length)
                {
                    _audioData.YData[i] = recorder.samples[i];
                }   
            }

            return _audioData;
        }
    }
}
