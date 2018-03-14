using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace Xamarin.Examples.Demo.Droid.UITests
{
    internal static class VisualTestHelpers
    {
        private static readonly string ExportActualPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "SciChart",
                "XamarinAndroid_VisualTests_Trunk",
                "Actuals");


        public static void SaveToPng(string fileName, Bitmap bmp)
        {
            var path = Path.GetDirectoryName(fileName);
            if (path != null && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var fileStream = File.Create(fileName))
            {
                bmp.Save(fileStream, ImageFormat.Png);
            }
        }

        public static Bitmap LoadFromPng(string fileName)
        {
            return new Bitmap(fileName);
        }

        public static void CompareBitmaps(string resourceName, Bitmap actual, Bitmap expected, double allowableErrorPercent = 1)
        {
            try
            {
                double averageError = 0.0, maxError = double.MinValue;

                Assert.That(new Size(actual.Width, actual.Height), Is.EqualTo(new Size(expected.Width, expected.Height)), "Image sizes are different!");

                var width = actual.Width;
                var height = actual.Height;

                for (var i = 0; i < width; i++)
                {
                    for (var j = 0; j < height; j++)
                    {
                        var expectedPixel = expected.GetPixel(i, j);
                        var actualPixel = actual.GetPixel(i, j);

                        // Use Euclidean distance to find the difference
                        var error = Math.Sqrt(Math.Pow(expectedPixel.A - actualPixel.A, 2) +
                                              Math.Pow(expectedPixel.R - actualPixel.R, 2) +
                                              Math.Pow(expectedPixel.G - actualPixel.G, 2) +
                                              Math.Pow(expectedPixel.B - actualPixel.B, 2));

                        averageError += error;
                        maxError = Math.Max(error, maxError);
                    }
                }

                // Compute average Euclidean distance
                averageError /= (width * height * 5.10);
                maxError /= 5.10;

                Assert.That(averageError < allowableErrorPercent, $"Image AveError: {averageError}%, Allowable AveError: {allowableErrorPercent}%, MaxError: {maxError}%");
            }
            catch
            {
                // Output diff file 
                SaveDiffImages(resourceName, expected, actual);

                throw;
            }
        }

        private static void SaveDiffImages(string resourceName, Bitmap expectedBitmap, Bitmap actualBitmap)
        {
            var expectedPath = Path.Combine(ExportActualPath, Path.GetFileNameWithoutExtension(resourceName) + "-expected.png");
            var actualPath = Path.Combine(ExportActualPath, Path.GetFileNameWithoutExtension(resourceName) + "-actual.png");

            SaveToPng(expectedPath, expectedBitmap);
            Console.WriteLine("Expected bitmap saved to " + expectedPath);

            SaveToPng(actualPath, actualBitmap);
            Console.WriteLine("Actual bitmap saved to " + actualPath);

            if (expectedBitmap.Width != actualBitmap.Width || expectedBitmap.Height != actualBitmap.Height) return;

            var width = expectedBitmap.Width;
            var height = expectedBitmap.Height;

            var diffBitmap = new Bitmap(width, height);
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var expectedPixel = expectedBitmap.GetPixel(i, j);
                    var actualPixel = actualBitmap.GetPixel(i, j);

                    // For alpha use the average of both images (otherwise pixels with the same alpha won't be visible)
                    var alpha = (actualPixel.A + expectedPixel.A)/2;
                    var red = Math.Abs(actualPixel.R - expectedPixel.R);
                    var green = Math.Abs(actualPixel.G - expectedPixel.G);
                    var blue = Math.Abs(actualPixel.B - expectedPixel.B);

                    diffBitmap.SetPixel(i, j, Color.FromArgb(alpha, red, green, blue));
                }
            }

            var diffPath = Path.Combine(ExportActualPath, Path.GetFileNameWithoutExtension(resourceName) + "-diff.png");

            SaveToPng(diffPath, diffBitmap);
            Console.WriteLine("Difference bitmap saved to " + diffPath);
        }
    }
}