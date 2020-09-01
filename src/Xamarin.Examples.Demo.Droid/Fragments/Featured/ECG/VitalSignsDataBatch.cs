using System.Collections.Generic;
using System.Linq;
using Java.Lang;
using SciChart.Core.Model;
using Xamarin.Examples.Demo.Showcase.VitalSignsMonitor;

namespace Xamarin.Examples.Demo.Droid.Fragments.Featured.ECG
{
    public class VitalSignsDataBatch
    {
        public VitalSignsDataBatch()
        {
            XValues = new DoubleValues();
          
            ECGHeartRateValuesA = new DoubleValues();
            BloodPressureValuesA = new DoubleValues();
            BloodVolumeValuesA = new DoubleValues();
            BloodOxygenationValuesA = new DoubleValues();

            ECGHeartRateValuesB = new DoubleValues();
            BloodPressureValuesB = new DoubleValues();
            BloodVolumeValuesB = new DoubleValues();
            BloodOxygenationValuesB = new DoubleValues();
        }
        
        public DoubleValues XValues { get; }

        public DoubleValues ECGHeartRateValuesA { get; }
        public DoubleValues BloodPressureValuesA { get; }
        public DoubleValues BloodVolumeValuesA { get; }
        public DoubleValues BloodOxygenationValuesA { get; }

        public DoubleValues ECGHeartRateValuesB { get; set; }
        public DoubleValues BloodPressureValuesB { get; set; }
        public DoubleValues BloodVolumeValuesB { get; set; }
        public DoubleValues BloodOxygenationValuesB { get; set; }

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
                    BloodPressureValuesA.Add(ecgData.BloodPressure);;
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