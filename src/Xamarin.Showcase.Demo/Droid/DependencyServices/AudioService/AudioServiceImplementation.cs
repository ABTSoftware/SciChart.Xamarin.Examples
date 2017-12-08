using System;
using System.Runtime.InteropServices;
using Android.Media;
using scichartshowcase.Droid.DependencyServices.AudioService;
using scichartshowcase.Services.AudioService;
using AForge.Math;

[assembly: Xamarin.Forms.Dependency(typeof(AudioServiceImplementation))]
namespace scichartshowcase.Droid.DependencyServices.AudioService
{
    public class AudioServiceImplementation : IAudioService
    {
        AudioRecord audioRecord;

        public event EventHandler samplesUpdated;

        public int[] FFT(int[] y)
        {
            var input = new AForge.Math.Complex[y.Length];

            for (int i = 0; i < y.Length; i++)
            {
                input[i] = new AForge.Math.Complex(y[i], 0);
            }

            FourierTransform.FFT(input, FourierTransform.Direction.Forward);

            var result = new int[y.Length / 2];

            // getting magnitude
            for (int i = 0; i < y.Length / 2 - 1; i++)
            {
                var current = Math.Sqrt(input[i].Re * input[i].Re + input[i].Im * input[i].Im);
                current = Math.Log10(current) * 10;
                result[i] = (int)current;
            }

            return result;
        }

        public void StartRecord()
        {
            if (audioRecord == null)
            {
                audioRecord = new AudioRecord(AudioSource.Mic, 44100, ChannelIn.Mono, Encoding.Pcm16bit, 2048 * sizeof(byte));
                if (audioRecord.State != State.Initialized)
                    throw new InvalidOperationException("This device doesn't support AudioRecord");
            }

            //audioRecord.SetRecordPositionUpdateListener()

            audioRecord.StartRecording();

            while (audioRecord.RecordingState == RecordState.Recording)
            {
                try
                {
                    OnNext();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void StopRecord()
        {
            audioRecord.Stop();
            audioRecord = null;
        }

        void OnNext()
        {
            short[] audioBuffer = new short[2048];
            audioRecord.Read(audioBuffer, 0, audioBuffer.Length);

            int[] result = new int[audioBuffer.Length];
            for (int i = 0; i < audioBuffer.Length; i++)
            {
                result[i] = (int)audioBuffer[i];
            }

            samplesUpdated(this, new SamplesUpdatedEventArgs(result));
        }
    }
}