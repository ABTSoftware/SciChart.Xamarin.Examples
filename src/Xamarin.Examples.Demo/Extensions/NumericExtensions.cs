using System;

namespace Xamarin.Examples.Demo
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Convert to Radians.
        /// </summary>
        /// <param name="val">The value to convert to radians</param>
        /// <returns>The value in radians</returns>
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
