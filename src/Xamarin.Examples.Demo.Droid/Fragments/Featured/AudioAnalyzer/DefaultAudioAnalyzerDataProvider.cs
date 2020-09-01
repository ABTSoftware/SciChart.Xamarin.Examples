using System;
using System.Reactive.Linq;
using Android.Media;
using Xamarin.Examples.Demo.Showcase.AudioAnalyzer;

namespace Xamarin.Examples.Demo.Droid.Fragments.Featured.AudioAnalyzer
{
    public class DefaultAudioAnalyzerDataProvider : IAudioAnalyzerDataProvider
    {
        private readonly AudioData _audioData;
        private readonly AudioRecord _audioRecord;

        private long _time = 0;

        public DefaultAudioAnalyzerDataProvider(int sampleRate = 44100, int bufferSize = 2048)
        {
            SampleRate = sampleRate;
            BufferSize = bufferSize;

            _audioData = new AudioData(BufferSize);
            _audioRecord = new AudioRecord(AudioSource.Mic, SampleRate, ChannelIn.Mono, Encoding.Pcm16bit, BufferSize);
        }

        public bool IsInitialized => _audioRecord.State == State.Initialized;

        public IObservable<AudioData> Data
        {
            get
            {
                _audioRecord.StartRecording();

                return Observable.Interval(TimeSpan
                        .FromMilliseconds((double)SampleRate / BufferSize))
                    .Select(interval => OnNext())
                    .Finally(() => _audioRecord.Stop());
            }
        }

        private AudioData OnNext()
        {
            _audioRecord.Read(_audioData.YData, 0, BufferSize);

            var timeValues = _audioData.XData;
            for (int i = 0; i < BufferSize; i++)
            {
                timeValues[i] = _time++;
            }

            return _audioData;
        }

        public int BufferSize { get; }

        public int SampleRate { get; }
    }
}