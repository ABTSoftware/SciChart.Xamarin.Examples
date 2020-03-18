using System;
using System.Collections.Generic;
using System.Linq;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Showcase.VitalSignsMonitor;

namespace Xamarin.Examples.Demo.iOS
{
    public class VitalSignsDataBatch
    {
        public VitalSignsDataBatch()
        {
            XValues = new SCIDoubleValues();

            ECGHeartRateValuesA = new SCIDoubleValues();
            BloodPressureValuesA = new SCIDoubleValues();
            BloodVolumeValuesA = new SCIDoubleValues();
            BloodOxygenationValuesA = new SCIDoubleValues();

            ECGHeartRateValuesB = new SCIDoubleValues();
            BloodPressureValuesB = new SCIDoubleValues();
            BloodVolumeValuesB = new SCIDoubleValues();
            BloodOxygenationValuesB = new SCIDoubleValues();
        }

        public SCIDoubleValues XValues { get; }

        public SCIDoubleValues ECGHeartRateValuesA { get; }
        public SCIDoubleValues BloodPressureValuesA { get; }
        public SCIDoubleValues BloodVolumeValuesA { get; }
        public SCIDoubleValues BloodOxygenationValuesA { get; }

        public SCIDoubleValues ECGHeartRateValuesB { get; set; }
        public SCIDoubleValues BloodPressureValuesB { get; set; }
        public SCIDoubleValues BloodVolumeValuesB { get; set; }
        public SCIDoubleValues BloodOxygenationValuesB { get; set; }

        public VitalSignsData LastVitalSignsData { get; private set; }

        public void UpdateData(IList<VitalSignsData> ecgDataList)
        {
            XValues.Clear();

            ECGHeartRateValuesA.Clear();
            BloodPressureValuesA.Clear();
            BloodVolumeValuesA.Clear();
            BloodOxygenationValuesA.Clear();

            ECGHeartRateValuesB.Clear();
            BloodPressureValuesB.Clear();
            BloodVolumeValuesB.Clear();
            BloodOxygenationValuesB.Clear();

            foreach (var ecgData in ecgDataList)
            {
                XValues.Add(ecgData.XValue);

                if (ecgData.IsATrace)
                {
                    ECGHeartRateValuesA.Add(ecgData.ECGHeartRate);
                    BloodPressureValuesA.Add(ecgData.BloodPressure); ;
                    BloodVolumeValuesA.Add(ecgData.BloodVolume);
                    BloodOxygenationValuesA.Add(ecgData.BloodOxygenation);

                    ECGHeartRateValuesB.Add(Double.NaN);
                    BloodPressureValuesB.Add(Double.NaN);
                    BloodVolumeValuesB.Add(Double.NaN);
                    BloodOxygenationValuesB.Add(Double.NaN);
                }
                else
                {
                    ECGHeartRateValuesB.Add(ecgData.ECGHeartRate);
                    BloodPressureValuesB.Add(ecgData.BloodPressure); ;
                    BloodVolumeValuesB.Add(ecgData.BloodVolume);
                    BloodOxygenationValuesB.Add(ecgData.BloodOxygenation);

                    ECGHeartRateValuesA.Add(Double.NaN);
                    BloodPressureValuesA.Add(Double.NaN);
                    BloodVolumeValuesA.Add(Double.NaN);
                    BloodOxygenationValuesA.Add(Double.NaN);
                }
            }

            LastVitalSignsData = ecgDataList.Last();
        }
    }
}
