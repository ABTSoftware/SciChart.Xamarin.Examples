using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Random = System.Random;
using System.Reflection;

namespace SciChart.Examples.Demo.Data
{
    public class DataManager
    {
#if __ANDROID__
        private const string ResourcePrefix = "Xamarin.Examples.Demo.Droid.";
#elif __IOS__
        private const string ResourcePrefix = "Xamarin.Examples.Demo.iOS.";
#endif
        private const string PriceDataIndu = "Resources.Data.INDU_Daily.csv";
        private const string PriceDataEurUsd = "Resources.Data.EURUSD_Daily.csv";
        private const string TradeTicks = "Resources.Data.TradeTicks.csv";
        private const string Waveform = "Resources.Data.waveform.txt";

        public static readonly DataManager Instance = new DataManager();

        private readonly Random _random = new Random(42);

        private DataManager()
        {
        }

        public DoubleSeries GetRandomDoubleSeries(int count)
        {
            return GetDoubleSeries(count, series => SetRandomDoubleSeries(series, count));
        }

        private DoubleSeries GetDoubleSeries(int count, Action<DoubleSeries> initAction)
        {
            var doubleSeries = new DoubleSeries(count);

            initAction(doubleSeries);

            return doubleSeries;
        }

        public void GetFanData(int count, Action<FanDataPoint> handler)
        {
            var dateTime = new DateTime();

            var lastValue = 0.0;
            var i = 0;
            var dataPoint = new FanDataPoint();

            while (i < count)
            {
                var nextValue = lastValue + _random.NextDouble() - 0.5;
                lastValue = nextValue;
                dateTime = dateTime.AddDays(1);

                dataPoint.Date = dateTime;
                dataPoint.ActualValue = nextValue;

                if (i > 4)
                {
                    dataPoint.MaxValue = nextValue + ((double)i - 5) * 0.3;
                    dataPoint.Value1 = nextValue + ((double)i - 5) * 0.2;
                    dataPoint.Value2 = nextValue + ((double)i - 5) * 0.1;
                    dataPoint.Value3 = nextValue - ((double)i - 5) * 0.1;
                    dataPoint.Value4 = nextValue - ((double)i - 5) * 0.2;
                    dataPoint.MinValue = nextValue - ((double)i - 5) * 0.3;
                }
                handler(dataPoint);

                i += 1;
            }
        }

        public void SetRandomDoubleSeries(DoubleSeries doubleValues, int count)
        {
            var amplitude = _random.NextDouble() + 0.5;
            var freq = Math.PI * (_random.NextDouble() + 0.5) * 10;
            var offset = _random.NextDouble() - 0.5;

            for (var i = 0; i < count; i++)
            {
                doubleValues.Add(new XyPoint { X = i, Y = offset + amplitude * Math.Sin(freq * i) });
            }
        }

        public DoubleSeries GetStraightLine(double gradient, double yIntercept, int count = 5000)
        {
            return GetDoubleSeries(count, series => SetStraightLine(series, gradient, yIntercept, count));
        }

        public void SetStraightLine(DoubleSeries series, double gradient, double yIntercept, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var x = i + 1;
                var y = gradient * x + yIntercept;
                series.Add(new XyPoint { X = x, Y = y });
            }
        }

        public DoubleSeries GetFourierSeries(double amplitude, double phaseShift, int count = 5000)
        {
            return GetDoubleSeries(count, series => SetFourierSeries(series, amplitude, phaseShift, count));
        }

        public DoubleSeries GetFourierSeries(double amplitude, double phaseShift, double xStart, double xEnd, int count = 5000)
        {
            var fourierSeries = GetFourierSeries(amplitude, phaseShift);

            var startIndex = Array.FindLastIndex(fourierSeries.XData, x => x < xStart);
            var endIndex = Array.FindIndex(fourierSeries.XData, x => x > xEnd);

            var size = endIndex - startIndex;

            var result = new DoubleSeries(size);
            for (var i = startIndex; i < endIndex; i++)
            {
                result.Add(fourierSeries[i]);
            }

            return result;
        }

        public void SetFourierSeries(DoubleSeries series, double amplitude, double phaseShift, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var xyPoint = new XyPoint();

                var time = 10.0 * i / count;
                var wn = 2 * Math.PI / count * 10;

                xyPoint.X = time;
                xyPoint.Y = Math.PI * amplitude *
                            (Math.Sin(i * wn + phaseShift) +
                             0.33 * Math.Sin(i * 3 * wn + phaseShift) +
                             0.20 * Math.Sin(i * 5 * wn + phaseShift) +
                             0.14 * Math.Sin(i * 7 * wn + phaseShift) +
                             0.11 * Math.Sin(i * 9 * wn + phaseShift) +
                             0.09 * Math.Sin(i * 11 * wn + phaseShift));

                series.Add(xyPoint);
            }
        }

        public DoubleSeries GetDampedSinewave(double amplitude, double dampingFactor, int count, int freq = 10)
        {
            return GetDampedSinewave(0, amplitude, 0.0, dampingFactor, count, freq);
        }

        public DoubleSeries GetSinewave(double amplitude, double phase, int count, int freq = 10)
        {
            return GetDampedSinewave(0, amplitude, phase, 0.0, count, freq);
        }

        public DoubleSeries GetNoisySinewave(double amplitude, double phase, int count, double noiseAmplitude)
        {
            var sinewave = GetSinewave(amplitude, phase, count);

            // Add some noise
            for (var i = 0; i < count; i++)
            {
                sinewave[i].Y += _random.NextDouble() * noiseAmplitude - noiseAmplitude * 0.5;
            }

            return sinewave;
        }

        public DoubleSeries GetDampedSinewave(int pad, double amplitude, double phase, double dampingFactor, int count, int freq = 10)
        {
            var doubleSeries = new DoubleSeries(count);

            for (var i = 0; i < pad; i++)
            {
                var time = 10 * i / (double)count;
                doubleSeries.Add(new XyPoint { X = time });
            }

            for (int i = pad, j = 0; i < count; i++, j++)
            {
                var xyPoint = new XyPoint();

                var time = 10 * i / (double)count;
                var wn = 2 * Math.PI / (count / (double)freq);

                xyPoint.X = time;
                xyPoint.Y = amplitude * Math.Sin(j * wn + phase);
                doubleSeries.Add(xyPoint);

                amplitude *= 1.0 - dampingFactor;
            }

            return doubleSeries;
        }

        public PriceSeries GetPriceDataIndu()
        {
            return GetPriceBarsFromPath(ResourcePrefix + PriceDataIndu);
        }

        public PriceSeries GetPriceDataEurUsd()
        {
            return GetPriceBarsFromPath(ResourcePrefix + PriceDataEurUsd);
        }

        private static PriceSeries GetPriceBarsFromPath(string path)
        {
            var priceSeries = new PriceSeries();

            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(path);

            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var priceBar = new PriceBar();
                    // Line Format: 
                    // Date, Open, High, Low, Close, Volume 
                    // 2007.07.02 03:30, 1.35310, 1.35310, 1.35280, 1.35310, 12 
                    var tokens = line.Split(',');
                    priceBar.DateTime = DateTime.Parse(tokens[0], DateTimeFormatInfo.InvariantInfo);
                    priceBar.Open = double.Parse(tokens[1], NumberFormatInfo.InvariantInfo);
                    priceBar.High = double.Parse(tokens[2], NumberFormatInfo.InvariantInfo);
                    priceBar.Low = double.Parse(tokens[3], NumberFormatInfo.InvariantInfo);
                    priceBar.Close = double.Parse(tokens[4], NumberFormatInfo.InvariantInfo);
                    priceBar.Volume = long.Parse(tokens[5], NumberFormatInfo.InvariantInfo);
                    priceSeries.Add(priceBar);
                }
            }
            return priceSeries;
        }

        public List<double> LoadWaveformData()
        {
            var data = new List<double>();

            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(ResourcePrefix + Waveform);

            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    data.Add(double.Parse(line, NumberFormatInfo.InvariantInfo));
                }
            }

            return data;
        }

        public DoubleSeries GetLissajousCurve(double alpha, double beta, double delta, int count)
        {
            var doubleSeries = new DoubleSeries(count);

            for (var i = 0; i < count; i++)
            {
                var x = Math.Sin(alpha * i * 0.1 + delta);
                var y = Math.Sin(beta * i * 0.1);
                doubleSeries.Add(new XyPoint { X = x, Y = y });
            }

            return doubleSeries;
        }

        public IEnumerable<TradeData> GetTradeticks()
        {
            var dataSource = new List<TradeData>();

            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(ResourcePrefix + TradeTicks);

            using (var reader = new StreamReader(stream))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var data = new TradeData();
                    // Line Format: 
                    // Date, Open, High, Low, Close, Volume 
                    // 2007.07.02 03:30, 1.35310, 1.35310, 1.35280, 1.35310, 12 
                    var tokens = line.Split(',');
                    data.TradeDate = DateTime.Parse(tokens[0], DateTimeFormatInfo.InvariantInfo);
                    data.TradePrice = double.Parse(tokens[1], NumberFormatInfo.InvariantInfo);
                    data.TradeSize = double.Parse(tokens[2], NumberFormatInfo.InvariantInfo);

                    dataSource.Add(data);

                    line = reader.ReadLine();
                }
            }
            return dataSource;
        }

        public IEnumerable<double> Offset(IList<double> inputList, double offset)
        {
            foreach (double value in inputList)
            {
                yield return value + offset;
            }
        }

        public IList<double> ComputeMovingAverage(IList<double> prices, int length)
        {
            double[] result = new double[prices.Count];
            for (int i = 0; i < prices.Count; i++)
            {
                if (i < length)
                {
                    result[i] = double.NaN;
                    continue;
                }

                result[i] = AverageOf(prices, i - length, i);
            }

            return result;
        }

        private static double AverageOf(IList<double> prices, int from, int to)
        {
            double result = 0.0;
            for (int i = from; i < to; i++)
            {
                result += prices[i];
            }

            return result / (to - from);
        }

        public void SetHeatmapValues(double[] heatmapValues, int heatmapIndex, int heatmapWidth, int heatmapHeight, int seriesPerPeriod)
        {
            var cx = heatmapWidth / 2;
            var cy = heatmapHeight / 2;

            var angle = Math.PI * 2 * heatmapIndex / seriesPerPeriod;

            for (var x = 0; x < heatmapWidth; x++)
            {
                for (var y = 0; y < heatmapHeight; y++)
                {
                    var v = (1 + Math.Sin(x * 0.04 + angle)) * 50 + (1 + Math.Sin(y * 0.1 + angle)) * 50 * (1 + Math.Sin(angle * 2));
                    var r = Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
                    var exp = Math.Max(0, 1 - r * 0.008);

                    heatmapValues[x * heatmapHeight + y] = v * exp + _random.NextDouble() * 50;
                }
            }
        }
    }
}