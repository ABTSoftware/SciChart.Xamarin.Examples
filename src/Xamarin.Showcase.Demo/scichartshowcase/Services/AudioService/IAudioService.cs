using System;
namespace scichartshowcase.Services.AudioService
{
    public interface IAudioService
    {
        event EventHandler samplesUpdated;
        void StartRecord();
        void StopRecord();
        int[] FFT(int[] y);
    }

    public class SamplesUpdatedEventArgs : EventArgs
    {
        public int[] UpdatedSamples { get; set; }

        public SamplesUpdatedEventArgs(int[] samples)
        {
            UpdatedSamples = samples;
        }
    }
}