using SciChart.Examples.Demo.Data;
using System;


namespace Xamarin.Examples.Demo.Data
{
    public class RandomPricesDataSource
    {
        private sealed class PriceBarInfo
        {
            public DateTime DateTime;
            public double Close;
        }

        private static readonly TimeSpan OpenMarketTime = new TimeSpan(0, 08, 0, 0);
        private static readonly TimeSpan CloseMarketTime = new TimeSpan(0, 16, 30, 0);

        private readonly int _candleIntervalMinutes;
        private readonly bool _simulateDateGap;
        private readonly int _updatesPerPrice;
        private readonly PriceBarInfo _initialPriceBar;

        private readonly Random _random;

        private PriceBar _lastPriceBar;
        private double _currentTime;
        private int _currentUpdateCount;

        public RandomPricesDataSource(int candleIntervalMinutes, bool simulateDateGap, int updatesPerPrice, int randomSeed, double startingPrice, DateTime startDate)
        {
            _candleIntervalMinutes = candleIntervalMinutes;
            _simulateDateGap = simulateDateGap;
            _updatesPerPrice = updatesPerPrice;

            _initialPriceBar = new PriceBarInfo
            {
                Close = startingPrice,
                DateTime = startDate
            };

            _lastPriceBar = new PriceBar(_initialPriceBar.DateTime, _initialPriceBar.Close, _initialPriceBar.Close, _initialPriceBar.Close, _initialPriceBar.Close, 0L);
            _random = new Random(randomSeed);
        }

        public PriceBar GetNextData()
        {
            return GetNextRandomPriceBar();
        }

        private PriceBar GetNextRandomPriceBar()
        {
            double close = _lastPriceBar.Close;
            double num = (_random.NextDouble() - 0.9) * _initialPriceBar.Close / 30.0;
            double num2 = _random.NextDouble();
            double num3 = _initialPriceBar.Close + _initialPriceBar.Close / 2.0 * Math.Sin(7.27220521664304E-06 * _currentTime) + _initialPriceBar.Close / 16.0 * Math.Cos(7.27220521664304E-05 * _currentTime) + _initialPriceBar.Close / 32.0 * Math.Sin(7.27220521664304E-05 * (10.0 + num2) * _currentTime) + _initialPriceBar.Close / 64.0 * Math.Cos(7.27220521664304E-05 * (20.0 + num2) * _currentTime) + num;
            double num4 = Math.Max(close, num3);
            double num5 = _random.NextDouble() * _initialPriceBar.Close / 100.0;
            double high = num4 + num5;
            double num6 = Math.Min(close, num3);
            double num7 = _random.NextDouble() * _initialPriceBar.Close / 100.0;
            double low = num6 - num7;
            long volume = (long)(_random.NextDouble() * 30000 + 20000);
            DateTime openTime = _simulateDateGap ? EmulateDateGap(_lastPriceBar.DateTime) : _lastPriceBar.DateTime;
            DateTime closeTime = openTime.AddMinutes(_candleIntervalMinutes);
            PriceBar candle = new PriceBar(closeTime, close, high, low, num3, volume);
            _lastPriceBar = new PriceBar(candle.DateTime, candle.Open, candle.High, candle.Low, candle.Close, volume);
            _currentTime += _candleIntervalMinutes * 60;
            return candle;
        }

        private DateTime EmulateDateGap(DateTime candleOpenTime)
        {
            DateTime result = candleOpenTime;
            TimeSpan timeOfDay = candleOpenTime.TimeOfDay;
            if (timeOfDay > CloseMarketTime)
            {
                DateTime dateTime = candleOpenTime.Date;
                dateTime = dateTime.AddDays(1.0);
                result = dateTime.Add(OpenMarketTime);
            }
            while (result.DayOfWeek == DayOfWeek.Saturday || result.DayOfWeek == DayOfWeek.Sunday)
            {
                result = result.AddDays(1.0);
            }
            return result;
        }

        private PriceBar GetUpdatedData()
        {
            double num = _lastPriceBar.Close + ((_random.NextDouble() - 0.48) * (_lastPriceBar.Close / 100.0));
            double high = (num > _lastPriceBar.High) ? num : _lastPriceBar.High;
            double low = (num < _lastPriceBar.Low) ? num : _lastPriceBar.Low;
            long volumeInc = (long)((_random.NextDouble() * 30000 + 20000) * 0.05);
            _lastPriceBar = new PriceBar(_lastPriceBar.DateTime, _lastPriceBar.Open, high, low, num, _lastPriceBar.Volume + volumeInc);

            return _lastPriceBar;
        }


        public PriceBar Tick()
        {
            if (_currentUpdateCount < _updatesPerPrice)
            {
                _currentUpdateCount++;
                return GetUpdatedData();
            }
            else
            {
                _currentUpdateCount = 0;
                return GetNextData();
            }
        }
    }
}