using System;

namespace Xamarin.Examples.Demo.Showcase.VitalSignsMonitor
{
    public class VitalSignsIndicatorsProvider
    {
        private readonly Random _random = new Random();

        private static readonly string[] BpmValues = new string[] {"67", "69", "72", "74"};

        private static readonly string[] BpValues = new string[] {"120/70", "115/70", "115/75", "120/75"};
        private static readonly int[] BpbValues = new int[] {3, 4, 5};

        private static readonly string[] BvValues = new string[] {"13.1", "13.2", "13.3", "13.0"};
        private static readonly int[] BvbValues = new int[] {8, 9, 10};

        private static readonly string[] BoValues = new string[] {"93", "95", "96", "97"};

        public string BpmValue { get; private set; } = BpmValues[0];

        public string BpValue { get; private set; } = BpValues[0];
        public int BpbValue { get; private set; } = BpbValues[0];

        public string BvValue { get; private set; } = BvValues[0];
        public int BvBar1Value { get; private set; } = BvbValues[0];
        public int BvBar2Value { get; private set; } = BvbValues[0];

        public string SpoValue { get; private set; } = BoValues[0];
        public string SpoClockValue { get; private set; } = GetTimeString();

        public void Update()
        {
            BpmValue = RandomString(BpmValues);

            BpValue = RandomString(BpValues);
            BpbValue = RandomInt(BpbValues);

            BvValue = RandomString(BvValues);
            BvBar1Value = RandomInt(BvbValues);
            BvBar2Value = RandomInt(BvbValues);

            SpoValue = RandomString(BoValues);
            SpoClockValue = GetTimeString();
        }

        private string RandomString(string[] values)
        {
            return values[_random.Next(values.Length)];
        }

        private int RandomInt(int[] values)
        {
            return values[_random.Next(values.Length)];
        }

        private static string GetTimeString()
        {
            return DateTime.Now.ToString("HH:mm");
        }
    }
}