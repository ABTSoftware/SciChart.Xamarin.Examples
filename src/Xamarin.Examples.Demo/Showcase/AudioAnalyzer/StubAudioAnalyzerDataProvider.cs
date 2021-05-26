using System;
using System.Reactive.Linq;

namespace Xamarin.Examples.Demo.Showcase.AudioAnalyzer
{
    public class StubAudioAnalyzerDataProvider : IAudioAnalyzerDataProvider
    {
        private const int ItemsCount = 2048;
        private readonly AudioData _audioData = new AudioData(ItemsCount);

        private long _time = 0;

        private AudioData OnNext()
        {
            var timeValues = _audioData.XData;
            for (int i = 0; i < ItemsCount; i++)
            {
                timeValues[i] = _time++;
            }
            _provider.UpdateYValues(timeValues, _audioData.YData);

            return _audioData;
        }

        public IObservable<AudioData> Data
        {
            get
            {
                return Observable
                    .Interval(TimeSpan.FromMilliseconds(20))
                    .Select(interval => OnNext());
            }
        }

        public int BufferSize => ItemsCount;

        public int SampleRate { get; } = 44100;

        private readonly IYValuesProvider _provider = new AggregateYValuesProvider(new IYValuesProvider[]
        {
            new FrequencySinewaveYValuesProvider(8000, 0, 0, 1, 0.0000005),
            new NoisySinewaveYValuesProvider(8000, 0, 0.000032, 200),
            new NoisySinewaveYValuesProvider(6000, 0, 0.000016, 100),
            new NoisySinewaveYValuesProvider(4000, 0, 0.000064, 100)
        });

        interface IYValuesProvider
        {
            void UpdateYValues(long[] timeValues, short[] yValuesToUpdate);
        }

        class FrequencySinewaveYValuesProvider : IYValuesProvider
        {
            private readonly double _amplitude;
            private readonly double _phase;

            private readonly double _minFrequency;
            private readonly double _maxFrequency;
            private readonly double _step;

            private double _frequency;
            public FrequencySinewaveYValuesProvider(double amplitude, double phase, double minFrequency, double maxFrequency, double step)
            {
                _amplitude = amplitude;
                _phase = phase;

                _minFrequency = minFrequency;
                _maxFrequency = maxFrequency;
                _step = step;

                _frequency = minFrequency;
            }

            private short GetYValueForIndex(long index)
            {
                _frequency = _frequency <= _maxFrequency ? _frequency + _step : _minFrequency;

                var wn = 2 * Math.PI * _frequency;
                return (short)(_amplitude * Math.Sin(index * wn + _phase));
            }

            public void UpdateYValues(long[] timeValues, short[] yValuesToUpdate)
            {
                for (int i = 0; i < timeValues.Length; i++)
                {
                    var time = timeValues[i];

                    _frequency = _frequency <= _maxFrequency ? _frequency + _step : _minFrequency;

                    var wn = 2 * Math.PI * _frequency;
                    yValuesToUpdate[i] += (short)(_amplitude * Math.Sin(time * wn + _phase));
                }
            }
        }

        class NoisySinewaveYValuesProvider : IYValuesProvider
        {
            private readonly Random _random = new Random();

            private readonly double _amplitude;
            private readonly double _phase;
            private readonly double _wn;
            private readonly double _noiseAmplitude;

            public NoisySinewaveYValuesProvider(double amplitude, double phase, double frequency, double noiseAmplitude)
            {
                _amplitude = amplitude;
                _phase = phase;
                _wn = 2 * Math.PI * frequency;
                _noiseAmplitude = noiseAmplitude;
            }

            public void UpdateYValues(long[] timeValues, short[] yValuesToUpdate)
            {
                for (int i = 0; i < timeValues.Length; i++)
                {
                    var time = timeValues[i];

                    yValuesToUpdate[i] += (short)(_amplitude * Math.Sin(time * _wn + _phase) + (_random.NextDouble() - .5) * _noiseAmplitude);
                }
            }
        }

        class AggregateYValuesProvider : IYValuesProvider
        {
            private readonly IYValuesProvider[] _providers;

            public AggregateYValuesProvider(IYValuesProvider[] providers)
            {
                _providers = providers;
            }

            public void UpdateYValues(long[] timeValues, short[] yValuesToUpdate)
            {
                Array.Clear(yValuesToUpdate, 0, yValuesToUpdate.Length);

                for (int i = 0; i < _providers.Length; i++)
                {
                    _providers[i].UpdateYValues(timeValues, yValuesToUpdate);
                }
            }
        }
    }
}